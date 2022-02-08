using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Forms;


namespace keyboard
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("User32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIdex);

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
        }




        private void Window_Drop(object sender, System.Windows.DragEventArgs e)
        {
            // 在此处添加事件处理程序实现。

        }
        Timer timer = new Timer();
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // 在此处添加事件处理程序实现。
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (CapsLockStatus == true)
            {
                checkImage.Visibility = Visibility.Visible;
            }
            else
            {
                checkImage.Visibility = Visibility.Hidden;

            }
            IntPtr a = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            int temp = GetWindowLong(a, -20);
            SetWindowLong(a, -20, temp | 0x08000000);
           // HwndSource.FromHwnd(a).AddHook(new HwndSourceHook(WndProc));
           // double height = Screen.PrimaryScreen.Bounds.Height;
           // double width = Screen.PrimaryScreen.Bounds.Width;
          //  this.Left = (width-960)/2; this.Top = height - 400;
           // this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.ShowInTaskbar = false;

          
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
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == 0x0216)
            {
                System.Drawing.Rectangle rect = (System.Drawing.Rectangle)Marshal.PtrToStructure(lParam, typeof(System.Drawing.Rectangle));
                this.Left = rect.Left;
                this.Top = rect.Top;
            }
            /*
             WM_ACTIVATE =$0006;一个窗口被激活或失去激活状态；
             WM_SETFOCUS =$0007;获得焦点后
             WM_KILLFOCUS =$0008;失去焦点

             WM_SETCURSOR =$0020;如果鼠标引起光标在某个窗口中移动且鼠标输入没有被捕获时，就发消息给某个窗口
             WM_MOUSEACTIVATE =$0021;当光标在某个非激活的窗口中而用户正按着鼠标的某个键发送此消息给当前窗口
             WM_CHILDACTIVATE =$0022;发送此消息给MDI子窗口当用户点击此窗口的标题栏，或当窗口被激活，移动，改变大小

             */


            //if (msg == 0x0020)
            //{
            //    this.Opacity = 0;
            //}
            //if (msg == 0x0201)//0201
            //{
            //    IntPtr hWnd = GetForegroundWindow();
            //    uint processId;
            //    uint threadid = GetWindowThreadProcessId(hWnd, out processId);
            //    GUITHREADINFO lpgui = new GUITHREADINFO();
            //    lpgui.cbSize = Marshal.SizeOf(lpgui);

            //    if (GetGUIThreadInfo(threadid, ref lpgui))
            //    {
            //        if (lpgui.hwndCaret != 0)
            //        {
            //      this.Opacity = 1;
            //this.WindowState = WindowState.Normal;
            //}
            //else
            //{
            //    //       this.Opacity = 0;
            // this.WindowState = WindowState.Minimized;
            //        }

            //    }
            //}
            //if(msg==0x)


            return IntPtr.Zero;
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
            System.Windows.Controls.Button keybtn = sender as System.Windows.Controls.Button;
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

                System.Windows.Application.Current.Shutdown();
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

            keybd_event(0x11, 0, 0, 0);

            keybd_event(0x20, 0, 0, 0);

            //keybd_event(0x10, 0, 0, 0);

            keybd_event(0x11, 0, 0x02, 0);
            keybd_event(0x20, 0, 0x02, 0);
            //keybd_event(0x10, 0, 0x02, 0);


            //if (InputLanguage.InstalledInputLanguages.Count == 1)
            //    return;

            //InputLanguage Currentlanguage = InputLanguage.CurrentInputLanguage;
            //InputLanguageCollection lic = InputLanguage.InstalledInputLanguages;
            //for (int i = 0; i < lic.Count; i++)
            //{
            //    if (lic[i].LayoutName == Currentlanguage.LayoutName)
            //    {
            //        if (i == lic.Count - 1)
            //        {
            //            InputLanguage.CurrentInputLanguage = lic[0];
            //        }
            //        else
            //        {
            //            InputLanguage.CurrentInputLanguage = lic[i + 1];
            //        }
            //        return;
            //    }
            //}



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

        public struct GUITHREADINFO
        {
            public int cbSize;
            public int flags;
            public int hwndActive;
            public int hwndFocus;
            public int hwndCapture;
            public int hwndMenuOwner;
            public int hwndMoveSize;
            public int hwndCaret;
            public System.Drawing.Rectangle rcCaret;
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetGUIThreadInfo(uint idThread, ref GUITHREADINFO lpgui);

        [DllImport("user32")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;

            IntPtr hWnd = GetForegroundWindow();
            uint processId;
            uint threadid = GetWindowThreadProcessId(hWnd, out processId);
            GUITHREADINFO lpgui = new GUITHREADINFO();
            lpgui.cbSize = Marshal.SizeOf(lpgui);

            if (GetGUIThreadInfo(threadid, ref lpgui))
            {
                if (lpgui.hwndCaret != 0)
                {
                    this.Opacity = 1;
                    //this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.Opacity = 0;
                    // this.WindowState = WindowState.Minimized;
                }

            }

            timer.Enabled = true;
        }



        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
            if (hwndSource != null)
                hwndSource.AddHook(new HwndSourceHook(this.WndProc));
        }

       

        //private void CmdCapsLock_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{

        //    if (CapsLockStatus == true)
        //    {
        //        checkImage.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        checkImage.Visibility = Visibility.Hidden;
        //    }
        //}
    }
}
