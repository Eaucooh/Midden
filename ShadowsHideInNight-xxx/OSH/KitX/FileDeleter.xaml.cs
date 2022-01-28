using Microsoft.Win32;
using System.Windows;
using Path = System.IO.Path;

namespace OSH.KitX
{
    /// <summary>
    /// FileDeleter.xaml 的交互逻辑
    /// </summary>
    public partial class FileDeleter : Window
    {
        public FileDeleter()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog()
                {
                    Title = "选择粉碎目标",
                    Filter = "所有文件|*.*",
                    Multiselect = true
                };
                ofd.ShowDialog();
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    string name = Path.GetFileNameWithoutExtension(ofd.FileNames[i]);
                    string filter = Path.GetExtension(ofd.FileNames[i]);
                    goal.Items.Add(new { Names = name, Filters = filter, Paths = ofd.FileNames[i] });
                }
            }
            catch
            { 
            
            }
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                goal.Items.RemoveAt(goal.SelectedIndex);
            }
            catch
            {

            }
        }

        private void com_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
