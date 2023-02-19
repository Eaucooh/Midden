using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using PopEye.WPF.Animation;

namespace KitX.Controls
{
    /// <summary>
    /// ToolItem.xaml 的交互逻辑
    /// </summary>
    public partial class ToolItem : UserControl
    {
        public Core.IContract item;
        public ListBoxItem lbi;

        public ToolItem()
        {
            InitializeComponent();
        }

        public ToolItem(ref Core.IContract plugin)
        {
            InitializeComponent();
            item = plugin;
            item.SetWorkBase($"{App.ToolsBase}\\{item.GetPublisher()}\\{item.GetName()}");
        }

        public void Initialize()
        {
            Namer.Text = item.GetName();
            Publisher.Text = item.GetPublisher();
            Versioner.Text = item.GetVersion();
            Description.Text = item.GetDescribe_Simple();
            Header.Source = item.GetIcon();
        }

        public bool HasAdded = false;

        private System.Collections.Generic.List<Window> wins = new System.Collections.Generic.List<Window>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window win = item.GetWindow();
            win.Show();
            wins.Add(win);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Window win in wins)
            {
                win.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //MainWindow win = (MainWindow)Application.Current.MainWindow;
            //win.RemoveTool(ref item);
        }

        public void Show()
        {
            lbi.Visibility = Visibility.Visible;
            DoubleAnimation ani = AnimationHelper.CreateAnimation(new System.TimeSpan(0, 0, 0, 0, 300), 0, 1,
                FillBehavior.HoldEnd, AnimationHelper.EasingFunction.Cubic, EasingMode.EaseIn, 0, 0);
            BeginAnimation(OpacityProperty, ani);
        }

        public void Hide()
        {
            DoubleAnimation ani = AnimationHelper.CreateAnimation(new System.TimeSpan(0, 0, 0, 0, 300), 1, 0,
                FillBehavior.HoldEnd, AnimationHelper.EasingFunction.Cubic, EasingMode.EaseIn, 0, 0);
            ani.Completed += (x, y) =>
            {
                lbi.Visibility = Visibility.Hidden;
            };
            BeginAnimation(OpacityProperty, ani);
        }
    }
}
