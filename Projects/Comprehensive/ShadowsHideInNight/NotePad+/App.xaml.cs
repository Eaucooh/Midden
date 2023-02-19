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
            /*
            if (e.Args.Length == 1)
            {
                FileInfo file = new FileInfo(e.Args[0]);
                if (file.Exists)
                {
                    string filename = file.FullName.ToString();
                    
                }
            }
            */
            bool isStarted = false;
            var prces = Process.GetProcesses();
            foreach (Process target in prces)
            {
                if (target.ProcessName.Equals("ELMTC"))
                {
                    isStarted = true;
                }
            }
            if (!isStarted)
            {
                MessageBox.Show("未启动ELMTC启示物控制中心应用，NoPressNoWrite将不会运行。", "提示", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
                Current.Shutdown(0);
            }
        }
    }
}
