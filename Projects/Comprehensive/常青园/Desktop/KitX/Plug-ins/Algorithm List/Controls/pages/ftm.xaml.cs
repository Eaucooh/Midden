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

namespace Algorithm_List.Controls.pages
{
    /// <summary>
    /// ftm.xaml 的交互逻辑
    /// </summary>
    public partial class ftm : Page
    {
        public ftm()
        {
            InitializeComponent();
        }

        double v = 5, h = 100, g = 9.8;

        private void MenuItem_Click(object sender, RoutedEventArgs e) => draw();

        private void Clean(object sender, RoutedEventArgs e) => canv.Children.Clear();

        private void draw()
        {
            if (double.TryParse(vBox.Text, out v) && double.TryParse(gBox.Text, out g) && double.TryParse(sBox.Text, out double size))
            {
                int s = 1;
                for (double t = 0; t < ActualWidth; t = t + 0.1)
                {
                    h = 0.5 * g * t * t;
                    if (h > ActualHeight + 10)
                    {
                        break;
                    }
                    Ellipse e = new Ellipse()
                    {
                        Width = size,
                        Height = size,
                        Stroke = new SolidColorBrush()
                        {
                            Color = Color.FromRgb(255, 255, 255)
                        },
                        Fill = new SolidColorBrush()
                        {
                            Color = Color.FromRgb(0, 0, 0)
                        }
                    };
                    e.MouseEnter += (x, y) =>
                    {
                        e.Stroke = new SolidColorBrush()
                        {
                            Color = Color.FromRgb(0, 0, 0)
                        };
                        e.Fill = new SolidColorBrush()
                        {
                            Color = Color.FromRgb(255, 255, 255)
                        };
                        point.Text = $"({Canvas.GetLeft(e)},{Math.Round(canv.ActualHeight - Canvas.GetTop(e))})";
                    };
                    e.MouseLeave += (x, y) =>
                    {
                        e.Stroke = new SolidColorBrush()
                        {
                            Color = Color.FromRgb(255, 255, 255)
                        };
                        e.Fill = new SolidColorBrush()
                        {
                            Color = Color.FromRgb(0, 0, 0)
                        };
                    };
                    canv.Children.Add(e);
                    Canvas.SetLeft(e, t + v * s);
                    Canvas.SetTop(e, h);
                    s++;
                }
            }
        }
    }
}
