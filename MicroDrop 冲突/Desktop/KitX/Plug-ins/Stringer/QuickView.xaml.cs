using System.Windows;
using System.Windows.Controls;

namespace Stringer
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

        public Main win = null;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GO(Sourcer.Text);
        }

        public void GO(string content)
        {
            if (win != null)
            {
                if (win.Visibility == Visibility.Hidden)
                {
                    win.Visibility = Visibility.Visible;
                }
                win.Pager.SelectedIndex = 2;
                win.Format_Source.Text = content;
            }
            else
            {
                win = new Main();
                win.Show();
                win.Pager.SelectedIndex = 2;
                win.Format_Source.Text = content;
            }
        }
    }
}
