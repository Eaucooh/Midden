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

namespace OhManControl
{
    /// <summary>
    /// PersonHang.xaml 的交互逻辑
    /// </summary>
    public partial class PersonHang : UserControl
    {
        public Point Center; //圆心
        public System.Drawing.Point MousePosition;

        public PersonHang()
        {
            InitializeComponent();

            var LfTopPoint = PointToScreen(new Point(0, 0));
            Center = new Point(LfTopPoint.X + (Width / 2), LfTopPoint.Y + (Height / 2));
            MousePosition = System.Windows.Forms.Control.MousePosition;
        }

        public double EyeSize //眼珠的大小 Size=Width=Height
        {
            get { return (double)GetValue(EyeWidthProperty); }
            set { SetValue(EyeWidthProperty, value); }
        }

        public static readonly DependencyProperty EyeWidthProperty =
            DependencyProperty.Register("EyeWidth", typeof(double), typeof(UserControl), new PropertyMetadata(80));

        public int Radius //眼珠与圆心的距离
        {
            get { return (int)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(int), typeof(UserControl), new PropertyMetadata(20));

    }
}
