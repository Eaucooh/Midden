using System;
using System.Collections.Generic;
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
using System.Windows.Forms;
using System.Threading;

namespace WpfApplication3
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            reflashTime();
        }
        public void reflashTime()//动态时间线程
        {
            new Thread (() =>
            {
                while (true)
                {
                    try
                    {
                        this.Dispatcher.BeginInvoke(
                            new Action(() => {
                                myDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");//字符串的传递
                                myTime.Text = DateTime.Now.ToString("HH:mm:ss");
                            }));
                    }
                    catch
                    {

                    }
                    Thread.Sleep(1000);
                }
            })
            { IsBackground = true }.Start();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 win1= new Window1 ();  //Login为窗口名，把要跳转的新窗口实例化
            win1.ShowDialog();   //打开新窗口，并悬停旧窗口
            //this.Close();  //关闭当前窗口
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            Window2 win2 = new Window2();  //Login为窗口名，把要跳转的新窗口实例化
            win2.ShowDialog();  //Login为窗口名，把要跳转的新窗口实例化
             //打开新窗口，并悬停旧窗口
            //this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = System.Windows.MessageBox.Show("您确定要退出程序？", "系统退出", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (r != MessageBoxResult.OK)
            {
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            record record =new WpfApplication3.record();
            record.ShowDialog(); 
        }
    }
}
