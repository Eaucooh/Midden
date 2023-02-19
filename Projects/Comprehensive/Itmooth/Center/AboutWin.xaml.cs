using System;
using System.Diagnostics;
using System.Windows;
using UI = Panuon.UI.Silver;

namespace Center
{
    /// <summary>
    /// AboutWin.xaml 的交互逻辑
    /// </summary>
    public partial class AboutWin : Window
    {
        public string WorkBase = AppDomain.CurrentDomain.BaseDirectory;

        public AboutWin()
        {
            InitializeComponent();
            back.Address = WorkBase + @"\Lib\Back\index.html";
        }

        private void Validate(object sender, RoutedEventArgs e)
        {
            if (SpeCode.Text == "A colorful egg")
            {
                back.Address = WorkBase + @"\Lib\CeLib_1\index.html";
                fore.Visibility = Visibility.Hidden;
                Exiter.Visibility = Visibility.Visible;
            }
            if(SpeCode.Text == "I am CQY")
            {
                back.Address = WorkBase + @"\Lib\CeLib_2\index.html";
                fore.Visibility = Visibility.Hidden;
                Exiter.Visibility = Visibility.Visible;
            }
            if(SpeCode.Text == "I wanna be a controler")
            {
                Window win = new Window()
                {
                    Title = "成为控制者",
                    Width = Width,
                    Height = Height,
                    Left = Left,
                    Top = Top,
                    Icon = Icon
                };
                win.Content = new CefSharp.Wpf.ChromiumWebBrowser()
                {
                    Address = WorkBase + @"\Lib\CeLib_3\index.html"
                };
                win.Show();
            }
        }

        private void InterHome(object sender, RoutedEventArgs e)
        {
            Process.Start("http://Center.Itmooth.com/");
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ExitEgg(object sender, RoutedEventArgs e)
        {
            Exiter.Visibility = Visibility.Hidden;
            fore.Visibility = Visibility.Visible;
            back.Address = WorkBase + @"\Lib\Back\index.html";
        }
    }
}
