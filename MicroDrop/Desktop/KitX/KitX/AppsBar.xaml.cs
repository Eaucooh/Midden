using KitX.Core;
using lib_windows;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Window = System.Windows.Window;

namespace KitX
{
    /// <summary>
    /// AppsBar.xaml 的交互逻辑
    /// </summary>
    public partial class AppsBar : Window
    {
        public bool CanCloseNow = false;
        public bool CanAnimate = true;
        private readonly DoubleAnimation Chrome_FadeIn;
        private readonly DoubleAnimation Chrome_FadeOut;
        private readonly OhManControl.Animation.AnimationHelper animationHelper = new OhManControl.Animation.AnimationHelper();
        private readonly System.Windows.Forms.Timer ti;

        public Theme NowTheme = Theme.Light;

        #region HotKey
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow([MarshalAs(UnmanagedType.LPTStr)] string lpClassName, [MarshalAs(UnmanagedType.LPTStr)] string lpWindowName);

        [DllImport("user32")]
        private static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        int hotkey; 
        #endregion

        #region Window styles
        [Flags]
        public enum ExtendedWindowStyles
        {
            // ...
            WS_EX_TOOLWINDOW = 0x00000080,
            // ...
        }

        public enum GetWindowLongFields
        {
            // ...
            GWL_EXSTYLE = (-20),
            // ...
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        public static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            int error = 0;
            IntPtr result = IntPtr.Zero;
            // Win32 SetWindowLong doesn't clear error on success
            SetLastError(0);

            if (IntPtr.Size == 4)
            {
                // use SetWindowLong
                Int32 tempResult = IntSetWindowLong(hWnd, nIndex, IntPtrToInt32(dwNewLong));
                error = Marshal.GetLastWin32Error();
                result = new IntPtr(tempResult);
            }
            else
            {
                // use SetWindowLongPtr
                result = IntSetWindowLongPtr(hWnd, nIndex, dwNewLong);
                error = Marshal.GetLastWin32Error();
            }

            if ((result == IntPtr.Zero) && (error != 0))
            {
                throw new System.ComponentModel.Win32Exception(error);
            }

            return result;
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", SetLastError = true)]
        private static extern IntPtr IntSetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
        private static extern Int32 IntSetWindowLong(IntPtr hWnd, int nIndex, Int32 dwNewLong);

        private static int IntPtrToInt32(IntPtr intPtr)
        {
            return unchecked((int)intPtr.ToInt64());
        }

        [DllImport("kernel32.dll", EntryPoint = "SetLastError")]
        public static extern void SetLastError(int dwErrorCode);
        #endregion

        public AppsBar()
        {
            InitializeComponent();

            Docker.Height = 0;

            Width = App.WorkAreaWidth;
            Top = 0;
            Left = 0;

            SizeToContent = SizeToContent.Height;

            Chrome_FadeOut = animationHelper.CreateDoubleAnimation(TimeSpan.FromMilliseconds(300), 80, 0, FillBehavior.HoldEnd,
                OhManControl.Animation.AnimationHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);
            Chrome_FadeIn = animationHelper.CreateDoubleAnimation(TimeSpan.FromMilliseconds(300), 0, 80, FillBehavior.HoldEnd,
                OhManControl.Animation.AnimationHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);

            Loaded += AppsBar_Loaded;

            Closing += (x, y) =>
            {
                if (!CanCloseNow)
                {
                    y.Cancel = true;
                }
                else
                {
                    ti.Stop();
                    ti.Dispose();
                }
            };

            timer.Text = DateTime.Now.ToString($"{(TS.SelectedIndex == 0 ? "hh" : "HH")}:mm");
            ti = new System.Windows.Forms.Timer()
            {
                Interval = 10 * 1000
            };
            ti.Tick += (x, y) =>
            {
                timer.Text = DateTime.Now.ToString($"{(TS.SelectedIndex == 0 ? "hh" : "HH")}:mm");
            };
            ti.Start();

            Loaded += AppsBar_Loaded1;
            Loaded += AppsBar_Loaded2;
            
            IntPtr pWnd = FindWindow("AppsBar", null);
            pWnd = FindWindowEx(pWnd, IntPtr.Zero, "SHELLDLL_DefVIew", null);
            pWnd = FindWindowEx(pWnd, IntPtr.Zero, "SysListView32", null);

            SetParent(new WindowInteropHelper(this).Handle, pWnd);

            Loaded += (x, y) =>
            {
                LS.SelectionChanged += (m, n) =>
                {
                    switch (LS.SelectedIndex)
                    {
                        case 0:
                            Width = App.WorkAreaWidth;
                            Top = 0;
                            Left = 0;
                            SizeToContent = SizeToContent.Height;
                            AppsContainer.VerticalAlignment = VerticalAlignment.Top;
                            Docker.VerticalAlignment = VerticalAlignment.Top;
                            Quicker.Margin = new Thickness(0, 120, 0, 0);
                            Quicker.VerticalAlignment = VerticalAlignment.Top;
                            checker.VerticalAlignment = VerticalAlignment.Top;
                            App.AppsBarStartLocation = 0;
                            break;
                        case 1:
                            Width = App.WorkAreaWidth;
                            Top = 0;
                            Left = 0;
                            SizeToContent = SizeToContent.Manual;
                            Height = App.WorkAreaHeight - 20;
                            AppsContainer.VerticalAlignment = VerticalAlignment.Bottom;
                            Docker.VerticalAlignment = VerticalAlignment.Bottom;
                            Quicker.Margin = new Thickness(0, 0, 0, 120);
                            Quicker.VerticalAlignment = VerticalAlignment.Bottom;
                            checker.VerticalAlignment = VerticalAlignment.Bottom;
                            App.AppsBarStartLocation = 1;
                            break;
                    }
                    App.SaveConfig();
                };
            };
        }

        private void AppsBar_Loaded(object sender, RoutedEventArgs e) => RefreshBackground();

        private void AppsBar_Loaded2(object sender, RoutedEventArgs e) => HideAltTab();

        private void HideAltTab()
        {
            WindowInteropHelper wndHelper = new WindowInteropHelper(this);
            int exStyle = (int)GetWindowLong(wndHelper.Handle, (int)GetWindowLongFields.GWL_EXSTYLE);
            exStyle |= (int)ExtendedWindowStyles.WS_EX_TOOLWINDOW;
            SetWindowLong(wndHelper.Handle, (int)GetWindowLongFields.GWL_EXSTYLE, (IntPtr)exStyle);
        }

        #region 全局热键
        private void AppsBar_Loaded1(object sender, RoutedEventArgs e)
        {
            HwndSource hWndSource;
            WindowInteropHelper wih = new WindowInteropHelper(this);
            hWndSource = HwndSource.FromHwnd(wih.Handle);
            //添加处理程序
            hWndSource.AddHook(MainWindowProc);
            hotkey = HotKey.GlobalAddAtom("Alt-K");
            HotKey.RegisterHotKey(wih.Handle, hotkey, HotKey.KeyModifiers.Alt, (int)System.Windows.Forms.Keys.K);
        }

        private IntPtr MainWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case HotKey.WM_HOTKEY:
                    int sid = wParam.ToInt32();
                    if (sid == hotkey)
                    {
                        Animate();
                    }
                    handled = true;
                    break;
            }

            return IntPtr.Zero;
        }
        #endregion

        private Dictionary<string, IContract> Names = new Dictionary<string, IContract>();

        public void AddTool(IContract item, BitmapImage icon, string name)
        {
            // 设定工作目录
            item.SetWorkBase($"{App.ToolsBase}\\{item.GetPublisher()}\\{item.GetName()}");
            Dispatcher.Invoke(new Action(delegate
            {
                if (!IsExists(name))
                {
                    ContextMenu menu = new ContextMenu()
                    {
                        StaysOpen = false
                    };
                    MenuItem m1 = new MenuItem();
                    m1.SetResourceReference(HeaderedItemsControl.HeaderProperty, "Item_Close");
                    m1.Click += (x, y) =>
                    {
                        item.End();
                    };
                    menu.Items.Add(m1);

                    Button btn = new Button()
                    {
                        Name = name,
                        Margin = new Thickness(5),
                        Width = 45,
                        Height = 45,
                        AllowDrop = true,
                        Content = new Image()
                        {
                            Source = icon,
                            Stretch = Stretch.UniformToFill
                        },
                        Style = new ResourceDictionary
                        {
                            // 通过key找到指定的样式
                            Source = new Uri("/KitX;component/PulseButton.xaml", UriKind.Relative) // 指定样式文件的路径
                        }["PulseButton"] as Style,
                        ContextMenu = menu
                    };
                    btn.Click += (x, y) =>
                    {
                        Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
                        {
                            item.Start();
                            item.SetTheme(NowTheme);
                        }));
                    };
                    btn.MouseEnter += (x, y) =>
                    {
                        Quicker.Content = item.GetQuickView();
                        AppInfoBack.Visibility = Visibility.Visible;
                        AppInfoer.Text = $"{item.GetName()}\r\n{item.GetDescribe_Simple()}";
                    };
                    btn.DragEnter += (x, y) => { y.Effects = DragDropEffects.All; Quicker.Content = item.GetQuickView(); };
                    Quicker.MouseLeave += (x, y) => Quicker.Content = null;
                    fishButtons.Children.Add(btn);
                    Names.Add(name, item);
                }
            }));            
        }

        private bool IsExists(string name)
        {
            foreach (string item in Names.Keys)
            {
                if (item.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }

        public void RefreshToolTheme(Theme tem)
        {
            foreach (var item in Names.Values)
            {
                item.SetTheme(tem);
            }
        }

        public void RemoveTool(string name)
        {
            if (IsExists(name))
            {
                Names.Remove(name);
                foreach (Button item in fishButtons.Children)
                {
                    if (item.Name.Equals(name))
                    {
                        fishButtons.Children.Remove(item);
                        break;
                    }
                }
            }
        }

        public void RefreshBackground()
        {
            Backgrounder.Background = Application.Current.MainWindow.Background;
            checker.Background = Application.Current.MainWindow.Background;
        }

        #region 防止Alt+F4组合键和Alt+Space组合键
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Alt && e.SystemKey == Key.Space)
            {
                e.Handled = true;
            }
            else if (Keyboard.Modifiers == ModifierKeys.Alt && e.SystemKey == Key.F4)
            {
                e.Handled = true;
            }
            else
            {
                base.OnKeyDown(e);
            }
        }
        #endregion

        bool isAnimating = true;

        private void Animate()
        {
            if (CanAnimate)
            {
                if (isAnimating)
                {
                    isAnimating = false;
                    Docker.BeginAnimation(HeightProperty, Chrome_FadeOut);
                }
                else
                {
                    isAnimating = true;
                    Docker.BeginAnimation(HeightProperty, Chrome_FadeIn);
                }
            }
        }

        //private void Border_MouseEnter(object sender, MouseEventArgs e) => Docker.Height = CanAnimate ? 80 : 8;
        //private void Backgrounder_MouseLeave(object sender, MouseEventArgs e) => Docker.Height = CanAnimate ? 0 : 80;

        private void Border_MouseEnter(object sender, MouseEventArgs e) => Animate();

        private void Backgrounder_MouseLeave(object sender, MouseEventArgs e)
        {
            Animate();
            amated = false;
            AppInfoer.Text = null;
            AppInfoBack.Visibility = Visibility.Hidden;
        }

        private void ExitApp(object sender, RoutedEventArgs e) => App.LazyClose();

        public void Locker(bool _lock)
        {
            PinToScreen.IsChecked = _lock ? true : false;
            UpdatePinEvent(PinToScreen, null);
        }

        private void UpdatePinEvent(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as CheckBox).IsChecked)
            {
                isAnimating = false;
                Animate();
            }
            else
            {
                isAnimating = false;
                Docker.BeginAnimation(HeightProperty, Chrome_FadeOut);
            }
            CanAnimate = (sender as CheckBox).IsChecked != true;
        }

        bool amated = false;

        private void DragEnter_Origin(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.All;
            if (!amated)
            {
                Animate();
                amated = true;
            }
        }
    }
}