using KitX.Core;
using Planner.Controls;
using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Planner
{
    /// <summary>
    /// MainWindowWindow.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IContract))]
    public partial class MainWindow : Window, IContract
    {
        System.Windows.Forms.Timer ti = new System.Windows.Forms.Timer();
        System.Timers.Timer ti_snd = new System.Timers.Timer(10);
        System.Timers.Timer ti_tick = new System.Timers.Timer(1000);

        private DateTime nowTick_snd = new DateTime(0001, 1, 1, 0, 0, 0, 0);
        private DateTime nowTick_tick = new DateTime(0001, 1, 1, 23, 59, 59);

        PopEye.WPF.Animation.AnimationHelper ah = new PopEye.WPF.Animation.AnimationHelper();

        private string LastAlert = "25:61";

        public MainWindow()
        {
            InitializeComponent();

            win = this;
            Closed += (x, y) =>
            {
                started = false;
            };
            Loaded += (x, y) =>
            {
                ti = new System.Windows.Forms.Timer()
                {
                    Interval = (int)(0.1 * 1000)
                };
                ti.Tick += (m, n) =>
                {
                    TimeViewer.SelectedTime = DateTime.Now;
                    UpdateGlobalTimeBox();
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        foreach (AlarmItem item in clocks.Children)
                        {
                            if (!(LastAlert.Equals(item.ClockTime)))
                            {
                                if (item.GetEnable() && DateTime.Now.ToString("HH:mm") == item.TarTi.ToString("HH:mm"))
                                {
                                    LastAlert = item.ClockTime;
                                    new AlertWin(item.ClockTime, 0)
                                    {
                                        Topmost = true
                                    }.Show();
                                }
                            }
                        }
                    }));
                };
                ti.Start();
                ti_snd.Elapsed += (m, n) =>
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        nowTick_snd = nowTick_snd.AddMilliseconds(15.485);
                        majorTickTimer.Text = nowTick_snd.ToString("HH:mm:ss");
                        viceTickTimer.Text = nowTick_snd.ToString("ff");
                    }));
                };
                ti_tick.Elapsed += (m, n) =>
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        nowTick_tick = nowTick_tick.AddSeconds(-1);
                        tick_tishow.Text = nowTick_tick.ToString("HH:mm:ss");
                        tick_progress.BeginAnimation(System.Windows.Controls.Primitives.RangeBase.ValueProperty, new PopEye.WPF.Animation.AnimationHelper().CreateDoubleAnimation(
                            new TimeSpan(0, 0, 0, 0, 500), tick_progress.Value, tick_progress.Value + 10, System.Windows.Media.Animation.FillBehavior.HoldEnd,
                            PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0));
                        if (nowTick_tick.Hour == 0 && nowTick_tick.Minute == 0 && nowTick_tick.Second == 0)
                        {
                            ti_tick.Enabled = false;
                            tick_player.IsChecked = false;
                            tick_doing = false;
                            new AlertWin("到点了", 1)
                            {
                                Topmost = true
                            }.Show();
                        }
                    }));
                };
            };

            Closing += (x, y) =>
            {
                ti.Stop();
                ti.Dispose();
                ti_snd.Stop();
                ti_snd.Dispose();
            };
        }

        private void OpenLink(object sender, RoutedEventArgs e)
        {
            string[] args = (sender as FrameworkElement).Tag.ToString().Split(':');
            var parameter = args[1];
            switch (args[0])
            {
                case "clock":
                    Clock(parameter);
                    break;
                case "snd":
                    Second(parameter);
                    break;
                case "tick":
                    Tick(parameter);
                    break;
            }
        }

        private double mepWidth = 240;
        private double mepHeight = 80;

        private void Clock(string args)
        {
            switch (args)
            {
                case "new":
                    AlarmItem item = new AlarmItem(TimePicker.SelectedTime.Value.ToString("HH:mm"), true)
                    {
                        container = clocks,
                        TarTi = TimePicker.SelectedTime.Value
                    };
                    item.LeftConfirmed += () =>
                    {
                        HandyControl.Controls.Growl.Info("LeftSucceed");
                    };
                    item.RightConfirmed += () =>
                    {
                        HandyControl.Controls.Growl.Info("RightSucceed");
                    };
                    clocks.Children.Add(item);
                    break;
                case "sle1":
                    foreach (AlarmItem ai in clocks.Children)
                    {
                        ai.TurnSelecterVisible();
                    }
                    EnableMulti.Tag = "clock:sle2";
                    MultiEditPane.BeginAnimation(OpacityProperty, ah.CreateDoubleAnimation(new System.TimeSpan(0, 0, 0, 0, 500), 0, 1,
                     System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0));
                    MultiEditPane.BeginAnimation(WidthProperty, ah.CreateDoubleAnimation(new System.TimeSpan(0, 0, 0, 0, 500), 0, mepWidth,
                     System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0));
                    MultiEditPane.BeginAnimation(HeightProperty, ah.CreateDoubleAnimation(new System.TimeSpan(0, 0, 0, 0, 850), 0, mepHeight,
                     System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0));
                    break;
                case "sle2":
                    foreach (AlarmItem ai in clocks.Children)
                    {
                        ai.TurnSelecterVisible();
                    }
                    EnableMulti.Tag = "clock:sle1";
                    MultiEditPane.BeginAnimation(OpacityProperty, ah.CreateDoubleAnimation(new System.TimeSpan(0, 0, 0, 0, 500), 1, 0,
                     System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0));
                    MultiEditPane.BeginAnimation(WidthProperty, ah.CreateDoubleAnimation(new System.TimeSpan(0, 0, 0, 0, 500), mepWidth, 0,
                     System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0));
                    MultiEditPane.BeginAnimation(HeightProperty, ah.CreateDoubleAnimation(new System.TimeSpan(0, 0, 0, 0, 850), mepHeight, 0,
                     System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0));
                    break;
                case "asd":
                    foreach (AlarmItem ai in clocks.Children)
                    {
                        if (ai.GetSelected())
                        {
                            ai.DelThis();
                        }
                    }
                    break;
                case "saa":
                    foreach (AlarmItem ai in clocks.Children)
                    {
                        ai.Select();
                    }
                    SelectAllItem.Tag = "clock:usa";
                    break;
                case "usa":
                    foreach (AlarmItem ai in clocks.Children)
                    {
                        ai.UnSelect();
                    }
                    SelectAllItem.Tag = "clock:saa";
                    break;
                case "rst":
                    foreach (AlarmItem ai in clocks.Children)
                    {
                        ai.UnSelect();
                        ai.UnVisibleSelector();
                    }
                    EnableMulti.Tag = "clock:sle1";
                    SelectAllItem.Tag = "clock:saa";
                    MultiEditPane.BeginAnimation(OpacityProperty, ah.CreateDoubleAnimation(new System.TimeSpan(0, 0, 0, 0, 500), 1, 0,
                     System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0));
                    MultiEditPane.BeginAnimation(WidthProperty, ah.CreateDoubleAnimation(new System.TimeSpan(0, 0, 0, 0, 500), mepWidth, 0,
                     System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0));
                    MultiEditPane.BeginAnimation(HeightProperty, ah.CreateDoubleAnimation(new System.TimeSpan(0, 0, 0, 0, 850), mepHeight, 0,
                     System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0));
                    break;
            }
        }

        private void SlideList(FrameworkElement target)
        {
            var currentScrollPosition = meteringer_scv.VerticalOffset;
            var point = new Point(0, currentScrollPosition);
            var targetPosition = target.TransformToVisual(meteringer_scv).Transform(point);
            meteringer_scv.ScrollToVerticalOffset(targetPosition.Y);
        }

        int nowIndex = 1;

        private void Second(string args)
        {
            switch (args)
            {
                case "rec":
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        ti_snd.Stop();
                        nowTick_snd = new DateTime(0001, 1, 1, 0, 0, 0, 0);
                        majorTickTimer.Text = "00:00:00";
                        viceTickTimer.Text = "00";
                        nowIndex = 1;
                        meteringer.Children.Clear();
                        snd_player.IsChecked = false;
                    }));
                    break;
                case "set":
                    var ti = new MeteringItem()
                    {
                        index = nowIndex,
                        time = nowTick_snd.ToString("HH:mm:ss.ff")
                    };
                    meteringer.Children.Add(ti);
                    ti.Loaded += (x, y) =>
                    {
                        SlideList(ti);
                    };
                    nowIndex++;
                    break;
                case "start":
                    switch (snd_player.IsChecked)
                    {
                        case true:
                            ti_snd.Start();
                            break;
                        case false:
                            ti_snd.Stop();
                            break;
                    }
                    break;
            }
        }

        bool tick_doing = false;

        private void Tick(string args)
        {
            switch (args)
            {
                case "start":
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        if (!ti_tick.Enabled)
                        {
                            if (!tick_doing)
                            {
                                nowTick_tick = new DateTime(1, 1, 1, tick_duration.DisplayTime.Hour, tick_duration.DisplayTime.Minute, tick_duration.DisplayTime.Second);
                                tick_tishow.Text = nowTick_tick.ToString("HH:mm:ss");
                                tick_progress.BeginAnimation(System.Windows.Controls.Primitives.RangeBase.ValueProperty, new PopEye.WPF.Animation.AnimationHelper().CreateDoubleAnimation(
                                    new TimeSpan(0, 0, 0, 0, 500), tick_progress.Value, 0, System.Windows.Media.Animation.FillBehavior.HoldEnd,
                                    PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0));
                                tick_progress.Maximum = (nowTick_tick.Hour * 3600 + nowTick_tick.Minute * 60 + nowTick_tick.Second) * 10;
                            }
                            tick_dash.SelectedIndex = 1;
                            tick_doing = true;
                        }
                        ti_tick.Enabled = (bool)tick_player.IsChecked;
                    }));
                    break;
                case "cancle":
                    tick_dash.SelectedIndex = 0;
                    tick_player.IsChecked = false;
                    ti_tick.Enabled = false;
                    tick_progress.BeginAnimation(System.Windows.Controls.Primitives.RangeBase.ValueProperty, new PopEye.WPF.Animation.AnimationHelper().CreateDoubleAnimation(
                            new TimeSpan(0, 0, 0, 0, 500), tick_progress.Value, 0, System.Windows.Media.Animation.FillBehavior.HoldEnd,
                            PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0));
                    break;
            }
        }

        #region 接口

        private string WorkBase = null;

        public void SetWorkBase(string path)
        {
            WorkBase = path;
            if (!Directory.Exists(WorkBase))
            {
                Directory.CreateDirectory(WorkBase);
            }
        }

        public string GetDescribe_Complex() => "闹钟啊、计时器啊、任务规划啊，还有什么跟计划有关的都在这呐(*･ω-q)";

        public string GetDescribe_Simple() => "你就是计划通吗？JOJO|ू･ω･`)";

        public string GetHelpLink() => "https://docs.catrol.cn/planner/";

        public string GetHostLink() => "https://blog.catrol.cn/";

        public BitmapImage GetIcon() => FindResource("Icon") as BitmapImage;

        public Languages GetLang() => Languages.zh_CN;

        public string GetName() => "Planner";

        public string GetPublisher() => "Catrol";

        public string GetVersion() => "v1.9.6";

        public Window GetWindow()
        {
            MainWindow win = new MainWindow()
            {
                Width = 1000,
                Height = 800,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ShowActivated = true,
                Title = "Planner"
            };
            return win;
        }

        public void SetTheme(KitX.Core.Theme tm)
        {

        }

        private readonly QuickView Quicker = new QuickView();

        public UserControl GetQuickView()
        {
            Quicker.win = win;
            if (started)
            {
                return Quicker;
            }
            else
            {
                return null;
            }
        }

        MainWindow win;
        bool started = true;
        bool start_st = true;

        public void Start()
        {
            if (start_st)
            {
                start_st = false;
                win.Show();
            }
            else
            {
                if (!started)
                {
                    win = new MainWindow();
                    win.Closed += (x, y) => started = false;
                    win.Show();
                    started = true;
                }
                else
                {
                    if (win.Visibility == Visibility.Hidden)
                    {
                        win.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        win.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        public void End()
        {
            win.Close();
            started = false;
        }

        public string GetFileName() => "Planner.dll";

        public Tags GetTag() => Tags.Normal;

        #endregion

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        public string nowZone = "China Standard Time";

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            string zone = "";
            switch ((sender as FrameworkElement).Tag)
            {
                case "BeiJing":
                    nowZone = "China Standard Time";
                    zone = "北京";
                    break;
                case "Canberra":                    
                    nowZone = "AUS Eastern Standard Time";
                    zone = "堪培拉";
                    break;
                case "Singapore":                    
                    nowZone = "Singapore Standard Time";
                    zone = "新加坡";
                    break;
                case "Brasilia":                    
                    nowZone = "E. South America Standard Time";
                    zone = "巴西利亚";
                    break;
                case "Paris":                    
                    nowZone = "Romance Standard Time";
                    zone = "巴黎";
                    break;
                case "Nairobi":                    
                    nowZone = "E. Africa Standard Time";
                    zone = "内罗华";
                    break;
                case "Seattle":
                    nowZone = "Alaskan Standard Time";
                    zone = "西雅图";
                    break;
            }
            //(Template.FindName("ZoneInfo", this) as TextBlock).Text = $"{zone}时间";
            ZoneInfo.Text = $"{zone}时间";
            ZoneInfoSrc.Text = nowZone;
        }

        public void UpdateGlobalTimeBox()
        {
            DateTime dt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now, TimeZoneInfo.Local);
            DateTime dt1 = TimeZoneInfo.ConvertTimeFromUtc(dt, TimeZoneInfo.FindSystemTimeZoneById(nowZone));
            ZoneTime.Text = dt1.ToString("HH:mm");
        }

        ///<summary>
        /// 获取标准北京时间2
        ///</summary>
        ///<returns></returns>
        public static DateTime GetBeijingTime()
        {
            //t0 = new Date().getTime();
            //nyear = 2011;
            //nmonth = 7;
            //nday = 5;
            //nwday = 2;
            //nhrs = 17;
            //nmin = 12;
            //nsec = 12;
            DateTime dt;
            WebRequest wrt = null;
            WebResponse wrp = null;
            try
            {
                wrt = WebRequest.Create("http://www.beijing-time.org/time.asp");
                wrp = wrt.GetResponse();

                string html = string.Empty;
                using (Stream stream = wrp.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
                    {
                        html = sr.ReadToEnd();
                    }
                }

                string[] tempArray = html.Split(';');
                for (int i = 0; i < tempArray.Length; i++)
                {
                    tempArray[i] = tempArray[i].Replace("\r\n", "");
                }

                string year = tempArray[1].Substring(tempArray[1].IndexOf("nyear=") + 6);
                string month = tempArray[2].Substring(tempArray[2].IndexOf("nmonth=") + 7);
                string day = tempArray[3].Substring(tempArray[3].IndexOf("nday=") + 5);
                string hour = tempArray[5].Substring(tempArray[5].IndexOf("nhrs=") + 5);
                string minite = tempArray[6].Substring(tempArray[6].IndexOf("nmin=") + 5);
                string second = tempArray[7].Substring(tempArray[7].IndexOf("nsec=") + 5);
                dt = DateTime.Parse(year + "-" + month + "-" + day + "" + hour + ":" + minite + ":" + second);
            }
            catch (WebException)
            {
                return DateTime.Parse("2011-1-1");
            }
            catch (Exception)
            {
                return DateTime.Parse("2011-1-1");
            }
            finally
            {
                if (wrp != null)
                    wrp.Close();
                if (wrt != null)
                    wrt.Abort();
            }
            return dt;
        }

        int hh_tick = 0;
        int mm_tick = 0;
        int ss_tick = 0;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch ((sender as FrameworkElement).Tag)
            {
                case "HH":
                    if (!int.TryParse((sender as TextBox).Text, out hh_tick) || hh_tick > 24)
                    {
                        HandyControl.Controls.Growl.Warning("Illicit numbers.\r\n非法的数值");
                        (sender as TextBox).Text = "00";
                    }
                    break;
                case "mm":
                    if (!int.TryParse((sender as TextBox).Text, out mm_tick) || mm_tick > 60)
                    {
                        HandyControl.Controls.Growl.Warning("Illicit numbers.\r\n非法的数值");
                        (sender as TextBox).Text = "00";
                    }
                    break;
                case "ss":
                    if (!int.TryParse((sender as TextBox).Text, out ss_tick) || ss_tick > 60)
                    {
                        HandyControl.Controls.Growl.Warning("Illicit numbers.\r\n非法的数值");
                        (sender as TextBox).Text = "00";
                    }
                    break;
            }
        }
    }
}
