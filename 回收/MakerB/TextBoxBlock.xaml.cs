using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MakerB
{
    /// <summary>
    /// TextBoxBlock.xaml 的交互逻辑
    /// </summary>
    public partial class TextBoxBlock : UserControl
    {
        public int type = 0;
        public string text = "新";

        public TextBoxBlock()
        {
            InitializeComponent();
            Typer();
            KeyDown += (x, y) =>
            {
                if (y.Key == Key.F2)
                {
                    type = 1;
                    Typer();
                }
                if (y.Key == Key.Enter)
                {
                    Changer();
                }
            };
            LostFocus += (x, y) =>
            {
                Changer();
            };
            Loaded += TextAndInput_Loaded;
        }

        private void Changer()
        {
            show.Text = input.Text;
            text = input.Text;
            type = 0;
            Typer();
        }

        private void Rename(object sender, RoutedEventArgs e)
        {
            type = 1;
            Typer();
        }

        private void dp(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
        }

        private void TextAndInput_Loaded(object sender, RoutedEventArgs e)
        {
            show.Text = text;
            input.Text = text;
        }

        public void Typer()
        {
            switch (type)
            {
                case 0:
                    show.Visibility = Visibility.Visible;
                    input.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    show.Visibility = Visibility.Hidden;
                    input.Visibility = Visibility.Visible;
                    input.SelectAll();
                    break;
            }
        }
    }
}
