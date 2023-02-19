using KitX.Core;
using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Algorithm_List
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IContract))]
    public partial class MainWindow : Window, IContract
    {
        public MainWindow()
        {
            InitializeComponent();
            win = this;
            Closed += (x, y) =>
            {
                started = false;
            };
            sortAlgPart.win = this;

            Loaded += (x, y) =>
            {
                Cataloger.PreviewMouseWheel += (sender, e) =>
                {
                    var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                    {
                        RoutedEvent = UIElement.MouseWheelEvent,
                        Source = sender
                    };
                    Cataloger.RaiseEvent(eventArg);
                };
            };

            SizeChanged += (x, y) =>
            {
                list.MaxWidth = Width - leftList.ActualWidth - 40;
            };
            StateChanged += (x, y) =>
            {
                if (WindowState == WindowState.Maximized)
                {
                    new Thread(() =>
                    {
                        Thread.Sleep(200);
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            list.BeginAnimation(MaxWidthProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(
                                new TimeSpan(0, 0, 0, 0, 300), list.ActualWidth, SystemParameters.WorkArea.Width - leftList.ActualWidth - 40,
                                System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic,
                                System.Windows.Media.Animation.EasingMode.EaseIn, 0, 0));
                        }));
                    }).Start();
                }
                else
                {
                    list.MaxWidth = Width - leftList.ActualWidth - 40;
                }
            };
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Bitmap bmp = PopEye.WPF.Helper.GetImageFromControl.ToBitmap((sender as FrameworkElement).Parent as FrameworkElement);
            BitmapSource bmpResource = PopEye.WPF.Helper.ImageWork.getBitMapSourceFromBitmap(bmp);
            try
            {
                Clipboard.SetImage(bmpResource);
                HandyControl.Controls.Growl.Success("多元一次解方程截图已复制到剪切板");
            }
            catch
            {
                HandyControl.Controls.Growl.Warning("复制截图失败");
            }
        }

        #region 接口实现
        public string WorkBase = null;

        public void SetWorkBase(string path)
        {
            WorkBase = path;
            if (!Directory.Exists(WorkBase))
            {
                Directory.CreateDirectory(WorkBase);
            }
        }

        public string GetDescribe_Complex() => "收录各种简单算法源码以及 Demo 页面，本地预览算法效果，包括对算法的效率测试。";

        public string GetDescribe_Simple() => "简单算法总集";

        public string GetFileName() => "Algorithm List.dll";

        public string GetHelpLink() => "https://docs.catrol.cn/kitxplugins/Algorithm%20List/";

        public string GetHostLink() => "https://blog.catrol.cn/";

        public BitmapImage GetIcon() => FindResource("Icon") as BitmapImage;

        public Languages GetLang() => Languages.zh_CN;

        public string GetName() => "Algorithm List";

        public string GetPublisher() => "Catrol";

        public string GetVersion() => "v1.1.5";

        public Window GetWindow() => new MainWindow();

        public void SetTheme(Theme theme)
        {

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
                win.Show();
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

        public Tags GetTag() => Tags.Program;
        #endregion

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                string to = ((sender as TreeView).SelectedItem as TreeViewItem).Tag.ToString();
                if (to != string.Empty)
                {
                    SlideList(FindName(to) as FrameworkElement);
                }
            }
            catch (Exception)
            {

            }
        }

        private void SlideList(FrameworkElement target)
        {
            var currentScrollPosition = list.VerticalOffset;
            var point = new System.Windows.Point(0, currentScrollPosition);
            var targetPosition = target.TransformToVisual(list).Transform(point);
            list.ScrollToVerticalOffset(targetPosition.Y);
        }

        private void OpenLink(object sender, RoutedEventArgs e) => OpenLink((sender as FrameworkElement).Tag.ToString());

        private void OpenLink(string link)
        {
            switch (link)
            {
                default:
                    break;
            }
        }
    }
}
