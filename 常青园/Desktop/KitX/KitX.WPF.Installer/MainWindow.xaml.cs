using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KitX.WPF.Installer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        CubicEase ce = new CubicEase()
        {
            EasingMode = EasingMode.EaseOut
        };
        DoubleAnimation ani = new DoubleAnimation()
        {
            From = 0,
            To = 1,
            Duration = new Duration(new TimeSpan(0, 0, 0, 0, 1200)),
            FillBehavior = FillBehavior.HoldEnd
        };
        ThicknessAnimation ani2 = new ThicknessAnimation()
        {
            From = new Thickness(0),
            To = new Thickness(0, 0, 0, 160),
            Duration = new Duration(new TimeSpan(0, 0, 0, 0, 800)),
            FillBehavior = FillBehavior.HoldEnd
        };
        ThicknessAnimation ani4 = new ThicknessAnimation()
        {
            From = new Thickness(0,120,0,0),
            To = new Thickness(0, 120, 0, 40),
            Duration = new Duration(new TimeSpan(0, 0, 0, 0, 800)),
            FillBehavior = FillBehavior.HoldEnd
        };
        ThicknessAnimation ani3 = new ThicknessAnimation()
        {
            From = new Thickness(0),
            To = new Thickness(0, 0, 0, 30),
            Duration = new Duration(new TimeSpan(0, 0, 0, 0, 800)),
            FillBehavior = FillBehavior.HoldEnd
        };

        RunType rt = RunType.Install;

        public MainWindow()
        {
            InitializeComponent();
            switch (rt)
            {
                case RunType.Install:
                    panel_uninstall.Visibility = Visibility.Hidden;
                    break;
                case RunType.Uninstall:
                    panel_install.Visibility = Visibility.Hidden;
                    break;
            }
            MouseDown += (x, y) =>
            {
                if (y.LeftButton == MouseButtonState.Pressed)
                {
                    DragMove();
                }
            };
            CorrectOpacity();
            BeginAnimation(OpacityProperty, ani);
            head.BeginAnimation(OpacityProperty, ani);
            SizeChanged += (x, y) =>
            {
                head.Width = Width / 5 * 2;
                head.Height = Height / 3;
            };
            new Thread(() =>
            {
                Thread.Sleep(500);
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    head.BeginAnimation(MarginProperty, ani2);
                    headTxt.BeginAnimation(OpacityProperty, ani);
                }));
                Thread.Sleep(1000);
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    headTxt.BeginAnimation(MarginProperty, ani4);
                    panel.BeginAnimation(OpacityProperty, ani);
                    panel.BeginAnimation(MarginProperty, ani3);
                }));
                Thread.Sleep(500);
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    btn_ins.BeginAnimation(OpacityProperty, ani);
                }));
            }).Start();
        }

        private enum RunType
        {
            Install, Uninstall
        }

        private void CorrectOpacity()
        {
            Opacity = 0;
            head.Opacity = 0;
            panel.Opacity = 0;
            btn_ins.Opacity = 0;
            headTxt.Opacity = 0;
            ani.EasingFunction = ce;
            ani2.EasingFunction = ce;
            ani3.EasingFunction = ce;
            ani4.EasingFunction = ce;
            FlushBack();
        }

        private void FlushBack()
        {
            GetSysColor.DwmGetColorizationColor(out int pcrColorization, out _);
            backer.Background = new SolidColorBrush(GetSysColor.Get_Color(pcrColorization));
        }
    }
}
