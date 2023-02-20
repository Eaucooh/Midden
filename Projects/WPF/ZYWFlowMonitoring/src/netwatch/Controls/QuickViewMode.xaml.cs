using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using MahApps.Metro;
using iphelper;
using netwatch.IpTable;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;
using Image = System.Windows.Controls.Image;

namespace netwatch.Controls
{
    /// <summary>
    /// Interaction logic for QuickViewMode.xaml
    /// </summary>
    public partial class QuickViewMode
    {
        private readonly List<Int32> _pids;
        public DispatcherTimer GlobalUpdateTimer;

        public ObservableCollection<TaskItemQuick> Obdata = new ObservableCollection<TaskItemQuick>();

        public QuickViewMode()
        {
            InitializeComponent();
            _pids = new List<Int32>();
            GlobalUpdateTimer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            GlobalUpdateTimer.Tick += GlobalUpdateTimerTick;
        }

        public ObservableCollection<TaskItemQuick> GetAllData
        {
            get { return Obdata; }
        }

        public void Start()
        {
            GlobalUpdateTimer.Start();
            GlobalUpdateTimerTick(GlobalUpdateTimer, new EventArgs());
        }

        public void Stop()
        {
            GlobalUpdateTimer.Stop();
        }

        public void KillSelectedTask()
        {
            if (lstBox.SelectedIndex != -1)
            {
                try
                {
                    var item = lstBox.SelectedItem as TaskItemQuick;
                    if (item != null)
                    {
                        if (iphelper.Helper.TaskKill(item.ProcessId) == 0)
                            Obdata.Remove(item);
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(
                        "Sending Termination Signal failed due the following reason :"
                        + Environment.NewLine
                        + String.Format("Error Source : {0}, Error Message :{1}, Target Site Name:{2}",
                                        exp.Source,
                                        exp.Message
                                        , exp.TargetSite.Name)
                        , DateTime.Now + "Operation Exception",
                        MessageBoxButton.OK,
                        MessageBoxImage.Stop);
                    Trace.WriteLine("Something Went Wrong! :" + exp.Message);
                }
            }
        }

        private void MenuItemShowPropertiesDialogClick(object sender, RoutedEventArgs e)
        {
            if (lstBox.SelectedIndex != -1)
            {
                try
                {
                    var item = lstBox.SelectedItem as TaskItemQuick;
                    if (item != null)
                    {
                        string pAddress = iphelper.Helper.GetProcessFullPath(item.ProcessId);
                        Win32Functions.ShowFileProperties(pAddress);
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(
                        "Unable to show Properties dialog due the following reason :"
                        + Environment.NewLine
                        + String.Format("Error Source : {0}, Error Message :{1}, Target Site Name:{2}",
                                        exp.Source,
                                        exp.Message
                                        , exp.TargetSite.Name)
                        , "Operation Exception",
                        MessageBoxButton.OK,
                        MessageBoxImage.Stop);
                    Trace.WriteLine("Something Went Wrong! :" + exp.Message);
                }
            }
        }

        private void MnuItemSearchOnline(object sender, RoutedEventArgs e)
        {
            if (lstBox.SelectedIndex != -1)
            {
                try
                {
                    var item = lstBox.SelectedItem as TaskItemQuick;
                    if (item != null)
                    {
                        string pAddress = "http://www.bing.com/search?q=" + item.ProcessName + ".exe";
                        Process.Start(pAddress);
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(
                        "Opening default Web-Browser  failed due the following reason :"
                        + Environment.NewLine
                        + String.Format("Error Source : {0}, Error Message :{1}, Target Site Name:{2}",
                                        exp.Source,
                                        exp.Message
                                        , exp.TargetSite.Name)
                        , DateTime.Now + "Operation Exception",
                        MessageBoxButton.OK,
                        MessageBoxImage.Stop);
                    Trace.WriteLine("Something Went Wrong! :" + exp.Message);
                }
            }
        }

        private void MnuItemOpenFileLocation(object sender, RoutedEventArgs e)
        {
            if (lstBox.SelectedIndex != -1)
            {
                try
                {
                    var item = lstBox.SelectedItem as TaskItemQuick;
                    if (item != null)
                    {
                        string pAddress = iphelper.Helper.GetProcessFullPath(item.ProcessId);
                        string args = string.Format("/Select, {0}", pAddress);

                        var pfi = new ProcessStartInfo("explorer.exe", args);
                        Process.Start(pfi);
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(
                        "Unable to open directory due the following reason :"
                        + Environment.NewLine
                        + String.Format("Error Source : {0}, Error Message :{1}, Target Site Name:{2}",
                                        exp.Source,
                                        exp.Message
                                        , exp.TargetSite.Name)
                        , DateTime.Now + "Operation Exception",
                        MessageBoxButton.OK,
                        MessageBoxImage.Stop);
                    Trace.WriteLine("Something Went Wrong! :" + exp.Message);
                }
            }
        }

        private void MnuItemKillSelectedProcess(object sender, RoutedEventArgs e)
        {
            KillSelectedTask();
        }

        private void GlobalUpdateTimerTick(object sender, EventArgs e)
        {
            var t = new Thread(UpdateTcpTables);
            t.Start();

            RemoveOldData();
            StoringData();
        }

        private void RemoveOldData()
        {
            List<TaskItemQuick> removeList = Obdata.Where(item => !_pids.Contains(item.ProcessId)).ToList();
            foreach (TaskItemQuick item in removeList)
            {
                Obdata.Remove(item);
            }
        }

        private void StoringData()
        {
            var getClone = new List<Int32>(_pids);
            foreach (int pid in getClone)
            {
                if (Obdata.Any(item => item.ProcessId == pid))
                {
                    // We Already Have this PID!

                    //Console.Write(pid);
                }
                else
                {
                    // New Process Found!
                    string processName = iphelper.Helper.GetProcessProcessName(pid);
                    if (processName.ToLower() == "null" ||
                        processName.ToLower() == "system" && String.IsNullOrEmpty(processName))
                        continue;

                    string processPath = iphelper.Helper.GetProcessFullPath(pid);
                    if (processPath.ToLower() == "null" && String.IsNullOrEmpty(processPath))
                        continue;

                    Image img;
                    try
                    {
                        if (processPath == "System")
                        {
                            img = new Image();
                        }
                        else
                        {
                            Icon newIcon = Icon.ExtractAssociatedIcon(processPath);

                            Bitmap bitmap = newIcon.ToBitmap();
                            IntPtr hBitmap = bitmap.GetHbitmap();

                            ImageSource wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero,
                                                                                          Int32Rect.Empty,
                                                                                          BitmapSizeOptions.
                                                                                              FromEmptyOptions
                                                                                              ());
                            img = new Image
                                      {
                                          Source = wpfBitmap,
                                          Stretch = Stretch.Uniform,
                                          Height = 16,
                                          Width = 16
                                      };
                        }
                        Obdata.Add(new TaskItemQuick(img, processName, pid));
                    }
                    catch (Exception exp)
                    {
                        Trace.WriteLine("Something Went Wrong!" + Environment.NewLine
                                        +
                                        String.Format("Error Source : {0}, Error Message :{1}, Target Site Name:{2}",
                                                      exp.Source, exp.Message, exp.TargetSite.Name),
                                        DateTime.Now + "Operation Exception");
                    }
                }
            }
        }

        private void UpdateTcpTables()
        {
            TcpTable eTcpData = ManagedIpHelper.GetExtendedTcpTable(true);
            var currentList = new List<Int32>();

            foreach (TcpRow currentRow in eTcpData.Where(currentRow => !currentList.Contains(currentRow.ProcessId)))
            {
                if (currentRow.ProcessId != 0 && currentRow.ProcessId != 4)
                    currentList.Add(currentRow.ProcessId);
            }

            List<int> removeList = _pids.Where(item => !currentList.Contains(item)).ToList();
            foreach (int item in removeList)
            {
                _pids.Remove(item);
            }
            foreach (int item in currentList.Where(item => !_pids.Contains(item)))
            {
                _pids.Add(item);
            }
        }


        public void SwitchTheme(Theme color)
        {
            if (color == Theme.Dark)
            {
                var brush = new SolidColorBrush(Color.FromRgb(37, 37, 37));
                Background = brush;
                lstBox.Background = brush;
                lstBox.Foreground = Brushes.White;
            }
            else if (color == Theme.Light)
            {
                Background = Brushes.White;
                lstBox.Background = Brushes.White;
                lstBox.Foreground = Brushes.Black;
            }
        }
    }
}