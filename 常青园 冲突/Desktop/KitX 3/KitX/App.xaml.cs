using KitX.Helper;
using KitX.info;
using KitX.lang;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KitX
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow? mainWindow; // 主窗口
        public static runninginfo runninginfo = new runninginfo(); // 运行时信息
        public static ConfHelper? confHelper; // 配置助手

        public App()
        {
            runninginfo.WorkDirectory = Environment.CurrentDirectory;
            Startup += App_Startup;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            if (!MutexHelper.CheckApplicationMutex())
            {
                MutexHelper.Restore();
                ToastHelper.ToastStr(
                    lang.lang.langs[(int)runninginfo.Now_Lang][0],
                    lang.lang.langs[(int)runninginfo.Now_Lang][1]);
                Environment.Exit(0);
            }
            base.OnStartup(e);
            StartUp();
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            string sum = "", fp = $"{runninginfo.WorkDirectory}\\log\\argv\\{runninginfo.RanTimes}.bin"; // 参数列表
            foreach (string arg in e.Args)
            {
                sum += arg + Environment.NewLine;
                switch (arg)
                {
                    case "-ToastActivated":
                        //Environment.Exit(0);
                        break;
                    case "cqy":
                        ToastHelper.ToastStr("我的心弦");
                        break;
                }
            }
            if(!File.Exists(fp) && e.Args.Length > 0)
            {
                File.Create(fp);
                Library.FileHelper.FileHelper.WriteBytesToFile(fp, Encoding.UTF8.GetBytes(sum));
            }
        }

        private void StartUp()
        {
            confHelper = new ConfHelper(ref runninginfo);
            confHelper.LoadConf($"{runninginfo.WorkDirectory}\\conf\\conf.xml");
            mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
