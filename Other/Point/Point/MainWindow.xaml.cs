using System;
using System.IO;
using System.Windows;
using System.Configuration;
using System.Diagnostics;
using System.Text;

namespace Point
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Order();
            string appStartupPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\out.txt";
            if (File.Exists(appStartupPath))
            {

            }
            else
            {
                File.CreateText(appStartupPath);
            }
            double high = SystemParameters.PrimaryScreenHeight;
            double width = SystemParameters.PrimaryScreenWidth;
            Width = width;
            Top = high - Height;
            Left = 0;
            Top = 0;
            button2.Visibility = Visibility.Hidden;
            button3.Visibility = Visibility.Hidden;
            button4.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        int num = 0;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Order();
            button2.Visibility = Visibility.Visible;
            button3.Visibility = Visibility.Visible;
            button4.Visibility = Visibility.Visible;
            Random sjs = new Random();
            int number = sjs.Next(1, 30);
            num = number;
            label1.Text = number.ToString();
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            double now = double.Parse(conf.AppSettings.Settings[num.ToString()].Value.ToString());
            label2.Text = "目前分数：" + now + "分";
            switch (number)
            {
                case 1:
                    label1.Text = "董正阳";
                    break;
                case 2:
                    label1.Text = "杜天一";
                    break;
                case 3:
                    label1.Text = "陈庆瑜";
                    break;
                case 4:
                    label1.Text = "吴傲然";
                    break;
                case 5:
                    label1.Text = "冯博俊";
                    break;
                case 6:
                    label1.Text = "段思远";
                    break;
                case 7:
                    label1.Text = "罗瑞";
                    break;
                case 8:
                    label1.Text = "王朝状";
                    break;
                case 9:
                    label1.Text = "周宦";
                    break;
                case 10:
                    label1.Text = "韦春月";
                    break;
                case 11:
                    label1.Text = "罗治禹";
                    break;
                case 12:
                    label1.Text = "胡欣柔";
                    break;
                case 13:
                    label1.Text = "李霞";
                    break;
                case 14:
                    label1.Text = "王露";
                    break;
                case 15:
                    label1.Text = "田丹裕子";
                    break;
                case 16:
                    label1.Text = "王子秋";
                    break;
                case 17:
                    label1.Text = "杜羿昕";
                    break;
                case 18:
                    label1.Text = "颜玘荷";
                    break;
                case 19:
                    label1.Text = "杨业彬";
                    break;
                case 20:
                    label1.Text = "安家兴";
                    break;
                case 21:
                    label1.Text = "杨凤";
                    break;
                case 22:
                    label1.Text = "陈远";
                    break;
                case 23:
                    label1.Text = "彭开欣";
                    break;
                case 24:
                    label1.Text = "方玉洁";
                    break;
                case 25:
                    label1.Text = "张天翼";
                    break;
                case 26:
                    label1.Text = "陈启月";
                    break;
                case 27:
                    label1.Text = "孙晨云";
                    break;
                case 28:
                    label1.Text = "唐景森";
                    break;
                case 29:
                    label1.Text = "王章宇";
                    break;
                case 30:
                    label1.Text = "于子涵";
                    break;
            }            
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            double now = double.Parse(conf.AppSettings.Settings[num.ToString()].Value.ToString());
            conf.AppSettings.Settings[num.ToString()].Value = (now + 0.5).ToString();
            conf.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            label2.Text = "目前分数：" + now + "分";
            Order();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            double now = double.Parse(conf.AppSettings.Settings[num.ToString()].Value.ToString());
            conf.AppSettings.Settings[num.ToString()].Value = (now + 1).ToString();
            conf.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            label2.Text = "目前分数：" + now + "分";
            Order();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            double now = double.Parse(conf.AppSettings.Settings[num.ToString()].Value.ToString());
            conf.AppSettings.Settings[num.ToString()].Value = (now + 2).ToString();
            conf.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            label2.Text = "目前分数：" + now + "分";
            Order();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string appStartupPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\out.txt";
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            FileStream fs = new FileStream(appStartupPath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            for (int i = 1; i < 31; i++)
            {
                int niiu = int.Parse(conf.AppSettings.Settings[i.ToString()].Value.ToString());
                sw.WriteLine(i + ":" + niiu);
            }
            sw.Close();
        }

        public void Order()
        {
            double[] array = new double[30];
            string appStartupPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\out.txt";
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);            
            for (int i = 1; i < 31; i++)
            {
                array[i-1] = double.Parse(conf.AppSettings.Settings[i.ToString()].Value.ToString());
            }
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        double temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            first.Text = "First:" + array[29] + "Point(s)";
            second.Text = "Second:" + array[28] + "Point(s)";
            third.Text = "Third:" + array[27] + "Point(s)";
        }
    }
}
