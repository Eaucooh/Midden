using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace OSH
{
    /// <summary>
    /// UsbDrive.xaml 的交互逻辑
    /// </summary>
    public partial class UsbDrive : Window
    {
        public UsbDrive()
        {
            InitializeComponent();
        }

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
                        case DBT_DEVICEREMOVECOMPLETE: //U盘卸载   
                            var s = DriveInfo.GetDrives();
                            foreach (var drive in s)
                            {
                                if (drive.DriveType == DriveType.Removable)
                                {
                                    if (myGoalPath.Equals(drive.Name))
                                    {
                                        Environment.Exit(0);
                                    }
                                }
                            }
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            long totalSize = new long();
            long freeSpace = new long();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.Name == myGoalPath)
                {
                    totalSize = drive.TotalSize / (1024 * 1024 * 1024);
                }
                if (drive.Name == myGoalPath)
                {
                    freeSpace = drive.TotalFreeSpace / (1024 * 1024 * 1024);
                }
            }
            leftBase_bar.Maximum = totalSize;
            leftBase_bar.Value = freeSpace;
            leftBase.Text = freeSpace + "G/" + totalSize + "G";
            if (leftBase_bar.Value < (leftBase_bar.Maximum) / 3 && leftBase_bar.Value > (leftBase_bar.Maximum) / 3 * 2)
            {
                qualityBase.Text = "容量概况:" + "良好";
            }
            if (leftBase_bar.Value < (leftBase_bar.Maximum) / 3 * 2)
            {
                qualityBase.Text = "容量概况:" + "蒂花之秀";
            }
            if (leftBase_bar.Value > (leftBase_bar.Maximum) / 3)
            {
                qualityBase.Text = "容量概况:" + "优秀";
            }
            if (leftBase_bar.Value == (leftBase_bar.Maximum))
            {
                qualityBase.Text = "容量概况:" + "新U盘？";
            }
            if (leftBase_bar.Value == 0 || leftBase_bar.Value == 1)
            {
                qualityBase.Text = "容量概况:" + "卧槽！";
            }
            MessageBox.Show(myGoalPath);
        }

        public string myGoalPath = @"C:\";

        private void main_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {

            }
        }

        private void openUsbDrive_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(myGoalPath);
        }

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

        private void outUsbDrive_Click(object sender, RoutedEventArgs e)
        {
            string result = myGoalPath.Replace(@"\", "");
            IntPtr handle = CreateFile(@"\\.\" + result, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, 0x3, 0, IntPtr.Zero);
            uint byteReturned;
            DeviceIoControl(handle, IOCTL_STORAGE_EJECT_MEDIA, IntPtr.Zero, 0, IntPtr.Zero, 0, out byteReturned, IntPtr.Zero);
            if (File.Exists(myGoalPath))
            {
                MessageBox.Show("未知错误\r\n弹出失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Close();
            }
        }

        private void UsbDriveQualityTest_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
