using KitX.Core;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KitX
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public AppsBar_Controller abc = new AppsBar_Controller();
        public static string StartTheme = Library.FileHelper.Config.ReadValue($"{App.WorkBase}\\App.config", "LastTheme");
        private readonly bool ShouldShow_AppsBar = Convert.ToBoolean(Library.FileHelper.Config.ReadValue($"{App.WorkBase}\\App.config", "ShouldAppsBarOpen"));

        private bool CanClose = false;

        /// <summary>
        /// 退出程序
        /// </summary>
        private void Quit()
        {
            CanClose = false;
            Close();
            abc.Quit();
            App.LazyClose();
        }

        /// <summary>
        /// 主窗体构造函数
        /// </summary>
        public MainWindow()
        {
            App.WriteLineLog(App.MainLogFile, "MainWindow Actived.");
            InitializeComponent();
            App.WriteLineLog(App.MainLogFile, "InitializeComponent() Actived.");

            Resources["UserName"] = Environment.UserName;

            Loaded += (x, y) =>
              {
                  ReFresher_Click(null, null);
                  App.WriteLineLog(App.MainLogFile, "MainWindow loaded.");
                  if (StartTheme.Equals("Dark"))
                  {
                      ModifyTheme(theme => theme.SetBaseTheme(MaterialDesignThemes.Wpf.Theme.Dark));
                      (Template.FindName("ToggleButton_Theme", this) as ToggleButton).IsChecked = true;
                      abc.SetForeground(AppsBar_Controller.Fore.white);
                      ToastToolThemeChanged(Core.Theme.Dark);

                      App.WriteLineLog(App.MainLogFile, "Checked StartTheme is Dark.");
                  }

                  #region 第一次启动事件
                  if (File.Exists($"{App.WorkBase}\\FirstRun.signal"))
                  {
                      System.Diagnostics.Process.Start($"{App.WorkBase}\\KitX.Helper.exe", "-f");

                      App.WriteLineLog(App.MainLogFile, "Hello World!");
                      App.WriteLineLog(App.MainLogFile, "It's my first running on your computer.");
                      App.WriteLineLog(App.MainLogFile, "What's your name?");

                      File.Delete($"{App.WorkBase}\\FirstRun.signal");
                      FirstStartTeacher first = new FirstStartTeacher()
                      {
                          WindowStartupLocation = WindowStartupLocation.CenterOwner,
                          Owner = this
                      };
                      first.Show();
                  } 
                  #endregion

                  App.WriteLineLog(App.MainLogFile, "Check should open AppsBar on startUp.");

                  RefreshPathSetting();

                  ToggleButton tb = Template.FindName("AppsBarManager", this) as ToggleButton;
                  if (ShouldShow_AppsBar)
                  {
                      AppsBarManager_Checked(tb, null);
                  }
              };

            KeyDown += MainWindow_KeyDown;

            App.WriteLineLog(App.MainLogFile, "Read config for theme.");
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyStates == e.KeyboardDevice.GetKeyStates(Key.P) && e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                Command.NormalCommand(App.Input_Normal("输入调试命令", "调试"), this);
            }
            var facer = (Template.FindName("Facer", this) as MaterialDesignThemes.Wpf.Transitions.Transitioner);
            if (e.KeyStates == e.KeyboardDevice.GetKeyStates(Key.W) && facer.SelectedIndex != 0)
                facer.SelectedIndex--;
            if (e.KeyStates == e.KeyboardDevice.GetKeyStates(Key.S) && facer.SelectedIndex != facer.Items.Count)
                facer.SelectedIndex++;

            var cog = (Template.FindName("Cog_Pages", this) as MaterialDesignThemes.Wpf.Transitions.Transitioner);
            if (e.KeyStates == e.KeyboardDevice.GetKeyStates(Key.A) && cog.SelectedIndex != 0)
                cog.SelectedIndex--;
            if (e.KeyStates == e.KeyboardDevice.GetKeyStates(Key.D) && cog.SelectedIndex != cog.Items.Count)
                cog.SelectedIndex++;

            var lib = (Template.FindName("LibViewer", this) as MaterialDesignThemes.Wpf.Transitions.Transitioner);
            if (e.KeyStates == e.KeyboardDevice.GetKeyStates(Key.Q) && lib.SelectedIndex != 0)
                lib.SelectedIndex--;
            if (e.KeyStates == e.KeyboardDevice.GetKeyStates(Key.E) && lib.SelectedIndex != lib.Items.Count)
                lib.SelectedIndex++;
        }

        /// <summary>
        /// 取消窗体关闭事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            if (CanClose)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                Hide();
                Library.FileHelper.Config.WriteValue($"{App.WorkBase}\\App.config", "LastSize", $"{ActualWidth},{ActualHeight}");
                Library.FileHelper.Config.WriteValue($"{App.WorkBase}\\App.config", "LastLocation", $"{Left},{Top}");
            }
        }

        /// <summary>
        /// 窗体移动代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        #region 主题相关代码
        /// <summary>
        /// 切换主题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ToggleButton_Theme_Click(object sender, RoutedEventArgs e)
        {
            await Dispatcher.BeginInvoke(new Action(delegate
            {
                ModifyTheme(theme => theme.SetBaseTheme((bool)(sender as ToggleButton).IsChecked ? MaterialDesignThemes.Wpf.Theme.Dark : MaterialDesignThemes.Wpf.Theme.Light));
                if (StartTheme.Equals("Dark"))
                {
                    StartTheme = "Light";
                    Library.FileHelper.Config.WriteValue($"{App.WorkBase}\\App.config", "LastTheme", StartTheme);
                    abc.SetForeground(AppsBar_Controller.Fore.black);
                    ToastToolThemeChanged(Core.Theme.Light);
                }
                else
                {
                    StartTheme = "Dark";
                    Library.FileHelper.Config.WriteValue($"{App.WorkBase}\\App.config", "LastTheme", StartTheme);
                    abc.SetForeground(AppsBar_Controller.Fore.white);
                    ToastToolThemeChanged(Core.Theme.Dark);
                }
                abc.RefreshTheme();
            }));
        }

        /// <summary>
        /// 通知插件切换主题
        /// </summary>
        /// <param name="theme"></param>
        private void ToastToolThemeChanged(Core.Theme theme)
        {
            foreach (var item in finds)
            {
                item.SetTheme(theme);
            }
            abc.RefreshToolTheme(theme);
        }

        /// <summary>
        /// MD的主题切换
        /// </summary>
        /// <param name="modificationAction"></param>
        private static void ModifyTheme(Action<ITheme> modificationAction)
        {
            PaletteHelper paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();
            modificationAction?.Invoke(theme);
            paletteHelper.SetTheme(theme);
        }
        #endregion

        /// <summary>
        /// 语言改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LangS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string langName;
            switch ((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    langName = "zh-CN";
                    break;
                case 1:
                    langName = "zh-CHT";
                    break;
                case 2:
                    langName = "en-US";
                    break;
                case 3:
                    langName = "ja-JP";
                    break;
                default:
                    langName = "zh-CN";
                    (sender as ComboBox).SelectedIndex = 0;
                    HandyControl.Controls.Growl.Info($"Your selected language wasn't surpported.");
                    break;
            }

            ResourceDictionary langRd = null;
            try
            {
                //根据名字载入语言文件
                langRd = Application.LoadComponent(new Uri(@"Lang\" + langName + ".xaml", UriKind.Relative)) as ResourceDictionary;
            }
            catch (Exception e2)
            {
                HandyControl.Controls.Growl.Error($"File {App.WorkBase}\\Lang\\{langName}.xaml didn't found.\r\n{e2.Message}");
            }

            if (langRd != null)
            {
                //如果已使用其他语言,先清空
                if (Resources.MergedDictionaries.Count > 0)
                {
                    Resources.MergedDictionaries.Clear();
                }
                Resources.MergedDictionaries.Add(langRd);
            }
            else
            {
                HandyControl.Controls.Growl.Warning($"Please selected one Language first.");
            }
            App.WriteLineLog(App.MainLogFile, "LangS_SelectionChanged Actived and Language changed.");
        }

        public List<IContract> finds = new List<IContract>();

        [ImportMany]
        public Lazy<IContract>[] Plugins { get; set; }
        private CompositionContainer container = null;

        /// <summary>
        /// 寻找并发现插件
        /// </summary>
        public void Tools_Refind()
        {
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate
            {
                if (Directory.Exists(App.ToolsPath))
                {
                    var catalog = new DirectoryCatalog(App.ToolsPath, "*.dll");
                    container = new CompositionContainer(catalog);
                    IEnumerable<IContract> sub = container.GetExportedValues<IContract>();
                    foreach (var item in sub)
                    {
                        finds.Add(item);
                        item.SetWorkBase($"{App.ToolsBase}\\{item.GetPublisher()}\\{item.GetName()}");
                    }

                    foreach (IContract item in finds)
                    {
                        _ = Task.Run(() => AddTool(item));
                    }
                }
            }));
        }

        /// <summary>
        /// 多线程更新工具
        /// </summary>
        private void AddToolThread()
        {
            App.WriteLineLog(App.MainLogFile, "ReFresher_Click Actived.");
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate
            {
                ListBox lister = Template.FindName("ToolsList", this) as ListBox;
                lister.Items.Clear();
            }));
            finds.Clear();

            Tools_Refind();
        }

        /// <summary>
        /// 刷新工具按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ReFresher_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(AddToolThread);

            #region 原先发现工具代码块
            //if (!Directory.Exists(App.ToolsPath))
            //{
            //    Directory.CreateDirectory(App.ToolsPath);
            //}
            //var catalog = new DirectoryCatalog(App.ToolsPath, "*.dll");
            //if (catalog != null)
            //{
            //    using (CompositionContainer container = new CompositionContainer(catalog))
            //    {
            //        IEnumerable<IContract> sub = container.GetExportedValues<IContract>();
            //        foreach (var item in sub)
            //        {
            //            finds.Add(item);
            //        }
            //    }
            //}
            //catalog.Dispose();

            //foreach (var item in finds)
            //{
            //    _ = Task.Run(() => AddTool(item));
            //}
            #endregion
        }

        /// <summary>
        /// 异步添加工具条
        /// </summary>
        /// <param name="item">接口传参</param>
        private void AddTool(IContract item)
        {
            ListBox lister = Template.FindName("ToolsList", this) as ListBox;
            Dispatcher.BeginInvoke(new Action(delegate
            {
                ToolItem ti = CreateItem(item);
                ListBoxItem lb = new ListBoxItem() { Content = ti };
                lb.Selected += (x, y) =>
                {
                    Resources["ToolName"] = item.GetName();
                    Resources["Publisher"] = item.GetPublisher();
                    Resources["InstalledVersion"] = item.GetVersion();
                    Resources["Discription"] = item.GetDescribe_Complex();
                    Resources["HelpLink"] = item.GetHelpLink();
                    Resources["HostLink"] = item.GetHostLink();
                    Resources["Icon"] = item.GetIcon();
                    Resources["LangProvided"] = item.GetLang();
                    SetTager(item.GetTag());
                    ChangePage_Lib(1);
                };
                lister.Dispatcher.BeginInvoke(new Action(() => lister.Items.Add(lb)));
            }));
        }

        /// <summary>
        /// 选项分类动态资源设置
        /// </summary>
        /// <param name="tag"></param>
        private void SetTager(Tags tag)
        {
            string sourceName = null;
            switch (tag)
            {
                case Tags.Process:
                    sourceName = "Process";
                    break;
                case Tags.Program:
                    sourceName = "Program";
                    break;
                case Tags.Normal:
                    sourceName = "Normal";
                    break;
                case Tags.Design:
                    sourceName = "Design";
                    break;
                case Tags.System:
                    sourceName = "System";
                    break;
            }
            (Template.FindName("Tager", this) as HandyControl.Controls.Shield).SetResourceReference(HandyControl.Controls.Shield.StatusProperty, $"Left_Sort_{sourceName}");
        }

        /// <summary>
        /// 创建工具条
        /// </summary>
        /// <param name="item">接口传参</param>
        /// <returns></returns>
        private ToolItem CreateItem(IContract item)
        {
            ToolItem ti = new ToolItem(ref item);
            ti.Initialize();
            ti.Adder.Click += (x, y) =>
            {
                if (ti.HasAdded)
                {
                    abc.RemoveTool($"{item.GetPublisher()}_{item.GetName()}");
                    ti.HasAdded = false;
                }
                else
                {
                    abc.AddTool(item, item.GetIcon(), $"{item.GetPublisher()}_{item.GetName()}");
                    ti.HasAdded = true;
                }
            };
            if (ti.HasAdded)
            {
                abc.RemoveTool($"{item.GetPublisher()}_{item.GetName()}");
                ti.HasAdded = false;
            }
            else
            {
                abc.AddTool(item, item.GetIcon(), $"{item.GetPublisher()}_{item.GetName()}");
                ti.HasAdded = true;
            }
            item.SetWorkBase($"{App.ToolsBase}\\{item.GetPublisher()}\\{item.GetName()}");
            ti.HasAdded = true;
            return ti;
        }

        /// <summary>
        /// 添加工具按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Adder_Click(object sender, RoutedEventArgs e)
        {
            App.WriteLineLog(App.MainLogFile, "Adder_Click Actived.");
            try
            {
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog()
                {
                    Filter = "通用插件|*.dll|专用插件|*.kxt", //kxt - KitX Tool 的缩写
                    Multiselect = true,
                    CheckFileExists = true,
                    InitialDirectory = App.WorkBase,
                    Title = "选取要添加的工具 - Select one or more tools which are your wants",
                    DereferenceLinks = true
                };
                ofd.ShowDialog();
                if (ofd.FileNames != null)
                {
                    foreach (string fiPath in ofd.FileNames)
                    {
                        AddPG(fiPath);
                    }
                }
                ofd.Reset();
                ReFresher_Click(null, null);
            }
            catch (Exception f)
            {
                App.WriteLineLog(App.MainLogFile, f.Message);
            }
        }

        /// <summary>
        /// 复制插件到插件目录
        /// </summary>
        /// <param name="path">插件路径</param>
        private void AddPG(string path)
        {
            if (Library.TextHelper.Text.ToCapital(Path.GetExtension(path)).Equals(".DLL"))
            {
                string tp = $"{App.ToolsPath}\\{System.IO.Path.GetFileName(path)}";
                if (!File.Exists(tp))
                {
                    File.Move(path, tp);
                    File.Copy(tp, path);
                }
                else
                {
                    string ntp = $"{App.ToolsPath}\\{System.IO.Path.GetFileNameWithoutExtension(path)}{new Random().Next(0, 300)}{System.IO.Path.GetExtension(path)}";
                    if (!File.Exists(ntp))
                    {
                        File.Copy(path, ntp);
                    }
                }
            }
            else if (Library.TextHelper.Text.ToCapital(Path.GetExtension(path)).Equals(".KXT"))
            {
                Dispatcher.BeginInvoke(new Action(delegate
                {
                    KxtFileManager.InstallKxt(path);
                }));
            }
        }

        #region 工具栏相关代码

        /// <summary>
        /// 显示工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppsBarManager_Checked(object sender, RoutedEventArgs e)
        {
            (sender as ToggleButton).IsChecked = true;
            abc.Show();
            abc.SelectLocation(App.AppsBarStartLocation);
            Library.FileHelper.Config.WriteValue($"{App.WorkBase}\\App.config", "ShouldAppsBarOpen", "true");
        }

        /// <summary>
        /// 不显示工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppsBarManager_Unchecked(object sender, RoutedEventArgs e)
        {
            (sender as ToggleButton).IsChecked = false;
            abc.Hide();
            Library.FileHelper.Config.WriteValue($"{App.WorkBase}\\App.config", "ShouldAppsBarOpen", "false");
        }

        /// <summary>
        /// 关闭工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseAppsbar(object sender, RoutedEventArgs e) => abc.Close();

        #endregion

        /// <summary>
        /// 退出应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitApp(object sender, RoutedEventArgs e)
        {
            Library.FileHelper.Config.WriteValue($"{App.WorkBase}\\App.config", "LastSize", $"{ActualWidth},{ActualHeight}");
            Library.FileHelper.Config.WriteValue($"{App.WorkBase}\\App.config", "LastLocation", $"{Left},{Top}");
            Quit();
        }

        #region 窗口置顶事件
        /// <summary>
        /// 置顶窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeepToper_Checked(object sender, RoutedEventArgs e) => Topmost = true;

        /// <summary>
        /// 取消置顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeepToper_Unchecked(object sender, RoutedEventArgs e) => Topmost = false;
        #endregion

        /// <summary>
        /// 重启应用事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReStart(object sender, RoutedEventArgs e)
        {
            Quit();
            Helper.Program.RestartMainDomain(App.WorkBase);
        }

        #region 页面切换类

        /// <summary>
        /// 跳至 库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JumpTo_Lib(object sender, RoutedEventArgs e) => ChangePage_Main(0);

        /// <summary>
        /// 跳至 市场
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JumpTo_Shop(object sender, RoutedEventArgs e) => ChangePage_Main(1);

        /// <summary>
        /// 跳至 任务计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JumpTo_Task(object sender, RoutedEventArgs e) => ChangePage_Main(2);

        /// <summary>
        /// 跳至 用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JumpTo_User(object sender, RoutedEventArgs e) => ChangePage_Main(3);

        /// <summary>
        /// 跳至 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JumpTo_Cog(object sender, RoutedEventArgs e) => ChangePage_Main(4);

        /// <summary>
        /// 跳至 主页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Go_Homepage(object sender, RoutedEventArgs e) => ChangePage_Lib(0);

        /// <summary>
        /// 改变页面Index
        /// </summary>
        /// <param name="index">index</param>
        public void ChangePage_Main(int index) => (Template.FindName("Facer", this) as MaterialDesignThemes.Wpf.Transitions.Transitioner).SelectedIndex = index;

        /// <summary>
        /// 改变页面Index
        /// </summary>
        /// <param name="index">index</param>
        public void ChangePage_Lib(int index) => (Template.FindName("LibViewer", this) as MaterialDesignThemes.Wpf.Transitions.Transitioner).SelectedIndex = index;

        /// <summary>
        /// 设置页面切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CogPageSelect(object sender, RoutedEventArgs e) => (Template.FindName("Cog_Pages", this) as MaterialDesignThemes.Wpf.Transitions.Transitioner).SelectedIndex = Convert.ToInt32((sender as MenuItem).Tag);

        /// <summary>
        /// 跳转到关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToAbout(object sender, RoutedEventArgs e)
        {
            Point p = (Point)new PointConverter().ConvertFromString((sender as MenuItem).Tag.ToString());
            ChangePage_Main((int)p.X);
            (Template.FindName("Cog_Pages", this) as MaterialDesignThemes.Wpf.Transitions.Transitioner).SelectedIndex = (int)p.Y;
        }

        /// <summary>
        /// 统一跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Nomal_Jump(object sender, RoutedEventArgs e)
        {
            Point p = (Point)new PointConverter().ConvertFromString((sender as FrameworkElement).Tag.ToString());
            ChangePage_Main((int)p.X);
            switch ((int)p.X)
            {
                case 0:
                    (Template.FindName("LibViewer", this) as MaterialDesignThemes.Wpf.Transitions.Transitioner).SelectedIndex = (int)p.Y;
                    break;
                case 4:
                    (Template.FindName("Cog_Pages", this) as MaterialDesignThemes.Wpf.Transitions.Transitioner).SelectedIndex = (int)p.Y;
                    break;
            }
        }

        #endregion

        /// <summary>
        /// 图标保存到本地
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveIcon(object sender, RoutedEventArgs e) => Dev_ShowInfo();

        /// <summary>
        /// 显示开发中信息
        /// </summary>
        private void Dev_ShowInfo() => HandyControl.Controls.Growl.Info($"This function is developing.");

        /// <summary>
        /// 读取第三方通知文本并显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadInThirdParty(object sender, RoutedEventArgs e) => (Template.FindName("ThirdPartyNotificationBox", this) as TextBox).Text = File.Exists($"{App.WorkBase}\\Source\\ThirdParty.txt") ? Library.FileHelper.FileHelper.ReadAll($"{App.WorkBase}\\Source\\ThirdParty.txt") : "Undefind... (Please press \"Load\" button first.)";

        /// <summary>
        /// 全屏幕阅读
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FullScreenReading(object sender, RoutedEventArgs e)
        {
            TextBox tb = new TextBox()
            {
                IsReadOnly = true,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(10),
                Background = new SolidColorBrush(Colors.Transparent),
                Text = File.Exists($"{App.WorkBase}\\Source\\ThirdParty.txt") ? Library.FileHelper.FileHelper.ReadAll($"{App.WorkBase}\\Source\\ThirdParty.txt") : "Undefind... (Please press \"Load\" button first.)"
            };
            ScrollViewer sv = new ScrollViewer()
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
                Background = new SolidColorBrush(Colors.Transparent),
                Content = tb
            };
            HandyControl.Controls.BlurWindow fsr = new HandyControl.Controls.BlurWindow()
            {
                Content = sv,
                Title = "Full-screen Reading Window，Press \"Alt + F4\" to Close.",
                WindowState = WindowState.Maximized,
                Icon = Icon
            };
            fsr.Show();
        }

        /// <summary>
        /// 打开链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenLink(object sender, RoutedEventArgs e)
        {
            string link = (sender as FrameworkElement).Tag.ToString();
            if (link.Contains("http://") && link.Contains("."))
            {
                System.Diagnostics.Process.Start(link);
                return;
            }
            else if (link.StartsWith("path|"))
            {
                System.Diagnostics.Process.Start(link.Split('|')[1]);
            }
            else
            {
                switch (link)
                {
                    case "uri:logFile":
                        System.Diagnostics.Process.Start(App.MainLogFile);
                        break;
                    case "uri:developing":
                        Dev_ShowInfo();
                        break;
                    default:
                        System.Diagnostics.Process.Start(link);
                        break;
                }
            }
        }

        #region 工具条拖放插件

        /// <summary>
        /// 拖入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolsList_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.FileDrop))
            //{
            //    e.Effects = DragDropEffects.Link;
            //    Border dv = Template.FindName("Dragable", this) as Border;
            //    dv.BorderBrush = FindResource("Linear_BlueToRed_3_1") as LinearGradientBrush;
            //}
            //else
            //{
            //    e.Effects = DragDropEffects.None;
            //    Toolslist_SetNoBorder();
            //}
            e.Effects = DragDropEffects.All;
            Border dv = Template.FindName("Dragable", this) as Border;
            dv.BorderBrush = FindResource("Linear_BlueToRed_3_1") as LinearGradientBrush;
        }

        /// <summary>
        /// 拖出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolsList_DragLeave(object sender, DragEventArgs e) => Toolslist_SetNoBorder();

        /// <summary>
        /// 工具栏无边框显示
        /// </summary>
        private void Toolslist_SetNoBorder()
        {
            Border dv = Template.FindName("Dragable", this) as Border;
            dv.BorderBrush = new SolidColorBrush((Color)Colors.Transparent);
        }

        /// <summary>
        /// 汇报错误文件
        /// </summary>
        /// <param name="errFile"></param>
        private void ReportErrFile(List<string> errFile)
        {
            if (errFile.Count >= 1)
            {
                DialogHost dig = new DialogHost();
                TextBox tb = new TextBox()
                {
                    IsReadOnly = true,
                    TextWrapping = TextWrapping.Wrap,
                    Text = $"Error plug-ins:\r\n{Library.TextHelper.Text.ListToLines(errFile)}"
                };
                Button but = new Button()
                {
                    Content = "Okay",
                    Command = DialogHost.CloseDialogCommand,
                    CommandTarget = dig
                };
                StackPanel host = new StackPanel();
                host.Children.Add(tb);
                host.Children.Add(but);
                dig.ShowDialog(host);
            }
        }

        /// <summary>
        /// 拖放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolsList_Drop(object sender, DragEventArgs e)
        {
            Toolslist_SetNoBorder();
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                List<string> errFile = new List<string>();
                foreach (string path in files)
                {
                    string extension = Library.TextHelper.Text.ToCapital(Path.GetExtension(path));
                    if (extension.Equals(".DLL") || extension.Equals(".KXT"))
                    {
                        AddPG(path);
                    }
                    else
                    {
                        errFile.Add(path);
                    }
                }
                ReportErrFile(errFile);
            }
            e.Handled = true;
            ReFresher_Click(null, null);
        }
        #endregion

        /// <summary>
        /// 刷新路径界面设定
        /// </summary>
        private void RefreshPathSetting()
        {
            (Template.FindName("TPSetter", this) as TextBox).Text = App.ToolsPath;
            (Template.FindName("TWSetter", this) as TextBox).Text = App.ToolsBase;
            (Template.FindName("LPSetter", this) as TextBox).Text = App.MainLogFile;
        }

        /// <summary>
        /// 路径设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PathSet(object sender, RoutedEventArgs e)
        {
            switch ((sender as FrameworkElement).Tag.ToString())
            {
                case "TP":
                    using (System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog()
                    {
                        Description = "Select Path",
                        ShowNewFolderButton = true,
                        SelectedPath = "C:\\"
                    })
                    {
                        if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK && fbd.SelectedPath != null)
                        {
                            App.ToolsPath = fbd.SelectedPath;
                            App.SaveConfig();
                        }
                        fbd.Dispose();
                    }
                    break;
                case "TW":
                    using (System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog()
                    {
                        Description = "Select Path",
                        ShowNewFolderButton = true,
                        SelectedPath = "C:\\"
                    })
                    {
                        if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK && fbd.SelectedPath != null)
                        {
                            App.ToolsBase = fbd.SelectedPath;
                            App.SaveConfig();
                        }
                        fbd.Dispose();
                    }
                    break;
                case "LP":
                    Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog()
                    {
                        Multiselect = false,
                        CheckFileExists = true,
                        CheckPathExists = true,
                        DefaultExt = "Log file|*.log",
                        Filter = "Log file|*.log|All file|*.*",
                        Title = "Select one log file path",
                        ValidateNames = true
                    };
                    openFileDialog.ShowDialog();
                    if (openFileDialog.FileName != null)
                    {
                        App.MainLogFile = openFileDialog.FileName;
                        App.SaveConfig();
                    }
                    break;
            }
            RefreshPathSetting();
        }

        /// <summary>
        /// 刷新路径界面设定（按钮触发）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshPathSetter(object sender, RoutedEventArgs e) => RefreshPathSetting();

        /// <summary>
        /// 更新工具未选中状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolsList_LostFocus(object sender, RoutedEventArgs e) => (sender as ListBox).SelectedIndex = -1;

        private void Searching(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckForUpdate(object sender, RoutedEventArgs e)
        {

        }
    }

    /// <summary>
    /// 工具栏控制类
    /// </summary>
    public class AppsBar_Controller
    {
        /// <summary>
        /// 新建工具栏实例
        /// </summary>
        AppsBar bar = new AppsBar();

        /// <summary>
        /// 添加工具
        /// </summary>
        /// <param name="item">接口实例</param>
        /// <param name="icon">图标</param>
        /// <param name="name"></param>
        public void AddTool(IContract item, BitmapImage icon, string name) => bar.AddTool(item, icon, name);

        /// <summary>
        /// 移除工具
        /// </summary>
        /// <param name="name">工具名称</param>
        public void RemoveTool(string name) => bar.RemoveTool(name);

        /// <summary>
        /// 刷新主题
        /// </summary>
        public void RefreshTheme() => bar.RefreshBackground();

        /// <summary>
        /// 通知刷新工具主题
        /// </summary>
        /// <param name="tem"></param>
        public void RefreshToolTheme(Core.Theme tem)
        {
            bar.RefreshToolTheme(tem);
            bar.NowTheme = tem;
        }

        public enum Fore { black, white }

        /// <summary>
        /// 设置前景色
        /// </summary>
        /// <param name="fore"></param>
        public void SetForeground(Fore fore)
        {
            switch (fore)
            {
                case Fore.black:
                    bar.Foreground = new SolidColorBrush(Colors.Black);
                    break;
                case Fore.white:
                    bar.Foreground = new SolidColorBrush(Colors.White);
                    break;
            }
        }

        /// <summary>
        /// 显示工具栏
        /// </summary>
        public void Show() => bar.Show();

        /// <summary>
        /// 隐藏工具栏
        /// </summary>
        public void Hide() => bar.Hide();

        /// <summary>
        /// 关闭工具栏
        /// </summary>
        public void Close()
        {
            bar.CanCloseNow = true;
            bar.Close();
            bar = null;
            bar = new AppsBar();
        }

        /// <summary>
        /// 完全退出工具栏
        /// </summary>
        public void Quit()
        {
            bar.CanCloseNow = true;
            bar.Close();
        }

        /// <summary>
        /// 锁定
        /// </summary>
        public void Lock() => bar.Locker(true);

        /// <summary>
        /// 解锁
        /// </summary>
        public void UnLock() => bar.Locker(false);

        /// <summary>
        /// 选择appsBar的位置
        /// </summary>
        /// <param name="loc"></param>
        public void SelectLocation(int loc) => bar.LS.SelectedIndex = loc;
    }
}
