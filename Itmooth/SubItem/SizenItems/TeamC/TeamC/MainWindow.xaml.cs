using AppTool;
using Panuon.UI.Silver.Core;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Xml;
using pu = Panuon.UI.Silver;

namespace TeamC
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public string WorkBase = AppDomain.CurrentDomain.BaseDirectory;
        public bool IsPlayMusic = true;
        private readonly File file = new File();

        public MainWindow()
        {
            InitializeComponent();
            SetThis();
            ValueEffects();
            GetContacts();
        }

        private void SetThis()
        {
            if (file.ValueReader($"{WorkBase}\\conf\\music.ini").Equals("no"))
            {
                IsPlayMusic = false;
            }
            else
            {
                IsPlayMusic = true;
            }
            if (file.ValueReader($"{WorkBase}\\conf\\contacts.ini").Equals("left"))
            {
                contacts_docker.HorizontalAlignment = HorizontalAlignment.Left;
            }
            else
            {
                contacts_docker.HorizontalAlignment = HorizontalAlignment.Right;
            }
            if (file.ValueReader($"{WorkBase}\\conf\\theme.ini").Equals("dark"))
            {
                theme.SelectedIndex = 1;
            }
            else
            {
                theme.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// tcp客户端
        /// </summary>
        private TcpClient _client;

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SizeChecker();
            DefaultIp();
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                _client.Close();
                _client.Dispose();
            }
            catch
            {

            }
            Environment.Exit(0);
        }

        /// <summary>
        /// 发送按钮点击事件
        /// </summary>
        private void Btn_Send_Click(object sender, RoutedEventArgs e)
        {
            //发送消息至服务器
            string msg = tbx_Message.Text;
            byte[] data = Encoding.UTF8.GetBytes($"{myName.Text.ToString()}：{tbx_Message.Text}");
            try
            {
                Time();
                NetworkStream stream = _client.GetStream();
                stream.Write(data, 0, data.Length);

                Bubble bubble = new Bubble(msg, true);
                goDown.Click += (x, y) =>
                {
                    SlideList(bubble);
                };
                //添加到前端消息列表
                lbx_Messages.Children.Add(bubble);
                //lbx_Messages.Items.Add(string.Format("我:{0}", msg));
            }
            catch (Exception ex)
            {
                pu.MessageBoxX.Show(ex.Message, "错误", this, MessageBoxButton.OK, new MessageBoxXConfigurations
                {
                    MessageBoxIcon = pu.MessageBoxIcon.Error,
                    MessageBoxStyle = pu.MessageBoxStyle.Standard,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                });
            }
            tbx_Message.Text = null;
        }

        private void SlideList(FrameworkElement target)
        {
            var currentScrollPosition = msg_list.VerticalOffset;
            var point = new Point(0, currentScrollPosition);
            var targetPosition = target.TransformToVisual(msg_list).Transform(point);
            msg_list.ScrollToVerticalOffset(targetPosition.Y);
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        private void ReciveMessage()
        {
            try
            {
                NetworkStream stream = _client.GetStream();
                while (true)
                {
                    byte[] data = new byte[1024];
                    int length = stream.Read(data, 0, data.Length);
                    if (length > 0)
                    {
                        Time();
                        string msg = Encoding.UTF8.GetString(data, 0, length);

                        //添加到前端消息列表
                        lbx_Messages.Dispatcher.Invoke(() =>
                        {
                            Bubble bubble = new Bubble(msg, false);
                            lbx_Messages.Children.Add(bubble);
                            goDown.Click += (x, y) =>
                              {
                                  SlideList(bubble);
                              };
                            //lbx_Messages.Items.Add(bubble);
                        });

                        if (IsPlayMusic)
                        {
                            MediaPlayer msgMusic = new MediaPlayer();
                            msgMusic.Volume = 100;
                            msgMusic.Open(new Uri($"{WorkBase}\\lib\\msg.wav", UriKind.Absolute));
                            msgMusic.Play();
                            msgMusic.MediaEnded += (x, y) =>
                            {
                                msgMusic.Close();
                            };
                        }
                    }
                    else
                    {
                        pu.MessageBoxX.Show("连接已断开", "错误", this, MessageBoxButton.OK, new MessageBoxXConfigurations
                        {
                            MessageBoxIcon = pu.MessageBoxIcon.Error,
                            MessageBoxStyle = pu.MessageBoxStyle.Standard,
                            WindowStartupLocation = WindowStartupLocation.CenterOwner
                        });
                        btn_Connect.Content = "连接";
                        stream.Dispose();
                        break;
                    }
                }
            }
            catch
            {
                //Read是阻塞方法 程序退出释放资源是会引发异常 不做处理 线程结束
            }
        }

        private void Tip(string content)
        {
            Label time = new Label()
            {
                Content = content,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            switch (theme.SelectedIndex)
            {
                case 0:
                    time.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212121"));
                    break;
                case 1:
                    time.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
                    break;
            }
            theme.SelectionChanged += (x, y) =>
            {
                switch (theme.SelectedIndex)
                {
                    case 0:
                        time.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212121"));
                        break;
                    case 1:
                        time.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
                        break;
                }
            };
            lbx_Messages.Children.Add(time);
        }

        string lastTime;
        int lastMin;

        private void Time()
        {
            string now = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}";
            if (!now.Equals(lastTime))
            {
                if(DateTime.Now.Minute - lastMin >= 1)
                {
                    if (DateTime.Now.Minute < 10)
                    {
                        if (DateTime.Now.Hour < 10)
                        {
                            Tip($"0{DateTime.Now.Hour}:0{DateTime.Now.Minute}");
                        }
                        else
                        {
                            Tip($"{DateTime.Now.Hour}:0{DateTime.Now.Minute}");
                        }
                    }
                    else
                    {
                        Tip(now);
                    }
                    lastTime = now;
                    lastMin = DateTime.Now.Minute;
                }
            }
        }

        private void Btn_Connect_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btn_Connect.Content == "连接")
            {
                //初始化tcp客户端
                _client = new TcpClient();
                try
                {
                    _client.Connect(IPAddress.Parse(target.Text), 10800);
                    Tip($"已连接到主机：{target.Text}");
                }
                catch (Exception ex)
                {
                    pu.MessageBoxX.Show($"连接失败\n{ex.Message}", "错误", this, MessageBoxButton.OK, new MessageBoxXConfigurations
                    {
                        MessageBoxIcon = pu.MessageBoxIcon.Error,
                        MessageBoxStyle = pu.MessageBoxStyle.Standard,
                        WindowStartupLocation = WindowStartupLocation.CenterOwner
                    });
                    btn_Connect.Content = "连接";
                    return;
                }

                //接收消息线程
                Thread reciveMessageThread = new Thread(ReciveMessage);
                reciveMessageThread.Start();

                btn_Connect.Content = "断开";
            }
            else
            {
                _client.Close();
                _client.Dispose();
                btn_Connect.Content = "连接";
                Tip("已断开连接");
            }

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left&&e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Btn_clo_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_small_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Btn_big_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                btn_big.Content = "";
            }
            else
            {
                WindowState = WindowState.Maximized;
                btn_big.Content = "";
            }
        }

        private void SizeChecker()
        {
            if (WindowState == WindowState.Maximized)
            {
                btn_big.Content = "";
            }
            else
            {
                btn_big.Content = "";
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SizeChecker();
        }

        private void ReStoreDefaultIp(object sender, RoutedEventArgs e)
        {
            DefaultIp();
        }

        private void DefaultIp()
        {
            target.Text = file.ValueReader(WorkBase + @"\conf\serve.ini");
        }

        private void ShowAbout(object sender, RoutedEventArgs e)
        {

        }

        private void Privacy(object sender, RoutedEventArgs e)
        {

        }

        private void Dispose_Click(object sender, RoutedEventArgs e)
        {
            lbx_Messages.Children.Clear();
            GC.Collect();
        }

        private void NewClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start($"{WorkBase}\\TeamC.exe");
            }
            catch (Exception opq)
            {
                pu.MessageBoxX.Show($"新建连接失败：\n{opq.Message}", "错误", this, MessageBoxButton.OK, new MessageBoxXConfigurations
                {
                    MessageBoxIcon = pu.MessageBoxIcon.Error,
                    MessageBoxStyle = pu.MessageBoxStyle.Standard,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                });
            }
        }

        private void NetChecker_Click(object sender, RoutedEventArgs e)
        {
            Net net = new Net();
            string target = file.ValueReader(WorkBase + @"\conf\serve.ini");
            if (net.IsWebConected(target, 10))
            {
                pu.MessageBoxX.Show($"网络连接成功", "成功", this, MessageBoxButton.OK, new MessageBoxXConfigurations
                {
                    MessageBoxIcon = pu.MessageBoxIcon.Success,
                    MessageBoxStyle = pu.MessageBoxStyle.Standard,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                });
            }
            else
            {
                pu.MessageBoxX.Show($"检查网络连接失败：\n{net.WebConectionError(target, 1).Message}", "错误", this, MessageBoxButton.OK, new MessageBoxXConfigurations
                {
                    MessageBoxIcon = pu.MessageBoxIcon.Error,
                    MessageBoxStyle = pu.MessageBoxStyle.Standard,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                });
            }
        }

        /*
        private void netSituation_Click(object sender, RoutedEventArgs e)
        {
            Net net = new Net();
            string target = file.ValueReader(WorkBase + @"\conf\serve.ini");
            if (net.IsWebConected(target, 10))
            {
                Window win = new Window()
                {
                    Title = "网络状况",
                    WindowStyle = WindowStyle.ToolWindow,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this,
                    SizeToContent = SizeToContent.WidthAndHeight
                };
            }
            else
            {
                pu.MessageBoxX.Show($"无网络连接", "错误", this, MessageBoxButton.OK, new MessageBoxXConfigurations
                {
                    MessageBoxIcon = pu.MessageBoxIcon.Error,
                    MessageBoxStyle = pu.MessageBoxStyle.Standard,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                });
            }
        }
        */

        private void GoSizen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://sizen.itmooth.com/");
            }
            catch (Exception opq)
            {
                pu.MessageBoxX.Show($"新建连接失败：\n{opq.Message}", "错误", this, MessageBoxButton.OK, new MessageBoxXConfigurations
                {
                    MessageBoxIcon = pu.MessageBoxIcon.Error,
                    MessageBoxStyle = pu.MessageBoxStyle.Standard,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                });
            }
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Set setting = new Set()
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this
            };
            setting.main.Background = mainDocker.Background;
            setting.music.Foreground = menu.Foreground;
            setting.bar.Background = b4.Background;
            setting.ShowDialog();
            SetThis();
        }

        private void UserServe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://teamc.itmooth.com/userCenter/");
            }
            catch (Exception opq)
            {
                pu.MessageBoxX.Show($"新建连接失败：\n{opq.Message}", "错误", this, MessageBoxButton.OK, new MessageBoxXConfigurations
                {
                    MessageBoxIcon = pu.MessageBoxIcon.Error,
                    MessageBoxStyle = pu.MessageBoxStyle.Standard,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                });
            }
        }

        private DropShadowEffect b1e;
        private DropShadowEffect b2e;
        private DropShadowEffect b3e;
        private DropShadowEffect b4e;
        private DropShadowEffect b5e;
        private DropShadowEffect b6e;
        private DropShadowEffect b7e;

        private void ValueEffects()
        {
            try
            {
                b1e = (DropShadowEffect)b1.Effect;
                b2e = (DropShadowEffect)b2.Effect;
                b3e = (DropShadowEffect)b3.Effect;
                b4e = (DropShadowEffect)b4.Effect;
                b5e = (DropShadowEffect)b5.Effect;
                b6e = (DropShadowEffect)b6.Effect;
                b7e = (DropShadowEffect)contacts_docker.Effect;
            }
            catch
            {

            }
        }

        private void Theme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                switch (theme.SelectedIndex)
                {
                    case 0:
                        Resources.Remove("back");
                        Resources.Add("back", new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")));
                        Resources.Remove("foreback");
                        Resources.Add("foreback", new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5")));
                        Resources.Remove("font");
                        Resources.Add("font", new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212121")));

                        b1.Effect = b1e;
                        b2.Effect = b2e;
                        b3.Effect = b3e;
                        b4.Effect = b4e;
                        b5.Effect = b5e;
                        b6.Effect = b6e;
                        contacts_docker.Effect = b7e;
                        break;
                    case 1:
                        Resources.Remove("back");
                        Resources.Add("back", new SolidColorBrush((Color)ColorConverter.ConvertFromString("#252526")));
                        Resources.Remove("foreback");
                        Resources.Add("foreback", new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2A2A2B")));
                        Resources.Remove("font");
                        Resources.Add("font", new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")));

                        b1.Effect = null;
                        b2.Effect = null;
                        b3.Effect = null;
                        b4.Effect = null;
                        b5.Effect = null;
                        b6.Effect = null;
                        contacts_docker.Effect = null;
                        break;
                    default:
                        theme.SelectedIndex = 0;
                        break;
                }
            }
            catch
            {

            }
        }

        readonly RoutedEventArgs ela = null;

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Btn_Send_Click(sender, ela);
        }

        private void GetContacts()
        {
            string contactsSavePath = $"{WorkBase}\\conf\\contacts.xml";
            XmlDocument ctats = new XmlDocument();
            ctats.Load(contactsSavePath);
            foreach (XmlNode xn in ctats)
            {
                if(xn.NodeType.Equals("item"))
                {
                    _ = xn.Attributes["ip"];
                    _ = xn.Attributes["dc"];
                }
            }
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            string host = target.Text.ToString();



            GetContacts();
        }
    }
}