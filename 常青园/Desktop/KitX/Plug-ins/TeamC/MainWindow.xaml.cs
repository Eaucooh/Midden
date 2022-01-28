using KitX.Core;
using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Xml;

namespace TeamC
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IContract))]
    public partial class MainWindow : Window, IContract
    {
        public string WorkBase = null;
        public bool IsPlayMusic = true;

        public MainWindow()
        {
            InitializeComponent();
            win = this;
            //win.theme.SelectedIndex = (themee == Theme.Light) ? 0 : 1;
            Closed += (x, y) =>
            {
                started = false;
            };
            ValueEffects();
        }

        string xmlInitContent = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n<contacts>\r\n<item>\r\n" +
            "<ip>42.193.5.54</ip>\r\n<dc>常青园公共聊天室</dc>\r\n</item>\r\n<item>\r\n" +
            "<ip>127.0.0.1</ip>\r\n<dc>将此电脑作为主机，需要在此电脑运行TeamC-Serve</dc>\r\n</item>\r\n</contacts>";

        private void CheckEnvironment()
        {
            string[] inis = new string[5]
            {
                "contacts.ini", "contacts.xml", "music.ini", "serve.ini", "theme.ini"
            };
            string[] iniInit = new string[5]
            {
                "left", "(xml)", "has", "42.193.5.54", "light"
            };
            if (!Directory.Exists($"{WorkBase}\\conf"))
            {
                Directory.CreateDirectory($"{WorkBase}\\conf");
            }
            for (int i = 0; i < inis.Length; i++)
            {
                string tp = $"{WorkBase}\\conf\\{inis[i]}";
                if (!File.Exists(tp))
                {
                    File.Create(tp).Close();
                    if (!iniInit[i].Equals("(xml)"))
                    {
                        Library.FileHelper.FileHelper.WriteIn(tp, iniInit[i]);
                    }
                    else
                    {
                        Library.FileHelper.FileHelper.WriteIn(tp, xmlInitContent);
                    }
                }
            }

            if (!Directory.Exists($"{WorkBase}\\lib"))
            {
                Directory.CreateDirectory($"{WorkBase}\\lib");
            }
            new Thread(() =>
            {
                if (!File.Exists($"{WorkBase}\\lib\\msg.wav"))
                {
                    Library.NetHelper.NetHelper.DownloadFile("https://source.catrol.cn/TeamC/msg.wav", $"{WorkBase}\\lib\\msg.wav");
                }
            }).Start();
        }

        //Theme themee = Theme.Light;

        #region 接口实现

        public void SetWorkBase(string path)
        {
            WorkBase = path;
            if (!Directory.Exists(WorkBase))
            {
                Directory.CreateDirectory(WorkBase);
            }
        }

        public string GetDescribe_Complex() => "TeamC 支持连接到运行了 TeamC-Server 的服务器来构建聊天室，人数无上限，随心自我聊";

        public string GetDescribe_Simple() => "轻量级的即时聊天工具";

        public string GetFileName() => "TeamC.dll";

        public string GetHelpLink() => "https://docs.catrol.cn/";

        public string GetHostLink() => "https://blog.catrol.cn/";

        public BitmapImage GetIcon() => FindResource("Icon") as BitmapImage;

        public Languages GetLang() => Languages.zh_CN;

        public string GetName() => "TeamC";

        public string GetPublisher() => "Catrol";

        public string GetVersion() => "v2.1.0";

        public Window GetWindow() => new MainWindow();

        public void SetTheme(Theme tem)
        {
            //themee = tem;
            try
            {
                if (started)
                {
                    win.theme.SelectedIndex = (tem == Theme.Light) ? 0 : 1;
                }
            }
            catch (Exception)
            {

            }
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
                    win.WorkBase = WorkBase;
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

        public Tags GetTag() => Tags.Normal;
        #endregion

        private void SetThis()
        {
            if (Library.FileHelper.FileHelper.ReadAll($"{WorkBase}\\conf\\music.ini").Equals("no"))
            {
                IsPlayMusic = false;
            }
            else
            {
                IsPlayMusic = true;
            }
            if (Library.FileHelper.FileHelper.ReadAll($"{WorkBase}\\conf\\contacts.ini").Equals("left"))
            {
                contacts_docker.HorizontalAlignment = HorizontalAlignment.Left;
            }
            else
            {
                contacts_docker.HorizontalAlignment = HorizontalAlignment.Right;
            }
            if (Library.FileHelper.FileHelper.ReadAll($"{WorkBase}\\conf\\theme.ini").Equals("dark"))
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
            CheckEnvironment();
            DefaultIp();
            GetContacts();
            BeginStoryboard((System.Windows.Media.Animation.Storyboard)FindResource("WinStart"));
            SetThis();
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
        }

        public static void Error(string content) => HandyControl.Controls.Growl.Warning(content);

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
                Error($"错误：连接已断开\r\n{ex.Message}");
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
                        Error($"错误\r\n连接已断开");
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
                if (DateTime.Now.Minute - lastMin >= 1)
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
                    Error($"错误：连接已断开\r\n{ex.Message}");
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
            BeginStoryboard((System.Windows.Media.Animation.Storyboard)FindResource("WinMoving"));
            if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Btn_clo_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Media.Animation.Storyboard storyboard = (System.Windows.Media.Animation.Storyboard)FindResource("WinClose");
            storyboard.Completed += (x, y) =>
            {
                Close();
            };
            BeginStoryboard(storyboard);
        }

        private void Btn_small_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void ReStoreDefaultIp(object sender, RoutedEventArgs e) => DefaultIp();

        private void DefaultIp() => target.Text = Library.FileHelper.FileHelper.ReadAll(WorkBase + @"\conf\serve.ini");

        private void Dispose_Click(object sender, RoutedEventArgs e) => lbx_Messages.Children.Clear();

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Set setting = new Set()
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                WorkBase = WorkBase
            };
            setting.main.Background = mainDocker.Background;
            setting.music.Foreground = menu.Foreground;
            setting.bar.Background = b4.Background;
            setting.ShowDialog();
            SetThis();
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

        bool first = true;

        private void Theme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!first)
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
                        Resources.Add("foreback", new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333")));
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
            else
            {
                first = false;
            }
        }

        readonly RoutedEventArgs ela = null;

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) => Btn_Send_Click(sender, ela);

        private void GetContacts()
        {
            users.Children.Clear();
            string contactsSavePath = $"{WorkBase}\\conf\\contacts.xml";
            XmlDocument ctats = new XmlDocument();
            ctats.Load(contactsSavePath);
            XmlNode root = ctats.DocumentElement;
            foreach (XmlNode xn in root.ChildNodes)
            {
                user user = new user();
                foreach (XmlNode atbt in xn)
                {
                    switch (atbt.Name)
                    {
                        case "ip":
                            user.IP.Text = atbt.InnerText;
                            break;
                        case "dc":
                            user.Go.ToolTip = atbt.InnerText;
                            break;
                    }
                }
                user.Go.Click += (x, y) =>
                  {
                      target.Text = user.IP.Text;
                      hitaed(x, y);
                      BeginStoryboard((System.Windows.Media.Animation.Storyboard)FindResource("contacts_hide"));
                  };
                user.right.Click += (x, y) =>
                  {
                      foreach (XmlNode userToDel in root.ChildNodes)
                      {
                          foreach (XmlNode userToDel_atbt in userToDel)
                          {
                              if (userToDel.Name.Equals("ip"))
                              {
                                  if (userToDel_atbt.InnerText.Equals(user.IP.Text))
                                  {
                                      root.RemoveChild(userToDel);
                                  }
                              }
                          }
                      }
                      ctats.Save(contactsSavePath);
                      GetContacts();
                  };
                user.left.Click += (x, y) =>
                  {
                      Window win = new Window()
                      {
                          Width = 600,
                          Height = 350,
                          Title = "编辑联系簿（关闭此窗口自动保存）"
                      };
                      TextBox tb = new TextBox()
                      {
                          Margin = new Thickness(0),
                          TextWrapping = TextWrapping.Wrap
                      };
                      win.Content = tb;
                      tb.Text = Library.FileHelper.FileHelper.ReadAll(contactsSavePath);
                      win.Closed += (m, n) =>
                        {
                            string newValue = tb.Text;
                            System.IO.File.WriteAllText(contactsSavePath, newValue);
                            GetContacts();
                        };
                      win.ShowDialog();
                  };
                users.Children.Add(user);
            }
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            string host = target.Text.ToString();
            BeginStoryboard((System.Windows.Media.Animation.Storyboard)FindResource("addUserWin_show"));
            ip_addto.Text = host;
            dc_addto.Text = "备注/姓名（呜啦啦啦啦）";
        }

        private void hitable(object sender, RoutedEventArgs e) => contacts_mask.IsHitTestVisible = true;

        private void hitaed(object sender, RoutedEventArgs e) => contacts_mask.IsHitTestVisible = false;

        private void hitaed(object sender, MouseButtonEventArgs e) => contacts_mask.IsHitTestVisible = false;

        private void Window_LocationChanged(object sender, EventArgs e) => BeginStoryboard((System.Windows.Media.Animation.Storyboard)FindResource("WinMoved"));

        private void AddUser_Cancel(object sender, RoutedEventArgs e) => BeginStoryboard((System.Windows.Media.Animation.Storyboard)FindResource("addUserWin_hide"));

        private void AddUser_Sure(object sender, RoutedEventArgs e)
        {
            BeginStoryboard((System.Windows.Media.Animation.Storyboard)FindResource("addUserWin_hide"));
            string contactsSavePath = $"{WorkBase}\\conf\\contacts.xml";
            XmlDocument ctats = new XmlDocument();
            ctats.Load(contactsSavePath);
            XmlNode root = ctats.DocumentElement;
            XmlNode newUser = ctats.CreateNode("element", "item", "");
            XmlNode newIP = ctats.CreateNode("element", "ip", "");
            newIP.InnerText = ip_addto.Text;
            XmlNode newDc = ctats.CreateNode("element", "dc", "");
            newDc.InnerText = dc_addto.Text;
            newUser.AppendChild(newIP);
            newUser.AppendChild(newDc);
            root.AppendChild(newUser);
            ctats.Save(contactsSavePath);
            GetContacts();
        }
    }
}