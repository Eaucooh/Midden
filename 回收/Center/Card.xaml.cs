using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Center
{
    /// <summary>
    /// Card.xaml 的交互逻辑
    /// </summary>
    public partial class Card : UserControl
    {
        public string title;
        public string imgUri;

        public Card()
        {
            InitializeComponent();
            Loaded += (x, y) =>
              {
                  mom.Header = title;
                  cover.Source = new BitmapImage(new Uri(imgUri, UriKind.Absolute));
              };
        }

        private void UserControl_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            cover.Margin = new System.Windows.Thickness(0, 0, 0, 0);
        }

        private void UserControl_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            cover.Margin = new System.Windows.Thickness(5, 5, 5, 5);
        }
    }
}
