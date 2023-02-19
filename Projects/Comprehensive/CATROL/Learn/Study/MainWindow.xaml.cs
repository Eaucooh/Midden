using AddInView;
using System;
using System.AddIn.Hosting;
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

namespace Study
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.CurrentDirectory;
            AddInStore.Update(path);
            //AddInStore.Rebuild(path);
            //AddInStore.RebuildAddIns(path);
            IList<AddInToken> list = AddInStore.FindAddIns(typeof(TestAddInView), path);
            listAddIns.ItemsSource = list;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
