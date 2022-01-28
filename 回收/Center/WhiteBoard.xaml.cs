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

namespace Center
{
    /// <summary>
    /// WhiteBoard.xaml 的交互逻辑
    /// </summary>
    public partial class WhiteBoard : Window
    {
        public WhiteBoard()
        {
            InitializeComponent();
        }

        private void iseditmode_Checked(object sender, RoutedEventArgs e)
        {
            board.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void iseditmode_Unchecked(object sender, RoutedEventArgs e)
        {
            board.EditingMode = InkCanvasEditingMode.None;
        }

        private void more_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
