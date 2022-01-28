using System.Windows;
using System.Windows.Input;

namespace OSH
{
    /// <summary>
    /// QualityTest.xaml 的交互逻辑
    /// </summary>
    public partial class QualityTest : Window
    {
        public QualityTest()
        {
            InitializeComponent();
            testingGrid.Visibility = Visibility.Hidden;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Alt && e.SystemKey == Key.Space)
            {
                e.Handled = true;
            }
            else if (Keyboard.Modifiers == ModifierKeys.Alt && e.SystemKey == Key.F4)
            {
                e.Handled = true;
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        private void StartTest_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("是否立即对" + chosen.Text + "进行性能测试？", "开始执行", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk) == MessageBoxResult.OK)
            {
                startGrid.Visibility = Visibility.Hidden;
                testingGrid.Visibility = Visibility.Visible;
                QualityTestStart();
            }
        }

        private void QualityTestStart()
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            startGrid.Visibility = Visibility.Visible;
            testingGrid.Visibility = Visibility.Hidden;
        }

        private void Retest_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("是否重新对" + chosen.Text + "进行性能测试？", "开始执行", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk) == MessageBoxResult.OK)
            {
                QualityTestStart();
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
