using System;
using System.Windows;

namespace XAML_Viewer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string WorkBase = Environment.CurrentDirectory;

        //private void New_Click(object sender, RoutedEventArgs e)
        //{
        //    string fn = Microsoft.VisualBasic.Interaction.InputBox("New file name:", "Create a new file", "NewXamlFile.xaml", -1, -1);
        //    string fp = $"{WorkBase}\\Views\\{fn}";
        //    xfs.Add(new XFile()
        //    {
        //        FileName = fn,
        //        FilePath = fp
        //    });
        //    var fi = new System.IO.FileInfo(fp);
        //    if (!fi.Exists)
        //    {
        //        if (!Directory.Exists(fi.DirectoryName))
        //        {
        //            Directory.CreateDirectory(fi.DirectoryName);
        //        }
        //        File.Create(fi.FullName);
        //    }
        //}

        //private void Open_Click(object sender, RoutedEventArgs e)
        //{
        //    OperatingIndex = FileList.SelectedIndex;
        //    var fi = new System.IO.FileInfo(xfs[OperatingIndex].FilePath);
        //    XamlBox.Text = fi.OpenText().ReadToEnd();
        //}

        //private void Flush_Click(object sender, RoutedEventArgs e) => LoadLocalFile();

        //public int OperatingIndex = -1;

        //private void Del_Click(object sender, RoutedEventArgs e)
        //{
        //    var fi = new System.IO.FileInfo(xfs[FileList.SelectedIndex].FilePath);
        //    xfs.RemoveAt(FileList.SelectedIndex);
        //    fi.Delete();
        //}

        //private void Rename_Click(object sender, RoutedEventArgs e)
        //{
        //    var fi = new System.IO.FileInfo(xfs[FileList.SelectedIndex].FilePath);
        //    string nn = Microsoft.VisualBasic.Interaction.InputBox("New file name:", "Rename a existing file", "NewXamlFile.xaml", -1, -1);
        //    var nfi = new System.IO.FileInfo(nn);
        //    using (System.IO.FileStream fs = nfi.Create())
        //    {
        //        Byte[] info = new UTF8Encoding(true).GetBytes(fi.OpenText().ReadToEnd());
        //        Add some information to the file.
        //        fs.Write(info, 0, info.Length);
        //    }
        //    nfi.Refresh();
        //    fi.Delete();
        //}

        //private void Save_Click(object sender, RoutedEventArgs e)
        //{
        //    var fi = new System.IO.FileInfo(xfs[OperatingIndex].FilePath);
        //    using (System.IO.FileStream fs = fi.Open(System.IO.FileMode.Open))
        //    {
        //        Byte[] info = new UTF8Encoding(true).GetBytes(XamlBox.Text);
        //        Add some information to the file.
        //        fs.Write(info, 0, info.Length);
        //    }
        //    fi.Refresh();
        //}

        //private void Undo_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Redo_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Copy_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Paste_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Cut_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void PreView_Click(object sender, RoutedEventArgs e)
        {
            if (Processed)
            {
                App.PreView(XamlBox.Text);
            }
            else
            {
                MessageBox.Show("请先单击处理按钮\r\nPlease click the \"处理\" button", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Process_Click(object sender, RoutedEventArgs e) => ToProcess();

        bool Processed = false;

        private void XamlBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) => Processed = false;

        private void ToProcess()
        {
            Processed = true;
        }
    }
}
