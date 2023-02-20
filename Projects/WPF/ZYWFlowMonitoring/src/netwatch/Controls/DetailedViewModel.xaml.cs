using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;
using MahApps.Metro;
using iphelper;
using netwatch.IpTable;

namespace netwatch.Controls
{
    /// <summary>
    /// Interaction logic for DetailedViewModel.xaml
    /// </summary>
    public partial class DetailedViewModel
    {
        public static DetailedViewModel Instance;
        private readonly List<TcpRow> _latestTcpRowData; // Updates with Timer interval
        private readonly List<TcpRow> _tcpRowsData; // We Will Create ObData from this List :)

        public DispatcherTimer GlobalUpdateTimer;

        public ObservableCollection<TaskItemDetailed> ObData = new ObservableCollection<TaskItemDetailed>();
        public ProcessHelper ProcessDictionary = new ProcessHelper();
        private bool isActive;

        public DetailedViewModel()
        {
            InitializeComponent();
            _latestTcpRowData = new List<TcpRow>();
            _tcpRowsData = new List<TcpRow>();
            GlobalUpdateTimer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            GlobalUpdateTimer.Tick += GlobalUpdateTimerTick;

            Instance = this;
        }

        public ObservableCollection<TaskItemDetailed> GetAllData
        {
            get { return ObData; }
        }

        public bool IsObDataContains(TcpRow tcpRow)
        {
            return ObData.Any(taskItemDetailed => taskItemDetailed.InnerData.Equals(tcpRow));
        }

        public void RemoveTcpRowItemFromObData(TcpRow tcpRow)
        {
            int removeIndex = 0;
            bool isfinded = false;
            for (int i = 0; i < ObData.Count; i++)
            {
                if (ObData[i].InnerData.Equals(tcpRow))
                {
                    isfinded = true;
                    removeIndex = i;
                    break;
                }
            }
            if (isfinded)
                ObData.Remove(ObData[removeIndex]);
        }

        public void KillSelectedTask()
        {
            if (LstViewData.SelectedIndex != -1)
            {
                try
                {
                    var item = LstViewData.SelectedItem as TaskItemDetailed;
                    if (item != null)
                    {
                        if (iphelper.Helper.TaskKill(item.ProcessId) == 0)
                            ObData.Remove(item);
                    }
                }
                catch (Exception exp)
                {
                    Trace.WriteLine("Something Went Wrong! :" + exp.Message);
                }
            }
        }

        private void MenuItemShowPropertiesDialogClick(object sender, RoutedEventArgs e)
        {
            if (LstViewData.SelectedIndex != -1)
            {
                try
                {
                    var item = LstViewData.SelectedItem as TaskItemDetailed;
                    if (item != null)
                    {
                        Win32Functions.ShowFileProperties(item.ProcessPath);
                    }
                }
                catch (Exception exp)
                {
                    Trace.WriteLine("Something Went Wrong! :" + exp.Message);
                }
            }
        }

        private void MnuItemSearchOnline(object sender, RoutedEventArgs e)
        {
            if (LstViewData.SelectedIndex != -1)
            {
                try
                {
                    var item = LstViewData.SelectedItem as TaskItemDetailed;
                    if (item != null)
                    {
                        string pAddress = "http://www.bing.com/search?q=" + item.ProcessName + ".exe";
                        Process.Start(pAddress);
                    }
                }
                catch (Exception exp)
                {
                    Trace.WriteLine("Something Went Wrong! :" + exp.Message);
                }
            }
        }

        private void MnuItemOpenFileLocation(object sender, RoutedEventArgs e)
        {
            if (LstViewData.SelectedIndex != -1)
            {
                try
                {
                    var item = LstViewData.SelectedItem as TaskItemDetailed;
                    if (item != null)
                    {
                        string pAddress = item.ProcessPath;
                        string args = string.Format("/Select, {0}", pAddress);

                        var pfi = new ProcessStartInfo("explorer.exe", args);
                        Process.Start(pfi);
                    }
                }
                catch (Exception exp)
                {
                    Trace.WriteLine("Something Went Wrong! :" + exp.Message);
                }
            }
        }

        private void TabCtrlMotherSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainWindow.Instance != null)
            {
                if (tabCtrlMother.SelectedIndex == 0)
                {
                    //MainWindow.Instance.ChangeVisibilityOfEndTaskBtn(Visibility.Visible);
                }
                else
                {
                    //MainWindow.Instance.ChangeVisibilityOfEndTaskBtn(Visibility.Hidden);
                }
            }
        }

        private void MnuItemKillSelectedProcess(object sender, RoutedEventArgs e)
        {
            KillSelectedTask();
        }

        public void Start()
        {
            GlobalUpdateTimer.Start();
            GlobalUpdateTimerTick(GlobalUpdateTimer, new EventArgs());
            isActive = true;
        }

        public void Stop()
        {
            GlobalUpdateTimer.Stop();
            isActive = false;
        }

        private void GlobalUpdateTimerTick(object sender, EventArgs e)
        {
            DoUpdate();
        }

        public void DoUpdate()
        {
            _latestTcpRowData.Clear();
            UpdateTcpTables();
            ProcessData();

            ObData.BubbleSort();
        }

        public void ProcessData()
        {
            var cloneData = new List<TcpRow>(_latestTcpRowData);

            //Removing Old Entries!

            List<TcpRow> removeList = _tcpRowsData.Where(tcpRow => !cloneData.Contains(tcpRow)).ToList();

            //var removeList = new List<TcpRow>();
            //foreach (var tcpRow in _tcpRowsData)
            //{
            //    if (cloneData.Contains() )
            //}
            foreach (TcpRow tcpRow in removeList)
            {
                _tcpRowsData.Remove(tcpRow);
                RemoveTcpRowItemFromObData(tcpRow);
            }

            //Process  Rest of  List
            foreach (TcpRow tcpRow in cloneData)
            {
                if (_tcpRowsData.Contains(tcpRow))
                {
                    // We Already have this Item
                    //Done
                }
                else
                {
                    // New Item!
                    _tcpRowsData.Add(tcpRow);
                    ProcessInfo data = ProcessDictionary.PassMeDataofThisPid(tcpRow.ProcessId);

                    var taskItem = new TaskItemDetailed(data.ProcessName, data.ProcessId, tcpRow,
                                                        data.ProcessPath, data.ProcessIcon);

                    ObData.Add(taskItem);
                }

                // Identifying New Items, Modified Items, Removed Items
            }
        }

        private void UpdateTcpTables()
        {
            TcpTable eTcpData = ManagedIpHelper.GetExtendedTcpTable(true);

            foreach (TcpRow currentRow in eTcpData)
            {
                if (chkBoxOnlyInternet.IsChecked != null && chkBoxOnlyInternet.IsChecked.Value)
                {
                    bool canWeAdd = !IPAddress.IsLoopback(currentRow.LocalEndPoint.Address);

                    if (currentRow.LocalEndPoint.Address.ToString() == "0.0.0.0")
                        canWeAdd = false;

                    if (currentRow.State == TcpState.Listen)
                        canWeAdd = false;

                    if (canWeAdd)
                    {
                        if (currentRow.ProcessId != 0)
                            _latestTcpRowData.Add(currentRow);
                    }
                }
                else
                {
                    if (currentRow.ProcessId != 0)
                        _latestTcpRowData.Add(currentRow);
                }
            }
        }

        public void RefreshLables(long rcvd, long sent)
        {
            lbl_TotalRcvd.Content = Helper.UsageStringHelper(rcvd, NetworkSettings.UnitTypes.KBytepers) +
                                    String.Format("  - ({0}  Bytes)", rcvd);
            lbl_TotalSent.Content = Helper.UsageStringHelper(sent, NetworkSettings.UnitTypes.KBytepers) +
                                    String.Format("  - ({0}  Bytes)", sent);
        }

        private void HyperlinkClick(object sender, RoutedEventArgs e)
        {
            var source = sender as Hyperlink;

            if (source != null)
            {
                Process.Start(source.NavigateUri.ToString());
            }
        }

        public void SwitchTheme(Theme color)
        {
            if (color == Theme.Dark)
            {
                myGraphControl.SwitchTheme(color);
                // ...
            }
            else if (color == Theme.Light)
            {
                myGraphControl.SwitchTheme(color);
                // ...
            }
        }


        private void ChkBoxOnlyInternetCheckedUnchecked(object sender, RoutedEventArgs e)
        {
            if (isActive)
                DoUpdate();
        }
    }
}