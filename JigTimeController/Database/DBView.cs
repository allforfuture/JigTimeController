using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;

namespace JigTimeController.Database
{
    public partial class DBView : Form
    {
        readonly SQLiteConnection jigDB = new SQLiteConnection("Data Source=JigTimeController.db3;Version=3;");

        public DBView()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string sql = "select * from operate_history order by id desc";
            DataSet ds = SQLiteHelper.ExecuteDataSet(jigDB, sql, null);
            dgv.DataSource = ds.Tables[0];
        }

        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            TestMethods methods = new TestMethods();
            methods.CreateNewDatabase();
            methods.ConnectToDatabase();
            methods.CreateTable();
            //methods.FillTable();
            //methods.PrintHighscores();
        }
    }
}
