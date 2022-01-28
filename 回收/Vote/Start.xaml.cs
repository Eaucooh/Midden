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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vote
{
    /// <summary>
    /// Start.xaml 的交互逻辑
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BeginStoryboard((Storyboard)FindResource("WinStart"));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Storyboard winend = (Storyboard)FindResource("WinEnd");
            winend.Completed += (x, y) =>
              {
                  Close();
              };
            BeginStoryboard(winend);
        }

        private void addSelection_Click(object sender, RoutedEventArgs e)
        {
            switch (itemTyper.SelectedIndex)
            {
                case 0:
                    ItemList.Items.Add(new ListBoxItem()
                    {
                        Content = text_addInto.Text
                    });
                    break;
                case 1:
                    break;
            }
        }

        private void deleteSelected_Click(object sender, RoutedEventArgs e)
        {
            int index = ItemList.SelectedIndex;
            if (index - 1 >= 0)
            {
                ItemList.SelectedIndex -= 1;
                ItemList.Items.RemoveAt(index);
            }
            else if (index - 1 == -1)
            {
                ItemList.SelectedIndex -= 1;
                ItemList.Items.RemoveAt(index);
            }
            else
            {
                ItemList.SelectedIndex = -1;
            }
        }

        int startUp = 0;

        private void itemTyper_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (startUp)
            {
                case 0:
                    startUp = 1;
                    break;
                case 1:
                    CubicEase cubicEase = new CubicEase()
                    {
                        EasingMode = EasingMode.EaseOut
                    };
                    DoubleAnimation showAnimation = new DoubleAnimation()
                    {
                        From = 0,
                        To = 24,
                        FillBehavior = FillBehavior.Stop,
                        Duration = new TimeSpan(0, 0, 0, 800),
                        EasingFunction = cubicEase
                    };
                    DoubleAnimation hideAnimation = new DoubleAnimation()
                    {
                        From = 24,
                        To = 0,
                        FillBehavior = FillBehavior.Stop,
                        Duration = new TimeSpan(0, 0, 0, 800),
                        EasingFunction = cubicEase
                    };
                    switch (itemTyper.SelectedIndex)
                    {
                        case 1:
                            text_addInto.BeginAnimation(HeightProperty, showAnimation);
                            break;
                        case 0:
                            text_addInto.BeginAnimation(HeightProperty, hideAnimation);
                            break;
                    }
                    break;
            }
        }

        private void StartVote_Click(object sender, RoutedEventArgs e)
        {
            if (!Date.SelectedDate.HasValue)
            {

            }
            else
            {
                string vote_content = null;
                foreach (ListBoxItem item in ItemList.Items)
                {
                    vote_content += $"{item.Content}^";
                }
                int number = 0;
                try
                {
                    number = Convert.ToInt32(voter_number.Text);
                }
                catch
                {

                }
                MainWindow mainWindow = new MainWindow(vote_title.Text, vote_content, number, Date.SelectedDate);
                Storyboard winend = (Storyboard)FindResource("WinEnd");
                winend.Completed += (x, y) =>
                {
                    mainWindow.Show();
                    Close();
                };
                BeginStoryboard(winend);
            }
        }
    }
}