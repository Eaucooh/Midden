using IWshRuntimeLibrary;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace OSH
{
    /// <summary>
    /// Settings.xaml 的交互逻辑
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Alt && e.SystemKey == Key.Space)
            {
                e.Handled = true;
            }
            else if (Keyboard.Modifiers == ModifierKeys.Alt && e.SystemKey == Key.F4)
            {
                e.Handled = true;
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string strPath = ConfigurationManager.AppSettings["IsStartWithSystem"].ToString();
            if (strPath == "true")
            {
                startWithSystem.IsChecked = true;
            }
            else if (strPath == "false")
            {
                startWithSystem.IsChecked = false;
            }
        }

        private void startWithSystem_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                #region 创建启动快捷方式
                string target = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup";
                string SelfPath = System.Windows.Forms.Application.StartupPath;
                string dirPath = Environment.CurrentDirectory;
                string exePath = Assembly.GetExecutingAssembly().Location;
                FileVersionInfo exeInfo = FileVersionInfo.GetVersionInfo(exePath);
                if (System.IO.File.Exists(string.Format(@"{0}\OSH.lnk", target)))
                {
                    System.IO.File.Delete(string.Format(@"{0}\OSH.lnk",target));//删除原来的桌面快捷键方式
                    return;
                }
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\" + "OSH.lnk");
                shortcut.TargetPath = @exePath;         //目标文件
                shortcut.WorkingDirectory = dirPath;    //目标文件夹
                shortcut.WindowStyle = 1;               //目标应用程序的窗口状态分为普通、最大化、最小化【1,3,7】
                shortcut.Description = "OSH";   //描述
                shortcut.IconLocation = string.Format(@SelfPath+@"\Resources\icon_notify.ico"); ; //快捷方式图标
                shortcut.Arguments = "";
                shortcut.Hotkey = "SHIFT+DELETE";              // 快捷键
                shortcut.Save();
                #endregion
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["IsStartWithSystem"].Value = "true";
                cfa.Save();
            }
            catch (Exception o)
            {
                startWithSystem.IsChecked = false;
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["IsStartWithSystem"].Value = "false";
                cfa.Save();
                MessageBox.Show("原因如下:\r\n" + o, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void startWithSystem_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                #region 取消开机自启
                string target = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup";
                if (System.IO.File.Exists(string.Format(@"{0}\OSH.lnk", target)))
                {
                    System.IO.File.Delete(string.Format(@"{0}\OSH.lnk", target));//删除原来的桌面快捷键方式
                    return;
                }
                #endregion
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["IsStartWithSystem"].Value = "false";
                cfa.Save();
            }
            catch (Exception o)
            {
                startWithSystem.IsChecked = true;
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["IsStartWithSystem"].Value = "true";
                cfa.Save();
                MessageBox.Show("原因如下:\r\n" + o, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            { 
            
            }            
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            NetworkConection("183.232.231.174");
        }

        private void NetworkConection(string target)
        {
            try
            {
                Ping objPingSender = new Ping();
                PingOptions objPinOptions = new PingOptions();
                objPinOptions.DontFragment = true;
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int intTimeout = 120;
                //string target = "183.232.231.174";
                PingReply objPinReply = objPingSender.Send(target, intTimeout, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    MessageBox.Show("您使用的是最新版本", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("无网络连接，请检查您的网络状况。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception o)
            {
                MessageBox.Show("网络连接错误，原因如下:" + o, "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void allowMode_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void allowMode_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void ModeMgr_Click(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory(@"C:\ProgramData\OSH\Modes\Default");
            if (Directory.Exists(@"C:\ProgramData\OSH\Modes\"))
            {
                Form mgr = new Form
                {
                    Icon = new System.Drawing.Icon(System.Windows.Forms.Application.StartupPath + @"\Resources\icon_notify.ico"),
                    Width = 600,
                    Height = 450,
                    Text = "插件管理",
                    StartPosition = FormStartPosition.CenterScreen,
                    ShowInTaskbar = false,
                    AutoScroll = true
                };
                DirectoryInfo directories = new DirectoryInfo(@"C:\ProgramData\OSH\Modes\");
                foreach (DirectoryInfo NextFolder in directories.GetDirectories())
                {
                    Label label = new Label
                    {
                        Text = "插件名:" + NextFolder.Name,
                        Size = new System.Drawing.Size(82, 24),
                        Width = 600,
                        Height = 15
                    };
                    ContextMenuStrip cms = new ContextMenuStrip();
                    ToolStripMenuItem uninstall = new ToolStripMenuItem();
                    ToolStripMenuItem checkUpdate = new ToolStripMenuItem();
                    ToolStripMenuItem newMode = new ToolStripMenuItem();
                    uninstall.Text = "卸载插件";
                    checkUpdate.Text = "检查更新";
                    newMode.Text = "安装新插件";
                    uninstall.Click += (x, y) =>
                    {
                        if (MessageBox.Show("您是否要卸载 | " + NextFolder.Name + " | 这个插件?", "警告", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            if (NextFolder.FullName != @"C:\ProgramData\OSH\Modes\Default")
                            {
                                Directory.Delete(NextFolder.FullName);
                                mgr.Close();
                                ModeMgr_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("默认插件包不允许卸载!", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }
                    };
                    checkUpdate.Click += (x, y) =>
                    {
                        NetworkConection("183.232.231.174");
                    };
                    newMode.Click += (x, y) =>
                    {
                        OpenFileDialog dialog = new OpenFileDialog()
                        {
                            Title = "选择新插件",
                            Filter = "功能插件|*.fpi|界面插件|*.upi|综合插件|*.mpi"
                        };
                        dialog.ShowDialog();
                    };
                    cms.Items.Add(uninstall);
                    cms.Items.Add(checkUpdate);
                    cms.Items.Add(newMode);
                    label.ContextMenuStrip = cms;
                    mgr.Controls.Add(label);
                }
                mgr.ShowDialog();
            }
            else
            {
                Directory.CreateDirectory(@"C:\ProgramData\OSH\Modes\");
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("http://www.InkShadow.com");
        }

        private void ChooseTheme_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            cd.AnyColor = true;
            cd.ShowDialog();
        }
    }
}
