using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
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

namespace MakerB
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> dataitems { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Data.ItemsSource = dataitems;
            try
            {
                dataitems.Add(items_num.ToString());
            }
            catch
            {

            }
        }

        public int items_num = 1;

        private void AddColumn_Click(object sender, RoutedEventArgs e)
        {
            string newBinding = "newBinding";
            TextBoxBlock tai = new TextBoxBlock()
            {
                text = "未命名新列"
            };
            DataGridTextColumn added = new DataGridTextColumn()
            {
                Header = tai,
                Binding = new Binding(newBinding)
            };
            Data.Columns.Insert(Data.Columns.Count - 1, added);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.F11)
            {
                if(WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                    WindowStyle = WindowStyle.SingleBorderWindow;
                }
                else
                {
                    WindowState = WindowState.Maximized;
                    WindowStyle = WindowStyle.None;
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
