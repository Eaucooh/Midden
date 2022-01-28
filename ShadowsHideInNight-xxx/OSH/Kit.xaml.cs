using System.Windows;
using System.Windows.Input;

namespace OSH
{
    /// <summary>
    /// Kit.xaml 的交互逻辑
    /// </summary>
    public partial class Kit : Window
    {
        #region 主事件
        public Kit()
        {
            InitializeComponent();
        }
        #endregion
        #region 窗体拖动
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {

            }
        }
        #endregion
        #region 防止Alt+F4组合键和Alt+Space组合键
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
        #endregion
        #region 工具箱按钮
        private void desktopClip_Click(object sender, RoutedEventArgs e)
        {
            DesktopClip.MainWindow dc = new DesktopClip.MainWindow();
            dc.Show();
        }
        #endregion

        private void fd_Click(object sender, RoutedEventArgs e)
        {
            KitX.FileDeleter file = new KitX.FileDeleter();
            file.ShowDialog();
        }

        private void MulSources_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
