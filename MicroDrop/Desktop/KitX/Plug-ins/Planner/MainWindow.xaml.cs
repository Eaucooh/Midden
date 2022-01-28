using KitX.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Planner
{
    /// <summary>
    /// MainWindowWindow.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IContract))]
    public partial class MainWindow : Window, IContract
    {
        System.Windows.Forms.Timer ti = new System.Windows.Forms.Timer();

        public MainWindow()
        {
            InitializeComponent();

            Loaded += (x, y) =>
            {
                ti = new System.Windows.Forms.Timer()
                {
                    Interval = (int)(0.2 * 1000)
                };
                ti.Tick += (m, n) =>
                {
                    TimeViewer.SelectedTime = DateTime.Now;
                };
                ti.Start();
            };

            Closing += (x, y) =>
            {
                ti.Stop();
                ti.Dispose();
            };
        }

        #region 接口

        private string WorkBase = null;

        public void SetWorkBase(string path)
        {
            WorkBase = path;
            if (!Directory.Exists(WorkBase))
            {
                Directory.CreateDirectory(WorkBase);
            }
        }

        public string GetDescribe_Complex()
        {
            return "闹钟啊、计时器啊、任务规划啊，还有什么跟计划有关的都在这呐(*･ω-q)";
        }

        public string GetDescribe_Simple()
        {
            return "你就是计划通吗？JOJO|ू･ω･`)";
        }

        public string GetHelpLink()
        {
            return "http://docs.catrol.cn/planner/";
        }

        public string GetHostLink()
        {
            return "http://www.catrol.cn/";
        }

        public BitmapImage GetIcon()
        {
            return FindResource("Icon") as BitmapImage;
        }

        public Languages GetLang()
        {
            return Languages.zh_CN;
        }

        public string GetName()
        {
            return "Planner";
        }

        public string GetPublisher()
        {
            return "Catrol";
        }

        public string GetVersion()
        {
            return "Beta";
        }

        public Window GetWindow()
        {
            MainWindow win = new MainWindow()
            {
                Width = 1000,
                Height = 800,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ShowActivated = true,
                Title = "Planner"
            };
            return win;
        }

        public void SetTheme(KitX.Core.Theme tm)
        {

        }

        private readonly QuickView Quicker = new QuickView();

        public UserControl GetQuickView()
        {
            Quicker.win = win;
            if (started)
            {
                return Quicker;
            }
            else
            {
                return null;
            }
        }

        MainWindow win;
        bool started = false;

        public void Start()
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

        public void End()
        {
            win.Close();
            started = false;
        }

        public string GetFileName()
        {
            return "Planner.dll";
        }

        public Tags GetTag()
        {
            return Tags.Normal;
        }
        #endregion

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
