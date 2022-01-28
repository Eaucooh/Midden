using KitX.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Player
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IContract))]
    public partial class MainWindow : Window, IContract
    {
        private Dictionary<string, string> formats = new Dictionary<string, string>();

        private System.Windows.Forms.Timer ti;

        public static double WorkAreaWidth = SystemParameters.WorkArea.Width;//获取工作区宽度
        public static double WorkAreaHeight = SystemParameters.WorkArea.Height;//获取工作区高度

        public bool OperationVisible = true;

        public MainWindow()
        {
            InitializeComponent();

            win = this;
            Closed += (x, y) =>
            {
                started = false;
            };
            ti = new System.Windows.Forms.Timer()
            {
                Interval = (int)(0.8 * 1000)
            };
            ti.Tick += (x, y) =>
            {
                ProcessBar.Value = player.Position.TotalSeconds;
            };

            player.MediaOpened += (x, y) =>
            {
                ProcessBar.Maximum = Convert.ToInt32(player.NaturalDuration.TimeSpan.TotalSeconds);
                Width = player.NaturalVideoWidth;
                Height = player.NaturalVideoHeight;
                if (Width + Left >= WorkAreaWidth && Width < WorkAreaWidth)
                {
                    Left = (WorkAreaWidth - Width) / 2;
                }
                else if (Width >= WorkAreaWidth)
                {
                    Left = 0;
                }
                if (Height + Top >= WorkAreaHeight && Height < WorkAreaHeight)
                {
                    Top = (WorkAreaHeight - Height) / 2;
                }
                else if (Height >= WorkAreaHeight)
                {
                    Top = 0;
                }
            };
        }

        #region 接口实现
        private string WorkBase = null;

        public void SetWorkBase(string path)
        {
            WorkBase = path;
            if (!Directory.Exists(WorkBase))
            {
                Directory.CreateDirectory(WorkBase);
            }
        }

        public string GetDescribe_Complex() => "多媒体播放器，支持多种格式，当前功能仍不完善，仍在升级维护中。";

        public string GetDescribe_Simple() => "简单的多媒体播放器";

        public string GetFileName() => "Player.dll";

        public string GetHelpLink() => "https://docs.catrol.cn/";

        public string GetHostLink() => "https://blog.catrol.cn/";

        public BitmapImage GetIcon() => FindResource("Icon") as BitmapImage;

        public Languages GetLang() => Languages.zh_CN;

        public string GetName() => "Player";

        public string GetPublisher() => "Catrol";

        public string GetVersion() => "v2.1.11";

        public Window GetWindow() => new MainWindow();

        public void SetTheme(Theme theme)
        {
            Background = (theme == Theme.Light) ? new SolidColorBrush(Colors.WhiteSmoke) : new SolidColorBrush(Colors.Black);
            Foreground = (theme == Theme.Light) ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.WhiteSmoke);
        }

        QuickView quicker = new QuickView();

        public UserControl GetQuickView() => quicker;

        MainWindow win;
        bool started = true;
        bool start_st = true;

        public void Start()
        {
            if (start_st)
            {
                start_st = false;
                win.Opacity = 0;
                win.Show();
                win.BeginAnimation(OpacityProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 500),
                    0, 1, FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic,
                    EasingMode.EaseOut, 0, 0));
            }
            else
            {
                if (!started)
                {
                    win = new MainWindow();
                    win.Closed += (x, y) =>
                    {
                        started = false;
                        quicker.win = null;
                    };
                    win.Opacity = 0;
                    win.Show();
                    win.BeginAnimation(OpacityProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 500),
                        0, 1, FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic,
                        EasingMode.EaseOut, 0, 0));
                    started = true;
                }
                else
                {
                    if (win.Visibility == Visibility.Hidden)
                    {
                        win.Opacity = 0;
                        win.Visibility = Visibility.Visible;
                        win.BeginAnimation(OpacityProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 500),
                            0, 1, FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic,
                            EasingMode.EaseOut, 0, 0));
                    }
                    else
                    {
                        DoubleAnimation da = PopEye.WPF.Animation.AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 500),
                            1, 0, FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic,
                            EasingMode.EaseOut, 0, 0);
                        da.Completed += (x, y) =>
                        {
                            win.Visibility = Visibility.Hidden;
                        };
                        win.BeginAnimation(OpacityProperty, da);
                    }
                }
            }
        }

        public void End()
        {
            DoubleAnimation da = PopEye.WPF.Animation.AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 500),
                1, 0, FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic,
                EasingMode.EaseOut, 0, 0);
            da.Completed += (x, y) =>
            {
                win.Close();
            };
            win.BeginAnimation(OpacityProperty, da);
            started = false;
        }

        public Tags GetTag() => Tags.Normal; 
        #endregion

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                if (OperationVisible)
                {

                    optionPane.BeginStoryboard(Resources["OptionPane_Hide"] as Storyboard);
                    OperationVisible = false;
                }
                else
                {
                    optionPane.BeginStoryboard(Resources["OptionPane_Show"] as Storyboard);
                    OperationVisible = true;
                }
            }
        }

        private void OpenLink(object sender, RoutedEventArgs e)
        {
            string[] parts = (sender as FrameworkElement).Tag.ToString().Split(':');
            switch (parts[0])
            {
                case "cmd":
                    DoCmd(parts[1]);
                    break;
                default:
                    System.Diagnostics.Process.Start(parts[1]);
                    break;
            }
        }

        private void Jump(object sender, RoutedEventArgs e) => player.Position += new TimeSpan(0, 0, Convert.ToInt32((sender as FrameworkElement).Tag));

        private void DoCmd(string cmd)
        {
            switch (cmd)
            {
                case "Close":
                    End();
                    break;
                case "Minimize":
                    WindowState = WindowState.Minimized;
                    break;
                default:
                    break;
            }
        }

        private void ShowThePlayList(object sender, RoutedEventArgs e) => PlayLister_mask.IsHitTestVisible = true;

        private void FillScreen()
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void HideThePlayList(object sender, MouseButtonEventArgs e) => PlayLister_mask.IsHitTestVisible = false;

        public void Play()
        {
            player.Play();
            ti.Start();
            Playing.IsChecked = true;
        }

        public void Pause()
        {
            if (player.CanPause)
            {
                player.Pause();
                ti.Stop();
                Playing.IsChecked = false;
            }
            else
            {
                Playing.IsChecked = true;
            }
        }

        public void AddTask(string path)
        {
            var bar = new VideoItem()
            {
                fileName = System.IO.Path.GetFileName(path),
                filePath = path,
                width = 300
            };
            bar.btn.Click += (x, y) =>
            {
                player.Source = new Uri(path, UriKind.Absolute);
            };
            playLister.Items.Add(bar);
        }

        public void PlayLastTask(string path)
        {
            player.Source = new Uri(path, UriKind.Absolute);
            Play();
        }

        private void Playing_Checked(object sender, RoutedEventArgs e) => Play();

        private void Playing_Unchecked(object sender, RoutedEventArgs e) => Pause();

        private void OpenVideo(object sender, RoutedEventArgs e) => AddTask(Library.FileHelper.FileWin.OpenFile_Single(formats, "选择一个视频文件打开"));

        private void ProcessBar_MouseUp(object sender, MouseButtonEventArgs e) => player.Position = new TimeSpan(0, 0, Convert.ToInt32((sender as HandyControl.Controls.PreviewSlider).Value));

        private void fser_Checked(object sender, RoutedEventArgs e) => FillScreen();

        private void fser_Unchecked(object sender, RoutedEventArgs e) => FillScreen();
    }
}
