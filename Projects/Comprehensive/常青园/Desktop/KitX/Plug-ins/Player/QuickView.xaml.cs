using System.Windows;
using System.Windows.Controls;

namespace Player
{
    /// <summary>
    /// QuickView.xaml 的交互逻辑
    /// </summary>
    public partial class QuickView : UserControl
    {
        public MainWindow win = null;

        public QuickView()
        {
            InitializeComponent();
        }

        private void ClearSign() => sign.BorderThickness = new Thickness(0);

        private void ShowTSign() => sign.BorderThickness = new Thickness(3);

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            ClearSign();
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (win == null)
                {
                    win = new MainWindow();
                }
                for (int i = 0; i < files.Length; i++)
                {
                    win.AddTask(files[i]);
                }
                win.Show();
                win.PlayLastTask(files[files.Length - 1]);
            }
            e.Handled = true;
        }

        private void Grid_DragEnter(object sender, DragEventArgs e)
        {
            ShowTSign();
            e.Effects = DragDropEffects.All;
        }

        private void Grid_DragLeave(object sender, DragEventArgs e) => ClearSign();
    }
}
