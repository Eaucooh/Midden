using Bll;
using Model;
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

namespace Brainscape_WPF
{
    /// <summary>
    /// EditMe.xaml 的交互逻辑
    /// </summary>
    public partial class EditMe : Window
    {
        public EditMe()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.CanMinimize;
        }
        public string ManagerID;
        public string ManagerName;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != "" && textBox1.Text != "")
            {
               
                ManagerMessage m = new ManagerMessage();
                m.ManagerName = textBox1.Text;
                m.ManagerPassword = textBox.Text;
                m.ManagerID = ManagerID;                
                ManagerMessageBll.UpdateManager(m);
                ManagerName = textBox1.Text;
                this.Close();
            }
            else
            {
                label2.Content = "*请填写完整！";
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
