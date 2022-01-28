using System.Windows;
using System.Windows.Controls;

namespace Algorithm_List.Controls
{
    /// <summary>
    /// llfc2.xaml 的交互逻辑
    /// </summary>
    public partial class llfc2 : UserControl
    {
        public llfc2()
        {
            InitializeComponent();
        }

        private void Solve(object sender, RoutedEventArgs e)
        {
            double a1, b1, c1, d1, a2, b2, c2, d2, a3, b3, c3, d3;
            a1 = double.Parse(txt_a1.Text); b1 = double.Parse(txt_b1.Text); c1 = double.Parse(txt_c1.Text); d1 = double.Parse(txt_d1.Text);
            a2 = double.Parse(txt_a2.Text); b2 = double.Parse(txt_b2.Text); c2 = double.Parse(txt_c2.Text); d2 = double.Parse(txt_d2.Text);
            a3 = double.Parse(txt_a3.Text); b3 = double.Parse(txt_b3.Text); c3 = double.Parse(txt_c3.Text); d3 = double.Parse(txt_d3.Text);
            double[] xyz = Library.MathHelper.Equation.SolveEquation(a1, b1, c1, d1, a2, b2, c2, d2, a3, b3, c3, d3);
            txt_x.Text = xyz[0].ToString("0.00"); txt_y.Text = xyz[1].ToString("0.00"); txt_z.Text = xyz[2].ToString("0.00");
        }
    }
}
