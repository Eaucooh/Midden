using System;
using System.Configuration;
using System.IO;
using System.Windows;

namespace MediaPlayer
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length == 1)
            {
                FileInfo file = new FileInfo(e.Args[0]);
                if (file.Exists)
                {
                    string filename = Path.GetExtension(file.FullName.ToString());
                    string title = Path.GetFileNameWithoutExtension(file.FullName.ToString());
                    try
                    {
                        if (filename.Equals(".mp4") || filename.Equals(".avi") || filename.Equals(".mkv") || filename.Equals(".wmv") || filename.Equals(".mpg") || filename.Equals(".gif") || filename.Equals(".3gp") || filename.Equals(".mp3") || filename.Equals(".mp2") || filename.Equals(".wma"))
                        {
                            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                            cfa.AppSettings.Settings["path"].Value = file.FullName.ToString();
                            cfa.AppSettings.Settings["title"].Value = title;
                            cfa.Save();
                        }
                    }
                    catch (Exception i)
                    {
                        MessageBox.Show("原因如下:\r\n" + i.ToString(), "应用错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
