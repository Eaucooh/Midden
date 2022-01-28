using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Threading;
using Button = System.Windows.Controls.Button;
using ContextMenu = System.Windows.Controls.ContextMenu;
using Label = System.Windows.Controls.Label;
using MenuItem = System.Windows.Controls.MenuItem;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using UI = Panuon.UI.Silver;

namespace Center
{
    /// <summary>
    /// Working.xaml 的交互逻辑
    /// </summary>
    public partial class Working : Window
    {
        public string workbasepath;
        public string workbase = AppDomain.CurrentDomain.BaseDirectory;

        public char[] letters_capitals =
        {
            'A','B','C','D','E','F','G',
            'H','I','J','K','L','M','N',
            'O','P','Q','R','S','T',
            'U','V','W','X','Y','Z'
        };
        public char[] letters_Lower =
        {
            'a','b','c','d','e','f','g',
            'h','i','j','k','l','m','n',
            'o','p','q','r','s','t',
            'u','v','w','x','y','z'
        };

        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_NOACTIVATE = 0x0010;
        const UInt32 SWP_NOZORDER = 0x0004;
        const int WM_ACTIVATEAPP = 0x001C;
        const int WM_ACTIVATE = 0x0006;
        const int WM_SETFOCUS = 0x0007;
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const int WM_WINDOWPOSCHANGING = 0x0046;

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X,
           int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll")]
        static extern IntPtr DeferWindowPos(IntPtr hWinPosInfo, IntPtr hWnd,
           IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll")]
        static extern IntPtr BeginDeferWindowPos(int nNumWindows);
        [DllImport("user32.dll")]
        static extern bool EndDeferWindowPos(IntPtr hWinPosInfo);

        private IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_SETFOCUS)
            {
                IntPtr hWnd2 = new WindowInteropHelper(this).Handle;
                SetWindowPos(hWnd2, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVATE);
                handled = true;
            }
            return IntPtr.Zero;
        }

        public Working()
        {
            InitializeComponent();
            FileStream fs = new FileStream(workbase + @"\Conf\wbp.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            workbasepath = sr.ReadToEnd();
            if (workbasepath == "")
            {
                if (UI.MessageBoxX.Show("未配置工作路径，是否现在配置？", "提示", null, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    FolderBrowserDialog ofd = new FolderBrowserDialog()
                    {
                        Description = "选择工作文件夹，建议选择固态硬盘且空间至少剩余6GB",
                        ShowNewFolderButton = true,
                    };
                    ofd.ShowDialog();
                    if (ofd.SelectedPath == null)
                    {
                        UI.MessageBoxX.Show("下次记得告诉我一个答案", "提示", this, MessageBoxButton.OK);
                    }
                    else
                    {
                        StreamWriter sw = new StreamWriter(fs);
                        sw.Write(ofd.SelectedPath);
                        sw.Flush();
                        sw.Close();
                        workbasepath = ofd.SelectedPath;
                        RestoreDesktop();
                    }
                }
            }
            else
            {
                RestoreDesktop();
            }
            sr.Close();
            fs.Close();
            FSWMan();
            KeyDown += (s, x) =>
              {
                  if (x.Key == System.Windows.Input.Key.F5)
                  {
                      RestoreDesktop();
                  }
              };
            Loaded += (j, z) =>
              {
                  IntPtr hWnd = new WindowInteropHelper(this).Handle;
                  SetWindowPos(hWnd, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVATE);

                  IntPtr windowHandle = (new WindowInteropHelper(this)).Handle;
                  HwndSource src = HwndSource.FromHwnd(windowHandle);
                  src.AddHook(new HwndSourceHook(WndProc));
              };
            Closing += (g, b) =>
              {
                  SetAppBarAutoDisplay(false);
                  IntPtr windowHandle = (new WindowInteropHelper(this)).Handle;
                  HwndSource src = HwndSource.FromHwnd(windowHandle);
                  src.RemoveHook(new HwndSourceHook(this.WndProc));
              };
            SetAppBarAutoDisplay(true);
            MenuLister();
        }

        private void MenuLister()
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu) + @"\Programs");
                for (int i = 0; i < 10; i++)
                {
                    TreeViewItem numitem = new TreeViewItem()
                    {
                        Header = i
                    };
                    AllAppByNum.Items.Add(numitem);
                    foreach (DirectoryInfo NextFolder in info.GetDirectories())
                    {

                        if (NextFolder.Name.ToCharArray()[0] == numitem.Header.ToString().ToCharArray()[0])
                        {
                            TreeViewItem item = new TreeViewItem()
                            {
                                Header = NextFolder.Name
                            };
                            numitem.Items.Add(item);
                            item.MouseDoubleClick += (d, k) =>
                            {
                                try
                                {
                                    Process.Start(NextFolder.FullName);
                                }
                                catch(Exception mygod)
                                {
                                    UI.Notice.Show(mygod.Message, "警告", UI.MessageBoxIcon.Warning);
                                }
                            };
                        }
                    }
                    foreach (FileInfo NextFile in info.GetFiles())
                    {
                        if (NextFile.Name.ToCharArray()[0] == numitem.Header.ToString().ToCharArray()[0])
                        {
                            TreeViewItem item = new TreeViewItem()
                            {
                                Header = NextFile.Name
                            };
                            numitem.Items.Add(item);
                            item.MouseDoubleClick += (d, k) =>
                            {
                                try
                                {
                                    Process.Start(NextFile.FullName);
                                }
                                catch (Exception mygod)
                                {
                                    UI.Notice.Show(mygod.Message, "警告", UI.MessageBoxIcon.Warning);
                                }
                            };
                        }
                    }
                }
                for (int i = 0; i < letters_capitals.Length; i++)
                {
                    TreeViewItem numitem = new TreeViewItem()
                    {
                        Header = letters_capitals[i]
                    };
                    AllAppByChar.Items.Add(numitem);
                    foreach (DirectoryInfo NextFolder in info.GetDirectories())
                    {
                        if (NextFolder.Name.ToCharArray()[0].ToString().ToUpperInvariant() == numitem.Header.ToString().ToCharArray()[0].ToString())
                        {
                            TreeViewItem item = new TreeViewItem()
                            {
                                Header = NextFolder.Name
                            };
                            numitem.Items.Add(item);
                            item.MouseDoubleClick += (d, k) =>
                            {
                                try
                                {
                                    Process.Start(NextFolder.FullName);
                                }
                                catch (Exception mygod)
                                {
                                    UI.Notice.Show(mygod.Message, "警告", UI.MessageBoxIcon.Warning);
                                }
                            };
                        }
                    }
                    foreach (FileInfo NextFile in info.GetFiles())
                    {
                        if (NextFile.Name.ToCharArray()[0].ToString().ToUpperInvariant() == numitem.Header.ToString().ToCharArray()[0].ToString())
                        {
                            TreeViewItem item = new TreeViewItem()
                            {
                                Header = NextFile.Name
                            };
                            numitem.Items.Add(item);
                            item.MouseDoubleClick += (d, k) =>
                            {
                                try
                                {
                                    Process.Start(NextFile.FullName);
                                }
                                catch (Exception mygod)
                                {
                                    UI.Notice.Show(mygod.Message, "警告", UI.MessageBoxIcon.Warning);
                                }
                            };
                        }
                    }
                }
            }
            catch(Exception oh)
            {
                UI.Notice.Show(oh.Message, "警告", UI.MessageBoxIcon.Warning);
            }
        }

        private void FSWMan()
        {
            FileSystemWatcher fsw = new FileSystemWatcher(workbase)
            {
                IncludeSubdirectories = false
            };
            fsw.Created += (x, y) =>
            {
                RestoreDesktop();
            };
            fsw.Deleted += (x, y) =>
            {
                RestoreDesktop();
            };
            fsw.Renamed += (x, y) =>
            {
                RestoreDesktop();
            };
            fsw.EnableRaisingEvents = true;
        }

        private void RestoreDesktop()
        {
            UI.Notice.Show("正在加载桌面，请稍后", "提示", 3, UI.MessageBoxIcon.Info);
            Desktop.Children.Clear();
            DirectoryInfo info = new DirectoryInfo(workbasepath);
            foreach (DirectoryInfo NextFolder in info.GetDirectories())
            {
                DeskCard dc = new DeskCard
                {
                    IsFolder = true,
                    TargetPath = NextFolder.FullName,
                    FolderName = NextFolder.Name
                };
                Desktop.Children.Add(dc);
                Label zw = new Label();
                Desktop.Children.Add(zw);
            }
            foreach (FileInfo NextFile in info.GetFiles())
            {
                DeskCard dc = new DeskCard
                {
                    IsFolder = false,
                    TargetPath = NextFile.FullName
                };
                Desktop.Children.Add(dc);
                Label zw = new Label();
                Desktop.Children.Add(zw);
            }
            UI.Notice.Show("加载完成", "成功", 3, UI.MessageBoxIcon.Success);
        }

        public void ShowWin(Window win, string title, bool IsChild)
        {
            win.Show();
            if (IsChild)
            {
                WindowInteropHelper parentHelper = new WindowInteropHelper(this);
                WindowInteropHelper childHelper = new WindowInteropHelper(win);
                Win32Native.SetParent(childHelper.Handle, parentHelper.Handle);
            }
            Button but = new Button()
            {
                Style = showMenu.Style,
                Width = showMenu.Width,
                Height = showMenu.Height,
                ToolTip = win.Title,
                FontFamily = showExplorer.FontFamily,
                Content = title
            };
            Label ZhanWei = new Label();
            WindowState state = win.WindowState;
            but.Click += (n, b) =>
            {
                if (win.WindowState == WindowState.Maximized && win.WindowState == WindowState.Normal)
                {
                    win.WindowState = WindowState.Minimized;
                    state = WindowState.Minimized;
                }
                else if (win.WindowState == WindowState.Minimized)
                {
                    win.WindowState = state;
                }
            };
            MenuItem exit = new MenuItem()
            {
                Header = "关闭窗口"
            };
            exit.Click += (g, b) =>
            {
                win.Close();
            };
            win.Closed += (y, c) =>
            {
                dock.Children.Remove(but);
                dock.Children.Remove(ZhanWei);
            };
            ContextMenu context = new ContextMenu();
            context.Items.Add(exit);
            but.ContextMenu = context;
            dock.Children.Add(but);
            dock.Children.Add(ZhanWei);
        }

        public void ShowWin(string win, string com)
        {
            try
            {
                Process.Start(win, com);
            }
            catch (Exception o)
            {
                UI.Notice.Show(o.Message, "错误", 3, UI.MessageBoxIcon.Error);
            }
            //将窗口内嵌至此窗口
            /*
            WindowInteropHelper parentHelper = new WindowInteropHelper(this);
            WindowInteropHelper childHelper = new WindowInteropHelper(win);
            Win32Native.SetParent(childHelper.Handle, parentHelper.Handle);
            */
            /*
            Button but = new Button()
            {
                Style = showMenu.Style,
                Width = showMenu.Width,
                Height = showMenu.Height,
                ToolTip = win,
                FontFamily = showExplorer.FontFamily,
                Content = title
            };
            Label ZhanWei = new Label();
            but.Click += (n, b) =>
            {
                UI.Notice.Show("没有权利控制外部窗体", "警告", 3, UI.MessageBoxIcon.Warning);
            };
            MenuItem exit = new MenuItem()
            {
                Header = "关闭窗口"
            };
            Process[] myProgress;
            myProgress = Process.GetProcesses();
            foreach (Process p in myProgress)
            {
                if (p.ProcessName == Path.GetFileNameWithoutExtension(win))
                {
                    p.Exited += (y, c) =>
                      {
                          dock.Children.Remove(but);
                          dock.Children.Remove(ZhanWei);
                      };
                    exit.Click += (g, b) =>
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch(Exception oh)
                        {
                            UI.Notice.Show(oh.Message, "警告", 3, UI.MessageBoxIcon.Warning);
                        }
                    };
                }
            }
            ContextMenu context = new ContextMenu();
            context.Items.Add(exit);
            but.ContextMenu = context;
            dock.Children.Add(but);
            dock.Children.Add(ZhanWei);
            */
        }

        private void ShowExplorer_Click(object sender, RoutedEventArgs e)
        {
            ShowWin(@"C:\Windows\explorer.exe", null);
        }

        private void Turn(FrameworkElement goal)
        {
            if(goal.Visibility == Visibility.Visible)
            {
                goal.Visibility = Visibility.Hidden;
            }
            else
            {
                goal.Visibility = Visibility.Visible;
            }
        }

        private void ShowMenu_Click(object sender, RoutedEventArgs e)
        {
            double speed = 1;
            if (StartMenu.Visibility == Visibility.Visible)
            {
                DispatcherTimer dt = new DispatcherTimer()
                {
                    Interval = TimeSpan.FromMilliseconds(speed)
                };
                dt.Tick += (j, y) =>
                  {
                      if(StartMenu_Radius.Radius!=0)
                      {
                          StartMenu_Radius.Radius--;
                          StartMenu_Docker.Opacity -= 0.05;
                      }
                      else
                      {
                          dt.Stop();
                          Turn(StartMenu);
                      }
                  };
                dt.Start();
            }
            else
            {
                Turn(StartMenu);
                DispatcherTimer dt = new DispatcherTimer()
                {
                    Interval = TimeSpan.FromMilliseconds(speed)
                };
                dt.Tick += (j, y) =>
                {
                    if (StartMenu_Radius.Radius != 20)
                    {
                        StartMenu_Radius.Radius++;
                        StartMenu_Docker.Opacity += 0.05;
                    }
                    else
                    {
                        dt.Stop();
                    }
                };
                dt.Start();
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddApp_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "选择外部程序",
                Filter = "可执行程序|*.exe;*.msi;*.com;",
                Multiselect = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
            };
            if (ofd.ShowDialog(this).HasValue == true)
            {

            }
            else
            {
                UI.Notice.Show("下次记得别按取消咯", "提示");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            UI.MessageBoxX.Show("亲，下次不要隐藏我了咯", "提示", this, MessageBoxButton.OK);
        }

        private void window_StateChanged(object sender, EventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            RestoreDesktop();
        }

        private void StartBoarder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Minmost_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ShowMessages_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowTogether_Click(object sender, RoutedEventArgs e)
        {

        }

        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        public struct APPBARDATA
        {
            public int cbSize;
            public int hwnd;
            public int uCallbackMessage;
            public int uEdge;
            public RECT rc;
            public int lParam;
        }

        public const int ABS_ALWAYSONTOP = 0x002;
        public const int ABS_AUTOHIDE = 0x001;
        public const int ABS_BOTH = 0x003;
        public const int ABM_ACTIVATE = 0x006;
        public const int ABM_GETSTATE = 0x004;
        public const int ABM_GETTASKBARPOS = 0x005;
        public const int ABM_NEW = 0x000;
        public const int ABM_QUERYPOS = 0x002;
        public const int ABM_SETAUTOHIDEBAR = 0x008;
        public const int ABM_SETSTATE = 0x00A;

        ///
        /// 向系统任务栏发送消息
        ///
        [DllImport("shell32.dll")]
        public static extern int SHAppBarMessage(int dwmsg, ref APPBARDATA app);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        ///
        /// 设置系统任务栏是否自动隐藏
        ///
        ///
        public static void SetAppBarAutoDisplay(bool IsAuto)
        {
            APPBARDATA abd = new APPBARDATA();
            abd.hwnd = FindWindow("Shell_TrayWnd", "");
            //abd.lParam = ABS_ALWAYSONTOP Or ABS_AUTOHIDE   '自动隐藏,且位于窗口前
            //abd.lParam = ABS_ALWAYSONTOP                   '不自动隐藏,且位于窗口前
            //abd.lParam = ABS_AUTOHIDE                       '自动隐藏,且不位于窗口前
            if (IsAuto)
            {
                abd.lParam = ABS_AUTOHIDE;
                SHAppBarMessage(ABM_SETSTATE, ref abd);
            }
            else
            {
                abd.lParam = ABS_ALWAYSONTOP;
                SHAppBarMessage(ABM_SETSTATE, ref abd);
            }
        }

        private void WhiteBoard_Click(object sender, RoutedEventArgs e)
        {
            WhiteBoard win = new WhiteBoard();
            ShowWin(win, "", false);
        }

        private void window_GotFocus(object sender, RoutedEventArgs e)
        {
            Focusable = false;
        }

        private void ShowBin_Click(object sender, RoutedEventArgs e)
        {
            ShowWin(@"C:\Windows\explorer.exe", "::{645FF040-5081-101B-9F08-00AA002F954E}");
        }

        private void Desktop_ShowOrHide(object sender, RoutedEventArgs e)
        {
            if(DSODer.IsChecked)
            {
                Desktop.Visibility = Visibility.Visible;
            }
            else
            {
                Desktop.Visibility = Visibility.Hidden;
            }
        }
    }
}