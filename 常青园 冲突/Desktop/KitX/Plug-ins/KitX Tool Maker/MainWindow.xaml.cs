using KitX.Core;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Path = System.IO.Path;

namespace KitX_Tool_Maker
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IContract))]
    public partial class MainWindow : Window, IContract
    {
        public MainWindow()
        {
            InitializeComponent();
            win = this;
            Closed += (x, y) =>
            {
                started = false;
            };
        }

        private void FlushBack()
        {
            Library.Windows.SystemColor.DwmGetColorizationColor(out int pcrColorization, out _);
            win.Background = new SolidColorBrush(Library.Windows.SystemColor.Get_Color(pcrColorization));
        }

        #region 接口实现
        
        private string WorkBase = null;

        public void SetWorkBase(string path)
        {
            WorkBase = path;
            if (!Directory.Exists(WorkBase))
            {
                Directory.CreateDirectory(WorkBase);
            }
        }

        public string GetDescribe_Complex() => "用于将 插件主体（.dll） 与 外部文件 打包成专用 .kxt 格式安装包";

        public string GetDescribe_Simple() => "制作 .kxt 格式文件";

        public string GetFileName() => "KitX Tool Maker.dll";

        public string GetHelpLink() => "https://docs.catrol.cn/";

        public string GetHostLink() => "https://blog.catrol.cn/";

        public BitmapImage GetIcon() => FindResource("Icon") as BitmapImage;

        public Languages GetLang() => Languages.zh_CN;

        public string GetName() => "KitX Tool Maker";

        public string GetPublisher() => "Catrol";

        public string GetVersion() => "v1.5.4";

        public Window GetWindow() => new MainWindow();

        public void SetTheme(Theme theme)
        {
            FlushBack();
        }

        QuickView quicker = new QuickView();

        public UserControl GetQuickView() => quicker;

        MainWindow win;
        bool started = true;
        bool start_st = true;

        public void Start()
        {
            if (start_st)
            {
                start_st = false;
                win.Show();
            }
            else
            {
                if (!started)
                {
                    win = new MainWindow();
                    win.Closed += (x, y) =>
                    {
                        started = false;
                        quicker.win = null;
                    };
                    win.Show();

                    FlushBack();

                    started = true;
                }
                else
                {
                    if (win.Visibility == Visibility.Hidden)
                    {
                        win.Visibility = Visibility.Visible;

                        FlushBack();
                    }
                    else
                    {
                        win.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        public void End()
        {
            win.Close();
            started = false;
        }

        public Tags GetTag() => Tags.Program;
        #endregion

        public string ProjectBase { get; set; }
        public bool PBSet = false;

        private void OpenLink(object sender, RoutedEventArgs e)
        {
            switch ((sender as FrameworkElement).Tag.ToString().Split(':')[1])
            {
                case "add":
                    if (PBSet)
                    {
                        Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog()
                        {
                            Multiselect = true,
                            Title = "添加文件",
                            CheckFileExists = true,
                            CheckPathExists = true,
                            Filter = "所有文件|*.*"
                        };
                        ofd.ShowDialog();
                        if (ofd.FileNames.Length != 0)
                        {
                            for (int i = 0; i < ofd.FileNames.Length; i++)
                            {
                                string tarP = $"{ProjectBase}\\{Path.GetFileName(ofd.FileNames[i])}";
                                if (!File.Exists(tarP))
                                {
                                    File.Copy(ofd.FileNames[i], tarP);
                                }
                                else
                                {
                                    File.Delete(tarP);
                                    File.Copy(ofd.FileNames[i], tarP);
                                }
                            }
                        }
                        FlushList();
                    }
                    else
                    {
                        NoPBDialog();
                    }
                    break;
                case "del":
                    if (PBSet)
                    {
                        TreeViewItem tvi = (TreeViewItem)Files.SelectedItem;
                        string path = tvi.Tag.ToString();
                        if (Directory.Exists(path))
                        {
                            DirectoryInfo di = new DirectoryInfo(path);
                            di.Delete();
                        }
                        else
                        {
                            FileInfo fi = new FileInfo(path);
                            fi.Delete();
                        }
                        FlushList();
                    }
                    else
                    {
                        NoPBDialog();
                    }
                    break;
                case "fls":
                    FlushList();
                    break;
                case "set":
                    Microsoft.Win32.OpenFileDialog odd = new Microsoft.Win32.OpenFileDialog()
                    {
                        Multiselect = false,
                        Title = "选择项目路径",
                        CheckFileExists = true,
                        CheckPathExists = true,
                        Filter = "KitX 插件|*.dll"
                    };
                    odd.ShowDialog();
                    if (odd.FileName != null)
                    {
                        ProjectBase = Path.GetDirectoryName(odd.FileName);
                    }
                    PBSet = true;
                    PBBox.Text = ProjectBase;
                    FlushList();
                    break;
                case "apply":
                    if (PBSet)
                    {
                        Library.FileHelper.FileHelper.WriteIn($"{ProjectBase}\\inf_name.txt", ToolName.Text);
                        Library.FileHelper.FileHelper.WriteIn($"{ProjectBase}\\inf_author.txt", ToolPublisher.Text);
                        FlushList();
                    }
                    else
                    {
                        NoPBDialog();
                    }
                    break;
                case "view":
                    if (PBSet)
                    {
                        Process.Start(ProjectBase);
                    }
                    else
                    {
                        NoPBDialog();
                    }
                    break;
                case "pack":
                    if (PBSet)
                    {
                        string name = Library.FileHelper.FileHelper.ReadAll($"{ProjectBase}\\inf_name.txt");
                        string tar = $"{Directory.GetParent(ProjectBase)}\\{name}.zip";
                        Library.FileHelper.GZipCompress.Compress(ProjectBase, tar);
                        File.Move(tar, $"{Directory.GetParent(ProjectBase)}\\{name}.kxt");
                    }
                    else
                    {
                        NoPBDialog();
                    }
                    break;
            }
        }

        private void FlushList()
        {
            if (PBSet)
            {
                Files.Items.Clear();
                Library.FileHelper.DirInfo.SetOnTreeView(ref Files, ProjectBase);
            }
            else
            {
                NoPBDialog();
            }
        }

        private void NoPBDialog() => HandyControl.Controls.Growl.Warning("你需要先选择项目路径");

        //private void Window_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    win.Background = Brushes.White;
        //}

        //private void Window_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    FlushBack();
        //}
    }
}
