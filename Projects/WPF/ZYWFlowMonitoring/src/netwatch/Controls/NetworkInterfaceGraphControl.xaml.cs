using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Media;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using netwatch.IpTable;

namespace netwatch.Controls
{
    /// <summary>
    /// Interaction logic for NetworkInterfaceGraphControl.xaml
    /// </summary>
    public partial class NetworkInterfaceGraphControl
    {
        private bool _isStarted = false;
        private long _totalSentbytes = 0;
        private long _totalReceivedbytes = 0;

        private List<NetworkInterface> _networkAdoptor;
        private readonly NetworkUsageDataCollection _networkUsage = new NetworkUsageDataCollection(60);

        public NetworkInterfaceGraphControl(List<NetworkInterface> selectednetworkInterface)
        {
            InitializeComponent();
            Start(selectednetworkInterface);
        }

        public NetworkInterfaceGraphControl()
        {
            InitializeComponent();
        }

        public void Start(List<NetworkInterface> selectednetworkInterface)
        {
            _isStarted = true;
            _networkAdoptor = selectednetworkInterface;
            for (int i = 0; i < 60; i++)
            {
                DateTime dateNow = DateTime.Now;
                dateNow = dateNow.Subtract(TimeSpan.FromSeconds(60 - i));
                _networkUsage.Add(new NetworkUsageData(dateNow, 0, 0));
            }

            try
            {
                //Removing the Legend (pen description)
                plotter.Children.RemoveAll(typeof(Legend));
            }
            catch (Exception)
            {
            }

            InitializePlotter();
        }

        private void CalculateSpeed()
        {
            long sentBytes = 0;
            long recivedBytes = 0;
            foreach (var networkInterface in _networkAdoptor)
            {
                var interfaceStats = networkInterface.GetIPv4Statistics();
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

            lblDownload.Content = Helper.UsageStringHelper(recivedSpeed, NetworkSettings.UnitTypes.KBytepers);
            lblUpload.Content = Helper.UsageStringHelper(sentSpeed, NetworkSettings.UnitTypes.KBytepers);

            _networkUsage.Add(new NetworkUsageData(DateTime.Now, sentSpeed, recivedSpeed));
            lblMaxVolumeSpeed.Content =
                Helper.UsageStringHelper(Mathematics.GetUpperRounded(_networkUsage.GetMaximumAtAll()),
                                         NetworkSettings.UnitTypes.KBytepers);

            _totalSentbytes = sentBytes;
            _totalReceivedbytes = recivedBytes;
        }

        public void DoUpdate()
        {
            if (_isStarted == false)
            {
                throw new InvalidOperationException("Graph Adaptor is not Started!");
            }
            CalculateSpeed();
        }

        public void ToggleVisibility(object obj)
        {
            var uiElement = obj as UIElement;
            if (uiElement != null)
                uiElement.Visibility = uiElement.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }

        public void ToggleVisibilityOflblSent()
        {
            lblUpload.Visibility = lblUpload.Visibility == Visibility.Visible
                                         ? Visibility.Hidden
                                         : Visibility.Visible;

            recLineSent.Visibility = recLineSent.Visibility == Visibility.Visible
                                         ? Visibility.Hidden
                                         : Visibility.Visible;
        }

        public void ToggleVisibilityOfMaxVolume()
        {
            lblMaxVolumeSpeed.Visibility = lblMaxVolumeSpeed.Visibility == Visibility.Visible
                                         ? Visibility.Hidden
                                         : Visibility.Visible;
        }

        public void ToggleVisibilityOflblRcvd()
        {
            lblDownload.Visibility = lblDownload.Visibility == Visibility.Visible
                                          ? Visibility.Hidden
                                          : Visibility.Visible;

            recLineReceived.Visibility = recLineReceived.Visibility == Visibility.Visible
                                             ? Visibility.Hidden
                                             : Visibility.Visible;
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
    }
}