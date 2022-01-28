using System.Windows;
using System.Windows.Controls;

namespace Algorithm_List.Controls
{
    /// <summary>
    /// llfc3.xaml 的交互逻辑
    /// </summary>
    public partial class llfc3 : UserControl
    {
        public llfc3()
        {
            InitializeComponent();
        }

        private void Solve(object sender, RoutedEventArgs e)
        {
            double a1, b1, c1, d1, e1, a2, b2, c2, d2, e2, a3, b3, c3, d3, e3, a4, b4, c4, d4, e4;

            a1 = System.Convert.ToDouble(txt_a1.Text); a2 = System.Convert.ToDouble(txt_a2.Text);
            a3 = System.Convert.ToDouble(txt_a3.Text); a4 = System.Convert.ToDouble(txt_a4.Text);

            b1 = System.Convert.ToDouble(txt_b1.Text); b2 = System.Convert.ToDouble(txt_b2.Text);
            b3 = System.Convert.ToDouble(txt_b3.Text); b4 = System.Convert.ToDouble(txt_b4.Text);

            c1 = System.Convert.ToDouble(txt_c1.Text); c2 = System.Convert.ToDouble(txt_c2.Text);
            c3 = System.Convert.ToDouble(txt_c3.Text); c4 = System.Convert.ToDouble(txt_c4.Text);

            d1 = System.Convert.ToDouble(txt_d1.Text); d2 = System.Convert.ToDouble(txt_d2.Text);
            d3 = System.Convert.ToDouble(txt_d3.Text); d4 = System.Convert.ToDouble(txt_d4.Text);

            e1 = System.Convert.ToDouble(txt_e1.Text); e2 = System.Convert.ToDouble(txt_e2.Text);
            e3 = System.Convert.ToDouble(txt_e3.Text); e4 = System.Convert.ToDouble(txt_e4.Text);

            double[] x_y_z_m = Library.MathHelper.Equation.SolveEquation(a1, b1, c1, d1, e1, a2, b2, c2, d2, e2, a3, b3, c3, d3, e3, a4, b4, c4, d4, e4);
            rstx.Text = x_y_z_m[0].ToString("0.000"); rsty.Text = x_y_z_m[1].ToString("0.000");
            rstz.Text = x_y_z_m[2].ToString("0.000"); rstm.Text = x_y_z_m[3].ToString("0.000");
        }
    }
}
