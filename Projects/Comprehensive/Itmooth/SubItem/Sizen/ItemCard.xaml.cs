using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace Sizen
{
    /// <summary>
    /// ItemCard.xaml 的交互逻辑
    /// </summary>
    public partial class ItemCard : UserControl
    {
        public string imgPath;
        public int speed = 5;

        public ItemCard()
        {
            InitializeComponent();
            DispatcherTimer big = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMilliseconds(speed)
            };
            big.Tick += (n, b) =>
            {
                if (img.Width != Width)
                {
                    img.Width += 0.1;
                }
                if (img.Height != Height)
                {
                    img.Height += 0.1;
                }
                if (img.Width == Width && img.Height == Height)
                {
                    big.Stop();
                }
            };
            DispatcherTimer small = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMilliseconds(speed)
            };
            small.Tick += (n, b) =>
            {
                if (img.Width != 150)
                {
                    img.Width -= 0.1;
                }
                if (img.Height != 225)
                {
                    img.Height -= 0.1;
                }
                if (img.Width == 150 && img.Height == 225)
                {
                    small.Stop();
                }
            };
            MouseEnter += (x, y) =>
            {
                big.Start();
            };
            MouseLeave += (x, y) =>
            {
                small.Start();
            };
            Loaded += (n, b) =>
              {
                  if (File.Exists(imgPath))
                  {
                      img.Source = new BitmapImage(new Uri(imgPath, UriKind.Absolute));
                  }
              };
        }
    }
}
