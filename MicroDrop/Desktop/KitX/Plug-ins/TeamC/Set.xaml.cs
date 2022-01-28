using System;
using System.Windows;
using System.Windows.Input;

namespace TeamC
{
    /// <summary>
    /// Set.xaml 的交互逻辑
    /// </summary>
    public partial class Set : Window
    {
        public string WorkBase = null;
        private string musicSetPath;
        private string contactSetPath;
        private string themeSetPath;

        public Set()
        {
            InitializeComponent();
            Loaded += (x, y) =>
            {
                musicSetPath = $"{WorkBase}\\conf\\music.ini";
                contactSetPath = $"{WorkBase}\\conf\\contacts.ini";
                themeSetPath = $"{WorkBase}\\conf\\theme.ini";
                if (Library.FileHelper.FileHelper.ReadAll(musicSetPath).Equals("no"))
                {
                    music.IsChecked = false;
                }
                else
                {
                    music.IsChecked = true;
                }
                if (Library.FileHelper.FileHelper.ReadAll(contactSetPath).Equals("left"))
                {
                    contact.SelectedIndex = 0;
                }
                else
                {
                    contact.SelectedIndex = 1;
                }
                if (Library.FileHelper.FileHelper.ReadAll(themeSetPath).Equals("dark"))
                {
                    contact.SelectedIndex = 1;
                }
                else
                {
                    contact.SelectedIndex = 0;
                }
            };
        }

        string[] writeIn_music = new string[2] { "has", "no" };
        string[] writeIn_contact = new string[2] { "left", "right" };
        string[] writeIn_theme= new string[2] { "light", "dark" };

        private void Save(object sender, RoutedEventArgs e)
        {
            if (music.IsChecked == true)
            {
                System.IO.File.WriteAllText(musicSetPath, writeIn_music[0]);
            }
            else
            {
                System.IO.File.WriteAllText(musicSetPath, writeIn_music[1]);
            }
            System.IO.File.WriteAllText(contactSetPath, writeIn_contact[contact.SelectedIndex]);
            System.IO.File.WriteAllText(themeSetPath, writeIn_theme[theme.SelectedIndex]);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btn_clo_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
