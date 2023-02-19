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

namespace Vote
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string vote_name, string vote_content, int vote_persons, DateTime? vote_date)
        {
            InitializeComponent();
            if (vote_date.HasValue)
            {
                Title.Text = $"投票名称:{vote_name} - {vote_persons}人参与 - 投票日期:{vote_date}";
            }
            string[] list = vote_content.Split('^');
            int[] votes = new int[list.Length + 1];
            for (int i = 0; i < list.Length; i++)
            {
                Grid grid = new Grid();
                Grid dock = new Grid()
                {
                    Margin = new Thickness(0,5,0,5)
                };
                Button sub = new Button()
                {
                    Content = "-"
                };
                TextBox num = new TextBox()
                {
                    Text = "0"
                };
                votes[i] = Convert.ToInt32(num.Text);
                num.TextChanged += (x, y) =>
                {
                    votes[i] = Convert.ToInt32(num.Text);
                };
                Button plus = new Button()
                {
                    Content = "+"
                };
                plus.Click += (x, y) =>
                 {
                     num.Text = (Convert.ToInt32(num.Text) + 1).ToString();
                 };
                sub.Click += (x, y) =>
                  {
                      if (Convert.ToInt32(num.Text) >= 1)
                      {
                          num.Text = (Convert.ToInt32(num.Text) - 1).ToString();
                      }
                  };
                WrapPanel wp = new WrapPanel()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Right
                };
                wp.Children.Add(sub);
                wp.Children.Add(new Label());
                wp.Children.Add(num);
                wp.Children.Add(new Label());
                wp.Children.Add(plus);
                TextBlock tb = new TextBlock()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Text = list[i],
                    FontSize = 20
                };
                dock.Children.Add(tb);
                dock.Children.Add(wp);
                grid.Children.Add(dock);
                listbox.Children.Add(grid);
            }
            listbox.Children.RemoveAt(listbox.Children.Count - 1);
            StartCompute.Click += (x, y) =>
              {
                  string[] newList = new string[list.Length + 1];
                  for (int i = 0; i < list.Length; i++)
                  {
                      newList[i] = list[i];
                  }
                  for (int i = 0; i < votes.Length - 1; i++)
                  {
                      for (int j = 0; j < votes.Length - 1 - i; j++)
                      {
                          if (votes[j] < votes[j + 1])
                          {
                              int temp1 = votes[j];
                              votes[j] = votes[j + 1];
                              votes[j + 1] = temp1;

                              string temp2 = newList[j];
                              newList[j] = newList[j + 1];
                              newList[j + 1] = temp2;
                          }
                      }
                  }
                  string piao = null;
                  for (int i = 0; i < votes.Length; i++)
                  {
                      piao += votes[i];
                  }
                  string min = null;
                  for (int i = 0; i < newList.Length; i++)
                  {
                      min += newList[i];
                  }
                  MessageBox.Show(piao + "\n" + min + "\t");
              };
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定放弃当前投票进程来退出吗(QAQ)？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void Minimost_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
