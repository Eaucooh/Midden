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
using System.Diagnostics;
using System.Windows.Interop;


namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            AeroHelper.ExtendGlassFrame(this, new Thickness(-1));

        }

        int alts, altd;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HwndSource hWndSource;
            WindowInteropHelper wih = new WindowInteropHelper(this);
            hWndSource = HwndSource.FromHwnd(wih.Handle);
            //添加处理程序
            hWndSource.AddHook(MainWindowProc);

            alts = HotKey.GlobalAddAtom("Alt-S");
            altd = HotKey.GlobalAddAtom("Alt-D");
            HotKey.RegisterHotKey(wih.Handle, alts, HotKey.KeyModifiers.Alt, (int)System.Windows.Forms.Keys.S);
            HotKey.RegisterHotKey(wih.Handle, altd, HotKey.KeyModifiers.Alt, (int)System.Windows.Forms.Keys.D);

        }

        private IntPtr MainWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case HotKey.WM_HOTKEY:
                    {
                        int sid = wParam.ToInt32();
                        if (sid == alts)
                        {
                            MessageBox.Show("按下Alt+S");
                        }
                        else if (sid == altd)
                        {
                            MessageBox.Show("按下Alt+D");
                        }
                        handled = true;
                        break;
                    }
            }

            return IntPtr.Zero;
        }

        
    }


}
