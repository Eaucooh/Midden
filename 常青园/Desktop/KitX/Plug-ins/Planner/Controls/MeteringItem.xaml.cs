using System.Windows;
using System.Windows.Controls;

namespace Planner.Controls
{
    /// <summary>
    /// MeteringItem.xaml 的交互逻辑
    /// </summary>
    public partial class MeteringItem : UserControl
    {
        public string time { get; set; }

        public int index { get; set; }

        public MeteringItem()
        {
            InitializeComponent();
            Loaded += MeteringItem_Loaded;
        }

        private void MeteringItem_Loaded(object sender, RoutedEventArgs e)
        {
            Index.Text = index.ToString();
            Time.Text = time;
        }
    }
}
