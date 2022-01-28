using System.Windows;
using System.Windows.Controls;

namespace Algorithm_List.Controls
{
    /// <summary>
    /// llfc.xaml 的交互逻辑
    /// </summary>
    public partial class llfc : UserControl
    {
        public llfc()
        {
            InitializeComponent();
        }

        private void Solve(object sender, RoutedEventArgs e)
        {
            double a1, b1, c1, a2, b2, c2;
            a1 = double.Parse(axbyc2a1.Text);
            b1 = double.Parse(axbyc2b1.Text);
            c1 = double.Parse(axbyc2c1.Text);
            a2 = double.Parse(axbyc2a2.Text);
            b2 = double.Parse(axbyc2b2.Text);
            c2 = double.Parse(axbyc2c2.Text);
            double[] solved = Library.MathHelper.Equation.SolveEquation(a1, b1, c1, a2, b2, c2);
            axbyc2x.Text = solved[0].ToString();
            axbyc2y.Text = solved[1].ToString();
        }
    }
}
