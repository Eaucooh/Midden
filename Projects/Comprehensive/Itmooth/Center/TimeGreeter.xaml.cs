using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Center
{
    /// <summary>
    /// TimeGreeter.xaml 的交互逻辑
    /// </summary>
    public partial class TimeGreeter : UserControl
    {
        public TimeGreeter()
        {
            InitializeComponent();
            Greet();
            DispatcherTimer timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMinutes(1)
            };
            timer.Tick += (x, y) =>
            {
                Greet();
            };
        }

        private void Greet()
        {
            var target = Greeting;
            string UserName = Environment.UserName;
            string Sign = "，";
            string[] ForeGreeting = new string[6];
            ForeGreeting[0] = "你好";
            ForeGreeting[1] = "早上好";
            ForeGreeting[2] = "中午好";
            ForeGreeting[3] = "下午好";
            ForeGreeting[4] = "晚上好";
            ForeGreeting[5] = "夜深了";
            string[] BackGreeting = new string[6];
            BackGreeting[0] = "见到你是我的荣幸。";
            BackGreeting[1] = "又是活力满满的一天！";
            BackGreeting[2] = "要不要休息一下？";
            BackGreeting[3] = "是时候来一杯热咖啡了。";
            BackGreeting[4] = "肚子空了吧？";
            BackGreeting[5] = "注意休息哦~";
            int clocks = DateTime.Now.Hour;
            int partID = PartTime(clocks);
            /*
             *partID:区段标记
             * 0.未知[你好]
             * 1.早上好,USERNAME,又是活力满满的一天！6:00~12:00
             * 2.中午好,USERNAME,要不要休息一下？12:00~14:00
             * 3.下午好,USERNAME,是时候来一杯热咖啡了！14:00~18:00
             * 4.晚上好,USERNAME,肚子空了吧？18:00~22:00
             * 5.夜深了,USERNAME,注意休息哦！22:00~6:00
             */
            target.Text = ForeGreeting[partID] + Sign + UserName + Sign + BackGreeting[partID];
        }

        private int PartTime(int clocks)
        {
            if (clocks >= 6 && clocks < 12)
            {
                return 1;
            }
            else if (clocks >= 12 && clocks < 14)
            {
                return 2;
            }
            else if (clocks >= 14 && clocks < 18)
            {
                return 3;
            }
            else if (clocks >= 14 && clocks < 18)
            {
                return 4;
            }
            else if (clocks >= 14 && clocks < 18)
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }
    }
}
