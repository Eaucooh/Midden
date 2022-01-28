using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using Button = System.Windows.Controls.Button;
using MessageBox = System.Windows.MessageBox;

namespace DesktopClip
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public double X = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
        public double Y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
        public string nowpath = @"C:\";
        public string[] history = new string[80];
        public int nownum = 0;
        public MainWindow()
        {
            InitializeComponent();
            Visibility visi = new Visibility();
            visi.expander.MouseDown += (x, y) =>
            {
                if (visi.expander.Content.Equals(""))
                {
                    Hide();
                    visi.expander.Content = "";
                }
                else
                {
                    Show();
                    visi.expander.Content = "";
                }
            };
            visi.Show();
            Closing += (x, y) =>
            {
                visi.Close();
            };
            path.Text = "输入工作路径(错误路径输入将会打开浏览界面)\r\n回车以选择。";
            history[nownum] = @"C:\";
            nownum += 1;
            Produce(nowpath);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Top = 0;
            Height = Y;
            Width = X / 4;
            Left = X - Width;
            drives.IsExpanded = true;
            DriveInfoes();
        }

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
        const uint GENERIC_READ = 0x80000000;
        const int GENERIC_WRITE = 0x40000000;
        const int FILE_SHARE_READ = 0x1;
        const int FILE_SHARE_WRITE = 0x2;
        const int IOCTL_STORAGE_EJECT_MEDIA = 0x2D4808;
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr CreateFile(
             string lpFileName,
             uint dwDesiredAccess,
             uint dwShareMode,
             IntPtr SecurityAttributes,
             uint dwCreationDisposition,
             uint dwFlagsAndAttributes,
             IntPtr hTemplateFile
        );

        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool DeviceIoControl(
            IntPtr hDevice,
            uint dwIoControlCode,
            IntPtr lpInBuffer,
            uint nInBufferSize,
            IntPtr lpOutBuffer,
            uint nOutBufferSize,
            out uint lpBytesReturned,
            IntPtr lpOverlapped
        );

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
                            DriveInfoes();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return IntPtr.Zero;
        }
        private void DriveInfoes()
        {
            DriveInfo[] allDirves = DriveInfo.GetDrives();
            //检索计算机上的所有逻辑驱动器名称
            foreach (DriveInfo item in allDirves)
            {
                var myResourceDictionary = new ResourceDictionary
                {
                    Source = new Uri("/DesktopClip;component/Button1.xaml", UriKind.RelativeOrAbsolute) // 指定样式文件的路径
                };
                var myButtonStyle = myResourceDictionary["BtnInfoStyle"] as Style; // 通过key找到指定的样式
                Button button = new Button
                {
                    Content = item.VolumeLabel + " | " + item.Name + " | 可用空间:" + item.TotalFreeSpace / 1024 /1024 /1024 + "GB" + " | 总空间:" + item.TotalSize / 1024 / 1024 / 1024 + "GB",
                    Style = myButtonStyle,
                    FontSize = 12,
                    Width = Content.ToString().Length * 15,
                    Height = 35
                };
                button.MouseDoubleClick += (x, y) =>
                {
                    showD.Children.Clear();
                    showF.Children.Clear();
                    path.Text = item.Name;
                    nowpath = path.Text;
                    Produce(nowpath);
                    history[nownum] = nowpath;
                    nownum += 1;
                };
                button.Click += (x, y) =>
                {
                    Focus();
                };
                button.KeyDown += (x, y) =>
                {
                    if (y.Key == Key.Delete)
                    {
                        try
                        {
                            if (MessageBox.Show("是否删除" + item.VolumeLabel + "(" + item.Name + ")" + "驱动器", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                MessageBox.Show("删除失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            showD.Children.Clear();
                            showDr.Children.Clear();
                            showF.Children.Clear();
                            Produce(nowpath);
                            DriveInfoes();
                        }
                        catch
                        { 
                        
                        }                        
                    }
                };
                showDr.Children.Add(button);
                //Fixed 硬盘
                //Removable 可移动存储设备，如软盘驱动器或USB闪存驱动器
            }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                try
                {
                    path.Text = history[nownum - 1];
                    showD.Children.Clear();
                    showF.Children.Clear();
                    Produce(path.Text);
                }
                catch
                { 
                
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {

            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void choose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FolderBrowserDialog browserDialog = new FolderBrowserDialog
                {
                    ShowNewFolderButton = true,
                    Description = "选择工作路径:"
                };
                browserDialog.ShowDialog();
                showD.Children.Clear();
                showF.Children.Clear();
                path.Text = @browserDialog.SelectedPath;
                nowpath = path.Text;
                Produce(nowpath);
            }
            catch
            { 
            
            }
        }

        private void Produce(string mypath)
        {
            try
            {
                dE.IsExpanded = true;
                fE.IsExpanded = true;
                DirectoryInfo info = new DirectoryInfo(mypath);
                foreach (DirectoryInfo NextFolder in info.GetDirectories())
                {
                    var myResourceDictionary = new ResourceDictionary
                    {
                        Source = new Uri("/DesktopClip;component/Button1.xaml", UriKind.RelativeOrAbsolute) // 指定样式文件的路径
                    };
                    var myButtonStyle = myResourceDictionary["BtnInfoStyle"] as Style; // 通过key找到指定的样式
                    Button button = new Button
                    {
                        Content = NextFolder.Name,
                        Style = myButtonStyle,
                        FontSize = 12,
                        Width = Content.ToString().Length * 15,
                        Height = 35
                    };
                    button.MouseDoubleClick += (x, y) =>
                    {
                        showD.Children.Clear();
                        showF.Children.Clear();
                        path.Text += @"\" + button.Content;
                        nowpath = path.Text;
                        Produce(nowpath);
                        history[nownum] = nowpath;
                        nownum += 1;
                    };
                    button.Click += (x, y) =>
                    {
                        Focus();
                    };
                    button.KeyDown += (x, y) =>
                    {
                        if (y.Key == Key.Delete)
                        {
                            if (MessageBox.Show("是否删除" + button.Content + "文件夹", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                Directory.Delete(nowpath + @"\" + button.Content);
                                showD.Children.Clear();
                                showF.Children.Clear();
                                Produce(nowpath);
                            }
                        }
                    }; 
                    showD.Children.Add(button);
                }
                foreach (FileInfo NextFile in info.GetFiles())
                {
                    var myResourceDictionary = new ResourceDictionary
                    {
                        Source = new Uri("/DesktopClip;component/Button2.xaml", UriKind.RelativeOrAbsolute) // 指定样式文件的路径
                    };
                    var myButtonStyle = myResourceDictionary["BtnInfoStyle"] as Style; // 通过key找到指定的样式
                    Button button = new Button
                    {
                        Content = NextFile.Name,
                        Style = myButtonStyle,
                        FontSize = 12,
                        Width = Content.ToString().Length * 15,
                        Height = 35
                    };
                    button.MouseDoubleClick += (x, y) =>
                    {
                        try
                        {
                            Process.Start(path.Text + @"\" + button.Content);
                        }
                        catch
                        {

                        }
                    };
                    button.Click += (x, y) =>
                    {
                        Focus();
                    };
                    button.KeyDown += (x, y) =>
                    {
                        if (y.Key == Key.Delete)
                        {
                            if (MessageBox.Show("是否删除" + button.Content + "文件", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    File.Delete(nowpath + @"\" + button.Content);
                                    showD.Children.Clear();
                                    showF.Children.Clear();
                                    Produce(nowpath);
                                }
                                catch
                                {
                                    
                                }                                
                            }
                        }
                    };
                    showF.Children.Add(button);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("原因如下:\r\n" + e, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void path_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    showD.Children.Clear();
                    showF.Children.Clear();
                    nowpath = path.Text;
                    Produce(nowpath);
                    break;
                case Key.Escape:
                    path.Text = "输入工作路径\r\n错误路径输入将会打开浏览界面\r\n回车以选择";
                    break;
                case 0:
                    break;
            }
        }

        private void topM_Click(object sender, RoutedEventArgs e)
        {
            if(Topmost)
            {
                Topmost = false;
                topM.Content = "";
            }
            else
            {
                Topmost = true;
                topM.Content = "";
            }
        }

        private void Surfing()
        {
            showS.Children.Clear();
            if (surfContent.Text != "")
            {
                string surfin = surfContent.Text.ToString();
                DirectoryInfo info = new DirectoryInfo(nowpath);
                foreach (DirectoryInfo NextFolder in info.GetDirectories())
                {
                    if (NextFolder.Name.ToUpper().Contains(surfin.ToUpper()) || surfin.ToUpper().Contains(NextFolder.Name.ToUpper()))
                    {
                        var myResourceDictionary = new ResourceDictionary
                        {
                            Source = new Uri("/DesktopClip;component/Button1.xaml", UriKind.RelativeOrAbsolute) // 指定样式文件的路径
                        };
                        var myButtonStyle = myResourceDictionary["BtnInfoStyle"] as Style; // 通过key找到指定的样式
                        Button button = new Button
                        {
                            Content = NextFolder.Name,
                            Style = myButtonStyle,
                            FontSize = 12,
                            Width = Content.ToString().Length * 15,
                            Height = 35
                        };
                        button.MouseDoubleClick += (x, y) =>
                        {
                            showD.Children.Clear();
                            showF.Children.Clear();
                            path.Text += @"\" + button.Content;
                            nowpath = path.Text;
                            Produce(nowpath);
                            history[nownum] = nowpath;
                            nownum += 1;
                        };
                        button.Click += (x, y) =>
                        {
                            Focus();
                        };
                        button.KeyDown += (x, y) =>
                        {
                            if (y.Key == Key.Delete)
                            {
                                if (MessageBox.Show("是否删除" + button.Content + "文件夹", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                {
                                    Directory.Delete(nowpath + @"\" + button.Content);
                                    showD.Children.Clear();
                                    showF.Children.Clear();
                                    Produce(nowpath);
                                }
                            }
                        };
                        showS.Children.Add(button);
                    }
                }
                foreach (FileInfo NextFile in info.GetFiles())
                {
                    if (NextFile.Name.ToUpper().Contains(surfin.ToUpper()) || surfin.ToUpper().Contains(NextFile.Name.ToUpper()))
                    {
                        var myResourceDictionary = new ResourceDictionary
                        {
                            Source = new Uri("/DesktopClip;component/Button2.xaml", UriKind.RelativeOrAbsolute) // 指定样式文件的路径
                        };
                        var myButtonStyle = myResourceDictionary["BtnInfoStyle"] as Style; // 通过key找到指定的样式
                        Button button = new Button
                        {
                            Content = NextFile.Name,
                            Style = myButtonStyle,
                            FontSize = 12,
                            Width = Content.ToString().Length * 15,
                            Height = 35
                        };
                        button.MouseDoubleClick += (x, y) =>
                        {
                            try
                            {
                                Process.Start(path.Text + @"\" + button.Content);
                            }
                            catch
                            {

                            }
                        };
                        button.Click += (x, y) =>
                        {
                            Focus();
                        };
                        button.KeyDown += (x, y) =>
                        {
                            if (y.Key == Key.Delete)
                            {
                                if (MessageBox.Show("是否删除" + button.Content + "文件", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                {
                                    File.Delete(nowpath + @"\" + button.Content);
                                    showD.Children.Clear();
                                    showF.Children.Clear();
                                    Produce(nowpath);
                                }
                            }
                        };
                        showS.Children.Add(button);
                    }
                }
            }
        }

        private void surf_Click(object sender, RoutedEventArgs e)
        {
            Surfing();
        }

        private void surfContent_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Surfing();
            }
        }

        private void DesktopFastion_Click(object sender, RoutedEventArgs e)
        {
            nowpath = @"C:\Users\" + Environment.UserName + @"\Desktop\";
            path.Text = nowpath;
            Produce(nowpath);
            dE.IsExpanded = true;
            fE.IsExpanded = true;
        }

        private void surfContent_GotFocus(object sender, RoutedEventArgs e)
        {
            helptext_search.Visibility = System.Windows.Visibility.Visible;
        }

        private void surfContent_LostFocus(object sender, RoutedEventArgs e)
        {
            if (surfContent.Text == "")
            {
                helptext_search.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
