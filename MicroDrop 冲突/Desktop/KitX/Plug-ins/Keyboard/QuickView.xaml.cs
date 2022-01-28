using System.Windows;
using System.Windows.Controls;

namespace Keyboard
{
    /// <summary>
    /// QuickView.xaml 的交互逻辑
    /// </summary>
    public partial class QuickView : UserControl
    {
        public QuickView()
        {
            InitializeComponent();
        }

        private void SendKey(object sender, RoutedEventArgs e) => System.Windows.Forms.SendKeys.SendWait((sender as FrameworkElement).Tag.ToString());
    }
}
