using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace netwatch.Gadget
{
    /// <summary>
    /// Interaction logic for DesktopGadget.xaml
    /// </summary>
    public partial class DesktopGadget
    {
        private readonly DispatcherTimer _timer;
        private bool _switchform = true;

        public DesktopGadget()
        {
            InitializeComponent();
            _timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            _timer.Tick += TimerTick;
        }

        public void DoStart(List<NetworkInterface> interfaces)
        {
            graphControl.Start(interfaces);

            _timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            graphControl.DoUpdate();
        }

        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ChangeWindowStyle()
        {
            if (_switchform)
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
                ResizeMode = ResizeMode.CanResizeWithGrip;
                _switchform = false;
            }
            else
            {
                WindowStyle = WindowStyle.None;
                ResizeMode = ResizeMode.CanResize;
                _switchform = true;
            }
        }

        private void MnuItemSwitchWindowStyleClick(object sender, RoutedEventArgs e)
        {
            ChangeWindowStyle();
        }

        private void MnuItemCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void WindowMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ChangeWindowStyle();
        }

        private void MnuItemShowHidelblDownloadClick(object sender, RoutedEventArgs e)
        {
            graphControl.ToggleVisibilityOflblRcvd();
        }

        private void MnuItemShowHidelblUploadClick(object sender, RoutedEventArgs e)
        {
            graphControl.ToggleVisibilityOflblSent();
        }

        private void MnuItemShowHideMaxVolumeClick(object sender, RoutedEventArgs e)
        {
            graphControl.ToggleVisibilityOfMaxVolume();
        }
    }
}