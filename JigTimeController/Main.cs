using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using JigTimeController.Jigs;
using System.Data.SQLite;
using JigTimeController.Database;

namespace JigTimeController
{
    public partial class Main : Form
    {
        readonly SQLiteConnection jigDB = new SQLiteConnection("Data Source=JigTimeController.db3;Version=3;");
        Point mouse_offset;

        public Main()
        {
            InitializeComponent();
            Text = Application.ProductName + " " + Application.ProductVersion;
            timerCheckJig.Interval = 1000 * Convert.ToUInt16(ConfigurationManager.AppSettings["refreshTime"]);

            #region UI
            //测试模式
            if (ConfigurationManager.AppSettings["testMode"] == "SQLite")
                new DBView().Show();
            //Oven1
            int[] oven1LocationArr = Array.ConvertAll(ConfigurationManager.AppSettings["oven1Location"].Split(','), int.Parse);
            int[] oven1SizeArr = Array.ConvertAll(ConfigurationManager.AppSettings["oven1Size"].Split(','), int.Parse);
            Point oven1Location = new Point(oven1LocationArr[0], oven1LocationArr[1]);
            Size oven1Size = new Size(oven1SizeArr[0], oven1SizeArr[1]);
            int oven1Row = Convert.ToUInt16(ConfigurationManager.AppSettings["oven1Row"]);
            int oven1Column = Convert.ToUInt16(ConfigurationManager.AppSettings["oven1Column"]);
            CreatOvenUI(Oven1, oven1Location, oven1Size, oven1Row, oven1Column);
            //Oven2
            int[] oven2LocationArr = Array.ConvertAll(ConfigurationManager.AppSettings["oven2Location"].Split(','), int.Parse);
            int[] oven2SizeArr = Array.ConvertAll(ConfigurationManager.AppSettings["oven2Size"].Split(','), int.Parse);
            Point oven2Location = new Point(oven2LocationArr[0], oven2LocationArr[1]);
            Size oven2Size = new Size(oven2SizeArr[0], oven2SizeArr[1]);
            int oven2Row = Convert.ToUInt16(ConfigurationManager.AppSettings["oven2Row"]);
            int oven2Column = Convert.ToUInt16(ConfigurationManager.AppSettings["oven2Column"]);
            CreatOvenUI(Oven2, oven2Location, oven2Size, oven2Row, oven2Column);
            //panelRunningState
            panelRunningState.Location = new Point(Oven2.Location.X, Oven2.Location.Y + Oven2.Height);
            #endregion
        }

        private void panelRunningState_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
        }

        private void panelRunningState_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                ((Control)sender).Location = ((Control)sender).Parent.PointToClient(mousePos);
            }
        }

        private void Jig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                //信息输入文本框
                TextBox txtInput = (TextBox)sender;
                //Jig数据
                Label label = (Label)txtInput.Parent.Controls[txtInput.Name.Replace("txt", "")];

                if (label.Tag == null)
                {
                    Jig jig = new Jig()
                    {
                        ID = txtInput.Text,
                        Location = new Point(Convert.ToInt16(txtInput.Name.Split('_')[1]),
                                        Convert.ToInt16(txtInput.Name.Split('_')[2]))
                    };
                    label.Tag = jig;
                    label.Text = string.Format("{0}\r\n{1}", jig.ID, jig.StartTime.ToString("yy/MM/dd\r\nHH:mm:ss"));
                    label.BackColor = Control.DefaultBackColor;
                    txtInput.Text = "";

                    string sql = String.Format(@"INSERT INTO operate_history (jig_id,machine_id,location,oven_time,creat_time,operate_type)
VALUES('{0}','{1}', '{2}', {3}, DATETIME('now','localtime'), 'IN')", jig.ID, txtInput.Parent.Name, jig.Location, jig.OvenTime);
                    SQLiteHelper.ExecuteNonQuery(jigDB, sql, null);
                }
                else
                {
                    Jig jig = (Jig)label.Tag;
                    if (txtInput.Text == (jig.ID))
                    {
                        if (!jig.TimeOut)
                        {
                            DialogResult dr = MessageBox.Show("该Jig未到烘烤时间，确认是否强制解锁", "Jig解锁失败", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dr != DialogResult.Yes)
                                return;
                        }

                        jig.EndTime = DateTime.Now;

                        string sql = String.Format(@"INSERT INTO operate_history (jig_id,machine_id,location,oven_time,creat_time,operate_type)
VALUES('{0}','{1}', '{2}', {3}, DATETIME('now','localtime'), 'OUT')", jig.ID, txtInput.Parent.Name, jig.Location, jig.OvenTime);
                        SQLiteHelper.ExecuteNonQuery(jigDB, sql, null);

                        label.Tag = null;
                        label.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("两次Jig的ID不相同", "Jig解锁失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void timerCheckJig_Tick(object sender, EventArgs e)
        {
            panelRunningState.BackColor = panelRunningState.BackColor == Color.Green ? Control.DefaultBackColor : Color.Green;
            ShowTimeOut(Oven1);
            ShowTimeOut(Oven2);
        }

        void ShowTimeOut(GroupBox groupBox)
        {
            foreach (Control con in groupBox.Controls)
            {
                if (con is Label && con.Tag != null)
                {
                    Jig jig = (Jig)con.Tag;
                    if (jig.TimeOut)
                    {
                        con.BackColor = Color.Red;
                    }
                }
            }
        }

        void CreatOvenUI(GroupBox groupBoxName, Point UI_location, Size UI_Size, int rowInt, int columnInt)
        {
            groupBoxName.Location = UI_location;
            groupBoxName.Size = UI_Size;
            int oven1Row = rowInt;
            int oven1Column = columnInt;

            int lblX = 15; int lblY = 15;
            int txtX = lblX; int txtY = lblY + 40;
            int intervalX = groupBoxName.Size.Width / oven1Column;
            int intervalY = groupBoxName.Size.Height / oven1Row;

            for (int r = 0; r < oven1Row; r++)
            {
                for (int c = 0; c < oven1Column; c++)
                {
                    Label lbl = new Label();
                    lbl.Name = string.Format("Jig_{0}_{1}", r + 1, c + 1);
                    lbl.AutoSize = true;
                    lbl.Location = new Point(lblX + intervalX * c, lblY + intervalY * r);
                    //lbl.Text = string.Format("\r\n\r\n{0}", lbl.Name.Replace("Jig_", ""));
                    groupBoxName.Controls.Add(lbl);

                    TextBox txt = new TextBox();
                    txt.Name = string.Format("txtJig_{0}_{1}", r + 1, c + 1);
                    txt.Size = new Size(40, 21);
                    txt.Location = new Point(txtX + intervalX * c, txtY + intervalY * r);
                    txt.KeyDown += new KeyEventHandler(this.Jig_KeyDown);
                    //txt.Text = string.Format("({0},{1})", r + 1, c + 1);
                    groupBoxName.Controls.Add(txt);
                }
            }
        }
    }
}
