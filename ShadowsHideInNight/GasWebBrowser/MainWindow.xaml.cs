using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Forms;
using WebBrowser = System.Windows.Controls.WebBrowser;

namespace GasWebBrowser
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public string HomePageUri = "http://www.baidu.com";
        public double ItemsMostWidth = 80.0;
        public MainWindow()
        {
            InitializeComponent();
            FunDoc.Visibility = Visibility.Hidden;
            HomePageUri = ConfigurationManager.AppSettings["HomePath"].ToString();
            ItemsMostWidth = double.Parse(ConfigurationManager.AppSettings["ItemMostWidth"]);
            object sender = null;
            RoutedEventArgs e = null;
            AddPage_Click(sender, e);
            Navigater.GotFocus += (x, y) =>
            {
                Navigate.Opacity = 1;
                Navigate.BorderThickness = new Thickness(2, 2, 2, 2);
                Navigater.SelectAll();
            };
            Navigater.LostFocus += (x, y) =>
            {
                Navigate.Opacity = 1;
                Navigate.BorderThickness = new Thickness(0, 0, 0, 0);
            };
            Navigate.MouseDown += (x, y) => { Navigater.Focus(); };
            Navigate.MouseEnter += (x, y) => { Navigate.Opacity = 0.8; };
            Navigate.MouseLeave += (x, y) => { Navigate.Opacity = 1; };
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                }
                DragMove();
            }
            catch
            {

            }
        }

        private void ToMostSmall_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ToBigAndSmall_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                ToBigAndSmall.Content = "";
            }
            else
            {
                WindowState = WindowState.Maximized;
                ToBigAndSmall.Content = "";
            }
        }

        private void ToClose_Click(object sender, RoutedEventArgs e)
        {
            Docker.Items.Clear();
            Close();
            Environment.Exit(0);
        }

        private void AddPage_Click(object sender, RoutedEventArgs e)
        {
            AddOnePage(HomePageUri);
            Navigater.Text = HomePageUri;
        }

        private void AddOnePage(string uri)
        {
            var myResourceDictionary = new ResourceDictionary
            {
                Source = new Uri("/GasWebBrowser;component/DictionaryOfTabControlAndTabItem.xaml", UriKind.RelativeOrAbsolute) // 指定样式文件的路径
            };
            var myItemStyle = myResourceDictionary["TabItemExWithUnderLineStyle"] as Style; // 通过key找到指定的样式
            Color colY = Color.FromArgb(100, 51, 51, 55);
            SolidColorBrush scbY = new SolidColorBrush(colY);
            try
            {
                WebBrowser wb = new WebBrowser()
                {
                    Margin = new Thickness(0.0, 0.0, 0.0, 0.0),
                    Source = new Uri(uri)
                };
                TabItem ti = new TabItem()
                {
                    Style = myItemStyle,
                    FontSize = 16,
                    Height = 40,
                    Visibility = Visibility.Visible,
                    Header = "加载中",
                    Width = ItemsMostWidth,
                    Background = scbY,
                    BorderThickness = new Thickness(0, 0, 0, 0),
                    Foreground = Brushes.White
                };
                ti.MouseRightButtonDown += (x, y) =>
                {
                    Docker.Items.Remove(ti);
                    if (Docker.Items.Count == 0)
                    {
                        AddOnePage(HomePageUri);
                    }
                };
                ti.KeyDown += (x, y) =>
                {
                    if (y.Key == Key.F11)
                    {
                        try
                        {
                            Form fs = new Form();
                            System.Windows.Forms.WebBrowser fwb = new System.Windows.Forms.WebBrowser();
                            fs.WindowState = FormWindowState.Maximized;
                            fs.ShowInTaskbar = false;
                            fs.ShowIcon = false;
                            fs.FormBorderStyle = FormBorderStyle.None;
                            fs.KeyDown += (m, n) =>
                            {
                                if (n.KeyCode == Keys.F11 || n.KeyCode == Keys.Escape)
                                {
                                    fs.Close();
                                }
                            };
                            fwb.PreviewKeyDown += (m, n) =>
                            {
                                if (n.KeyCode == Keys.F11 || n.KeyCode == Keys.Escape)
                                {
                                    fs.Close();
                                }
                            };
                            fwb.Url = wb.Source;
                            fwb.Dock = DockStyle.Fill;
                            fs.Controls.Add(fwb);
                            fs.Show();
                        }
                        catch
                        {

                        }
                    }
                };
                wb.LoadCompleted += (x, y) =>
                {
                    ti.Header = wb.Document.ToString();
                };
                Docker.SelectionChanged += (x, y) =>
                {
                    foreach (TabItem item in Docker.Items)
                    {
                        if (item.Content == wb)
                        {
                            Navigater.Text = wb.Source.ToString();
                        }
                    }
                };
                ti.Content = wb;
                Docker.Items.Add(ti);
                ti.IsSelected = true;
                LastPath.Click += (x, y) =>
                {
                    try
                    {
                        wb.GoBack();
                        Navigater.Text = wb.Source.ToString();
                    }
                    catch { }
                };
                NextPath.Click += (x, y) =>
                {
                    try
                    {
                        wb.GoForward();
                        Navigater.Text = wb.Source.ToString();
                    }
                    catch { }
                };
                Refresh.Click += (x, y) =>
                {
                    try
                    {
                        wb.Refresh();
                        Navigater.Text = wb.Source.ToString();
                    }
                    catch { }
                };
                HomePage.Click += (x, y) =>
                {
                    try
                    {
                        wb.Source = new Uri(HomePageUri);
                        Navigater.Text = wb.Source.ToString();
                    }
                    catch { }
                };
                Navigater.Text = wb.Source.ToString();
            }
            catch (Exception o)
            {

            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                ToBigAndSmall.Content = "";
            }
            else
            {
                ToBigAndSmall.Content = "";
            }
        }
        
        private void MoreFunction_Click(object sender, RoutedEventArgs e)
        {
            if (FunDoc.Visibility == Visibility.Visible)
            {
                FunDoc.Visibility = Visibility.Hidden;
            }
            else
            {
                FunDoc.Visibility = Visibility.Visible;
            }
        }

        private void FixAllScreen_Click(object sender, RoutedEventArgs e)
        {
            Docker.Focus();
            SendKeys.Send(Keys.F11.ToString());
        }

        private void Navigater_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddOnePage(Navigater.Text);
            }
        }
    }
}
