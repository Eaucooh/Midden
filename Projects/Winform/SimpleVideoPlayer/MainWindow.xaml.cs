using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Threading;
/* =================================================
  * Author:     Micro
  * Date:       2016=03-25
  * Qq:         471812366@qq.com
  ================================================= */

namespace VideoPlayer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //进度时间设置
        private TimeSpan duration;
        private DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
            mediaElement.MediaOpened += new RoutedEventHandler(mediaElement_MediaOpened);
            mediaElement.MediaEnded += new RoutedEventHandler(mediaElement_MediaEnded);
        }
        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            timelineSlider.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
            duration = mediaElement.NaturalDuration.HasTimeSpan ? mediaElement.NaturalDuration.TimeSpan : TimeSpan.FromMilliseconds(0);
            totalTime.Text += string.Format(
                 "{0}{1:00}:{2:00}:{3:00}", "总时长：",
                 duration.Hours,
                 duration.Minutes,
                 duration.Seconds);
        }
        
        //启动视频
        private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            timelineSlider.Value = 0;
        }
        //窗口加载
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 每 500 毫秒调用一次指定的方法
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            //使播放进度条跟随播放时间移动
            timelineSlider.ToolTip = mediaElement.Position.ToString().Substring(0, 8);
            txtTime.Text = string.Format(
                               "{0}{1:00}:{2:00}:{3:00}",
                               "播放进度：",
                               mediaElement.Position.Hours,
                               mediaElement.Position.Minutes,
                               mediaElement.Position.Seconds);
        }
        // 设置播放，暂停，停止，前进，后退按钮是否可用
        private void SetPlayer(bool bVal)
        {
            playBtn.IsEnabled = bVal;
            pauseBtn.IsEnabled = bVal;
            stopBtn.IsEnabled = bVal;
            backBtn.IsEnabled = bVal;
            forwardBtn.IsEnabled = bVal;
        }
        //选择视频文件对话框
        private void openBtn_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = @"视频文件(*.avi格式)|*.avi|视频文件(*.wav格式)|*.wav|视频文件(*.wmv格式)|*.wmv|(*.mp4格式)|*.mp4|All Files|*.*"
            };
            var result = openFileDialog.ShowDialog();
            if (result == true)
            {
                mediaElement.Source = new Uri(openFileDialog.FileName, UriKind.Relative);
                playBtn.IsEnabled = true;
            }
        }
        
        //播放视频
        private void playBtn_Click(object sender, RoutedEventArgs e)
        {
            SetPlayer(true);
            mediaElement.Play();
            /***************************
            *进度时间设置4
            ****************************/
            //处于暂停状态则继续播放
            //mediaElement.Position = TimeSpan.FromSeconds(timelineSlider.Value);
            //判断播放器是否处于暂停状态
            /***************************
            *进度时间设置4
            ****************************/    
        }
        //暂停播放视频
        private void pauseBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
            string a = mediaElement.Position.ToString();
            string b = a.Substring(0, 8);//获取当前视频的时间
            string[] videotime = b.Split(':');
            int totime = int.Parse(videotime[0]) * 3600 + int.Parse(videotime[1]) * 60 + int.Parse(videotime[2]);
            textBox1.Text = Convert.ToString(totime);
            /*****************************
            *进度时间设置6
            *****************************/
            //timer.Stop();
            /*****************************
            *进度时间设置6
            *****************************/
        }       
        
        //停止播放
        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            SetPlayer(false);
            playBtn.IsEnabled = true;
            /*****************************
              *进度时间设置5
            *****************************/
            //timer.Stop();
            //timelineSlider.Value = 0;
            /*****************************
            *进度时间设置5
            *****************************/
        }
        //后退播放
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = mediaElement.Position - TimeSpan.FromSeconds(10);
        }
        //快进播放
        private void forwardBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = mediaElement.Position + TimeSpan.FromSeconds(10);
        }
        //滑动时间
        private void MediaTimeChanged(object sender, EventArgs e)
        {
            timelineSlider.Value = mediaElement.Position.TotalMilliseconds;
        }
        //跳转播放
        private void LocationBtn_Click(object sender, RoutedEventArgs e)
        {
            string Current_Position = textBox1.Text;
            if (Current_Position != "")
            {
                int current_time = int.Parse(Current_Position);
                int hour = current_time / 3600;
                int minutes = (current_time - (3600 * hour)) / 60;
                int second = current_time - (3600 * hour) - (minutes * 60);
                DateTime nows = DateTime.Now;
                int year = nows.Year;
                int month = nows.Month;
                int day = nows.Day;
                DateTime dt = new DateTime(year, month, day, hour, minutes, second);
                DateTime dt2 = new DateTime(year, month, day, 0, 0, 0);
                TimeSpan times = new TimeSpan((dt - dt2).Ticks);
                mediaElement.Position = times;
                mediaElement.Play();
            }
        }

        //是否静音
        private void IsMutedBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mediaElement.IsMuted == true)
            {
                IsMutedBtn.Content = "静音";
                mediaElement.IsMuted = false;
            }
            else
            {
                IsMutedBtn.Content = "有声";
                mediaElement.IsMuted = true;
            }
        }
        #region 播放进度，跳转到播放的哪个地方
        private void timelineSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int SliderValue = (int)timelineSlider.Value;
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
            mediaElement.Position = ts;
            timelineSlider.ToolTip = mediaElement.Position.ToString().Substring(0, 8);
            mediaElement.Play();
        }
        #endregion
        
    }
}
