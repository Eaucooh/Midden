using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using Timer = System.Windows.Forms.Timer;

namespace OSH
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 主事件
        public MainWindow()
        {
            InitializeComponent();

        }
        #endregion
        #region 全局定义
        public string newDrive = "Are you ok!!!";//不用在意
        public bool insucced = true;
        public bool isVisibility = false;
        public string selfPath = System.Windows.Forms.Application.StartupPath;
        public double X = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
        public double Y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
        public const int WM_DEVICECHANGE = 0x219;//U盘插入后，OS的底层会自动检测到，然后向应用程序发送“硬件设备状态改变“的消息
        public const int DBT_DEVICEARRIVAL = 0x8000;  //就是用来表示U盘可用的。一个设备或媒体已被插入一块，现在可用。
        public const int DBT_CONFIGCHANGECANCELED = 0x0019;  //要求更改当前的配置（或取消停靠码头）已被取消。
        public const int DBT_CONFIGCHANGED = 0x0018;  //当前的配置发生了变化，由于码头或取消固定。
        public const int DBT_CUSTOMEVENT = 0x8006; //自定义的事件发生。 的Windows NT 4.0和Windows 95：此值不支持。
        public const int DBT_DEVICEQUERYREMOVE = 0x8001;  //审批要求删除一个设备或媒体作品。任何应用程序也不能否认这一要求，并取消删除。
        public const int DBT_DEVICEQUERYREMOVEFAILED = 0x8002;  //请求删除一个设备或媒体片已被取消。
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;  //一个设备或媒体片已被删除。
        public const int DBT_DEVICEREMOVEPENDING = 0x8003;  //一个设备或媒体一块即将被删除。不能否认的。
        public const int DBT_DEVICETYPESPECIFIC = 0x8005;  //一个设备特定事件发生。
        public const int DBT_DEVNODES_CHANGED = 0x0007;  //一种设备已被添加到或从系统中删除。
        public const int DBT_QUERYCHANGECONFIG = 0x0017;  //许可是要求改变目前的配置（码头或取消固定）。
        public const int DBT_USERDEFINED = 0xFFFF;  //此消息的含义是用户定义的
        public const uint GENERIC_READ = 0x80000000;
        public const int GENERIC_WRITE = 0x40000000;
        public const int FILE_SHARE_READ = 0x1;
        public const int FILE_SHARE_WRITE = 0x2;
        public const int IOCTL_STORAGE_EJECT_MEDIA = 0x2d4808;
        public Timer timer_visible = new Timer();
        public Settings Setting = new Settings();
        public Kit kit = new Kit();
        public RoutedEventArgs rea_null = null;
        public NotifyIcon notifyicon = new NotifyIcon();
        public ContextMenuStrip cms = new ContextMenuStrip();
        public ToolStripMenuItem exitMenuItem = new ToolStripMenuItem();
        public ToolStripMenuItem moreMenuItem = new ToolStripMenuItem();
        public ToolStripMenuItem settingMenuItem = new ToolStripMenuItem();
        public ToolStripMenuItem kitMenuItem = new ToolStripMenuItem();
        #endregion
        #region 窗体启动时
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Top = 0;
            Left = X - Width;
            border.Visibility = Visibility.Hidden;
            Icon icon = new Icon(selfPath + @"\Resources\notify_visible.ico");
            notifyicon.Icon = icon;
            notifyicon.Text = "系统助手运行中";
            notifyicon.MouseDoubleClick += NotifyIcon_DoubleClick;
            notifyicon.ContextMenuStrip = cms;
            exitMenuItem.Text = "" + "退出";
            moreMenuItem.Text = "" + "更多";
            settingMenuItem.Text = "" + "设置";
            kitMenuItem.Text = "" + "工具箱";
            exitMenuItem.Click += new EventHandler(exitMenuItem_Click);
            moreMenuItem.Click += new EventHandler(moreMenuItem_Click);
            settingMenuItem.Click += new EventHandler(settingMenuItem_Click);
            kitMenuItem.Click += new EventHandler(kitMenuItem_Click);
            cms.Items.Add(moreMenuItem);
            cms.Items.Add(settingMenuItem);
            cms.Items.Add(kitMenuItem);
            cms.Items.Add(exitMenuItem);
            notifyicon.Visible = true;
            Setting.Show();
            Setting.Visibility = Visibility.Hidden;
            kit.Show();
            kit.Visibility = Visibility.Hidden;
        }
        #endregion
        #region 窗体移动
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        #endregion
        #region 旋转动画
        public void AngleEasingAnimationShow(UIElement element, double anglefrom, double angleto, int power, TimeSpan time)
        {
            RotateTransform angle = new RotateTransform();  //旋转
            element.RenderTransform = angle;
            //定义圆心位置
            element.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
            //定义过渡动画,power为过度的强度
            EasingFunctionBase easeFunction = new PowerEase()
            {
                EasingMode = EasingMode.EaseInOut,
                Power = power
            };
            DoubleAnimation angleAnimation = new DoubleAnimation()
            {
                From = anglefrom,                                   //起始值
                To = angleto,                                     //结束值
                FillBehavior = FillBehavior.HoldEnd,
                Duration = time,                                 //动画播放时间
            };
            angle.BeginAnimation(RotateTransform.AngleProperty, angleAnimation);
        }
        public static void DoWork(Action action, int millisecond = 300)
        {
            new Action<Dispatcher, Action, int>(DoWorkAsync).BeginInvoke(Dispatcher.CurrentDispatcher, action, millisecond, null, null);
        }
        static void DoWorkAsync(Dispatcher dispatcher, Action action, int millisecond)
        {
            System.Threading.Thread.Sleep(millisecond);
            dispatcher.BeginInvoke(action);
        }
        #endregion
        #region 任务栏事件
        void kitMenuItem_Click(object sender, EventArgs e)
        {
            kit_Click(sender, rea_null);
        }
        void settingMenuItem_Click(object sender, EventArgs e)
        {
            settings_Click(sender, rea_null);
        }
        void moreMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.InkShadow.com");
        }
        void exitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (Visibility == Visibility.Hidden)
            {
                Visibility = Visibility.Visible;
                notifyicon.Icon = new Icon(selfPath + @"\Resources\notify_visible.ico");
            }
            else
            {
                Visibility = Visibility.Hidden;
                notifyicon.Icon = new Icon(selfPath + @"\Resources\notify_hidden.ico");
            }
        }
        #endregion
        #region 系统消息匹配（U盘插拔）
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            var source = PresentationSource.FromVisual(this) as HwndSource;
            if (source != null)
            {
                source.AddHook(WndProc);
            }
        }
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            try
            {
                if (msg == WM_DEVICECHANGE)
                {
                    switch (wParam.ToInt32())
                    {
                        case WM_DEVICECHANGE:
                            break;
                        case DBT_DEVICEARRIVAL://U盘插入   
                            var s = DriveInfo.GetDrives();
                            foreach (var drive in s)
                            {
                                if (drive.DriveType == DriveType.Removable)
                                {
                                    UsbDrive x = new UsbDrive();
                                    x.myGoalPath = drive.Name;
                                    x.Top = Y - x.Height;
                                    x.Left = X - x.Width;
                                    x.Show();
                                    break;
                                }
                            }
                            break;
                        case DBT_CONFIGCHANGECANCELED:
                            break;
                        case DBT_CONFIGCHANGED:
                            break;
                        case DBT_CUSTOMEVENT:
                            break;
                        case DBT_DEVICEQUERYREMOVE:
                            break;
                        case DBT_DEVICEQUERYREMOVEFAILED:
                            break;
                        case DBT_DEVICEREMOVECOMPLETE: //U盘卸载   
                            try
                            {
                                
                            }
                            catch
                            {

                            }
                            break;
                        case DBT_DEVICEREMOVEPENDING:
                            break;
                        case DBT_DEVICETYPESPECIFIC:
                            break;
                        case DBT_DEVNODES_CHANGED:
                            break;
                        case DBT_QUERYCHANGECONFIG:
                            break;
                        case DBT_USERDEFINED:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {

            }
            return IntPtr.Zero;
        }
        #endregion
        #region 防止Alt+F4组合键和Alt+Space组合键
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Alt && e.SystemKey == Key.Space)
            {
                e.Handled = true;
            }
            else if (Keyboard.Modifiers == ModifierKeys.Alt && e.SystemKey == Key.F4)
            {
                e.Handled = true;
            }
            else
            {
                base.OnKeyDown(e);
            }
        }
        #endregion
        #region 主按钮事件
        private void ThreePoints_Click(object sender, RoutedEventArgs e)
        {
            if (isVisibility)
            {
                isVisibility = false;
                AngleEasingAnimationShow(border, 45, 0, 2, TimeSpan.FromMilliseconds(300));
                AngleEasingAnimationShow(close, 45, 0, 2, TimeSpan.FromMilliseconds(300));
                AngleEasingAnimationShow(self1, -45, 0, 2, TimeSpan.FromMilliseconds(300));
                AngleEasingAnimationShow(self2, -45, 0, 2, TimeSpan.FromMilliseconds(300));
                AngleEasingAnimationShow(self3, -45, 0, 2, TimeSpan.FromMilliseconds(300));
                AngleEasingAnimationShow(kitForm, -45, 0, 2, TimeSpan.FromMilliseconds(300));
                AngleEasingAnimationShow(settings, -45, 0, 2, TimeSpan.FromMilliseconds(300));
                host.Text = "";
                timer_visible.Interval = 300;
                timer_visible.Tick += Timer_visible_Tick;
                timer_visible.Enabled = true;
            }
            else
            {
                border.Visibility = Visibility.Visible;
                isVisibility = true;
                AngleEasingAnimationShow(border, 0, 45, 2, TimeSpan.FromMilliseconds(300));
                AngleEasingAnimationShow(close, 0, 45, 2, TimeSpan.FromMilliseconds(300));
                AngleEasingAnimationShow(self1, 0, -45, 2, TimeSpan.FromMilliseconds(300));
                AngleEasingAnimationShow(self2, 0, -45, 2, TimeSpan.FromMilliseconds(300));
                AngleEasingAnimationShow(self3, 0, -45, 2, TimeSpan.FromMilliseconds(300));
                AngleEasingAnimationShow(kitForm, 0, -45, 2, TimeSpan.FromMilliseconds(300));
                AngleEasingAnimationShow(settings, 0, -45, 2, TimeSpan.FromMilliseconds(300));
                host.Text = "";
            }
        }

        private void Timer_visible_Tick(object sender, EventArgs e)
        {
            timer_visible.Enabled = false;
            border.Visibility = Visibility.Hidden;
        }
        #endregion
        #region 最小化窗口
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
            notifyicon.Icon = new Icon(selfPath + @"\Resources\notify_hidden.ico");
        }
        #endregion
        #region 自定义按钮事件
        #region 按钮1
        private void Self1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckPathExists = true;
            ofd.Filter = "所有文件(All Types)|*.*";
            ofd.InitialDirectory = @"C:\";
            ofd.Multiselect = false;
            ofd.Title = "打开文件";
            do
            {
                ofd.ShowDialog();
                try
                {
                    Process.Start(ofd.FileName);
                    insucced = false;
                }
                catch
                {
                    if (MessageBox.Show("没有选择文件,是否重选", "错误", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
                    {
                        insucced = true;
                    }
                    else
                    {
                        insucced = false;
                    }
                }
            } while (insucced);
        }
        #endregion
        #region 按钮2
        private void Self2_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        #region 按钮3
        private void Self3_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        #endregion
        #region 关闭窗口事件
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            notifyicon.Visible = false;
            notifyicon.Dispose();
            System.Windows.Application.Current.Shutdown();
        }
        #endregion
        #region 工具箱及设置
        #region 工具箱
        private void kit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (kit.Visibility == Visibility.Hidden)
                {
                    kit.Visibility = Visibility.Visible;
                }
                else
                {
                    kit.Visibility = Visibility.Hidden;
                }
            }
            catch
            {
                kit = new Kit
                {
                    Visibility = Visibility.Visible
                };
                kit.Show();
            }
        }
        #endregion
        #region 设置
        private void settings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Setting.Visibility == Visibility.Hidden)
                {
                    Setting.Visibility = Visibility.Visible;
                }
                else
                {
                    Setting.Visibility = Visibility.Hidden;
                }
            }
            catch
            {
                Setting = new Settings
                {
                    Visibility = Visibility.Visible
                };
                Setting.Show();
            }
        }
        #endregion
        #endregion
    }
}
