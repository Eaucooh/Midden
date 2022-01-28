using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Threading;
using WinFTimer = System.Windows.Forms.Timer;

namespace ManageCenter
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 初始化
        string myselfpath = System.Windows.Forms.Application.StartupPath;
        public MainWindow()
        {
            InitializeComponent();
            HideWin();//隐藏所有初始不可见窗口
            logtime.Text = DateTime.Now.ToString("HH:mm");
            runtime.Text = DateTime.Now.ToString("HH:mm");
            WinFTimer st = new WinFTimer()
            {
                Interval = 2000,
                Enabled = true
            };
            st.Tick += (x, y) =>
            {
                st.Enabled = false;
                startwin.Visibility = Visibility.Hidden;
                logwin.Visibility = Visibility.Visible;
            };
            DispatcherTimer dt = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(10)
            };
            dt.Tick += (x, y) =>
            {
                logtime.Text = DateTime.Now.ToString("HH:mm");
                runtime.Text = DateTime.Now.ToString("HH:mm");
            };
            dt.Start();
            startMenu.LostFocus += (x, y) =>
            {
                startMenu.Visibility = Visibility.Hidden;
            };
            unconveniant.MouseDown += (x, y) =>
            {
                wbe.Visibility = Visibility.Visible;
            };
            moukey.MouseDown += (x, y) =>
            {
                wbe.Visibility = Visibility.Hidden;
            };
            WalletWin();
        }

        void WalletWin()
        {
            Wallet wallet = new Wallet();
            WindowInteropHelper parentHelper = new WindowInteropHelper(this);
            WindowInteropHelper childHelper = new WindowInteropHelper(wallet);
            Win32Naive.Win32Native.SetParent(childHelper.Handle, parentHelper.Handle);
            wallet.Show();
        }

        void HideWin()
        {
            startMenu.Visibility = Visibility.Hidden;
            powopt.Visibility = Visibility.Hidden;
            shuwin.Visibility = Visibility.Hidden;
            logwin.Visibility = Visibility.Hidden;
            runwin.Visibility = Visibility.Hidden;
            accwin.Visibility = Visibility.Hidden;
            setwin.Visibility = Visibility.Hidden;
            elcwin.Visibility = Visibility.Hidden;
            appwin.Visibility = Visibility.Hidden;
            wbe.Visibility = Visibility.Hidden;
            loginfo.Visibility = Visibility.Hidden;
            shezhi.Visibility = Visibility.Hidden;
            sethos.Visibility = Visibility.Visible;
            project.Visibility = Visibility.Hidden;
            apps.Visibility = Visibility.Hidden;
            shop.Visibility = Visibility.Hidden;
            license.Visibility = Visibility.Hidden;
            startwin.Visibility = Visibility.Visible;
            Accwin_Clear();
        }
        #endregion
        #region 窗口拖动
        private void Window_DragMove(object sender, MouseButtonEventArgs e)
        {
            try { DragMove(); } catch { }
        }
#endregion
        #region 电源选项
        private void power_Click(object sender, RoutedEventArgs e)
        {
            startMenu.Visibility = Visibility.Hidden;
            if (powopt.Visibility == Visibility.Hidden)
            {
                powopt.Visibility = Visibility.Visible;
            }
            else
            {
                powopt.Visibility = Visibility.Hidden;
            }
        }

        private void shutdown_Click(object sender, RoutedEventArgs e)
        {
            shuwin.Visibility = Visibility.Visible;
            runwin.Visibility = Visibility.Hidden;
            ShutDown();
        }

        private void sleep_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(myselfpath + @"\Center.exe");
            shutdown_Click(sender, e);
        }

        void ShutDown()
        {
            WinFTimer st = new WinFTimer()
            {
                Interval = 2000,
                Enabled = true
            };
            st.Tick += (x, y) =>
            {
                st.Enabled = false;
                Close();
            };            
        }
#endregion
        #region 交互按钮
        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (startMenu.Visibility == Visibility.Hidden)
            {
                startMenu.Visibility = Visibility.Visible;
            }
            else
            {
                startMenu.Visibility = Visibility.Hidden;
            }
        }

        private void logwin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyStates == Keyboard.GetKeyStates(Key.Enter))
            {
                logwin.Visibility = Visibility.Hidden;
                runwin.Visibility = Visibility.Visible;
            }
        }

        private void showlogwin_Click(object sender, RoutedEventArgs e)
        {
            loginfo.Visibility = Visibility.Visible;
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            string ni = id.Text;
            string np = pwd.Text;
            if (ni.Equals("test") && np.Equals("tester"))
            {
                logwin.Visibility = Visibility.Hidden;
                runwin.Visibility = Visibility.Visible;
            }
        }
        #endregion
        #region 开始菜单按钮
        bool isElcwinShowed = false;
        private void Centerloud_Click(object sender, RoutedEventArgs e)
        {
            if (isElcwinShowed)
            {
                elcwin.Visibility = Visibility.Visible;
            }
            else
            {
                var myResourceDictionary = new ResourceDictionary
                {
                    Source = new Uri("/Center;component/Button.xaml", UriKind.RelativeOrAbsolute) // 指定样式文件的路径
                };
                var myButtonStyle = myResourceDictionary["BtnInfoStyle"] as Style; // 通过key找到指定的样式
                elcwin.Visibility = Visibility.Visible;
                Button bu = new Button()
                {
                    Style = myButtonStyle,
                    Width = 40,
                    Height = 40,
                    Content = Centerloud.Content,
                    Foreground = Centerloud.Foreground,
                    Background = Centerloud.Background,
                    BorderBrush = Centerloud.BorderBrush,
                    BorderThickness = Centerloud.BorderThickness,
                    FontFamily = Centerloud.FontFamily,
                    FontSize = Centerloud.FontSize
                };
                bu.Click += (x, y) =>
                {
                    if (elcwin.Visibility == Visibility.Visible)
                    {
                        elcwin.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        elcwin.Visibility = Visibility.Visible;
                    }
                };
                bu.MouseRightButtonDown += (x, y) =>
                {
                    appsbar.Children.Remove(bu);
                    elcwin.Visibility = Visibility.Hidden;
                    isElcwinShowed = false;
                };
                /*cloelcwin.Click += (x, y) =>
                {
                    appsbar.Children.Remove(bu);
                    elcwin.Visibility = Visibility.Hidden;
                    isElcwinShowed = false;
                };
                */
                appsbar.Children.Add(bu);
                isElcwinShowed = true;
            }
            startMenu.Visibility = Visibility.Hidden;
        }

        bool isAppwinShowed = false;
        private void appman_Click(object sender, RoutedEventArgs e)
        {
            if (isAppwinShowed)
            {
                appwin.Visibility = Visibility.Visible;
            }
            else
            {
                var myResourceDictionary = new ResourceDictionary
                {
                    Source = new Uri("/Center;component/Button.xaml", UriKind.RelativeOrAbsolute) // 指定样式文件的路径
                };
                var myButtonStyle = myResourceDictionary["BtnInfoStyle"] as Style; // 通过key找到指定的样式
                appwin.Visibility = Visibility.Visible;
                Button bu = new Button()
                {
                    Style = myButtonStyle,
                    Width = 40,
                    Height = 40,
                    Content = appman.Content,
                    Foreground = appman.Foreground,
                    Background = appman.Background,
                    BorderBrush = appman.BorderBrush,
                    BorderThickness = appman.BorderThickness,
                    FontFamily = appman.FontFamily,
                    FontSize = appman.FontSize
                };
                bu.Click += (x, y) =>
                {
                    if (appwin.Visibility == Visibility.Visible)
                    {
                        appwin.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        appwin.Visibility = Visibility.Visible;
                    }
                };
                bu.MouseRightButtonDown += (x, y) =>
                {
                    appsbar.Children.Remove(bu);
                    appwin.Visibility = Visibility.Hidden;
                    isAppwinShowed = false;
                };
                cloappwin.Click += (x, y) =>
                {
                    appsbar.Children.Remove(bu);
                    appwin.Visibility = Visibility.Hidden;
                    isAppwinShowed = false;
                };
                appsbar.Children.Add(bu);
                isAppwinShowed = true;
            }
            startMenu.Visibility = Visibility.Hidden;
        }

        bool isAccwinShowed = false;
        private void account_Click(object sender, RoutedEventArgs e)
        {
            if (isAccwinShowed)
            {
                accwin.Visibility = Visibility.Visible;
            }
            else
            {
                var myResourceDictionary = new ResourceDictionary
                {
                    Source = new Uri("/Center;component/Button.xaml", UriKind.RelativeOrAbsolute) // 指定样式文件的路径
                };
                var myButtonStyle = myResourceDictionary["BtnInfoStyle"] as Style; // 通过key找到指定的样式
                accwin.Visibility = Visibility.Visible;
                Button bu = new Button()
                {
                    Style = myButtonStyle,
                    Width = 40,
                    Height = 40,
                    Content = account.Content,
                    Foreground = account.Foreground,
                    Background = account.Background,
                    BorderBrush = account.BorderBrush,
                    BorderThickness = account.BorderThickness,
                    FontFamily = account.FontFamily,
                    FontSize = account.FontSize
                };
                bu.Click += (x, y) =>
                {
                    if (accwin.Visibility == Visibility.Visible)
                    {
                        accwin.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        accwin.Visibility = Visibility.Visible;
                    }
                };
                bu.MouseRightButtonDown += (x, y) =>
                {
                    appsbar.Children.Remove(bu);
                    accwin.Visibility = Visibility.Hidden;
                    isAccwinShowed = false;
                };
                cloaccwin.MouseDown += (x, y) =>
                {
                    appsbar.Children.Remove(bu);
                    accwin.Visibility = Visibility.Hidden;
                    isAccwinShowed = false;
                };
                appsbar.Children.Add(bu);
                isAccwinShowed = true;
            }
            startMenu.Visibility = Visibility.Hidden;
        }

        bool isSetwinShowed = false;
        private void settings_Click(object sender, RoutedEventArgs e)
        {   
            if (isSetwinShowed)
            {
                setwin.Visibility = Visibility.Visible;
            }
            else
            {
                var myResourceDictionary = new ResourceDictionary
                {
                    Source = new Uri("/Center;component/Button.xaml", UriKind.RelativeOrAbsolute) // 指定样式文件的路径
                };
                var myButtonStyle = myResourceDictionary["BtnInfoStyle"] as Style; // 通过key找到指定的样式
                setwin.Visibility = Visibility.Visible;
                Button bu = new Button()
                {
                    Style = myButtonStyle,
                    Width = 40,
                    Height = 40,
                    Content = settings.Content,
                    Foreground = settings.Foreground,
                    Background = settings.Background,
                    BorderBrush = settings.BorderBrush,
                    BorderThickness = settings.BorderThickness,
                    FontFamily = settings.FontFamily,
                    FontSize = settings.FontSize
                };
                bu.Click += (x, y) =>
                {
                    if (setwin.Visibility == Visibility.Visible)
                    {
                        setwin.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        setwin.Visibility = Visibility.Visible;
                    }
                };
                bu.MouseRightButtonDown += (x, y) =>
                {
                    appsbar.Children.Remove(bu);
                    setwin.Visibility = Visibility.Hidden;
                    isSetwinShowed = false;
                };
                closetwin.Click += (x, y) =>
                {
                    appsbar.Children.Remove(bu);
                    setwin.Visibility = Visibility.Hidden;
                    isSetwinShowed = false;
                };
                appsbar.Children.Add(bu);
                isSetwinShowed = true;
            }
            startMenu.Visibility = Visibility.Hidden;
        }
        #endregion
        #region 设置
        #region 主页跳转
        private void gonor_Click(object sender, RoutedEventArgs e)
        {
            normal.IsSelected = true;
            ShowSheZhi();
        }

        private void gonet_Click(object sender, RoutedEventArgs e)
        {
            net.IsSelected = true;
            ShowSheZhi();
        }

        private void gothe_Click(object sender, RoutedEventArgs e)
        {
            theme.IsSelected = true;
            ShowSheZhi();
        }

        private void gotal_Click(object sender, RoutedEventArgs e)
        {
            tal.IsSelected = true;
            ShowSheZhi();
        }

        private void golic_Click(object sender, RoutedEventArgs e)
        {
            Lich.IsSelected = true;
            ShowSheZhi();
        }

        private void gosaf_Click(object sender, RoutedEventArgs e)
        {
            safe.IsSelected = true;
            ShowSheZhi();
        }

        void ShowSheZhi()
        {
            shezhi.Visibility = Visibility.Visible;
        }

        private void bacsethos_Click(object sender, RoutedEventArgs e)
        {
            shezhi.Visibility = Visibility.Hidden;
        }
#endregion
        private void closetwin_Click(object sender, RoutedEventArgs e)
        {
            setwin.Visibility = Visibility.Hidden;
        }
        #endregion
        #region 应用
        void appwinshow(Grid target)
        {
            project.Visibility = Visibility.Hidden;
            apps.Visibility = Visibility.Hidden;
            shop.Visibility = Visibility.Hidden;
            license.Visibility = Visibility.Hidden;
            target.Visibility = Visibility.Visible;
        }

        private void showprowin_Click(object sender, RoutedEventArgs e)
        {
            appwinshow(project);
        }

        private void showappwin_Click(object sender, RoutedEventArgs e)
        {
            appwinshow(apps);
        }

        private void showshowin_Click(object sender, RoutedEventArgs e)
        {
            appwinshow(shop);
        }

        private void showlicwin_Click(object sender, RoutedEventArgs e)
        {
            appwinshow(license);
        }

        private void cloappwin_Click(object sender, RoutedEventArgs e)
        {
            appwin.Visibility = Visibility.Hidden;
        }
        #endregion

        #region 账户
        #endregion

        #region 启示云
        #endregion

        private void links_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                Button but = new Button()
                {
                    Content = file,
                    Width = 65,
                    Height = 30
                };
                links.Children.Add(but);
            }
        }

        private void Sainfo(object sender, RoutedEventArgs e)
        {
            Accwin_Clear();
            accInformation.Visibility = Visibility.Visible;
        }

        private void Sawallet(object sender, RoutedEventArgs e)
        {
            Accwin_Clear();
            accWallet.Visibility = Visibility.Visible;
        }

        private void Sahistory(object sender, RoutedEventArgs e)
        {
            Accwin_Clear();
            accHistory.Visibility = Visibility.Visible;
        }

        private void Safavo(object sender, RoutedEventArgs e)
        {
            Accwin_Clear();
            accFavorites.Visibility = Visibility.Visible;
        }

        private void Saoptain(object sender, RoutedEventArgs e)
        {
            Accwin_Clear();
            accOptains.Visibility = Visibility.Visible;
        }

        private void Accwin_Clear()
        {
            accInformation.Visibility = Visibility.Hidden;
            accWallet.Visibility = Visibility.Hidden;
            accHistory.Visibility = Visibility.Hidden;
            accFavorites.Visibility = Visibility.Hidden;
            accOptains.Visibility = Visibility.Hidden;
        }
    }
}
