using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;

namespace JigTimeController.Jigs
{
    class Jig
    {
        public Jig()
        {

        }

        public Jig(DataRow dr)
        {
            ID = dr["jig_id"].ToString();
            Machine= dr["machine_id"].ToString();
            Location = dr["location"].ToString();
            now = (DateTime)dr["creat_time"];
            ovenTime=Convert.ToDouble(dr["oven_time"]);
        }

        //ID号
        public string ID
        {
            get;set;
        }

        public string Machine
        {
            get;set;
        }

        //坐标
        public string Location
        {
            get;
            set;
        }

        //烘烤开始时间
        readonly DateTime now = DateTime.Now;
        public DateTime StartTime
        {
            get
            {
                return now;
            }
        }

        //烘烤结束时间
        public DateTime EndTime
        {
            get;
            set;
        }

        //设定烘烤时间
        readonly double ovenTime = Convert.ToDouble(ConfigurationManager.AppSettings["ovenTime"]);
        public double OvenTime
        {
            get
            {
                return ovenTime;
            }
        }

        //是否超出设定时间
        public bool TimeOut
        {
            get
            {
                return DateTime.Now>=StartTime.AddSeconds(OvenTime);
            }
        }
    }
}
