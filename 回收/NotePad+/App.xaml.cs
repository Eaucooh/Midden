using System.Diagnostics;
using System.Windows;

namespace NoPressNoWrite
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            bool isStarted = false;
            var prces = Process.GetProcesses();
            foreach (Process target in prces)
            {
                if (target.ProcessName.Equals("Center"))
                {
                    isStarted = true;
                }
            }
            if (!isStarted)
            {
                MessageBox.Show("未启动Itmooth Center，NoPressNoWrite将不会运行。", "提示", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
                Current.Shutdown(0);
            }
        }
    }
}