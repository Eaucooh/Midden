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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using PopEye.WPF.Animation;
using KitX.Helper;

namespace KitX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowHelper mwh = new MainWindowHelper();

        public MainWindow()
        {
            InitializeComponent();
            mwh.EventsHandler(this);
            mwh.Init(this);
            Init();
        }

        public void Init()
        {

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void KeepToper_Checked(object sender, RoutedEventArgs e) => Topmost = true;

        private void KeepToper_Unchecked(object sender, RoutedEventArgs e) => Topmost = false;

        private void ShowControl(FrameworkElement? control, double h)
        {
            var ani1 = AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 350), 0, h,
                FillBehavior.HoldEnd, AnimationHelper.EasingFunction.Circle, EasingMode.EaseOut, 0, 0);
            var ani2 = AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 350), 0, 1,
                FillBehavior.HoldEnd, AnimationHelper.EasingFunction.Circle, EasingMode.EaseOut, 0, 0);
            control?.BeginAnimation(HeightProperty, ani1);
            control?.BeginAnimation(OpacityProperty, ani2);
        }

        private void HideControl(FrameworkElement? control)
        {
            var ani1 = AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 350), control.Height, 0,
                FillBehavior.HoldEnd, AnimationHelper.EasingFunction.Circle, EasingMode.EaseOut, 0, 0);
            var ani2 = AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 350), 1, 0,
                FillBehavior.HoldEnd, AnimationHelper.EasingFunction.Circle, EasingMode.EaseOut, 0, 0);
            control?.BeginAnimation(HeightProperty, ani1);
            control?.BeginAnimation(OpacityProperty, ani2);
        }
    }
}
