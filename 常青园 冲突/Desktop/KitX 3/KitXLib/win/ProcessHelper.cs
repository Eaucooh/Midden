using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;

namespace KitXLib.win
{
    public class ProcessHelper
    {
        /// <summary>
        /// 是否存在某个进程
        /// </summary>
        /// <param name="name">进程名称</param>
        /// <returns>一个布尔值</returns>
        public static bool Exist(string name)
        {
            Process[] sys_processes = Process.GetProcesses();
            foreach (Process process in sys_processes)
            {
                if (process.ProcessName.Equals(name)) return true;
            }
            return false;
        }

        /// <summary>
        /// 是否存在某个进程，同时指定存在数
        /// </summary>
        /// <param name="name">进程名</param>
        /// <param name="count">目标数量</param>
        /// <returns>是否存在大于等于目标数量的目标进程数</returns>
        public static bool Exist(string name, int count)
        {
            Process[] sys_processes = Process.GetProcesses();
            int chked = 0;
            foreach (Process process in sys_processes)
            {
                if(process.ProcessName.Equals(name)) chked ++;
                if(chked >= count) return true;
            }
            return false;
        }
    }
}
