using System;
using System.Windows;

namespace Center
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        System.Threading.Mutex mutex;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            bool ret;
            mutex = new System.Threading.Mutex(true, "ElectronicNeedleTherapySystem", out ret);
            if (!ret)
            {
                MessageBox.Show("已经有一个此程序的实例正在运行，本实例将退出", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                Environment.Exit(0);
            }
        }
    }
}
