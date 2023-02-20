using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using iphelper;
using Image = System.Windows.Controls.Image;

namespace netwatch.IpTable
{
    public class ProcessInfo
    {
        public ProcessInfo()
        {
            ProcessName = "processName";
            ProcessPath = "processPath";
            ProcessId = 0;
            ProcessIcon = new Image();
        }

        public ProcessInfo(string processName, int processId, string processPath, Image processIcon)
        {
            ProcessName = processName;
            ProcessPath = processPath;
            ProcessId = processId;
            ProcessIcon = processIcon;
        }

        public ProcessInfo(string processName, int processId, string processPath)
        {
            ProcessName = processName;
            ProcessPath = processPath;
            ProcessId = processId;
            ProcessIcon = GetImage(ProcessPath);
        }

        public ProcessInfo(string processName, int processId)
        {
            ProcessName = processName;
            ProcessPath = iphelper.Helper.GetProcessFullPath(processId);
            ProcessId = processId;
            ProcessIcon = GetImage(ProcessPath);
        }

        public ProcessInfo(int processId)
        {
            ProcessName = iphelper.Helper.GetProcessProcessName(processId);
            ProcessPath = iphelper.Helper.GetProcessFullPath(processId);
            ProcessId = processId;
            ProcessIcon = GetImage(ProcessPath);
        }

        public string ProcessName { get; set; }

        public string ProcessPath { get; set; }

        public Int32 ProcessId { get; set; }

        public Image ProcessIcon { get; set; }

        private Image GetImage(string path)
        {
            Image img;
            try
            {
                if (path == "System" || String.IsNullOrEmpty(path) || path.ToLower() == "null")
                {
                    img = new Image
                              {
                                  Source =
                                      new BitmapImage(new Uri("/netwatch;component/Images/graybitmap.bmp",
                                                              UriKind.Relative)),
                                  Height = 16,
                                  Width = 16
                              };
                }
                else
                {
                    Icon newIcon = Icon.ExtractAssociatedIcon(path);

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
            }
            catch (Exception)
            {
                img = new Image
                          {
                              Source =
                                  new BitmapImage(new Uri("/netwatch;component/Images/graybitmap.bmp",
                                                          UriKind.Relative)),
                              Height = 16,
                              Width = 16
                          };
                Trace.WriteLine("Something Went Wrong!");
            }
            return img;
        }
    }
}