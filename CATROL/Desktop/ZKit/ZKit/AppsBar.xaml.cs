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

namespace ZKit
{
    /// <summary>
    /// AppsBar.xaml 的交互逻辑
    /// </summary>
    public partial class AppsBar : Window
    {
        public bool CanCloseNow = false;

        public AppsBar()
        {
            InitializeComponent();

            Closing += (x, y) =>
            {
                if (!CanCloseNow)
                {
                    y.Cancel = true;
                }
            };
        }

        public void RestoreLocationAndScale()
        {
            Width = App.WorkAreaWidth / 3;
            Height = App.WorkAreaHeight / 3 * 2;
            Top = (App.ScreenHeight - Height) / 2;
            Left = App.WorkAreaWidth - Width + (Width - Backgrounder.Width) / 2;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            RestoreLocationAndScale();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            WindowState = WindowState.Normal;
            Show();
            RestoreLocationAndScale();
        }

        private void Closer_Click(object sender, RoutedEventArgs e)
        {
            CanCloseNow = true;
            Close();
        }

        private void OpenSettings_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}