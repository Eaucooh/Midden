using KitX.Core;
using System.ComponentModel.Composition;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Catrol.AvoidSleep
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

        public string GetDescribe_Complex() => "开启或关闭防止系统自动锁屏，自动睡眠的功能，通过定时向系统发送消息实现";

        public string GetDescribe_Simple() => "防锁屏、防睡眠、保持亮屏";

        public string GetFileName() => "Catrol.AvoidSleep.dll";

        public string GetHelpLink() => "https://docs.catrol.cn/kitxplugins/Algorithm%20List/";

        public string GetHostLink() => "https://blog.catrol.cn/";

        public BitmapImage GetIcon() => FindResource("Icon") as BitmapImage;

        public Languages GetLang() => Languages.zh_CN;

        public string GetName() => "Avoid Sleep";

        public string GetPublisher() => "Catrol";

        public string GetVersion() => "v1.1.0";

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

        public Tags GetTag() => Tags.System;
        #endregion

        public bool state = false;

        private void Btn_State_Click(object sender, RoutedEventArgs e)
        {
            if (state)
            {
                state = false;
                (sender as Button).Content = "启用";
                Library.Windows.AvoidSleep.RestoreForCurrentThread();
            }
            else
            {
                state = true;
                (sender as Button).Content = "关闭";
                Library.Windows.AvoidSleep.PreventForCurrentThread(true);
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e) => Title = $"AvoidSleep - {Width} x {Height}";

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            TextBox tb1 = new TextBox()
            {
                MinWidth = 50,
                Margin = new Thickness(5, 0, 5, 0),
                Text = Height.ToString()
            }, tb2 = new TextBox()
            {
                MinWidth = 50,
                Margin = new Thickness(5, 0, 5, 0),
                Text = Width.ToString()
            };
            WrapPanel wr = new WrapPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(10)
            }, wr2 = new WrapPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(10)
            };
            wr2.Children.Add(tb2);
            wr2.Children.Add(new TextBlock()
            {
                Text = "x",
                Margin = new Thickness(5, 0, 5, 0)
            });
            wr2.Children.Add(tb1);
            Button btn_confirm = new Button()
            {
                Content = "确定",
                Margin = new Thickness(5, 0, 5, 0)
            }, btn_cancel = new Button()
            {
                Content = "取消",
                Margin = new Thickness(5, 0, 5, 0),
                Style = (Style)FindResource("MaterialDesignOutlinedButton")
            };
            wr.Children.Add(btn_cancel);
            wr.Children.Add(btn_confirm);
            Grid gr = new Grid();
            gr.Children.Add(wr);
            gr.Children.Add(wr2);
            Window tmp_win = new Window()
            {
                Title = "重设窗口大小",
                Icon = Icon,
                Width = 270,
                Height = 140,
                ResizeMode = ResizeMode.NoResize,
                Content = gr,
                Owner = this,
                Top = Top + 50,
                Left = Left + (Width - 270) / 2
            };
            btn_cancel.Click += (x, y) =>
            {
                tmp_win.Close();
            };
            btn_confirm.Click += (x, y) =>
            {
                double n_width = 0, n_height = 0;
                if(double.TryParse(tb1.Text, out n_height) && double.TryParse(tb2.Text, out n_width))
                {
                    Width = n_width;
                    Height = n_height;
                }
                else
                {
                    MessageBox.Show("请检查数据格式", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                tmp_win.Close();
            };
            tmp_win.ShowDialog();
        }

        private void Btn_Temp_Click(object sender, RoutedEventArgs e) => Library.Windows.AvoidSleep.ResetIdle(true);
    }
}
