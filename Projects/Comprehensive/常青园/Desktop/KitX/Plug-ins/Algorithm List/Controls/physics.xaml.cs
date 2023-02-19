using System;
using System.Windows.Controls;

namespace Algorithm_List.Controls
{
    /// <summary>
    /// physics.xaml 的交互逻辑
    /// </summary>
    public partial class physics : UserControl
    {
        public physics()
        {
            InitializeComponent();
        }

        bool first = true;

        private void pageSelecter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!first)
            {
                switch ((sender as ComboBox).SelectedIndex)
                {
                    case 0:
                        box.Source = new Uri("/Algorithm List;component/Controls/pages/ftm.xaml", UriKind.Relative);
                        break;
                }
            }
            else
            {
                first = false;
            }
        }
    }
}
