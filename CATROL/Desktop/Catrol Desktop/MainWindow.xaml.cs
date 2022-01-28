using ape_UI.Animation;
using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Catrol_Desktop
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly string WorkBase = AppDomain.CurrentDomain.BaseDirectory;
        readonly string Path_Images = $"{AppDomain.CurrentDomain.BaseDirectory}\\Temp\\Images\\";

        readonly Delivery delivery;
        readonly BasicHelper basicHelper = new BasicHelper();
        readonly ape_System.Files files = new ape_System.Files();
        readonly ape_System.Mouse mouse = new ape_System.Mouse();

        #region DoubleAnimation 创建动画实例

        readonly DoubleAnimation Chrome_FadeIn;
        readonly DoubleAnimation Chrome_FadeOut;
        readonly DoubleAnimation Chrome_Navigater_Expand;
        readonly DoubleAnimation Chrome_Navigater_Shrink;
        readonly DoubleAnimation Chrome_Navigater_MissionList_SearchBar_Holder_Expand;
        readonly DoubleAnimation Chrome_Navigater_MissionList_SearchBar_Holder_Shrink;
        readonly DoubleAnimation Chrome_Navigater_MissionList_SearchBar_Holder_FadeIn;
        readonly DoubleAnimation Chrome_Navigater_MissionList_SearchBar_Holder_FadeOut;

        readonly ThicknessAnimation Frame_Expand;
        readonly ThicknessAnimation Frame_Shrink;

        readonly ColorAnimation Frame_FadeIn;
        readonly ColorAnimation Frame_FadeOut;

        WindowState tempState = WindowState.Normal;

        #endregion

        public MainWindow()
        {
            delivery = new Delivery(/*$"{WorkBase}\\Info_MainWindow.config"*/);

            InitializeComponent();

            Top = delivery.LastLocation_Top;
            Left = delivery.LastLocation_Left;
            Width = delivery.Width;
            Height = delivery.Height;
            Chrome_Minimizer.Click += Chrome_Minimizer_Click;
            Chrome_MaximizerOrRestorer.Click += Chrome_MaximizerOrRestorer_Click;
            Chrome_Closer.Click += Chrome_Closer_Click;
            SizeChanged += MainWindow_SizeChanged;
            Closed += MainWindow_Closed;

            #region DoubleAnimation 动画赋值

            Chrome_FadeIn = basicHelper.CreateDoubleAnimation(new TimeSpan(0, 0, 0, 0, 750), delivery.Chrome_Opacity_Minimize,
                delivery.Chrome_Opacity_Maximize, FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);
            Chrome_FadeOut = basicHelper.CreateDoubleAnimation(new TimeSpan(0, 0, 0, 0, 750), delivery.Chrome_Opacity_Maximize,
                delivery.Chrome_Opacity_Minimize, FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);

            Chrome_Navigater_Expand = basicHelper.CreateDoubleAnimation(new TimeSpan(0, 0, 0, 0, 500), delivery.Chorme_Navigater_Width_Maximize,
                delivery.Chorme_Navigater_Width_Minimize, FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);
            Chrome_Navigater_Shrink = basicHelper.CreateDoubleAnimation(new TimeSpan(0, 0, 0, 0, 500), delivery.Chorme_Navigater_Width_Minimize,
                delivery.Chorme_Navigater_Width_Maximize, FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);

            Chrome_Navigater_MissionList_SearchBar_Holder_Expand = basicHelper.CreateDoubleAnimation(new TimeSpan(0, 0, 0, 0, 500), delivery.Chrome_Navigater_MissionList_SearchBar_Holder_Height_Minimize,
                delivery.Chrome_Navigater_MissionList_SearchBar_Holder_Height_Maximize, FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);
            Chrome_Navigater_MissionList_SearchBar_Holder_Shrink = basicHelper.CreateDoubleAnimation(new TimeSpan(0, 0, 0, 0, 500), delivery.Chrome_Navigater_MissionList_SearchBar_Holder_Height_Maximize,
                delivery.Chrome_Navigater_MissionList_SearchBar_Holder_Height_Minimize, FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);

            Chrome_Navigater_MissionList_SearchBar_Holder_FadeIn = basicHelper.CreateDoubleAnimation(new TimeSpan(0, 0, 0, 0, 500), 0, 1, FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);
            Chrome_Navigater_MissionList_SearchBar_Holder_FadeOut = basicHelper.CreateDoubleAnimation(new TimeSpan(0, 0, 0, 0, 500), 1, 0, FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);

            Frame_Expand = basicHelper.CreateThicknessAnimation(TimeSpan.FromMilliseconds(500), new Thickness(20), new Thickness(0),
                FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);
            Frame_Shrink = basicHelper.CreateThicknessAnimation(TimeSpan.FromMilliseconds(500), new Thickness(0), new Thickness(20),
                FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);

            Frame_FadeIn = basicHelper.CreateColorAnimation(TimeSpan.FromSeconds(1), Color.FromArgb(0, 255, 255, 255), Color.FromArgb(100, 0, 0, 0), FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);
            Frame_FadeOut = basicHelper.CreateColorAnimation(TimeSpan.FromSeconds(1), Color.FromArgb(100, 0, 0, 0), Color.FromArgb(0, 255, 255, 255), FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);

            #endregion

            Chrome_Navigater_Expand.Completed += Chrome_Navigater_Animation_Completed;
            Chrome_Navigater_Shrink.Completed += Chrome_Navigater_Animation_Completed;
            Chrome_Navigater.MouseEnter += Chrome_Navigater_MouseEnter;
            Chrome_Navigater.MouseLeave += Chrome_Navigater_MouseLeave;
            Personalizer.Click += Personalizer_Click;
            GoMessageWin.Click += GoMessageWin_Click;

            Chrome_FadeOut.Completed += (x, y) =>
            {
                MinimizeOrClose();
            };

            PersonalizePopupBox.IsOpen = false;
            MessagePopupBox.IsOpen = false;

            Loaded += (x, y) =>
            {
                FadeIn_Chrome();
            };
            UI_Language_Selecter.SelectionChanged += UI_Language_Selecter_SelectionChanged;

            //MouseMove += MainWindow_MouseMove;
            for (int i = 0; i < 20; i++)
            {
                Messages_Holder.Children.Add(new MessageListItem(i.ToString(), "Hello", 14, 12, 17, "https://is1-ssl.mzstatic.com/image/thumb/Purple124/v4/cb/2b/0e/cb2b0ee8-2869-ea58-3a14-719aeab468c7/AppIcon-0-0-1x_U007emarketing-0-0-0-8-0-0-85-220.png/128x128bb-80.jpg"));
            }

            Web_Define();

            StateChanged += (x, y) =>
            {
                if (WindowState == WindowState.Normal && tempState == WindowState.Minimized)
                {
                    FadeIn_Chrome();
                }
                tempState = WindowState;
            };
        }

        private void ViewMessagesInWeb_Click(object sender, RoutedEventArgs e)
        {
            Web_DoExpand();
            Web_Create("https://www.bilibili.com");
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            if (Directory.Exists(Path_Images))
            {
                files.Directory_Clear(Path_Images);
            }
        }

        private void UI_Language_Selecter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string langName;
            switch (UI_Language_Selecter.SelectedIndex)
            {
                case 0:
                    langName = "zh-CN";
                    break;
                case 1:
                    langName = "en-US";
                    break;
                case 2:
                    langName = "ja-JP";
                    break;
                default:
                    langName = "defaultLang";
                    break;
            }

            ResourceDictionary langRd = null;
            try
            {
                //根据名字载入语言文件
                langRd = Application.LoadComponent(new Uri(@"Lang\" + langName + ".xaml", UriKind.Relative)) as ResourceDictionary;
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }

            if (langRd != null)
            {
                //如果已使用其他语言,先清空
                if (Resources.MergedDictionaries.Count > 0)
                {
                    Resources.MergedDictionaries.Clear();
                }
                Resources.MergedDictionaries.Add(langRd);
            }
            else
            {
                MessageBox.Show("Please selected one Language first.");
            }
        }

        private void GoMessageWin_Click(object sender, RoutedEventArgs e)
        {
            MessagePopupBox.IsOpen = false;
            MessagePopupBox.IsOpen = true;
        }

        private void Personalizer_Click(object sender, RoutedEventArgs e)
        {
            PersonalizePopupBox.IsOpen = false;
            PersonalizePopupBox.IsOpen = true;
        }

        private void FadeIn_Chrome()
        {
            BeginAnimation(OpacityProperty, Chrome_FadeIn);
        }

        private void FadeOut_Chrome()
        {
            delivery.LastLocation_Top = Top;
            delivery.LastLocation_Left = Left;
            delivery.Width = Width;
            delivery.Height = Height;
            delivery.Dispose();
            BeginAnimation(OpacityProperty, Chrome_FadeOut);
        }

        private void MinimizeOrClose()
        {
            //Delegate[] dels = Chrome_FadeOut.Completed.GetMethodInfo();
            //foreach (var d in dels)
            //{
            //    Chrome_FadeOut.Completed -= d as EventHandler;
            //}
            if (delivery.IsCloserToClose)
            {
                Close();
            }
            else
            {
                WindowState = WindowState.Minimized;
            }
        }

        private void Chrome_Navigater_Animation_Completed(object sender, EventArgs e)
        {
            Chrome_Navigater_Animation_IsEnable = true;
            Chrome_Navigater_Animation_IsExpanding = false;
        }

        bool Chrome_Navigater_Animation_IsEnable = true;
        bool Chrome_Navigater_Animation_IsExpanding = false;

        private void Chrome_Navigater_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Chrome_Navigater_Animation_IsEnable || Chrome_Navigater_Animation_IsExpanding)
            {
                Chrome_Navigater.BeginAnimation(WidthProperty, Chrome_Navigater_Expand);
                Chrome_Navigater_Animation_IsEnable = false;
                Chrome_Navigater_Animation_IsExpanding = false;
                Chrome_Navigater_MissionList_SearchBar_Holder.BeginAnimation(HeightProperty, Chrome_Navigater_MissionList_SearchBar_Holder_Shrink);
                Chrome_Navigater_MissionList_SearchBar_Holder.BeginAnimation(OpacityProperty, Chrome_Navigater_MissionList_SearchBar_Holder_FadeOut);
            }
        }

        private void Chrome_Navigater_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Chrome_Navigater_Animation_IsEnable || !Chrome_Navigater_Animation_IsExpanding)
            {
                Chrome_Navigater.BeginAnimation(WidthProperty, Chrome_Navigater_Shrink);
                Chrome_Navigater_Animation_IsEnable = false;
                Chrome_Navigater_Animation_IsExpanding = true;
                Chrome_Navigater_MissionList_SearchBar_Holder.BeginAnimation(HeightProperty, Chrome_Navigater_MissionList_SearchBar_Holder_Expand);
                Chrome_Navigater_MissionList_SearchBar_Holder.BeginAnimation(OpacityProperty, Chrome_Navigater_MissionList_SearchBar_Holder_FadeIn);
            }
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState.Equals(WindowState.Normal))
            {
                Chrome_MaximizerOrRestorer.Content = delivery.Maximizer_Content;
            }
            else
            {
                Chrome_MaximizerOrRestorer.Content = delivery.Restorer_Content;
            }
        }

        private void Chrome_Closer_Click(object sender, RoutedEventArgs e)
        {
            delivery.IsCloserToClose = true;
            FadeOut_Chrome();
        }

        private void Chrome_MaximizerOrRestorer_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState.Equals(WindowState.Normal))
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void Chrome_Minimizer_Click(object sender, RoutedEventArgs e)
        {
            delivery.IsCloserToClose = false;
            FadeOut_Chrome();
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState.Equals(MouseButtonState.Pressed))
            {
                DragMove();
            }
        }

        #region 2D人物跟随动画
        //double k;

        //private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        //{
        //    //获取三者坐标配【鼠标， 眼睛， 眼球中心】
        //    //鼠标 (p.X, p.Y)
        //    //眼睛 (position_eye.X, position_eye.Y)
        //    //眼球中心 (position_center.X, position_center.Y)
        //    System.Drawing.Point p = mouse.GetCursorPosition_ReturnPoint();
        //    Point position_eye = Character_Eye.PointToScreen(new Point(0d, 0d));
        //    Point position_center = Character_Eye_Center.PointToScreen(new Point(0d, 0d));
        //    Point position_canvas = Character_Holder.PointToScreen(new Point(0d, 0d));

        //    //计算鼠标与眼球中心的表达式// // y = kx + b //
        //    k = Math.Abs(position_center.Y - p.Y) / Math.Abs(position_center.X - p.X);

        //    //计算眼睛与眼球中心的距离// // |P1P2| = √(x1-x2)^ + (y1-y2)^ //
        //    double gap_X = Math.Abs(position_center.X - position_eye.X); //x1-x2//
        //    double gap_Y = Math.Abs(position_center.Y - position_eye.Y); //y1-y2//
        //    double distance = Math.Abs(Math.Sqrt((gap_X * gap_X) + (gap_Y * gap_Y))); //距离//

        //    #region 计算眼睛坐标

        //    // 设P点坐标// // (X, (y-b)/k) //
        //    // 计算眼睛与眼球中心的距离// // |P1P2| = √(x1-x2)^ + (y1-y2)^ //
        //    // 求解X，思路： | P~poisition_center | = distance //

        //    double X = Math.Sqrt((distance * distance) / ((1 + k) * (1 + k)));
        //    double Y = k * X;

        //    #endregion

        //    //MessageBox.Show($"k:{k}; b:{b};\n原: ({position_eye.X}, {position_eye.Y})\n现：({X},{Y})");

        //    //设定眼睛坐标
        //    if (X < 0)
        //    {
        //        Canvas.SetLeft(Character_Eye, position_center.X - position_canvas.X - X);
        //    }
        //    if (X > 0)
        //    {
        //        Canvas.SetLeft(Character_Eye, position_center.X + X);
        //    }

        //    if (Y < 0)
        //    {
        //        Canvas.SetTop(Character_Eye, position_center.Y + Y);
        //    }
        //    if (Y > 0)
        //    {
        //        Canvas.SetTop(Character_Eye, position_center.Y - position_canvas.Y - Y);
        //    }
        //    //Canvas.SetLeft(Character_Eye, X - position_canvas.X);
        //    //Canvas.SetTop(Character_Eye, Y - position_canvas.Y);
        //}
        #endregion

        #region Web的控制模块

        private void Web_Define()
        {
            ViewMessagesInWeb.Click += ViewMessagesInWeb_Click;
            Web_Expander.Click += (x, y) =>
            {
                Web_DoExpand();
            };
            Web_GoBacker.Click += (x, y) =>
            {
                if (web.CanGoBack)
                {
                    web.Back();
                }
            };
            Web_GoForwarder.Click += (x, y) =>
            {
                if (web.CanGoForward)
                {
                    web.Forward();
                }
            };
            Web_Refresher.Click += (x, y) =>
            {
                web.Load(web.Address);
            };
            web.Loaded += (x, y) =>
            {
                Web_Title.Content = web.Title;
            };
            Web_Shrinker.Click += (x, y) =>
            {
                Web_DoShrink();
            };
            Web_Clearer.Click += (x, y) =>
            {
                web.Dispose();
                Web_DoShrink();
            };
        }

        private bool IsExpandDoing = false;
        private bool IsShrinkDoing = false;

        DoubleAnimation Web_Expand;
        DoubleAnimation Web_Shrink;
        readonly SolidColorBrush color = new SolidColorBrush();

        private void Web_DoExpand()
        {
            Web_Expand = basicHelper.CreateDoubleAnimation(TimeSpan.FromMilliseconds(800), 0, Height - 40 - 50, FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);
            Web_Expand.Completed += (x, y) =>
            {
                IsExpandDoing = false;
                web.Visibility = Visibility.Visible;
            };
            if (!IsShrinkDoing && !IsExpandDoing)
            {
                Web_Holder_Container.BeginAnimation(HeightProperty, Web_Expand);
                Frame.BeginAnimation(MarginProperty, Frame_Shrink);
                Frame.Background = color;
                color.BeginAnimation(SolidColorBrush.ColorProperty, Frame_FadeIn);
                //Frame.BeginAnimation(BackgroundProperty, Frame_FadeIn);
                IsExpandDoing = true;
            }
        }

        bool IsTempAddressStored = false;
        string TempAddress;

        private void Web_DoShrink()
        {
            Web_Shrink = basicHelper.CreateDoubleAnimation(TimeSpan.FromMilliseconds(800), Web_Holder_Container.Height, 0, FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);
            Web_Shrink.Completed += (x, y) =>
            {
                IsShrinkDoing = false;
            };
            if (!IsShrinkDoing && !IsExpandDoing)
            {
                Web_Holder_Container.BeginAnimation(HeightProperty, Web_Shrink);
                Frame.BeginAnimation(MarginProperty, Frame_Expand);
                Frame.Background = color;
                color.BeginAnimation(SolidColorBrush.ColorProperty, Frame_FadeOut);
                //Frame.BeginAnimation(BackgroundProperty, Frame_FadeOut);
                IsShrinkDoing = true;
                web.Visibility = Visibility.Hidden;
            }
        }

        ChromiumWebBrowser web = new ChromiumWebBrowser();
        CefSettings cef;

        private void Web_Create(string uri)
        {
            //string cachePath = $"{WorkBase}\\Temp\\Cache\\";
            //cef = new CefSettings()
            //{
            //    CachePath = cachePath
            //};
            //cef.PersistSessionCookies = true;
            //cef.CefCommandLineArgs.Add("ppapi-flash-path", $"{WorkBase}\\Plugins\\pepflashplayer.dll");
            //Cef.Initialize(cef);
            web = new ChromiumWebBrowser()
            {
                AllowDrop = true,
                Address = uri,
                Visibility = Visibility.Hidden
            };
            web.LifeSpanHandler = new OpenPageSelf();
            web.PreviewTextInput += (x, y) =>
            {
                foreach (var character in y.Text)
                {
                    // 把每个字符向浏览器组件发送一遍
                    web.GetBrowser().GetHost().SendKeyEvent(0, character, 0);
                }

                // 不让cef自己处理
                y.Handled = true;
            };
            Web_Holder.Child = web;
            Web_Title.Content = web.Title;
        }

        #endregion
    }

    /// <summary>
    /// 在自己窗口打开链接
    /// </summary>
    internal class OpenPageSelf : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition,
            bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            var chromiumWebBrowser = (CefSharp.Wpf.ChromiumWebBrowser)browserControl;
            chromiumWebBrowser.Load(targetUrl);
            return true; //Return true to cancel the popup creation copyright by codebye.com.
        }
    }
}
