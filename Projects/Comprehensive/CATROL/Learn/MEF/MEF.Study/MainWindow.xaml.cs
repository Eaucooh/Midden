using MEFAddIn.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
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

namespace MEF.Study
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string path = Environment.CurrentDirectory;
            var catalog = new DirectoryCatalog(path + "\\Plug-ins", "*.dll");

            using (CompositionContainer container = new CompositionContainer(catalog))
            {
                IEnumerable<IContract> sub = container.GetExportedValues<IContract>();

                foreach (var item in sub)
                {
                    TabControl1.Items.Add(new TabItem()
                    {
                        Header = item.ToString(),
                        Content = item.GetElement()
                    });
                }
            }
        }
    }
}
