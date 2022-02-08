using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace FastDownload
{
    class Set
    {
        public static string Start;//是否开机自动启动
        public static string Auto;//是否自动开始未完成任务
        public static string Path;//默认下载路径
        public static string Net;//网络限制
        public static string NetValue;//网速限制值
        public static string DClose;//是否下载完成自动关机
        public static string TClose;//是否定时关机
        public static string TCloseValue;//定时关机时间
        public static string SNotify;//是否下载完成显示提示
        public static string Play;//是否下载完成播放提示音
        public static string Continue;//是否在有未完成的下载时显示继续提示
        public static string ShowFlow;//是否显示流量监控
        public static string strNode= "SET";//ini文件中要读取的节点
        public static string strPath = Application.StartupPath + "\\Set.ini";//ini配置文件路径

        [DllImport("kernel32")] //读取INI文件
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]//向INI文件中写入数据
        public static extern long WritePrivateProfileString(string mpAppName,string mpKeyName,string mpDefault,string mpFileName);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]//定时关机
        public static extern bool ExitWindowsEx(int uFlags, int dwReserved);

        [DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true)]//关闭、重启系统(拥有所有权限)
        public static extern bool RtlAdjustPrivilege(int htok, bool disall,bool newst, ref int len);

        /// <summary>
        /// 从INI文件中读取指定节点的内容
        /// </summary>
        /// <param name="section">INI节点</param>
        /// <param name="key">节点下的项</param>
        /// <param name="def">没有找到内容时返回的默认值</param>
        /// <param name="filePath">要读取的INI文件</param>
        /// <returns>读取的节点内容</returns>
        public static string GetIniFileString(string section, string key, string def, string filePath)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, temp, 1024, filePath);
            return temp.ToString();
        }

        /// <summary>
        /// 开启自动运行程序
        /// </summary>
        /// <param name="auto">是否自动运行</param>
        public void AutoRun(string auto)
        {
            string strName = Application.ExecutablePath;//记录可执行文件路径
            if (!System.IO.File.Exists(strName))//判断文件是否存在
                return;
            string strnewName = strName.Substring(strName.LastIndexOf("\\") + 1);//获取文件名
            //打开开机自动运行的注册表项
            RegistryKey RKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (RKey == null)
                RKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            if (auto == "0")//不运行
                RKey.DeleteValue(strnewName, false);
            else//自动运行
                RKey.SetValue(strnewName, strName);
        }

        private const int EWX_SHUTDOWN = 0x00000001;
        private const int SE_SHUTDOWN_PRIVILEGE = 0X13;
        public void Shutdown()//关机
        {
            int i = 0;
            RtlAdjustPrivilege(SE_SHUTDOWN_PRIVILEGE, true, false, ref i);
            ExitWindowsEx(EWX_SHUTDOWN, 0);
        }
        
        //获取各种设置的值
        public void GetConfig()
        {
            Start = GetIniFileString(strNode, "Start", "", strPath);//是否开机自动启动
            Auto = GetIniFileString(strNode, "Auto", "", strPath);//是否自动开始未完成任务
            Path = GetIniFileString(strNode, "Path", "", strPath);//默认下载路径
            string netTemp = GetIniFileString(strNode, "Net", "", strPath);//网络限制
            Net = netTemp.Split(' ')[0];//是否进行网络限制
            NetValue = netTemp.Split(' ')[1];//网络限制的值
            DClose = GetIniFileString(strNode, "DClose", "", strPath);//是否下载完成自动关机
            string closeTemp = GetIniFileString(strNode, "TClose", "", strPath);//定时关机
            TClose = closeTemp.Split(' ')[0];//是否定时关机
            TCloseValue = closeTemp.Split(' ')[1];//定时关机事件
            SNotify = GetIniFileString(strNode, "SNotify", "", strPath);//是否下载完成显示提示
            Play = GetIniFileString(strNode, "Play", "", strPath);//是否下载完成播放提示音
            Continue = GetIniFileString(strNode, "Continue", "", strPath);//是否在有未完成的下载时显示继续提示
            ShowFlow = GetIniFileString(strNode, "ShowFlow", "", strPath);//是否显示流量监控
        }

        //获取所选磁盘剩余空间
        public string GetSpace(string path)
        {
            System.IO.DriveInfo[] drive = System.IO.DriveInfo.GetDrives();//获取所有驱动器
            int i;
            for (i = 0; i < drive.Length; i++)//遍历驱动器
            {
                if (path == drive[i].Name)//判断遍历到的项是否与下拉列表中的项相同
                {
                    break;
                }
            }
            return (drive[i].TotalFreeSpace / 1024 / 1024 / 1024.0).ToString("0.00") + "G";//显示剩余空间
        }
    }
}
