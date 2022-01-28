using System;
using System.IO;
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
using File = System.IO.File;
using System.Collections;
using System.Data;
using System.Diagnostics;

namespace JDK配置大师
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string mydir = AppDomain.CurrentDomain.BaseDirectory;
        private AppTool.File file = new AppTool.File();
        private AppTool.Net net = new AppTool.Net();
        private AppTool.Main appTool = new AppTool.Main();
        private string website;
        private string jdkDir;

        public MainWindow()
        {
            InitializeComponent();
            Flush();
            Lister();
        }

        private void menu_exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        ArrayList list = new ArrayList();

        private void Lister()
        {
            dataGrid.Items.Clear();
            list.Add(new JDK("1.0", "Oak（橡树）", "24MB", new DateTime(1996, 1, 23), "该版本过于久远，暂无此版本资源", ""));
            list.Add(new JDK("1.1", "", "24MB", new DateTime(1997, 2, 19), "该版本过于久远，暂无此版本资源", ""));
            list.Add(new JDK("1.1.4", "Sparkler（宝石）", "24MB", new DateTime(1997, 9, 12), "该版本过于久远，暂无此版本资源", ""));
            list.Add(new JDK("1.1.5", "Pumpkin（南瓜）", "24MB", new DateTime(1997, 12, 13), "该版本过于久远，暂无此版本资源", ""));
            list.Add(new JDK("1.1.6", "Abigail（阿比盖尔–女子名）", "24MB", new DateTime(1998, 4, 24), "该版本过于久远，暂无此版本资源", ""));
            list.Add(new JDK("1.1.7", "Brutus（布鲁图–古罗马政治家和将军）", "24MB", new DateTime(1998, 9, 28), "该版本过于久远，暂无此版本资源", ""));
            list.Add(new JDK("1.1.8", "Chelsea（切尔西–城市名）", "24MB", new DateTime(1999, 4, 8), "该版本过于久远，暂无此版本资源", ""));
            list.Add(new JDK("1.2", "Playground（运动场）", "24MB", new DateTime(1998, 12, 4), "该版本过于久远，暂无此版本资源", ""));
            list.Add(new JDK("1.2.1", "none（无）", "24MB", new DateTime(1999, 3, 30), "该版本过于久远，暂无此版本资源", ""));
            list.Add(new JDK("1.2.2", "Cricket（蟋蟀）", "24MB", new DateTime(1999, 7, 8), "该版本过于久远，暂无此版本资源", ""));
            list.Add(new JDK("1.3", "Kestrel（美洲红隼）", "24MB", new DateTime(2000, 5, 8), "该版本过于久远，暂无此版本资源", ""));
            list.Add(new JDK("1.3.1", "Ladybird（瓢虫）", "24MB", new DateTime(2001, 5, 17), "该版本过于久远，暂无此版本资源", ""));
            list.Add(new JDK("1.4.0", "Merlin（灰背隼）", "24MB", new DateTime(2002, 2, 13), "该版本过于久远，暂无此版本资源", ""));
            list.Add(new JDK("1.4.1", "grasshopper（蚱蜢）", "24MB", new DateTime(2002, 9, 16), "该版本过于久远，暂无此版本资源", ""));
            list.Add(new JDK("1.4.2", "Mantis（螳螂）", "24MB", new DateTime(2003, 6, 26), "该版本过于久远，暂无此版本资源", ""));
            list.Add(new JDK("SE 5.0 / 1.5", "Tiger（老虎）", "24MB", new DateTime(2004, 9, 30), "该版本过于久远，暂无此版本资源", ""));
            list.Add(new JDK("SE 6.0 / 1.6", "Mustang（野马）", "24MB", new DateTime(2006, 4, 1), "该版本过于久远，不建议使用此版本", ""));
            list.Add(new JDK("SE 7.0 / 1.7", "Dolphin（海豚）", "24MB", new DateTime(2011, 7, 28), "该版本过于久远，不建议使用此版本", ""));
            list.Add(new JDK("SE 8.0 / 1.8", "Spider（蜘蛛）	", "24MB", new DateTime(2014, 3, 18), "该版本是部分版本Minecraft及其扩展所需版本", ""));
            list.Add(new JDK("SE 9.0", "", "24MB", new DateTime(2017, 9, 21), "暂无", ""));
            list.Add(new JDK("SE 10.0", "", "24MB", new DateTime(2018, 3, 21), "暂无", ""));
            list.Add(new JDK("SE 11.0", "", "24MB", new DateTime(2018, 9, 25), "暂无", ""));
            list.Add(new JDK("SE 12.0", "", "24MB", new DateTime(2019, 3, 19), "该版本是官方正式稳定版，建议使用此版本", ""));
            list.Add(new JDK("SE 13.0", "", "24MB", new DateTime(2019, 9, 17), "该版本是官方正式发布版，建议使用此版本", ""));
            foreach (JDK item in list)
            {
                dataGrid.Items.Add(new { Version = item.Version, Name = item.Name, Size = item.Size, Date = $"{item.Date.Year}.{item.Date.Month}.{item.Date.Day}", More = item.More });
            }
        }

        private void Flush()
        {
            website = file.ValueReader(mydir + @"\conf\website.txt");
            jdkDir = file.ValueReader(mydir + @"\conf\jdk.txt");
            InstallDir.Text = jdkDir;
        }

        private void install_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedIndex!=-1)
            {
                JDK temp = (JDK)list[dataGrid.SelectedIndex];
                if (File.Exists(jdkDir))
                {
                    if (temp.Install(jdkDir))
                    {
                        Flush();
                    }
                    else
                    {
                        MessageBox.Show($"安装 Java {temp} 的过程中发生了错误", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    Configure();
                }
            }
        }

        private void Configure()
        {
            if (File.Exists(InstallDir.Text))
            {
                if (file.ValueWriter(jdkDir, InstallDir.Text))
                {
                    Flush();
                }
                else
                {
                    MessageBox.Show($"配置 Java 安装路径的过程中发生了错误, 请打开{jdkDir}文件手动修改", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void menu_openJdkDir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(jdkDir))
                {
                    Process.Start(jdkDir);
                }
                else
                {
                    Configure();
                }
            }
            catch (Exception o)
            {
                MessageBox.Show($"错误原因：{o.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void menu_goWebsite_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(website);
            }
            catch (Exception p)
            {
                if (MessageBox.Show("错误原因：\n" + p.Message + "\n是否将官网网址复制到剪切板？", "错误", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
                {
                    Clipboard.SetDataObject(website);
                }
            }
        }

        private void menu_jdkdir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(jdkDir))
                {
                    Process.Start(jdkDir);
                }
                else
                {
                    if (MessageBox.Show("默认安装路径配置错误，是否现在重新配置？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        
                    }
                }
            }
            catch (Exception p)
            {
                MessageBox.Show("错误原因：\n" + p.Message, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void menu_option_Click(object sender, RoutedEventArgs e)
        {
            options.IsExpanded = true;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed && e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void menu_AboutApptool_Click(object sender, RoutedEventArgs e)
        {
            appTool.ShowAbout();
        }

        private void InstallDir_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Configure();
            }
        }
    }
}
