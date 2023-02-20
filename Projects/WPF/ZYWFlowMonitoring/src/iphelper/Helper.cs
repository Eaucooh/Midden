using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace iphelper
{
    public static class Helper
    {
        public static string WhichDayisToday()
        {
            var prCalendar = new PersianCalendar();

            int year = prCalendar.GetYear(DateTime.Now);
            int month = prCalendar.GetMonth(DateTime.Now);
            int dayofMonth = prCalendar.GetDayOfMonth(DateTime.Now);

            string returnValue = "[" + year.ToString(CultureInfo.InvariantCulture) + "." +
                                 month.ToString(CultureInfo.InvariantCulture) + "." +
                                 dayofMonth.ToString(CultureInfo.InvariantCulture) + "]";

            return returnValue;
        }

        public static string GetProcessFullPath(int pid)
        {
            try
            {
                Process process = Process.GetProcessById(pid);

                try
                {
                    return process.Modules[0].FileName;
                }
                catch (Exception)
                {
                    return "System";
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Cannot get Process Name Associated with PID : {0}", pid);
                return "null";
            }
        }

        public static string GetProcessProcessName(int pid)
        {
            try
            {
                Process process = Process.GetProcessById(pid);

                return process.ProcessName;
            }
            catch (Exception)
            {
                Debug.WriteLine("Cannot get Process Name Associated with PID : {0}", pid);
                return "null";
            }
        }

        public static int TaskKill(int pid)
        {
            // 0 Success!
            // 1 Error!
            try
            {
                Process process = Process.GetProcessById(pid);
                process.Kill();
                return 0;
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.Message);
                Debug.WriteLine("Something Went Wrong with killing Process with ID : {0}", pid);
                return 1;
            }
        }

        public static bool IsPidAlreadyExist(IEnumerable<ApplicationTCPActivityLogData> data, int pid)
        {
            return data.Any(applicationNetworkActivityLogData => applicationNetworkActivityLogData.Pid == pid);
        }
    }
}