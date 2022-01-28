using CefSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;
using Point = System.Windows.Point;
using UI = Panuon.UI.Silver;

namespace Center
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : UI.WindowX
    {
        public string WorkBase = AppDomain.CurrentDomain.BaseDirectory;
        public bool IsSigned = true;

        public object fobuo = null;
        public RoutedEventArgs fobur = null;

        public MainWindow()
        {
            InitializeComponent();
            Target(host);
            NotiIcon icon = new NotiIcon();
            icon.NewIcon(this);
            menu.Visibility = Visibility.Visible;
            if(!IsConected("183.232.231.174", 2000))
            {
                UI.Notice.Show("无网络连接，除本地功能外，其余功能不可用", "错误", 3.0, UI.MessageBoxIcon.Warning);
            }
            Showmenu_Click(fobuo, fobur);
            WinMode.SelectionChanged += (n, b) =>
            {
                switch (WinMode.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        Working ww = new Working();
                        Hide();
                        ww.Closing += (c, l) =>
                        {
                            WinMode.SelectedIndex = 0;
                            Show();
                            BackToThisMode();
                        };
                        ww.Show();
                        UI.Notice.Show("全屏工作模式已经启用，退出该模式会退回正常屏幕模式\n双击托盘图标也能返回主窗口", "提示", 3, UI.MessageBoxIcon.Info);
                        break;
                    case 2:
                        MiniWin mw = new MiniWin();
                        Hide();
                        mw.Closing += (c, l) =>
                          {
                              WinMode.SelectedIndex = 0;
                              Show();
                              BackToThisMode();
                          };
                        mw.Show();
                        UI.Notice.Show("小屏幕模式已经启用，退出该模式会退回正常屏幕模式\n双击托盘图标也能返回主窗口", "提示", 3, UI.MessageBoxIcon.Info);
                        break;
                    default:
                        break;
                }
            };
            Closing += (u, i) =>
              {
                  i.Cancel = true;
                  Visibility = Visibility.Hidden;
                  UI.Notice.Show("已经最小化到托盘\n要完全退出程序请右击托盘图标", "提示", 3, UI.MessageBoxIcon.Info);
              };
        }

        void BackToThisMode()
        {
            UI.Notice.Show("已经退回到正常屏幕模式", "提示", 3, UI.MessageBoxIcon.Info);
        }

        private void Target(Grid win)
        {
            DispatcherTimer dt = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMilliseconds(300)
            };
            dt.Tick += (x, y) =>
            {
                host.Visibility = Visibility.Hidden;
                libwin.Visibility = Visibility.Hidden;
                stowin.Visibility = Visibility.Hidden;
                accwin.Visibility = Visibility.Hidden;
                setwin.Visibility = Visibility.Hidden;
                win.Visibility = Visibility.Visible;
                if (win != host)
                {
                    Topbar.Visibility = Visibility.Visible;
                    if (win == libwin)
                    {
                        pagename.Content = "库";
                    }
                    if (win == stowin)
                    {
                        pagename.Content = "莫伊商城";
                    }
                    if (win == accwin)
                    {
                        pagename.Content = "用户中心";
                    }
                    if (win == setwin)
                    {
                        pagename.Content = "设置";
                    }
                }
                else
                {
                    Topbar.Visibility = Visibility.Hidden;
                    pagename.Content = "";
                }
                dt.Stop();
            };
            dt.Start();
        }

        private void Lib(object sender, RoutedEventArgs e)
        {
            Target(libwin);
        }

        private void Store(object sender, RoutedEventArgs e)
        {
            Target(stowin);
        }

        private void Account(object sender, RoutedEventArgs e)
        {
            Target(accwin);
        }

        private void Setting(object sender, RoutedEventArgs e)
        {
            Target(setwin);
        }

        private void GoHome(object sender, RoutedEventArgs e)
        {
            Target(host);
        }

        private void Themes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Themes.SelectedIndex;
            ChangeTheme(index);
        }

        private bool IsConected(string target, int waitTime)
        {
            try
            {
                System.Net.NetworkInformation.Ping objPingSender = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingOptions objPinOptions = new System.Net.NetworkInformation.PingOptions
                {
                    DontFragment = true
                };
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                System.Net.NetworkInformation.PingReply objPinReply = objPingSender.Send(target, waitTime, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void ChangeTheme(int target)
        {
            string[] Theme = new string[10];
            Theme[0] = "#C1C1C3";
            Theme[1] = "#141425";
            Theme[2] = "#FFFFFF";
            Theme[3] = "#000000";
            Theme[4] = "#F44336";
            Theme[5] = "#9C27B0";
            Theme[6] = "#7BB33A";
            Theme[7] = "#FFB007";
            Theme[8] = "#E36888";
            Theme[9] = "#007ACC";
            Resources.Remove("PrimaryHueMidBrush");
            Resources.Add("PrimaryHueMidBrush", new SolidColorBrush((Color)ColorConverter.ConvertFromString(Theme[target])));
        }

        private void Accbr_Loaded(object sender, RoutedEventArgs e)
        {
            accbr.LifeSpanHandler = new OpenPageSelf();
        }

        private void AccBack(object sender, RoutedEventArgs e)
        {
            accbr.Back();
        }

        private void AccRedo(object sender, RoutedEventArgs e)
        {
            accbr.Forward();

        }

        private void AccRego(object sender, RoutedEventArgs e)
        {
            accbr.Reload();
        }

        private void AccHome(object sender, RoutedEventArgs e)
        {
            accbr.Address = "http://Account.Itmooth.com/";
        }

        private void Showmenu_Click(object sender, RoutedEventArgs e)
        {
            if (menu.Visibility == Visibility.Visible)
            {
                showmenu.Content = "";
                menu.Visibility = Visibility.Hidden;
            }
            else
            {
                showmenu.Content = "";
                menu.Visibility = Visibility.Visible;
            }
        }

        #region 库界面加载

        private void ShowApps_Click(object sender, RoutedEventArgs e)
        {
            lib.Children.Clear();
            string target = WorkBase + @"\Conf\aip.txt";
            if (File.Exists(target))
            {
                string path = GetFileValue(target);
                if (path != null && path != "")
                {
                    DirectoryInfo info = new DirectoryInfo(path);
                    foreach (DirectoryInfo NextFolder in info.GetDirectories())
                    {
                        Card card = new Card()
                        {
                            title = NextFolder.Name,
                            imgUri = NextFolder.FullName + @"\cover.jpg"
                        };
                        lib.Children.Add(card);
                    }
                }
                else
                {
                    if (UI.MessageBoxX.Show("应用安装目录未配置，是否选择一个应用默认安装路径", "提示", this, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        FolderBrowserDialog pc = new FolderBrowserDialog()
                        {
                            ShowNewFolderButton = true,
                            Description = "选择应用默认安装路径",
                            RootFolder = Environment.SpecialFolder.MyComputer
                        };
                        pc.ShowDialog();
                        if (!WriteIntoFile(target, pc.SelectedPath))
                        {
                            UI.MessageBoxX.Show("应用安装目录配置失败", "错误", this, MessageBoxButton.OK);
                        }
                        pc.Dispose();
                    }
                }
            }
            else
            {
                UI.MessageBoxX.Show("应用安装目录配置文件丢失，请选择一个应用默认安装路径", "错误", this, MessageBoxButton.OK);
            }
        }

        private void ShowServices_Click(object sender, RoutedEventArgs e)
        {
            if(IsConected("183.232.231.174",10000))
            {
                if(IsSigned)
                {
                    UI.Notice.Show("正在为您准备内容，准备好大吃一惊吧！", "加载中", 3, UI.MessageBoxIcon.Info);
                }
                else
                {
                    UI.Notice.Show("您还未登陆，已经跳转到用户中心", "提示", 3, UI.MessageBoxIcon.Warning);
                    Target(accwin);
                }
            }
            else
            {
                UI.Notice.Show("连接到服务器失败，服务视图暂时无法显示", "警告", 3, UI.MessageBoxIcon.Warning);
            }
        }

        private void ShowGames_Click(object sender, RoutedEventArgs e)
        {
            lib.Children.Clear();
            string target = WorkBase + @"\Conf\gip.txt";
            if (File.Exists(target))
            {
                string path = GetFileValue(target);
                if (path != null && path != "")
                {
                    DirectoryInfo info = new DirectoryInfo(path);
                    foreach (DirectoryInfo NextFolder in info.GetDirectories())
                    {
                        Card card = new Card()
                        {
                            title = NextFolder.Name,
                            imgUri = NextFolder.FullName + @"\cover.jpg"
                        };
                        card.MouseDown += (q, d) =>
                        {
                            if(d.RightButton == System.Windows.Input.MouseButtonState.Pressed)
                            {
                                Process.Start(NextFolder.FullName + @"\info\index.html");
                            }
                            else
                            {
                                Process.Start(NextFolder.FullName + GetFileValue(NextFolder.FullName + @"\startUp.uri"));
                            }
                        };
                        lib.Children.Add(card);
                    }
                }
                else
                {
                    if (UI.MessageBoxX.Show("游戏安装目录未配置，是否选择一个游戏默认安装路径", "提示", this, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        FolderBrowserDialog pc = new FolderBrowserDialog()
                        {
                            ShowNewFolderButton = true,
                            Description = "选择游戏默认安装路径",
                            RootFolder = Environment.SpecialFolder.MyComputer
                        };
                        pc.ShowDialog();
                        if (!WriteIntoFile(target, pc.SelectedPath))
                        {
                            UI.MessageBoxX.Show("游戏安装目录配置失败", "错误", this, MessageBoxButton.OK);
                        }
                        pc.Dispose();
                    }
                }
            }
            else
            {
                UI.MessageBoxX.Show("游戏安装目录配置文件丢失，请选择一个游戏默认安装路径", "错误", this, MessageBoxButton.OK);
            }
        }

        private string GetFileValue(string target)
        {
            StreamReader sr = new StreamReader(target);
            string Value = sr.ReadToEnd();
            sr.Close();
            return Value;
        }

        private bool WriteIntoFile(string target, string content)
        {
            try
            {
                FileStream fs = new FileStream(target, FileMode.Open);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(content);
                sw.Flush();
                sw.Close();
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ShowOther_Click(object sender, RoutedEventArgs e)
        {
            if (IsConected("183.232.231.174", 10000))
            {
                if (IsSigned)
                {
                    UI.Notice.Show("正在为您准备内容，准备好大吃一惊吧！", "加载中", 3, UI.MessageBoxIcon.Info);
                }
                else
                {
                    UI.Notice.Show("您还未登陆，已经跳转到用户中心", "提示", 3, UI.MessageBoxIcon.Warning);
                    Target(accwin);
                }
            }
            else
            {
                UI.Notice.Show("连接到服务器失败，其它视图暂时无法显示", "警告", 3, UI.MessageBoxIcon.Warning);
            }
        }

        private void ShowInstalled_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowDownloading_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowOwns_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        private void Normal_Click(object sender, RoutedEventArgs e)
        {
            var currentScrollPosition = SetScroll.VerticalOffset;
            var point = new Point(0, currentScrollPosition);
            var targetPosition = NormalBox.TransformToVisual(SetScroll).Transform(point);
            SetScroll.ScrollToVerticalOffset(targetPosition.Y);
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            var currentScrollPosition = SetScroll.VerticalOffset;
            var point = new Point(0, currentScrollPosition);
            var targetPosition = DownloadBox.TransformToVisual(SetScroll).Transform(point);
            SetScroll.ScrollToVerticalOffset(targetPosition.Y);
        }

        private void Theme_Click(object sender, RoutedEventArgs e)
        {
            var currentScrollPosition = SetScroll.VerticalOffset;
            var point = new Point(0, currentScrollPosition);
            var targetPosition = ThemeBox.TransformToVisual(SetScroll).Transform(point);
            SetScroll.ScrollToVerticalOffset(targetPosition.Y);
        }

        private void Other_Click(object sender, RoutedEventArgs e)
        {
            var currentScrollPosition = SetScroll.VerticalOffset;
            var point = new Point(0, currentScrollPosition);
            var targetPosition = OtherBox.TransformToVisual(SetScroll).Transform(point);
            SetScroll.ScrollToVerticalOffset(targetPosition.Y);
        }

        private void ShowAbout(object sender, RoutedEventArgs e)
        {
            AboutWin aw = new AboutWin();
            aw.ShowDialog();
        }
    }

    /// <summary>
    /// 在自己窗口打开链接
    /// </summary>
    internal class OpenPageSelf : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            try { throw new NotImplementedException(); } catch { return true; }
        }

        public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            throw new NotImplementedException();
        }

        public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            throw new NotImplementedException();
        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl,
            string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture,
            IPopupFeatures popupFeatures,IWindowInfo windowInfo, IBrowserSettings browserSettings,
            ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            var chromiumWebBrowser = (CefSharp.Wpf.ChromiumWebBrowser)browserControl;
            chromiumWebBrowser.Load(targetUrl);
            return true;
        }
    }
}