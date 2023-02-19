using Microsoft.Win32;
using System;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace MediaPlayer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool isPlaying = false;
        DispatcherTimer upnowtime = new DispatcherTimer();
        TimeSpan timeSpan = new TimeSpan();
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                string Path = ConfigurationManager.AppSettings["path"].ToString();
                string Title = ConfigurationManager.AppSettings["title"].ToString();
                vp.Source = new Uri(Path);
                title.Text = Title;
                object sender = null;
                RoutedEventArgs e = null;
                play_Click(sender, e);
                upnowtime.Interval = TimeSpan.FromMilliseconds(0.1);
                upnowtime.Tick += (x, y) =>
                {
                    NowTimeUpdate();
                };
                upnowtime.Start();
            }
            catch
            {

            }            
        }

        private void NowTimeUpdate()
        {
            nowtime.Content = vp.Position;
            time.Value = vp.Position.Seconds + (vp.Position.Minutes * 60) + (vp.Position.Hours * 3600) + (vp.Position.Days * 216000);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {

            }
        }

        private void lastone_Click(object sender, RoutedEventArgs e)
        {
            if (vp.Position.TotalSeconds > 10)
            {
                vp.Position -= TimeSpan.FromSeconds(10);
            }
            else
            {
                vp.Position = TimeSpan.FromSeconds(0);
            }
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isPlaying == true)
                {
                    vp.Pause();
                    isPlaying = false;
                    play.Content = "";
                    upnowtime.Stop();
                }
                else
                {
                    vp.Play();
                    isPlaying = true;
                    play.Content = "";
                    upnowtime.Start();
                }
            }
            catch (Exception p)
            {
                MessageBox.Show("原因如下:\r\n" + p, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void nextone_Click(object sender, RoutedEventArgs e)
        {
            vp.Position += TimeSpan.FromSeconds(10);
        }

        private void mostsize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                mostsize.Content = "";
            }
            else
            {
                WindowState = WindowState.Maximized;
                mostsize.Content = "";
            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            vp.Stop();
            Application.Current.Shutdown();
        }

        private void vp_MediaEnded(object sender, RoutedEventArgs e)
        {
            object o = null;
            RoutedEventArgs re = null;
            play_Click(o, re);
        }

        private void vp_MediaOpened(object sender, RoutedEventArgs e)
        {
            alltime.Content = vp.NaturalDuration;
            var maxl = vp.NaturalDuration.TimeSpan;
            double seconds = maxl.TotalSeconds;
            time.Maximum = seconds;
        }

        private void time_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            timeSpan = TimeSpan.FromSeconds(time.Value);
            vp.Position = timeSpan;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                mostsize.Content = "";
            }
            else
            {
                mostsize.Content = "";
            }
        }

        private void opennew_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "视频|*.mp4|视频|*.avi|视频|*.mkv|视频|*.wmv|视频|*.mpg|视频|*.3gp|音频|*.mp3|音频|*.wma|音频|*.mp2|图片|*.gif",
                DefaultExt = "视频|*.mp4",
                Title = "选择多媒体",
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true
            };
            fileDialog.ShowDialog();
            try
            {
                string name = Path.GetFileNameWithoutExtension(fileDialog.FileName);
                vp.Source = new Uri(fileDialog.FileName);
                title.Text = name;
            }
            catch
            { 
            
            }
        }

        private void vp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (topBar.Visibility == Visibility.Hidden)
            {
                topBar.Visibility = Visibility.Visible;
                buttomBar.Visibility = Visibility.Visible;
            }
            else
            {
                topBar.Visibility = Visibility.Hidden;
                buttomBar.Visibility = Visibility.Hidden;
            }
        }
    }
}
