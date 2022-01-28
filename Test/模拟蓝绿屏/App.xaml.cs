using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace 模拟蓝绿屏
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Contains("-b"))
            {

            }
            else if(e.Args.Contains("-g"))
            {
                
            }
            else
            {
                MessageBox.Show("-b 蓝屏\r\n-g 绿屏");
            }
        }
    }
}
