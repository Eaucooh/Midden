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
using System.Xml;

namespace TeamC
{
    /// <summary>
    /// Test.xaml 的交互逻辑
    /// </summary>
    public partial class Test : Window
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string contactsSavePath = AppDomain.CurrentDomain.BaseDirectory + "\\conf\\contacts.xml";
                XmlDocument ctats = new XmlDocument();
                ctats.Load(contactsSavePath);
                XmlNode root = ctats.DocumentElement;
                foreach (XmlNode xn in root.ChildNodes)
                {
                    foreach (XmlNode attribute in xn)
                    {
                        MessageBox.Show(attribute.InnerText);
                    }
                }
            }
            catch (Exception u)
            {
                MessageBox.Show(u.Message + u.ToString());
            }
        }
    }
}
