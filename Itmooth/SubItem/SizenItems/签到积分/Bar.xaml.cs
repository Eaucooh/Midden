using System.Windows;
using System.Windows.Controls;

namespace 签到积分
{
    /// <summary>
    /// Bar.xaml 的交互逻辑
    /// </summary>
    public partial class Bar : UserControl
    {
        public bool regist = false;
        public Bar()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            regist = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            regist = false;
        }

        private void decrease(object sender, RoutedEventArgs e)
        {
            if(progress.Value>0)
            {
                progress.Value -= 10;
            }
        }

        private void increase(object sender, RoutedEventArgs e)
        {
            if (progress.Value < 100)
            {
                progress.Value += 10;
            }
        }

        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            option.Visibility = Visibility.Visible;
            label.Visibility = Visibility.Visible;
        }

        private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            option.Visibility = Visibility.Hidden;
            label.Visibility = Visibility.Hidden;
        }
    }
}
