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
using System.Windows.Shapes;
using System.IO;

namespace 练习
{
    /// <summary>
    /// 排行.xaml 的交互逻辑
    /// </summary>
    public partial class 排行 : Window
    {
        public 排行()
        {
            InitializeComponent();
        }

        private void yingxiongbang_Loaded(object sender, RoutedEventArgs e)
        {
            
            StreamReader heroReader = new StreamReader("../../file/初级记录.txt");
            string rr = heroReader.ReadToEnd();
            string[] heroList= rr.Split(':');
            heroReader.Close();

            StreamReader timeRead = new StreamReader("../../file/chuji.txt");
            string rad = timeRead.ReadToEnd();
            string[] timelist = rad.Split(';');
            timeRead.Close();
            for (int i=0;i<timelist.Length-i;i++)
            {
                for (int j=0;j<timelist.Length-i-1;j++)
                {
                    if (Convert.ToInt32(timelist[j])<Convert.ToInt32(timelist[j+1]))
                    {
                        string n=timelist[j];
                        timelist[j] = timelist[j + 1];
                        timelist[j + 1] = n;
                        string m = heroList[j];
                        heroList[j] = heroList[j + 1];
                        heroList[j + 1] = m;
                    }
                }
            }
            for (int i=0;i<heroList.Length;i++)
            {
                hero.Text += heroList[i]+"\r\n";
                hp.Text += heroList[i] + "\r\n";
            }
        }
    }
}
