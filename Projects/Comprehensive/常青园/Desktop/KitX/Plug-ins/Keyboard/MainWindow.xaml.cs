using KitX.Core;
using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Keyboard
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IContract))]
    public partial class MainWindow : Window, IContract
    {
        [DllImport("User32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("User32.dll")]
        public static extern void keybd_event(byte bVK, byte bScan, Int32 dwFlags, int dwExtraInfo);

        [DllImport("User32.dll")]
        public static extern uint MapVirtualKey(uint uCode, uint uMapType);

        [DllImport("user32.dll", EntryPoint = "GetKeyboardState")]
        public static extern int GetKeyboardState(byte[] pbKeyState);

        public MainWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
            MouseDown += MainWindow_MouseDown;
            win = this;
            Closed += (x, y) =>
            {
                started = false;
            };
        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (CapsLockStatus == true)
            {
                win.checkImage.Visibility = Visibility.Visible;
            }
            else
            {
                win.checkImage.Visibility = Visibility.Hidden;
            }
            IntPtr a = new WindowInteropHelper(win).Handle;
            int temp = (int)GetWindowLong(a, -20);
            SetWindowLong(a, -20, temp | 0x08000000);
            HideAltTab();
        }

        private void HideAltTab()
        {
            WindowInteropHelper wndHelper = new WindowInteropHelper(win);

            int exStyle = (int)GetWindowLong(wndHelper.Handle, (int)GetWindowLongFields.GWL_EXSTYLE);

            exStyle |= (int)ExtendedWindowStyles.WS_EX_TOOLWINDOW;

            SetWindowLong(wndHelper.Handle, (int)GetWindowLongFields.GWL_EXSTYLE, (IntPtr)exStyle);
        }

        private void cmd1_LostFocus(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        public static bool CapsLockStatus
        {
            get
            {
                byte[] bs = new byte[256];
                GetKeyboardState(bs);
                return (bs[0x14] == 1);
            }
        }

        #region Property & Variable & Constructor
        private static double _WidthTouchKeyboard = 605;

        public static double WidthTouchKeyboard
        {
            get { return _WidthTouchKeyboard; }
            set { _WidthTouchKeyboard = value; }

        }
        private static bool _ShiftFlag;

        protected static bool ShiftFlag
        {
            get { return _ShiftFlag; }
            set { _ShiftFlag = value; }
        }
        private static bool _CtrlFlag;
        protected static bool CtrlFlag
        {
            get { return _CtrlFlag; }
            set { _CtrlFlag = value; }
        }

        #endregion
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button keybtn = sender as Button;
            #region//First Row
            if (keybtn.Name == "CmdTlide")
            {
                addNumkeyINput(0xc0);
            }
            else if (keybtn.Name == "cmd1")
            {
                addNumkeyINput(0x31);
            }
            else if (keybtn.Name == "cmd2")
            {
                addNumkeyINput(0x32);
            }
            else if (keybtn.Name == "cmd3")
            {
                addNumkeyINput(0x33);
            }
            else if (keybtn.Name == "cmd4")
            {
                addNumkeyINput(0x34);
            }
            else if (keybtn.Name == "cmd5")
            {
                addNumkeyINput(0x35);
            }
            else if (keybtn.Name == "cmd6")
            {
                addNumkeyINput(0x36);

            }
            else if (keybtn.Name == "cmd7")
            {
                addNumkeyINput(0x37);
            }
            else if (keybtn.Name == "cmd8")
            {
                addNumkeyINput(0x38);
            }
            else if (keybtn.Name == "cmd9")
            {
                addNumkeyINput(0x39);
            }
            else if (keybtn.Name == "cmd0")
            {
                addNumkeyINput(0x30);

            }
            else if (keybtn.Name == "cmdminus")//-_
            {
                addNumkeyINput(0xbd);
            }
            else if (keybtn.Name == "cmd1")//+=
            {
                addNumkeyINput(0xbb);
            }
            else if (keybtn.Name == "cmdBackspace")//backspace
            {
                AddKeyBoardINput(0x08);
            }
            #endregion
            #region//Second Row
            else if (keybtn.Name == "CmdTab")
            {
                AddKeyBoardINput(0x09);
            }
            else if (keybtn.Name == "CmdQ")
            {
                AddKeyBoardINput(0x51);
            }
            else if (keybtn.Name == "Cmdw")
            {
                AddKeyBoardINput(0x57);

            }
            else if (keybtn.Name == "CmdE")
            {
                AddKeyBoardINput(0X45);

            }
            else if (keybtn.Name == "CmdR")
            {
                AddKeyBoardINput(0X52);

            }
            else if (keybtn.Name == "CmdT")
            {
                AddKeyBoardINput(0X54);

            }
            else if (keybtn.Name == "CmdY")
            {
                AddKeyBoardINput(0X59);

            }
            else if (keybtn.Name == "CmdU")
            {
                AddKeyBoardINput(0X55);

            }
            else if (keybtn.Name == "CmdI")
            {
                AddKeyBoardINput(0X49);

            }
            else if (keybtn.Name == "CmdO")
            {
                AddKeyBoardINput(0X4F);
            }
            else if (keybtn.Name == "CmdP")
            {
                AddKeyBoardINput(0X50);
            }
            else if (keybtn.Name == "CmdOpenCrulyBrace")
            {
                addNumkeyINput(0xdb);
            }
            else if (keybtn.Name == "CmdEndCrultBrace")
            {
                addNumkeyINput(0xdd);
            }
            else if (keybtn.Name == "CmdOR")
            {
                addNumkeyINput(0xdc);
            }
            #endregion
            #region///Third ROw

            else if (keybtn.Name == "CmdCapsLock")//caps lock
            {
                AddKeyBoardINput(0x14);
                if (checkImage.Visibility != Visibility.Visible)
                {
                    checkImage.Visibility = Visibility.Visible;
                }
                else
                {
                    checkImage.Visibility = Visibility.Hidden;
                }
            }
            else if (keybtn.Name == "CmdA")
            {
                AddKeyBoardINput(0x41);
            }
            else if (keybtn.Name == "CmdS")
            {
                AddKeyBoardINput(0x53);
            }
            else if (keybtn.Name == "CmdD")
            {
                AddKeyBoardINput(0x44);
            }
            else if (keybtn.Name == "CmdF")
            {
                AddKeyBoardINput(0x46);
            }
            else if (keybtn.Name == "CmdG")
            {
                AddKeyBoardINput(0x47);
            }
            else if (keybtn.Name == "CmdH")
            {
                AddKeyBoardINput(0x48);
            }
            else if (keybtn.Name == "CmdJ")
            {
                AddKeyBoardINput(0x4A);
            }
            else if (keybtn.Name == "CmdK")
            {
                AddKeyBoardINput(0X4B);
            }
            else if (keybtn.Name == "CmdL")
            {
                AddKeyBoardINput(0X4C);

            }
            else if (keybtn.Name == "CmdColon")//;:
            {
                addNumkeyINput(0xba);
            }
            else if (keybtn.Name == "CmdDoubleInvertedComma")//'"
            {
                addNumkeyINput(0xde);
            }
            else if (keybtn.Name == "CmdEnter")
            {
                AddKeyBoardINput(0x0d);
            }
            #endregion
            #region//Fourth Row
            else if (keybtn.Name == "CmdShift" || keybtn.Name == "CmdlShift")
            {
                if (CtrlFlag)
                {
                    CtrlFlag = false;
                    ShiftFlag = false;
                    changeInput();
                }
                else
                {
                    ShiftFlag = true;
                }
            }
            else if (keybtn.Name == "CmdZ")
            {

                AddKeyBoardINput(0X5A);

            }
            else if (keybtn.Name == "CmdX")
            {
                AddKeyBoardINput(0X58);

            }
            else if (keybtn.Name == "CmdC")
            {
                AddKeyBoardINput(0X43);

            }
            else if (keybtn.Name == "CmdV")
            {
                AddKeyBoardINput(0X56);

            }
            else if (keybtn.Name == "CmdB")
            {
                AddKeyBoardINput(0X42);

            }
            else if (keybtn.Name == "CmdN")
            {
                AddKeyBoardINput(0x4E);

            }
            else if (keybtn.Name == "CmdM")
            {
                AddKeyBoardINput(0x4D);
            }
            else if (keybtn.Name == "CmdLessThan")//<,
            {
                addNumkeyINput(0xbc);
            }
            else if (keybtn.Name == "CmdGreaterThan")//>.
            {
                addNumkeyINput(0xbe);
            }
            else if (keybtn.Name == "CmdQuestion")//?/
            {
                addNumkeyINput(0xbf);
            }

            else if (keybtn.Name == "CmdSpaceBar")
            {
                AddKeyBoardINput(0x20);
            }
            #endregion
            #region//Last row
            else if (keybtn.Name == "CmdCtrl" || keybtn.Name == "CmdlCtrl")//ctrl
            {
                if (ShiftFlag)
                {
                    ShiftFlag = false;
                    CtrlFlag = false;
                }
                else
                {
                    CtrlFlag = true;
                }
                //AddKeyBoardINput(0x11);
            }
            else if (keybtn.Name == "CmdpageUp")
            {
                AddKeyBoardINput(0x21);
            }
            else if (keybtn.Name == "CmdpageDown")
            {
                AddKeyBoardINput(0x22);
            }
            else if (keybtn.Name == "CmdClose")//关闭键盘
            {
                //this.Opacity = 0;
                // this.Close();
                //  this.keyboard.Visibility = Visibility.Hidden;
                //this.keyboard.Focusable = false;

                Close();
            }
            else if(keybtn.Name == "CmdTypeWriting")
            {
                changeInput();
                //keybd_event(0x8, 0, 0, 0);
                //keybd_event(0x8, 0, 0x02, 0);
            }

            #endregion
        }     
        
        //切换输入法
        private void changeInput()
        {
            keybd_event(0x10, 0, 0, 0);//shift
            System.Windows.Forms.SendKeys.SendWait("%+");
        }

        private static void addNumkeyINput(byte input)
        {
            if (CtrlFlag)
            {
                CtrlFlag = false;
                ShiftFlag = false;
                keybd_event(input, 0, 0, 0);
                keybd_event(input, 0, 0x02, 0);
            }
            else
            {
                if (!ShiftFlag)
                {
                    keybd_event(input, 0, 0, 0);
                    keybd_event(input, 0, 0x02, 0);
                }
                else
                {
                    keybd_event(0x10, 0, 0, 0);//shift
                    keybd_event(input, 0, 0, 0);
                    keybd_event(input, 0, 0x02, 0);
                    keybd_event(0x10, 0, 0x02, 0);

                    ShiftFlag = false;
                }
            }
        }

        private static void AddKeyBoardINput(byte input)
        {

            if (CtrlFlag)
            {
                CtrlFlag = false;
                ShiftFlag = false;
                keybd_event(input, 0, 0, 0);
                keybd_event(input, 0, 0x02, 0);
            }
            else
            {
                if (ShiftFlag)
                {
                    keybd_event(input, 0, 0, 0);
                    keybd_event(input, 0, 0x02, 0);
                    ShiftFlag = false;
                }
                else
                {
                    keybd_event(input, 0, 0, 0);
                    keybd_event(input, 0, 0x02, 0);
                }
            }
          
        }

        #region 接口实现


        private string WorkBase = null;

        public void SetWorkBase(string path)
        {
            WorkBase = path;
            if (!Directory.Exists(WorkBase))
            {
                Directory.CreateDirectory(WorkBase);
            }
        }

        public string GetDescribe_Complex() => "用鼠标操控的可视化键盘";

        public string GetDescribe_Simple() => "一个虚拟键盘鸭";

        public string GetFileName() => "Keyboard.dll";

        public string GetHelpLink() => "https://docs.catrol.cn/kitxplugins/Keyboard/";

        public string GetHostLink() => "https://blog.catrol.cn/";

        public BitmapImage GetIcon() => FindResource("Icon") as BitmapImage;

        public Languages GetLang() => Languages.general;

        public string GetName() => "Keyboard";

        public string GetPublisher() => "Catrol";

        public string GetVersion() => "v1.0.6";

        public Window GetWindow() => new MainWindow();

        public void SetTheme(Theme theme)
        {
            //Resources["back"] = (theme == Theme.Light) ? new SolidColorBrush(Colors.WhiteSmoke) : new SolidColorBrush(Colors.Black);
            //Foreground = (theme == Theme.Light) ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.WhiteSmoke);
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

        public void End()
        {
            win.Close();
            started = false;
        }

        public Tags GetTag() => Tags.System; 
        #endregion
    }
}
