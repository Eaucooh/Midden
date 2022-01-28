using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace 签到积分
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public double X = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
        public double Y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
        public MainWindow()
        {
            InitializeComponent();
            Left = X - Width - 40;
            Height = Y - 40 * 2;
            Top = 40;

            Main(AppDomain.CurrentDomain.BaseDirectory);
        }

        private void Reload(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("您确定要刷新列表吗？这会丢失已有计分和数据，此操作不可逆！", "警告", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Main(AppDomain.CurrentDomain.BaseDirectory);
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\list.txt");
        }

        private void Main(string path)
        {
            board.Children.Clear();
            string fp = path + @"\list.txt";
            FileStream fs = new FileStream(fp, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Bar person = new Bar();
                person.name.Content = line;
                board.Children.Add(person);
                board.Children.Add(new Label());
            }
            sr.Close();
            fs.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
