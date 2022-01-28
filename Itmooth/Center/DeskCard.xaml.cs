using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Path = System.IO.Path;
using UI = Panuon.UI.Silver;

namespace Center
{
    /// <summary>
    /// DeskCard.xaml 的交互逻辑
    /// </summary>
    public partial class DeskCard : UserControl
    {
        public string TargetPath = @"%ITMOOTH%\Lib\temp.lnk";
        public bool IsFolder = false;
        public string FolderName;
        private string workbase = AppDomain.CurrentDomain.BaseDirectory;
        public string FolderTheme = "Blue";

        public static ImageSource GetIcon(string fileName)
        {
            System.Drawing.Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileName);
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                        icon.Handle,
                        new Int32Rect(0, 0, icon.Width, icon.Height),
                        BitmapSizeOptions.FromEmptyOptions());
        }

        public DeskCard()
        {
            InitializeComponent();
            Loaded += (q, d) =>
              {
                  Start();
              };
        }

        void Start()
        {
            if (IsFolder)
            {
                BitmapImage imgSource = new BitmapImage(new Uri(workbase + @"\Lib\Folder_" + FolderTheme + ".png", UriKind.Absolute));
                icon.Source = imgSource;
                title_show.Text = FolderName;
                title_under.Text = FolderName;
            }
            else
            {
                if (Path.GetExtension(TargetPath).ToLower() == ".exe")
                {
                    try
                    {
                        icon.Source = GetIcon(TargetPath);
                    }
                    catch
                    {
                        BitmapImage img = new BitmapImage(new Uri(workbase + @"\Lib\Icon\.exe.png", UriKind.Absolute));
                        icon.Source = img;
                    }
                }
                else
                {
                    string uri = workbase + @"\Lib\Icon\" + Path.GetExtension(TargetPath).ToLower() + ".png";
                    if (File.Exists(uri))
                    {
                        BitmapImage img = new BitmapImage(new Uri(uri, UriKind.Absolute));
                        icon.Source = img;
                    }
                    else
                    {
                        BitmapImage img = new BitmapImage(new Uri(workbase + @"\Lib\Icon\未知.png", UriKind.Absolute));
                        icon.Source = img;
                    }
                }
                title_show.Text = Path.GetFileName(TargetPath);
                title_under.Text = Path.GetFileName(TargetPath);
            }
            Open.Click += (d, k) =>
            {
                OpenIt();
            };
            OpenAsAdmin.Click += (g, l) =>
            {
                InputBox input = new InputBox();
                System.Security.SecureString pwd = input.ShowPassword("请输入管理员密码：", "");
                if (pwd != null)
                {
                    try
                    {
                        WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
                        Process.Start(TargetPath, Environment.UserName, pwd, windowsIdentity.Name);
                    }
                    catch
                    {
                        UI.Notice.Show("用户名或密码不正确", "提示", 3, Panuon.UI.Silver.MessageBoxIcon.Error);
                    }
                }
            };
            Del.Click += (s, c) =>
            {
                Thread thread = new Thread(Delete);
                thread.Start();
            };
            ReName.Click += (mn, mg) =>
            {
                try
                {
                    InputBox input = new InputBox();
                    string name;
                    if (IsFolder)
                    {
                        name = input.Show("新名字：", FolderName);
                        if (name != null)
                        {
                            Microsoft.VisualBasic.Devices.Computer com = new Microsoft.VisualBasic.Devices.Computer();
                            com.FileSystem.RenameDirectory(TargetPath, name);
                            TargetPath = TargetPath + @"\" + name;
                        }
                    }
                    else
                    {
                        name = input.Show("新名字：", Path.GetFileName(TargetPath));
                        if (name != null)
                        {
                            Microsoft.VisualBasic.Devices.Computer com = new Microsoft.VisualBasic.Devices.Computer();
                            com.FileSystem.RenameFile(TargetPath, name);
                            TargetPath = TargetPath + @"\" + name;
                        }
                    }
                    Start();
                }
                catch (Exception err)
                {
                    UI.Notice.Show(err.Message, "错误", 3, Panuon.UI.Silver.MessageBoxIcon.Error);
                }
            };
        }

        void Delete()
        {
            if (IsFolder)
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine("rmdir /s/q " + TargetPath);
                p.StandardInput.AutoFlush = true;
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p.Close();
                UI.Notice.Show(output, "消息", 3, Panuon.UI.Silver.MessageBoxIcon.Info);
            }
            else
            {
                if (File.Exists(TargetPath))
                {
                    File.Delete(TargetPath);
                }
            }
        }

        Color color = Color.FromArgb(40, 0, 112, 204);
        Color lost = Color.FromArgb(100, 0, 112, 204);
        double Downthinkness = 3.0;
        double Enterthinkness = 1.5;

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            back.Background = new SolidColorBrush(color);
            dock.BorderThickness = new Thickness(Downthinkness, Downthinkness, Downthinkness, Downthinkness);
            if(e.ClickCount>1)
            {
                OpenIt();
            }
        }

        private void OpenIt()
        {
            try
            {
                if (IsFolder)
                {
                    Process.Start(TargetPath);
                }
                else
                {
                    Process.Start(TargetPath);
                }
            }
            catch(Exception p)
            {
                UI.Notice.Show(p.Message, "错误", 3, UI.MessageBoxIcon.Error);
            }
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            dock.BorderThickness = new Thickness(Enterthinkness, Enterthinkness, Enterthinkness, Enterthinkness);
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            back.Background = null;
            dock.BorderThickness = new Thickness(0, 0, 0, 0);
        }
    }
}
