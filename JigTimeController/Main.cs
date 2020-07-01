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
            //gbLeft
            gbOvenLeft.Text = gbOvenLeft.Name = ConfigurationManager.AppSettings["ovenLeftName"];
            int[] ovenLeftLocationArr = Array.ConvertAll(ConfigurationManager.AppSettings["ovenLeftLocation"].Split(','), int.Parse);
            int[] ovenLeftSizeArr = Array.ConvertAll(ConfigurationManager.AppSettings["ovenLeftSize"].Split(','), int.Parse);
            Point ovenLeftLocation = new Point(ovenLeftLocationArr[0], ovenLeftLocationArr[1]);
            Size ovenLeftSize = new Size(ovenLeftSizeArr[0], ovenLeftSizeArr[1]);
            int ovenLeftRow = Convert.ToUInt16(ConfigurationManager.AppSettings["ovenLeftRow"]);
            int ovenLeftColumn = Convert.ToUInt16(ConfigurationManager.AppSettings["ovenLeftColumn"]);
            CreatOvenUI(gbOvenLeft, ovenLeftLocation, ovenLeftSize, ovenLeftRow, ovenLeftColumn);
            //gbRight
            gbOvenRight.Text = gbOvenRight.Name = ConfigurationManager.AppSettings["ovenRightName"];
            int[] ovenRightLocationArr = Array.ConvertAll(ConfigurationManager.AppSettings["ovenRightLocation"].Split(','), int.Parse);
            int[] ovenRightSizeArr = Array.ConvertAll(ConfigurationManager.AppSettings["ovenRightSize"].Split(','), int.Parse);
            Point ovenRightLocation = new Point(ovenRightLocationArr[0], ovenRightLocationArr[1]);
            Size ovenRightSize = new Size(ovenRightSizeArr[0], ovenRightSizeArr[1]);
            int ovenRightRow = Convert.ToUInt16(ConfigurationManager.AppSettings["ovenRightRow"]);
            int ovenRightColumn = Convert.ToUInt16(ConfigurationManager.AppSettings["ovenRightColumn"]);
            CreatOvenUI(gbOvenRight, ovenRightLocation, ovenRightSize, ovenRightRow, ovenRightColumn);
            if (gbOvenLeft.Name == gbOvenRight.Name)
            {
                MessageBox.Show("配置文件中的ovenLeftName与ovenRightName值不可相同", "配置错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            //lblRunningState
            lblRunningState.Text = ConfigurationManager.AppSettings["runningStateText"];
            lblRunningState.Location = new Point(gbOvenRight.Location.X, gbOvenRight.Location.Y + gbOvenRight.Height);
            lblRunningState.Font = new Font(lblRunningState.Font.FontFamily.Name, Convert.ToSingle(ConfigurationManager.AppSettings["runningStateFontSize"]));
            //导入没完成的数据
            string sql = @"WITH alldata AS(
	SELECT*,ROW_NUMBER() OVER (PARTITION BY jig_id,machine_id,location ORDER BY creat_time DESC) IS 1 AS last_operate
	FROM operate_history
)

SELECT jig_id,machine_id,location,oven_time,creat_time
FROM alldata
WHERE last_operate is TRUE
AND operate_type='IN'";
            DataSet ds = SQLiteHelper.ExecuteDataSet(jigDB, sql, null);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                Jig jig = new Jig(dr);
                GroupBox oven = (GroupBox)Controls[jig.Machine];
                Label label = (Label)oven.Controls[jig.Location];
                label.Tag = jig;
                label.Text = string.Format("{0}\r\n{1}", jig.ID, jig.StartTime.ToString("yy/MM/dd\r\nHH:mm:ss"));
                label.BackColor = jig.TimeOut ? Color.Red : Control.DefaultBackColor;
            }
            #endregion
        }
        
        private void lblRunningState_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
        }

        private void lblRunningState_MouseMove(object sender, MouseEventArgs e)
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
                        Machine = txtInput.Parent.Name,
                        Location = label.Name
                    };
                    label.Tag = jig;
                    label.Text = string.Format("{0}\r\n{1}", jig.ID, jig.StartTime.ToString("yy/MM/dd\r\nHH:mm:ss"));
                    label.BackColor = Control.DefaultBackColor;
                    txtInput.Text = "";

                    string sql = String.Format(@"INSERT INTO operate_history (jig_id,machine_id,location,oven_time,creat_time,operate_type)
VALUES('{0}','{1}', '{2}', {3}, DATETIME('now','localtime'), 'IN')", jig.ID, jig.Machine, jig.Location, jig.OvenTime);
                    SQLiteHelper.ExecuteNonQuery(jigDB, sql, null);
                }
                else
                {
                    Jig jig = (Jig)label.Tag;
                    if (txtInput.Text == (jig.ID))
                    {
                        if (!jig.TimeOut)
                        {
                            DialogResult dr = MessageBox.Show("该Jig未到烘烤时间，确认是否强制解锁", "Jig解锁失败", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                            if (dr != DialogResult.Yes)
                                return;
                        }

                        jig.EndTime = DateTime.Now;

                        string sql = String.Format(@"INSERT INTO operate_history (jig_id,machine_id,location,oven_time,creat_time,operate_type)
VALUES('{0}','{1}', '{2}', {3}, DATETIME('now','localtime'), 'OUT')", jig.ID, jig.Machine, jig.Location, jig.OvenTime);
                        SQLiteHelper.ExecuteNonQuery(jigDB, sql, null);

                        label.Tag = null;
                        label.Text = "";
                        txtInput.Text = "";
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
            lblRunningState.Visible = !lblRunningState.Visible;
            ShowTimeOut(gbOvenLeft);
            ShowTimeOut(gbOvenRight);
        }

        void ShowTimeOut(GroupBox groupBox)
        {
            foreach (Control con in groupBox.Controls)
            {
                if (con is Label && con.Tag != null)
                {
                    Jig jig = (Jig)con.Tag;
                    con.BackColor = jig.TimeOut ? Color.Red : Control.DefaultBackColor;
                }
            }
        }

        void CreatOvenUI(GroupBox groupBoxName, Point UI_location, Size UI_Size, int rowInt, int columnInt)
        {
            groupBoxName.Location = UI_location;
            groupBoxName.Size = UI_Size;
            
            int lblX = 15; int lblY = 15;
            int txtX = lblX; int txtY = lblY + 40;
            int intervalX = groupBoxName.Size.Width / columnInt;
            int intervalY = groupBoxName.Size.Height / rowInt;

            for (int r = 0; r < rowInt; r++)
            {
                for (int c = 0; c < columnInt; c++)
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
