using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Center
{
    /// <summary>
    /// Timer.xaml 的交互逻辑
    /// </summary>
    public partial class Timer : UserControl
    {
        public Timer()
        {
            InitializeComponent();
            Time.Text = DateTime.Now.ToString("HH:mm");
            DispatcherTimer dt = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(30)
            };
            dt.Tick += (x, y) =>
            {
                Time.Text = DateTime.Now.ToString("HH:mm");
            };
            dt.Start();
        }
    }
}
