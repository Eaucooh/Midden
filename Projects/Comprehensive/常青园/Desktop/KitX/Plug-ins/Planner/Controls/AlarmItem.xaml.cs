using System;
using System.Windows;
using System.Windows.Controls;

namespace Planner.Controls
{
    /// <summary>
    /// AlarmItem.xaml 的交互逻辑
    /// </summary>
    public partial class AlarmItem : UserControl
    {
        public StackPanel container;

        public bool GetSelected() => (bool)selectful.IsChecked;

        public bool GetEnable() => (bool)TimeEnable.IsChecked;

        public void Select() => selectful.IsChecked = true;

        public void UnSelect() => selectful.IsChecked = false;

        public DateTime TarTi;

        public string ClockTime { get; set; }

        public bool ClockEnable { get; set; }

        public AlarmItem() => InitializeComponent();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ct">要显示的时间</param>
        /// <param name="ce">是否已经启用</param>
        public AlarmItem(string ct, bool ce)
        {
            InitializeComponent();
            ClockTime = ct; ClockEnable = ce;            
        }

        PopEye.WPF.Animation.AnimationHelper ah = new PopEye.WPF.Animation.AnimationHelper();

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TimeBox.Text = ClockTime;
            TimeEnable.IsChecked = ClockEnable;
            DelBtn.Click += (x, y) =>
            {
                DelThis();
            };
        }

        public void TurnSelecterVisible()
        {
            if (selectful.Width == 0)
            {
                selectful.BeginAnimation(WidthProperty, ah.CreateDoubleAnimation(new System.TimeSpan(0, 0, 0, 0, 500), 0, 16,
                     System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0));
            }
            else
            {
                selectful.BeginAnimation(WidthProperty, ah.CreateDoubleAnimation(new System.TimeSpan(0, 0, 0, 0, 500), 16, 0,
                     System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0));
            }
        }

        public void UnVisibleSelector()
        {
            if (!(selectful.Width == 0))
            {
                selectful.BeginAnimation(WidthProperty, ah.CreateDoubleAnimation(new System.TimeSpan(0, 0, 0, 0, 500), 16, 0, System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0));
            }
        }

        public void TurnEnable() => ClockEnable = !ClockEnable;

        public delegate void LeftActived();
        public event LeftActived LeftConfirmed;

        public delegate void RightActived();
        public event RightActived RightConfirmed;

        public void DelThis()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                System.Windows.Media.Animation.DoubleAnimation da = ah.CreateDoubleAnimation(new System.TimeSpan(0, 0, 0, 0, 500), 1, 0,
                     System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0);
                System.Windows.Media.Animation.DoubleAnimation da2 = ah.CreateDoubleAnimation(new System.TimeSpan(0, 0, 0, 0, 500), 60, 0,
                     System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, System.Windows.Media.Animation.EasingMode.EaseOut, 0, 0);
                da.Completed += (m, n) => container.Children.Remove(this);
                BeginAnimation(OpacityProperty, da);
                BeginAnimation(HeightProperty, da2);
            }));
        }
    }
}
