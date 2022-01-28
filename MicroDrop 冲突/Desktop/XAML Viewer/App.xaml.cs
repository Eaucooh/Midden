using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace XAML_Viewer
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"错误：\r\n位置：{sender}\r\n{e.Exception.Message}");
        }

        public static void PreView(string content)
        {
            string fp = $"{Environment.CurrentDirectory}\\XAMLFile.xaml";
            var fi = new FileInfo(fp);
            if (fi.Exists)
            {
                fi.Delete();
            }
            using (FileStream fs = fi.Create())
            {
                Byte[] info = new System.Text.UTF8Encoding(true).GetBytes(content);
                fs.Write(info, 0, info.Length);
            }
            Window myWindow = null;
            //退出using语句块时，FileStream将立即被关闭；
            using (FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.Read))
            {
                myWindow = (Window)XamlReader.Load(fs);
            }
            myWindow.Show();
        }
    }
}
