using System.Media;
using System.Windows;

namespace Planner
{
    /// <summary>
    /// AlertWin.xaml 的交互逻辑
    /// </summary>
    public partial class AlertWin : Window
    {
        public AlertWin(string tiShow, int musicIndex)
        {
            InitializeComponent();
            nowTi.Text = tiShow;

            Loaded += (x, y) =>
            {
                SoundPlayer player = new SoundPlayer((musicIndex == 0) ? @"C:\Windows\Media\Windows Unlock.wav" : @"C:\Windows\Media\Windows Logon.wav");
                player.Play();
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ani = new PopEye.WPF.Animation.AnimationHelper().CreateDoubleAnimation(new System.TimeSpan(0, 0, 0, 0, 500), 1, 0, System.Windows.Media.Animation.FillBehavior.HoldEnd,
                PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0);
            ani.Completed += (x, y) =>
            {
                Close();
            };
            rg.BeginAnimation(OpacityProperty, ani);
        }
    }
}
