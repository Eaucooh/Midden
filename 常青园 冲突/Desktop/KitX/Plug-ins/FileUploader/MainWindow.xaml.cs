using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using KitX.Core;
using Microsoft.Win32;
using MySqlConnector;

namespace FileUploader
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

        private void FlushBack()
        {
            Library.Windows.SystemColor.DwmGetColorizationColor(out int pcrColorization, out _);
            win.Background = new SolidColorBrush(Library.Windows.SystemColor.Get_Color(pcrColorization));
        }

        #region 接口实现

        public string GetDescribe_Complex() => "能为 MySQL 数据库上传文件\r\n对其它数据库的支持将在之后制作";

        public string GetDescribe_Simple() => "数据库文件上传工具";

        public string GetHelpLink() => "https://docs.catrol.cn/kitxplugins/FileUploader/";

        public string GetHostLink() => "https://blog.catrol.cn/";

        public BitmapImage GetIcon() => FindResource("Icon") as BitmapImage;

        public Languages GetLang() => Languages.zh_CN;

        public string GetName() => "FileUploader";

        public string GetPublisher() => "Catrol";

        public string GetVersion() => "v1.0.0";

        public Window GetWindow() => new MainWindow();

        public void SetTheme(Theme theme)
        {
            FlushBack();
        }

        public string GetFileName()
        {
            return "FileUploader.dll";
        }

        QuickView quicker = new QuickView();

        public UserControl GetQuickView()
        {
            quicker.win = win;
            if (started)
            {
                return quicker;
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

        private string WorkBase = null;

        public void SetWorkBase(string path)
        {
            WorkBase = path;
            if (!Directory.Exists(WorkBase))
            {
                Directory.CreateDirectory(WorkBase);
            }
        }

        public void End()
        {
            win.Close();
            started = false;
        }

        public Tags GetTag() => Tags.Program;
        #endregion

        private void TestCon(object sender, RoutedEventArgs e)
        {
            string connectStr = $"User Id={userID.Text};Password={userPwd.Password};Data Source={dataSource.Text};" +
                $"port={(int)portNum.Value};Database={originalDB.Text};" +
                $"pooling={(poolingSel.SelectedIndex == 0 ? "True" : "False")};CharSet=utf8;";
            if (MessageBox.Show(connectStr, "确认连接字符串", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                if (Library.NetHelper.NetHelper.IsWebConected("42.193.5.54", 3000))
                {
                    MySqlConnection msc = new MySqlConnection(connectStr);
                    try
                    {
                        msc.Open();
                        msc.Close();
                        msc.Dispose();
                        MessageBox.Show("连接成功，连接字符串工作正常", "成功", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception p)
                    {
                        MessageBox.Show($"连接失败，错误信息：\r\n{p.Message}", "失败", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("没有网络连接", "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private CubicEase ce = new CubicEase()
        {
            EasingMode = EasingMode.EaseOut
        };

        private void Upload(object sender, RoutedEventArgs e)
        {
            loading.Visibility = Visibility.Visible;
            loading.BeginAnimation(OpacityProperty, new DoubleAnimation()
            {
                From = 0, To = 1, FillBehavior = FillBehavior.HoldEnd,
                Duration = new TimeSpan(0, 0, 0, 0, 300), EasingFunction = ce
            });
            string sfp = FilePather.Text, db = DBname.Text, tab = TableName.Text, cn = columnName.Text, con = conditions.Text;
            string connectStr = $"User Id={userID.Text};Password={userPwd.Password};Data Source={dataSource.Text};" +
                $"port={(int)portNum.Value};Database={originalDB.Text};" +
                $"pooling={(poolingSel.SelectedIndex == 0 ? "True" : "False")};CharSet=utf8;";
            int index = fileType.SelectedIndex;
            new Thread(() =>
            {
                try
                {
                    string sendFileSql = $"USE {db};UPDATE {tab} SET {cn} = ?file {con};";
                    MySqlConnection msc = new MySqlConnection(connectStr);
                    msc.Open();
                    MySqlCommand sendCmd = new MySqlCommand(sendFileSql, msc);
                    byte[] content = Library.FileHelper.FileHelper.ReadByteAll(sfp);
                    switch (index)
                    {
                        case 0:
                            sendCmd.Parameters.Add("?file", MySqlDbType.TinyBlob).Value = content;
                            break;
                        case 1:
                            sendCmd.Parameters.Add("?file", MySqlDbType.Blob).Value = content;
                            break;
                        case 2:
                            sendCmd.Parameters.Add("?file", MySqlDbType.MediumBlob).Value = content;
                            break;
                        case 3:
                            sendCmd.Parameters.Add("?file", MySqlDbType.LongBlob).Value = content;
                            break;
                    }
                    sendCmd.ExecuteNonQuery();
                    msc.Close();
                    msc.Dispose();
                    MessageBox.Show("上传完毕", "成功", MessageBoxButton.OK, MessageBoxImage.Information);
                    FinishAni();
                }
                catch (Exception o)
                {
                    MessageBox.Show($"错误信息：\r\n{o}", "上传失败", MessageBoxButton.OK, MessageBoxImage.Error);
                    FinishAni();
                }
            }).Start();
        }

        private void FinishAni()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                DoubleAnimation da = new DoubleAnimation()
                {
                    From = 1,
                    To = 0,
                    EasingFunction = ce,
                    FillBehavior = FillBehavior.HoldEnd,
                    Duration = new TimeSpan(0, 0, 0, 0, 300)
                };
                da.Completed += (x, y) =>
                {
                    loading.Visibility = Visibility.Hidden;
                };
                loading.BeginAnimation(OpacityProperty, da);
            }));
        }

        private void Browse(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Multiselect = false, Filter = "所有文件|*.*", Title="选择要上传的文件（单选）",
                CheckFileExists = true, CheckPathExists = true
            };
            ofd.ShowDialog();
            if (ofd.FileName != null)
            {
                FilePather.Text = ofd.FileName;
            }
        }

        private void OpenLink(object sender, RoutedEventArgs e) => System.Diagnostics.Process.Start((sender as FrameworkElement).Tag.ToString());

        private void Help(object sender, RoutedEventArgs e)
        {
            string helpInfo = "Data Source - 数据库服务器地址，例如：www.baidu.com 或是 直接使用 IP 地址" +
                "\r\nPort - 要连接的端口号" +
                "\r\nData Base - 初始连接时数据库名称" +
                "\r\nPooling - 填 false 即可" +
                "\r\nChar Set - 连接用字符集 推荐 utf8" +
                "\r\nUser - 要登录的用户名" +
                "\r\nPassword - 用户的登陆密码" +
                "\r\nSource File Path - 要从本地上传的文件路径，必须是绝对路径" +
                "\r\nData Base - 要上传的数据库名称" +
                "\r\nTable - 要上传的表名称" +
                "\r\nColumn name - 上传到的列名称" +
                "\r\nCondition - 条件，例如：WHERE id = 123 不需要在末尾追加分号";
            new Window()
            {
                Title = "提示信息",
                Icon = Icon,
                Width = 478,
                Height = 247,
                WindowStyle = WindowStyle.ToolWindow,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                Background = Background,
                Content = new TextBlock()
                {
                    Text = helpInfo,
                    Margin = new Thickness(10),
                    Foreground = new SolidColorBrush(Color.FromRgb(255,255,255))
                }
            }.Show();
        }
    }
}
