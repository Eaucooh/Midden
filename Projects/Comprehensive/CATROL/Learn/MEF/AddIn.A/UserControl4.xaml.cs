using MEFAddIn.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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

namespace AddIn.A
{
    /// <summary>
    /// UserControl4.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IContract))]
    public partial class UserControl4 : UserControl, IContract
    {
        public UserControl4()
        {
            InitializeComponent();
        }

        public FrameworkElement GetElement()
        {
            return new UserControl4();
        }
    }
}
