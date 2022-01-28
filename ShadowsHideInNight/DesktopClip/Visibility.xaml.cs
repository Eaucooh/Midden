using System;
using System.Windows;
using System.Windows.Input;

namespace DesktopClip
{
    /// <summary>
    /// Visibility.xaml 的交互逻辑
    /// </summary>
    public partial class Visibility : Window
    {
        public Visibility()
        {
            InitializeComponent();
            double X = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            double Y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
            Top = 130;
            Left = X - Width - 80;
        }

        private void dragMove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {
                
            }
        }
    }
}
