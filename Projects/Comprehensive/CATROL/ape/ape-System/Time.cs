using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ape_System
{
    public class Time
    {
        public enum DateType
        {
            YYYY_MM_DD, //年月日
            MM_DD_YYYY, //月日年
            MM_DD, //月日
            YYYY, //年
            YYYY_MM, //年月
            YYYY_DD, //年日
            DD //日
        }

        public enum TimeType
        {
            HH_MM_SS, //时分秒
            HH_MM, //时分
            MM_SS, //分秒
            HH, //时
            MM, //分
            SS //秒
        }

        /// <summary>
        /// 返回指定格式的当时时间
        /// </summary>
        /// <param name="dateType">日期格式</param>
        /// <param name="timeType">时间格式</param>
        /// <param name="dateSpace">年月日间隔符号</param>
        /// <param name="timeSpace">时分秒间隔符号</param>
        /// <param name="dateTimeSpace">日期时间间隔符号</param>
        /// <param name="isTimeFirst">是否前置时间</param>
        /// <returns></returns>
        public string ReturnNowTime(DateType dateType, TimeType timeType, char dateSpace, char timeSpace, char dateTimeSpace, bool isTimeFirst)
        {
            DateTime now = DateTime.Now;
            string date = null;
            string time = null;
            switch (dateType)
            {
                case DateType.YYYY_MM_DD:
                    date = $"{now.Year}{dateSpace}{now.Month}{dateSpace}{now.Day}";
                    break;
                case DateType.MM_DD_YYYY:
                    date = $"{now.Month}{dateSpace}{now.Day}{dateSpace}{now.Year}";
                    break;
                case DateType.MM_DD:
                    date = $"{now.Month}{dateSpace}{now.Day}";
                    break;
                case DateType.YYYY:
                    date = $"{now.Year}";
                    break;
                case DateType.YYYY_MM:
                    date = $"{now.Year}{dateSpace}{now.Month}";
                    break;
                case DateType.YYYY_DD:
                    date = $"{now.Year}{dateSpace}{now.Day}";
                    break;
                case DateType.DD:
                    date = $"{now.Day}";
                    break;
            }
            switch (timeType)
            {
                case TimeType.HH_MM_SS:
                    time = $"{now.Hour}{timeSpace}{now.Minute}{timeSpace}{now.Second}";
                    break;
                case TimeType.HH_MM:
                    time = $"{now.Hour}{timeSpace}{now.Minute}";
                    break;
                case TimeType.MM_SS:
                    time = $"{now.Minute}{timeSpace}{now.Second}";
                    break;
                case TimeType.HH:
                    time = $"{now.Hour}";
                    break;
                case TimeType.MM:
                    time = $"{now.Minute}";
                    break;
                case TimeType.SS:
                    time = $"{now.Second}";
                    break;
            }
            if (isTimeFirst)
            {
                return $"{time}{dateTimeSpace}{date}";
            }
            else
            {
                return $"{date}{dateTimeSpace}{time}";
            }
        }
    }
}
