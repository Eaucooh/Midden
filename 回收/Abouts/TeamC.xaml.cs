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

namespace Abouts
{
    /// <summary>
    /// TeamC.xaml 的交互逻辑
    /// </summary>
    public partial class TeamC : Window
    {
        public TeamC()
        {
            InitializeComponent();
        }

        public TeamC(int option)
        {
            InitializeComponent();
            switch (option)
            {
                case 0:
                    about.Visibility = Visibility.Visible;
                    docs.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    about.Visibility = Visibility.Hidden;
                    docs.Visibility = Visibility.Visible;
                    break;
                default:
                    Close();
                    break;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            about.Visibility = Visibility.Hidden;
            docs.Visibility = Visibility.Visible;
        }
    }
}
