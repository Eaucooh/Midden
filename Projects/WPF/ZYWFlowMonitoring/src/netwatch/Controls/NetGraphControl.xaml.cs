using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using MahApps.Metro;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using netwatch.IpTable;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;

namespace netwatch.Controls
{
    /// <summary>
    /// Interaction logic for NetGraphControl.xaml
    /// </summary>
    public partial class NetGraphControl
    {
        private readonly NetworkUsageDataCollection _networkUsage = new NetworkUsageDataCollection(60);
        public long GlobalReceives = 0;
        public long GlobalSent = 0;

        private List<NetworkInterface> _operationalNiCs;
        private DispatcherTimer _timer;
        private long _totalReceivedbytes;
        private long _totalSentbytes;

        public NetGraphControl()
        {
            InitializeComponent();
            InitializeNetworkInterface();

            InitializeTimer();
            InitializePlotter();

            for (int i = 0; i < 60; i++)
            {
                DateTime dateNow = DateTime.Now;
                dateNow = dateNow.Subtract(TimeSpan.FromSeconds(60 - i));
                _networkUsage.Add(new NetworkUsageData(dateNow, 0, 0));
            }
            try
            {
                //Removing the Legend (pen description)
                plotter.Children.RemoveAll(typeof (Legend));
            }
            catch (Exception)
            {
            }
        }

        public bool EnableTimer
        {
            get { return _timer.IsEnabled; }
            set { _timer.IsEnabled = value; }
        }

        private void InitializeNetworkInterface()
        {
            _operationalNiCs = new List<NetworkInterface>();
            foreach (NetworkInterface t in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (t.OperationalStatus.ToString() == "Up")
                    if (t.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                        _operationalNiCs.Add(t);
            }
        }

        private void InitializeTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Tick += TimerTick;
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
        }

        private void CalculateSpeed()
        {
            long sentBytes = 0;
            long recivedBytes = 0;

            foreach (NetworkInterface nic in _operationalNiCs)
            {
                IPv4InterfaceStatistics interfaceStats = nic.GetIPv4Statistics();
                sentBytes += interfaceStats.BytesSent;
                recivedBytes += interfaceStats.BytesReceived;
            }

            long sentSpeed = sentBytes - _totalSentbytes;
            long recivedSpeed = recivedBytes - _totalReceivedbytes;

            if (_totalSentbytes == 0 && _totalReceivedbytes == 0)
            {
                sentSpeed = 0;
                recivedSpeed = 0;
            }

            GlobalReceives += recivedSpeed;
            GlobalSent += sentSpeed;

            lbl_Download.Content = Helper.UsageStringHelper(recivedSpeed, NetworkSettings.UnitTypes.KBytepers);
            lbl_Upload.Content = Helper.UsageStringHelper(sentSpeed, NetworkSettings.UnitTypes.KBytepers);

            _networkUsage.Add(new NetworkUsageData(DateTime.Now, sentSpeed, recivedSpeed));
            lbl_MaxMarker.Content =
                Helper.UsageStringHelper(Mathematics.GetUpperRounded(_networkUsage.GetMaximumAtAll()),
                                         NetworkSettings.UnitTypes.KBytepers);

            if (MainWindow.Instance != null)
            {
                MainWindow.Instance.TooltipTextBlock.Text = String.Format("Download : {0} , Uploads : {1}",
                                                                          lbl_Download.Content,
                                                                          lbl_Upload.Content);
                Icon icofile = _networkUsage.GenerateIconFromCollection();
                if (icofile != null)
                {
                    MainWindow.Instance.taskbarIcon.Icon = icofile;
                    if (_networkUsage.PrevPointer != IntPtr.Zero)
                        Win32Functions.DestroyIcon(_networkUsage.PrevPointer);
                    icofile.Dispose();
                }
            }

            _totalSentbytes = sentBytes;
            _totalReceivedbytes = recivedBytes;

            if (DetailedViewModel.Instance != null)
            {
                DetailedViewModel.Instance.RefreshLables(GlobalReceives, GlobalSent);
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            CalculateSpeed();
        }

        private void InitializePlotter()
        {
            var receivedGraph = new EnumerableDataSource<NetworkUsageData>(_networkUsage);
            receivedGraph.SetXMapping(x => timeAxis.ConvertToDouble(x.Time));
            receivedGraph.SetYMapping(y => y.ByteReceived);
            plotter.AddLineGraph(receivedGraph, Color.FromArgb(255, 0, 177, 255), 1, "ReceivedBytes");

            var brush = new SolidColorBrush(Color.FromArgb(255, 0, 177, 255));
            recLineReceived.Stroke = brush;

            var sentGraph = new EnumerableDataSource<NetworkUsageData>(_networkUsage);
            sentGraph.SetXMapping(x => timeAxis.ConvertToDouble(x.Time));
            sentGraph.SetYMapping(y => y.ByteSent);
            plotter.AddLineGraph(sentGraph, Colors.Red, 1, "SentBytes");
            recLineSent.Stroke = Brushes.Red;
        }

        private void NetMeterGadgetLoaded(object sender, RoutedEventArgs e)
        {
        }


        public void SwitchTheme(Theme color)
        {
            if (color == Theme.Dark)
            {
                var brush = new SolidColorBrush(Color.FromRgb(37, 37, 37));
                Background = brush;
                plotter.Background = brush;
                lbl_Download.Foreground = Brushes.White;
                lbl_MaxMarker.Foreground = Brushes.White;
                lbl_Upload.Foreground = Brushes.White;
            }
            else if (color == Theme.Light)
            {
                Background = Brushes.White;
                plotter.Background = Brushes.White;

                lbl_Download.Foreground = Brushes.Black;
                lbl_MaxMarker.Foreground = Brushes.Black;
                lbl_Upload.Foreground = Brushes.Black;
            }
        }
    }
}