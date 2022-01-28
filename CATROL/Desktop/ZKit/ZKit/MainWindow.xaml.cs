using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ZKit
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Resources["UserName"] = Environment.UserName;

            ShowAllTools();

            AppsBar_Controller abc = new AppsBar_Controller();
        }

        private void ShowAllTools()
        {

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void LangS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string langName;
            switch ((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    langName = "zh-CN";
                    break;
                case 1:
                    langName = "en-US";
                    break;
                default:
                    langName = "defaultLang";
                    break;
            }

            ResourceDictionary langRd = null;
            try
            {
                //根据名字载入语言文件
                langRd = Application.LoadComponent(new Uri(@"Lang\" + langName + ".xaml", UriKind.Relative)) as ResourceDictionary;
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }

            if (langRd != null)
            {
                //如果已使用其他语言,先清空
                if (Resources.MergedDictionaries.Count > 0)
                {
                    Resources.MergedDictionaries.Clear();
                }
                Resources.MergedDictionaries.Add(langRd);
            }
            else
            {
                MessageBox.Show("Please selected one Language first.");
            }
        }
    }

    public class AppsBar_Controller
    {
        AppsBar bar = new AppsBar();

        public AppsBar_Controller()
        {
            bar.Show();
        }

        public void AddApp(List<string> iconPaths)
        {
            foreach (string path in iconPaths)
            {
                bar.fishButtons.Children.Add(new Button()
                {
                    Margin = new Thickness(5),
                    Width = 48,
                    Height = 48,
                    Foreground = Brushes.White,
                    Style = new ResourceDictionary
                    {
                        Source = new Uri("/ZKit;component/PulseButton.xaml", UriKind.Relative)
                    }["PulseButton"] as Style,
                    Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(path, UriKind.Absolute)) }
                });
            }
        }
    }
}
