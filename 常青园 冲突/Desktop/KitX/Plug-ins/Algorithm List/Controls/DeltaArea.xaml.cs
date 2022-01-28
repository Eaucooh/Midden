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

namespace Algorithm_List.Controls
{
    /// <summary>
    /// DeltaArea.xaml 的交互逻辑
    /// </summary>
    public partial class DeltaArea : UserControl
    {
        public DeltaArea()
        {
            InitializeComponent();
        }

        private double gd(TextBox tb) => Convert.ToDouble(tb.Text);

        private void _half_ah_Click(object sender, RoutedEventArgs e) => _half_ah_S.Text = (0.5 * gd(_half_ah_a) * gd(_half_ah_h)).ToString("0.00");

        private void hl_Click(object sender, RoutedEventArgs e)
        {
            double a = gd(hl_a), b = gd(hl_b), c = gd(hl_c);
            double p = (a + b + c) / 2;
            hl_S.Text = Math.Sqrt(p * (p - a) * (p - b) * (p - c)).ToString("0.00");
        }

        private void tds_Click(object sender, RoutedEventArgs e) => tds_S.Text = (0.5 * gd(tds_a) * gd(tds_b) * Math.Sin(gd(tds_c))).ToString("0.00");

        private void lq_Click(object sender, RoutedEventArgs e) => lq_S.Text = (0.5 * (gd(lq_a) + gd(lq_b) + gd(lq_c)) * gd(lq_r)).ToString("0.00");

        private void wj_Click(object sender, RoutedEventArgs e) => wj_S.Text = (gd(wj_a) * gd(wj_b) * gd(wj_c) / (4 * gd(wj_R))).ToString("0.00");
    }
}
