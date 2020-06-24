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
        SQLiteConnection jigDB = new SQLiteConnection("Data Source=JigTimeController.db3;Version=3;");
        public Main()
        {
            InitializeComponent();
            Text = Application.ProductName + " " + Application.ProductVersion;
            timerCheckJig.Interval = 1000 * Convert.ToUInt16(ConfigurationManager.AppSettings["refreshTime"]);
            
            ////测试动态加行列
            //for (int i = 0; i < 5; i++)
            //{
            //    Button button = new Button();
            //    button.Location = new Point(5, 30 * i);
            //    this.Controls.Add(button);
            //}
        }

        private void Jig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                //this.GetChildAtPoint找附近正上方的lbl
                
                //信息输入文本框
                TextBox txtInput = (TextBox)sender;
                //Jig数据
                Label label = (Label)groupBoxOven1.Controls[txtInput.Name.Replace("txt", "")];
                
                if (label.Tag == null)
                {
                    Jig jig = new Jig()
                    {
                        ID = txtInput.Text,
                        Location = new Point(Convert.ToInt16(txtInput.Name.Split('_')[1]),
                                        Convert.ToInt16(txtInput.Name.Split('_')[2]))
                    };
                    label.Tag = jig;
                    label.Text = string.Format("{0},{1}", jig.ID, jig.StartTime);
                    label.BackColor = Control.DefaultBackColor;
                    txtInput.Text = "";
                    
                    string sql = String.Format(@"INSERT INTO operate_history (jig_id,location,oven_time,creat_time,operate_type)
VALUES('{0}', '{1}', {2}, DATETIME('now','localtime'), 'IN')", jig.ID,jig.Location,jig.OvenTime);
                    SQLiteHelper.ExecuteNonQuery(jigDB, sql, null);
                }
                else
                {
                    Jig jig=(Jig)label.Tag;
                    if (txtInput.Text == (jig.ID))
                    {
                        jig.EndTime = DateTime.Now;

                        string sql = String.Format(@"INSERT INTO operate_history (jig_id,location,oven_time,creat_time,operate_type)
VALUES('{0}', '{1}', {2}, DATETIME('now','localtime'), 'OUT')", jig.ID, jig.Location, jig.OvenTime);
                        SQLiteHelper.ExecuteNonQuery(jigDB, sql, null);

                        label.Tag = null;
                        label.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("两次Jig的ID不相同", "Jig解锁失败", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void timerCheckJig_Tick(object sender, EventArgs e)
        {
            lblRunningState.Text = lblRunningState.Text == "R" ? "" : "R";
            
            //遍历Jig查看超时的
            foreach (Control con in groupBoxOven1.Controls)
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
        
        private void button1_Click(object sender, EventArgs e)
        {
            TestMethods methods = new TestMethods();
            methods.CreateNewDatabase();
            methods.ConnectToDatabase();
            methods.CreateTable();
            methods.FillTable();
            methods.PrintHighscores();
        }
        
        private void btnTest_Click(object sender, EventArgs e)
        {
            //SQLiteHelper.ExecuteNonQuery();
            //string sql = "select * from highscores order by score desc";
            string sql = "select * from operate_history";
            DataSet ds = SQLiteHelper.ExecuteDataSet(jigDB, sql, null);
            dgv.DataSource = ds.Tables[0];
            
        }
    }
}
