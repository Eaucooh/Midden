using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using pu = Panuon.UI;
using ps = Panuon.UI.Silver;
using System.Diagnostics;
using CefSharp;
using CefSharp.Wpf;
using System.IO;

namespace Sizen
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public string WorkBase = AppDomain.CurrentDomain.BaseDirectory;
        AppTool.File file = new AppTool.File();
        AppTool.Net net = new AppTool.Net();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AllExit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void OpenAbout(object sender, RoutedEventArgs e)
        {
            AboutWin aboutWin = new AboutWin();
            aboutWin.ShowDialog();
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            string serveMachine = file.ValueReader(WorkBase + @"\Conf\serve.txt");
            int timeOut = 3;
            if (net.IsWebConected(serveMachine, timeOut))
            {
                ChromiumWebBrowser wb = new ChromiumWebBrowser()
                {
                    Address = "http://sizen.itmooth.com/home/",
                    Margin = new Thickness(0)
                };
                Contents.Child = wb;
            }
            else
            {
                try
                {
                    ps.Notice.Show(net.WebConectionError(serveMachine, timeOut).Message, "错误", 3, ps.MessageBoxIcon.Error);
                }
                catch
                {
                    ps.Notice.Show("未确定的错误原因", "错误", 3, ps.MessageBoxIcon.Error);
                }
            }
        }

        private void allTool_Click(object sender, RoutedEventArgs e)
        {
            WrapPanel docker = new WrapPanel();
            string path = file.ValueReader(WorkBase + @"\Conf\tools.txt");
            Path.Text = path;
            if (File.Exists(path))
            {
                DirectoryInfo info = new DirectoryInfo(path);
                foreach (DirectoryInfo NextFolder in info.GetDirectories())
                {
                    ItemCard ic = new ItemCard();
                    ic.imgPath = NextFolder.FullName + @"\cover.jpg";
                    ps.Notice.Show(ic.imgPath+"\n"+ic.Width+"\n"+ic.Height, "");
                    docker.Children.Add(ic);
                }
                Contents.Child = docker;
            }
            else
            {
                Directory.CreateDirectory(path);
            }
        }

        private void favTool_Click(object sender, RoutedEventArgs e)
        {

        }

        private void manTool_Click(object sender, RoutedEventArgs e)
        {

        }

        private void services_Click(object sender, RoutedEventArgs e)
        {

        }

        private void secret_Click(object sender, RoutedEventArgs e)
        {

        }

        private void official_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("http://sizen.itmooth.com/");
            }
            catch (Exception o)
            {
                ps.Notice.Show(o.Message, "错误", 3, ps.MessageBoxIcon.Error);
            }
        }

        private void WinMove(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void options_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
