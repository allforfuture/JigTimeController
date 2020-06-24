using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace JigTimeController.Jigs
{
    class Jig
    {
        //ID号
        public string ID
        {
            get;set;
        }

        //坐标
        public Point Location
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
        public double OvenTime
        {
            get
            {
                return Convert.ToDouble(ConfigurationManager.AppSettings["ovenTime"]);
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
