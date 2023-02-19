using KitX.Controls;
using KitX.Core;
using KitX.Helper;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;
using PointConverter = System.Windows.PointConverter;

namespace KitX
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 变量常量预定义
        /// </summary>
        public AppsBar_Controller abc = new AppsBar_Controller();//创建 工具栏控制类 实例
        public static string StartTheme = Library.FileHelper.Config.ReadValue($"{App.WorkBase}\\App.config", "LastTheme");//读取配置文件 启动主题
        public readonly bool ShouldShow_AppsBar = Convert.ToBoolean(Library.FileHelper.Config.ReadValue($"{App.WorkBase}\\App.config", "ShouldAppsBarOpen"));//读取配置文件 是否启动时显示工具栏
        public bool CanClose = false; //是否可以关闭
        public bool CanMovePage = true; //是否可以切换页面
        public bool CanMoveAccPages = true; //是否可以切换用户界面的页面
        public int LangIndex = 0; //语言组脚标
        public MySQLConnection msc = null; //数据库连接器
        public int nowIndex = 0; //工具市场加载下标
        public bool willRestart = false;
        private MainWindowHelper mwh = new MainWindowHelper();
        //private bool firLang = true;

        /// <summary>
        /// 退出程序
        /// </summary>
        private void Quit()
        {
            CanClose = false;//标记工具栏窗体可以关闭
            Close();//关闭此窗体
            abc.Quit();//关闭工具栏
            msc.Dispose();//通知数据库连接器结束任务
            if (willRestart)
            {
                App.LazyRestart();
            }
            else
            {
                App.LazyClose();//延时结束整个程序
            }
        }

        /// <summary>
        /// 主窗体构造函数
        /// </summary>
        public MainWindow()
        {
            mwh.FirstStart();
            mwh.win = this;
            mwh.init();
        }

        /// <summary>
        /// 取消窗体关闭事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e) => mwh.OnClosingHelp(e);

        /// <summary>
        /// 窗体移动代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseDown(object sender, MouseButtonEventArgs e) => mwh.WindowMove();

        /// <summary>
        /// 切换主题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ToggleButton_Theme_Click(object sender, RoutedEventArgs e)
        {
            await Dispatcher.BeginInvoke(new Action(delegate
            {
                //ModifyTheme(theme => theme.SetBaseTheme((bool)(sender as ToggleButton).IsChecked ? MaterialDesignThemes.Wpf.Theme.Dark : MaterialDesignThemes.Wpf.Theme.Light));
                if (StartTheme.Equals("Dark"))
                {
                    StartTheme = "Light";
                    abc.SetForeground(AppsBar_Controller.Fore.black);
                    ToastToolThemeChanged(Core.Theme.Light);
                    ChangeSkin(SkinType.Light);
                }
                else
                {
                    StartTheme = "Dark";
                    abc.SetForeground(AppsBar_Controller.Fore.white);
                    ToastToolThemeChanged(Core.Theme.Dark);
                    ChangeSkin(SkinType.Dark);
                }
                Library.FileHelper.Config.WriteValue($"{App.WorkBase}\\App.config", "LastTheme", StartTheme);
                abc.RefreshTheme();
            }));
        }

        /// <summary>
        /// 通知插件切换主题
        /// </summary>
        /// <param name="theme"></param>
        public void ToastToolThemeChanged(Core.Theme theme)
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

        /// <summary>
        /// 语言改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LangS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LangIndex = (sender as ComboBox).SelectedIndex;
            ((App)Application.Current).UpdateLangIndex(LangIndex);
            ((App)Application.Current).LoadLanguage(LangIndex);

            #region 元片段
            //string langName;
            //switch (LangIndex)
            //{
            //    case 0:
            //        langName = "zh-cn";
            //        break;
            //    case 1:
            //        langName = "zh-cht";
            //        break;
            //    case 2:
            //        langName = "en-us";
            //        break;
            //    case 3:
            //        langName = "ja-jp";
            //        break;
            //    default:
            //        langName = "zh-cn";
            //        (sender as ComboBox).SelectedIndex = 0;
            //        HandyControl.Controls.Growl.Info($"Your selected language wasn't surpported.");
            //        break;
            //}

            //ResourceDictionary langRd = null;
            //try
            //{
            //    //根据名字载入语言文件
            //    langRd = Application.LoadComponent(new Uri($"Lang\\{langName}.xaml", UriKind.Relative)) as ResourceDictionary;
            //}
            //catch (Exception e2)
            //{
            //    HandyControl.Controls.Growl.Error($"File {App.WorkBase}\\Lang\\{langName}.xaml didn't found.\r\n{e2.Message}");
            //}

            //if (langRd != null)
            //{
            //    ResourceDictionary rd = Application.Current.Resources;
            //    if (!firLang)
            //    {
            //        ResourceDictionary tmp = null;
            //        foreach (ResourceDictionary item in rd.MergedDictionaries)
            //        {
            //            if (item.Source.ToString().StartsWith("Lang"))
            //            {
            //                tmp = item;
            //            }
            //        }
            //        rd.MergedDictionaries.Remove(tmp);
            //    }
            //    else
            //    {
            //        firLang = true;
            //    }
            //    rd.MergedDictionaries.Add(langRd);
            //}
            //else
            //{
            //    HandyControl.Controls.Growl.Warning($"Please selected one Language first.");
            //} 
            #endregion
        }

        //已发现的插件 List
        public List<IContract> finds = new List<IContract>();
        //插件装载容器
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
                        AddTool(item);
                    }
                }
            }));
        }

        /// <summary>
        /// 多线程更新工具
        /// </summary>
        private void AddToolThread()
        {
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate
            {
                ListBox lister = Template.FindName("ToolsList", this) as ListBox;
                lister.Items.Clear();
            }));
            finds.Clear();

            if (container != null)
            {
                container.Dispose();
            }

            Tools_Refind();
        }

        /// <summary>
        /// 刷新工具按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ReFresher_Click(object sender, RoutedEventArgs e) => await Task.Run(AddToolThread);

        /// <summary>
        /// (异步?)添加工具条
        /// </summary>
        /// <param name="item">接口传参</param>
        private void AddTool(IContract item)
        {
            ListBox lister = Template.FindName("ToolsList", this) as ListBox;

            ToolItem ti = CreateItem(item);
            ListBoxItem lb = new ListBoxItem() { Content = ti };
            lb.Loaded += (x, y) =>
            {
                lb.Tag = lb.ActualHeight;
            };
            ti.lbi = lb;
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
            lister.Items.Add(lb);
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
            string binName = $"{item.GetPublisher()}_{item.GetName().Replace(' ', '_')}";
            ti.Adder.Click += (x, y) =>
            {
                if (ti.HasAdded)
                {
                    abc.RemoveTool(binName);
                    ti.HasAdded = false;
                }
                else
                {
                    abc.AddTool(item, item.GetIcon(), binName);
                    ti.HasAdded = true;
                }
            };
            if (ti.HasAdded)
            {
                abc.RemoveTool(binName);
                ti.HasAdded = false;
            }
            else
            {
                abc.AddTool(item, item.GetIcon(), binName);
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

        /// <summary>
        /// 显示工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AppsBarManager_Checked(object sender, RoutedEventArgs e)
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
        public void AppsBarManager_Unchecked(object sender, RoutedEventArgs e)
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
        private void CloseAppsbar(object sender, RoutedEventArgs e)
        {
            (Template.FindName("AppsBarManager", this) as ToggleButton).IsChecked = false;
            abc.Close();
        }

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

        /// <summary>
        /// 退出应用2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitApp2(object sender, RoutedEventArgs e)
        {
            Library.FileHelper.Config.WriteValue($"{App.WorkBase}\\App.config", "LastSize", $"{ActualWidth},{ActualHeight}");
            Library.FileHelper.Config.WriteValue($"{App.WorkBase}\\App.config", "LastLocation", $"{Left},{Top}");
            new Thread(() =>
            {
                Thread.Sleep(500);
                Dispatcher.Invoke(() =>
                {
                    Quit();
                });
            }).Start();
        }

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

        /// <summary>
        /// 重启应用事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReStart(object sender, RoutedEventArgs e)
        {
            willRestart = true;
            Quit();
            //Helper.Program.RestartMainDomain(App.WorkBase);
        }

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
        private void Normal_Jump(object sender, RoutedEventArgs e)
        {
            Point p = (Point)new PointConverter().ConvertFromString((sender as FrameworkElement).Tag.ToString());
            ChangePage_Main((int)p.X);
            switch ((int)p.X)
            {
                case 0:
                    (Template.FindName("LibViewer", this) as MaterialDesignThemes.Wpf.Transitions.Transitioner).SelectedIndex = (int)p.Y;
                    break;
                case 3:
                    if (CanMoveAccPages)
                    {
                        (Template.FindName("Acc_Pages", this) as MaterialDesignThemes.Wpf.Transitions.Transitioner).SelectedIndex = (int)p.Y;
                    }
                    break;
                case 4:
                    (Template.FindName("Cog_Pages", this) as MaterialDesignThemes.Wpf.Transitions.Transitioner).SelectedIndex = (int)p.Y;
                    break;
            }
        }

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
            if ((link.Contains("http://") || link.Contains("https://")) && link.Contains("."))
            {
                Process.Start(link);
                return;
            }
            else if (link.StartsWith("path|"))
            {
                Process.Start(link.Split('|')[1]);
            }
            else if (link.StartsWith("config"))
            {
                ConfigOperate(link.Split(':')[1]);
            }
            else if (link.StartsWith("mt"))
            {
                ChangeMarketType(link.Split(':')[1]);
            }
            else
            {
                switch (link)
                {
                    case "uri:logFile":
                        Process.Start(App.MainLogFile);
                        break;
                    case "uri:developing":
                        Dev_ShowInfo();
                        break;
                    case "uri:signin":
                        SignIn();
                        break;
                    case "uri:signup":
                        SignUp();
                        break;
                    case "uri:signout":
                        CanMoveAccPages = true;
                        Normal_Jump(new FrameworkElement()
                        {
                            Tag = "3,0"
                        }, null);
                        Resources["UserName"] = Environment.UserName;
                        Resources["UserSigned"] = Visibility.Hidden;
                        Resources["YUserIcon"] = Visibility.Visible;
                        break;
                    case "uri:uploadicon":
                        new Thread(() =>
                        {
                            Dictionary<string, string> dictionaries = new Dictionary<string, string>
                            {
                                { "PNG Image", "*.png" }
                            };
                            string path = Library.FileHelper.FileWin.OpenFile_Single(dictionaries, mwh.signUpInfos[LangIndex][5]);
                            if (path != null && File.Exists(path))
                            {
                                if (!msc.UploadIcon(Library.FileHelper.FileHelper.ReadByteAll(path), ID))
                                {
                                    Dispatcher.BeginInvoke(new Action(() =>
                                    {
                                        HandyControl.Controls.Growl.Error(mwh.signUpInfos[LangIndex][6]);
                                    }));
                                }
                            }
                        }).Start();
                        break;
                    case "uri:saveinfo":
                        string[][] ret = GetInfoDict();
                        new Thread(() =>
                        {
                            if (!msc.UploadInfo(ID, ret[0], ret[1]))
                            {
                                Dispatcher.BeginInvoke(new Action(() =>
                                {
                                    HandyControl.Controls.Growl.Error(mwh.signUpInfos[LangIndex][8]);
                                }));
                            }
                        }).Start();
                        break;
                    case "uri:unload":
                        if (container != null)
                        {
                            container.Dispose();
                        }
                        break;
                    case "uri:idcard":
                        Bitmap bmp = PopEye.WPF.Helper.GetImageFromControl.ToBitmap((sender as FrameworkElement).Parent as FrameworkElement);
                        BitmapSource bmpResource = PopEye.WPF.Helper.ImageWork.getBitMapSourceFromBitmap(bmp);
                        try
                        {
                            Clipboard.SetImage(bmpResource);
                            HandyControl.Controls.Growl.Success(mwh.signInfos[LangIndex][8]);
                        }
                        catch
                        {
                            HandyControl.Controls.Growl.Warning(mwh.signInfos[LangIndex][9]);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// 切换筛选器
        /// </summary>
        /// <param name="v"></param>
        private void ChangeMarketType(string v)
        {
            switch (v)
            {
                case "all":
                    nowMarketType = MarketType.All;
                    break;
                case "pcs":
                    nowMarketType = MarketType.Process;
                    break;
                case "pgm":
                    nowMarketType = MarketType.Program;
                    break;
                case "nml":
                    nowMarketType = MarketType.Normal;
                    break;
                case "dsn":
                    nowMarketType = MarketType.Design;
                    break;
                case "sys":
                    nowMarketType = MarketType.System;
                    break;
            }
            if (msc != null)
            {
                Button btn = (Template.FindName("Btn_Market_Flush", this) as Button);
                RefreshMarket(btn);
                btn.IsEnabled = false;
            }
        }

        /// <summary>
        /// 市场筛选器
        /// </summary>
        public enum MarketType
        {
            All, Process, Program, Normal, Design, System
        }

        public MarketType nowMarketType = MarketType.All;

        /// <summary>
        /// 刷新市场页面按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshMarket(object sender, RoutedEventArgs e)
        {
            if (msc != null)
            {
                RefreshMarket(sender as Button);
                (sender as Button).IsEnabled = false;
            }
        }

        /// <summary>
        /// 更新筛选按钮禁用状态
        /// </summary>
        /// <param name="target">状态</param>
        private void SortTypesStateUpdater(bool target)
        {
            WrapPanel wp = Template.FindName("Market_Filters_Panel", this) as WrapPanel;
            wp.IsEnabled = target;
            foreach (FrameworkElement element in wp.Children)
            {
                element.IsEnabled = target;
            }
        }

        /// <summary>
        /// 刷新市场页面
        /// </summary>
        private void RefreshMarket(Button btn)
        {
            WrapPanel wp = Template.FindName("Market", this) as WrapPanel;
            wp.Children.Clear();
            SortTypesStateUpdater(false);
            new Thread(() =>
            {
                List<string> ids = null;
                switch (nowMarketType)
                {
                    case MarketType.All:
                        for (int i = 0; i < 5; i++)
                        {
                            if (AddMarketToolName(Library.MathHelper.Basic.CoverPosition(i + 1, 18, '0')))
                            {
                                nowIndex = i + 1;
                            }
                        }
                        Dispatcher.Invoke(new Action(() =>
                        {
                            SortTypesStateUpdater(true);
                        }));
                        break;
                    case MarketType.Process:
                        ids = msc.GetIDs(MySQLConnection.toolType.process);
                        break;
                    case MarketType.Program:
                        ids = msc.GetIDs(MySQLConnection.toolType.program);
                        break;
                    case MarketType.Normal:
                        ids = msc.GetIDs(MySQLConnection.toolType.normal);
                        break;
                    case MarketType.Design:
                        ids = msc.GetIDs(MySQLConnection.toolType.design);
                        break;
                    case MarketType.System:
                        ids = msc.GetIDs(MySQLConnection.toolType.system);
                        break;
                }
                if (nowMarketType != MarketType.All)
                {
                    foreach (string nowpgid in ids)
                    {
                        AddMarketToolName(nowpgid);
                    }
                    Dispatcher.Invoke(new Action(() =>
                    {
                        SortTypesStateUpdater(true);
                    }));
                }
                AddAddButton(btn);
            }).Start();
        }

        /// <summary>
        /// 添加追加按钮
        /// </summary>
        private void AddAddButton(Button rfbtn)
        {
            WrapPanel wp = Template.FindName("Market", this) as WrapPanel;
            Dispatcher.BeginInvoke(new Action(() =>
            {
                Button btn = new Button()
                {
                    Content = "+ 10",
                    Margin = new Thickness(10)
                };
                btn.Click += (x, y) =>
                {
                    wp.Children.Remove(btn);
                    rfbtn.IsEnabled = false;
                    new Thread(() =>
                    {
                        for (int j = nowIndex; j < nowIndex + 10; j++)
                        {
                            if (AddMarketToolName(Library.MathHelper.Basic.CoverPosition(j + 1, 18, '0')))
                            {
                                nowIndex = j + 1;
                            }
                        }
                        AddAddButton(rfbtn);
                    }).Start();
                };
                wp.Children.Add(btn);
                rfbtn.IsEnabled = true;
            }));
        }

        /// <summary>
        /// 向市场中添加工具 UI 项
        /// </summary>
        /// <param name="pgid">工具 ID</param>
        private bool AddMarketToolName(string pgid)
        {
            WrapPanel wp = Template.FindName("Market", this) as WrapPanel;
            var connect = msc;
            string[] infos = connect.GetToolItem(pgid);
            if (infos != null)
            {
                byte[] head = connect.GetToolIcon(pgid);
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    ToolCard tc = new ToolCard()
                    {
                        RefreshFather = Template.FindName("Btn_Market_Flush", this) as Button,
                        ToolName = infos[1],
                        SimpleDescribe = infos[3],
                        ComplexDescribe = infos[4],
                        pgID = pgid,
                        FatherWin = this,
                        infos = infos
                    };
                    tc.img.Source = Library.BitmapImageHelper.Converter.ByteArray2BitmapImage(head);
                    wp.Children.Add(tc);
                }));
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 处理对配置文件的操作
        /// </summary>
        /// <param name="cmd"></param>
        private void ConfigOperate(string cmd)
        {
            switch (cmd)
            {
                case "download":
                    new Thread(() =>
                    {
                        byte[] config = msc.GetConfig(ID);
                        if (config != null)
                        {
                            Library.FileHelper.FileHelper.WriteByteIn($"{App.WorkBase}\\App.config", msc.GetConfig(ID));
                            //Library.FileHelper.FileHelper.WriteIn($"{App.WorkBase}\\KitX.exe.config", Library.FileHelper.FileHelper.ReadAll($"{App.WorkBase}\\App.config"));
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                HandyControl.Controls.Growl.Success(mwh.signUpInfos[LangIndex][9]);
                            }));
                        }
                        else
                        {
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                HandyControl.Controls.Growl.Warning(mwh.signUpInfos[LangIndex][11]);
                            }));
                        }
                    }).Start();
                    break;
                case "upload":
                    new Thread(() =>
                    {
                        if (msc.UploadConfig(Library.FileHelper.FileHelper.ReadByteAll($"{App.WorkBase}\\App.config"), ID))
                        {
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                HandyControl.Controls.Growl.Success(mwh.signUpInfos[LangIndex][10]);
                            }));
                        }
                        else
                        {
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                HandyControl.Controls.Growl.Warning(mwh.signUpInfos[LangIndex][12]);
                            }));
                        }
                    }).Start();
                    break;
            }
        }

        /// <summary>
        /// 获取当前用户信息表单列表
        /// </summary>
        /// <returns></returns>
        private string[][] GetInfoDict()
        {
            string[] keys = new string[9]
            {
                "username","usermail","usersex","usersign","userbirthday","usereducationbackground","userlocation","userjob","userdescribe",
            };
            string[] values = new string[9]
            {
                GetText("UserNameBox"), GetText("UserMailBox"), (Template.FindName("UserSexBox", this) as ComboBox).SelectedIndex.ToString(),
                GetText("UserSignBox"), ((DateTime)(Template.FindName("UserBirthBox", this) as DatePicker).SelectedDate).ToString("yyyy-MM-dd"),
                GetText("UserEBBox"), GetText("UserLocBox"), GetText("UserJobBox"), GetText("UserDcbBox")
            };
            return new string[2][]
            {
                keys, values
            };
        }

        /// <summary>
        /// 获取用户界面TextBox的Text属性值
        /// </summary>
        /// <param name="name">TextBox的控件名</param>
        /// <returns>属性值</returns>
        private string GetText(string name) => (Template.FindName(name, this) as TextBox).Text;

        /// <summary>
        /// 设置用户界面TextBox的Text属性值
        /// </summary>
        /// <param name="name">TextBox的控件名</param>
        /// <param name="text">要设置的属性值</param>
        /// <returns>属性值</returns>
        private void SetText(string name, string text) => (Template.FindName(name, this) as TextBox).Text = text;

        private string ID; //用户ID
        private string pwd; //用户密码

        /// <summary>
        /// 登录事件
        /// </summary>
        public void SignIn()
        {
            ID = (Template.FindName("SignIn_ID_Box", this) as TextBox).Text;
            pwd = (Template.FindName("SignIn_Pwd_Box", this) as PasswordBox).Password;
            srpwd = (bool)(Template.FindName("ShouldRememberPWD_CheckBox", this) as CheckBox).IsChecked;
            new Thread(CheckSignInfo).Start();
        }

        private bool srpwd = false;

        /// <summary>
        /// 更新用户界面用户信息
        /// </summary>
        private void UpdateUserUIInfo()
        {
            BitmapImage bitmap = Library.BitmapImageHelper.Converter.ByteArray2BitmapImage(msc.GetIcon(ID));
            Resources["UserHeader"] = bitmap;
            new Thread(() =>
            {
                int si = msc.GetSex(ID);
                DateTime dt = msc.GetBirth(ID);
                Dispatcher.Invoke(new Action(() =>
                {
                    (Template.FindName("UserSexBox", this) as ComboBox).SelectedIndex = si;
                    (Template.FindName("UserBirthBox", this) as DatePicker).SelectedDate = dt;
                }));
            }).Start();
            SetText("UserNameBox", userInfos[0]);
            Resources["UserName"] = userInfos[0];
            Resources["UserMail"] = userInfos[1];
            SetText("UserMailBox", userInfos[1]);
            //SetText("UserPhoneBox", msc.GetPhone(ID));
            SetText("UserSignBox", userInfos[2]);
            SetText("UserLocBox", userInfos[3]);
            SetText("UserJobBox", userInfos[4]);
            SetText("UserDcbBox", userInfos[5]);
            SetText("UserEBBox", userInfos[6]);
            Resources["UserSigned"] = Visibility.Visible;
            Resources["YUserIcon"] = Visibility.Hidden;
        }

        /// <summary>
        /// 校正用户信息文件
        /// </summary>
        private void ReviseUserInfoFile()
        {
            if (File.Exists($"{App.WorkBase}\\Config\\userinfo.bin"))
            {
                File.Delete($"{App.WorkBase}\\Config\\userinfo.bin");
            }
            if (File.Exists($"{App.WorkBase}\\Config\\userinfo.acc"))
            {
                File.Delete($"{App.WorkBase}\\Config\\userinfo.acc");
            }
        }

        private string[] userInfos = new string[7];

        /// <summary>
        /// 检查登录信息
        /// </summary>
        private void CheckSignInfo()
        {
            if (ID != string.Empty && pwd != string.Empty)
            {
                if (ID.Length == 11 || ID.Contains("@"))
                {
                    MySQLConnection conect = msc;
                    string tpwd = conect.GetPWD(ID);
                    if (tpwd != "NULL")
                    {
                        if (pwd.Equals(tpwd))
                        {
                            userInfos = msc.GetUserInfo(ID);
                            if (userInfos != null)
                            {
                                if (srpwd)
                                {
                                    new Thread(() =>
                                    {
                                        string a_pwd = Library.TextHelper.Coder.Encrypt(tpwd, null, ID.Substring(0, 8), Library.TextHelper.Coder.ALG.DES).value;
                                        string b_pwd = Library.TextHelper.Coder.Encrypt(a_pwd, null, ID.Substring(0, 8), Library.TextHelper.Coder.ALG.DES).value;
                                        string c_pwd = Library.TextHelper.Coder.Encrypt(b_pwd, null, ID.Substring(0, 8), Library.TextHelper.Coder.ALG.DES).value;
                                        Library.FileHelper.FileHelper.WriteIn($"{App.WorkBase}\\Config\\userinfo.bin", c_pwd);
                                        Library.FileHelper.FileHelper.WriteIn($"{App.WorkBase}\\Config\\userinfo.acc", ID);
                                    }).Start();
                                }
                                else
                                {
                                    ReviseUserInfoFile();
                                }
                                LogTip(0, TipType.suc);
                                Dispatcher.BeginInvoke(new Action(() =>
                                {
                                    Normal_Jump(new FrameworkElement()
                                    {
                                        Tag = "3,2"
                                    }, null);
                                    CanMoveAccPages = false;
                                    UpdateUserUIInfo();
                                }));
                            }
                            else
                            {
                                LogTip(1, TipType.warn);
                            }
                        }
                        else { LogTip(2, TipType.warn); }
                    }
                    else { LogTip(3, TipType.warn); }
                }
                else { LogTip(5, TipType.warn); }
            }
            else { LogTip(4, TipType.info); }
        }

        private enum TipType { info, warn, suc }

        /// <summary>
        /// 登陆提示
        /// </summary>
        /// <param name="num">角标</param>
        private void LogTip(int num, TipType tt)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                switch (tt)
                {
                    case TipType.info:
                        HandyControl.Controls.Growl.Info(mwh.signInfos[LangIndex][num]);
                        break;
                    case TipType.warn:
                        HandyControl.Controls.Growl.Warning(mwh.signInfos[LangIndex][num]);
                        break;
                    case TipType.suc:
                        HandyControl.Controls.Growl.Success(mwh.signInfos[LangIndex][num]);
                        break;
                }
            }));
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        private void SignUp()
        {
            if (CanSignUp)
            {
                SignUpThread();
            }
            else
            {
                HandyControl.Controls.Growl.Warning(mwh.signUpInfos[LangIndex][2]);
            }
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        private void SignUpThread()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (msc.AddUser(su_id, (Template.FindName("SignUp_Name_Box", this) as TextBox).Text, su_pwd) == 0)
                {
                    HandyControl.Controls.Growl.Warning(mwh.signUpInfos[LangIndex][4]);
                }
                else
                {
                    HandyControl.Controls.Growl.Success(mwh.signUpInfos[LangIndex][7]);
                    if ((bool)(Template.FindName("ShouldJumpToSignInAfterSignUp", this) as CheckBox).IsChecked)
                    {
                        Normal_Jump(new FrameworkElement()
                        {
                            Tag = "3,0"
                        }, null);
                        (Template.FindName("SignIn_ID_Box", this) as TextBox).Text = su_id;
                        (Template.FindName("SignIn_Pwd_Box", this) as PasswordBox).Password = su_pwd;
                    }
                }
            }));
        }

        string su_id, su_pwd, su_rpwd;

        private bool CanSignUp = false;

        /// <summary>
        /// 检查注册信息格式是否正确
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckSignUpFormat(object sender, TextChangedEventArgs e) => UpdateSignUpInfo();

        /// <summary>
        /// 密码框文本更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e) => UpdateSignUpInfo();

        /// <summary>
        /// 更新注册提示框信息
        /// </summary>
        private void UpdateSignUpInfo()
        {
            su_id = (Template.FindName("SignUp_ID_Box", this) as TextBox).Text;
            su_pwd = (Template.FindName("SignUp_PWD_Box", this) as PasswordBox).Password;
            su_rpwd = (Template.FindName("SignUp_RPWD_Box", this) as PasswordBox).Password;
            bool isChecked = (bool)(Template.FindName("PrivacyPolicyCheckBox", this) as CheckBox).IsChecked;
            string infoDisplay = "";
            if (su_id.Length != 11)
            {
                infoDisplay += $"1.{mwh.signUpInfos[LangIndex][0]}";
                CanSignUp = false;
                if (su_pwd != su_rpwd)
                {
                    infoDisplay += $"\r\n2.{mwh.signUpInfos[LangIndex][1]}";
                    if (!isChecked)
                    {
                        infoDisplay += $"\r\n3.{mwh.signUpInfos[LangIndex][16]}";
                    }
                }
                else if (!isChecked)
                {
                    infoDisplay += $"\r\n2.{mwh.signUpInfos[LangIndex][16]}";
                }
            }
            else if (su_pwd != su_rpwd)
            {
                infoDisplay += $"1.{mwh.signUpInfos[LangIndex][1]}";
                if (!isChecked)
                {
                    infoDisplay += $"\r\n2.{mwh.signUpInfos[LangIndex][16]}";
                }
                CanSignUp = false;
            }
            else if (!isChecked)
            {
                infoDisplay += $"1.{mwh.signUpInfos[LangIndex][16]}";
            }
            else
            {
                CanSignUp = true;
            }
            (Template.FindName("SignUpInfo", this) as TextBox).Text = infoDisplay;
        }

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

        /// <summary>
        /// 刷新路径界面设定
        /// </summary>
        public void RefreshPathSetting()
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

        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckForUpdate(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                if (App.MyVersion.Equals(msc.GetLatestVersion()))
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        HandyControl.Controls.Growl.Info(mwh.signUpInfos[LangIndex][13]);
                    }));
                }
                else
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        HandyControl.Controls.Growl.Warning(mwh.signUpInfos[LangIndex][14]);
                    }));
                }
            }).Start();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                try
                {
                    if (App.MyVersion.Equals(msc.GetLatestVersion()))
                    {
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            HandyControl.Controls.Growl.Info(mwh.signUpInfos[LangIndex][13]);
                        }));
                    }
                    else
                    {
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            HandyControl.Controls.Growl.Info(mwh.signUpInfos[LangIndex][15]);
                        }));
                        if (!Directory.Exists($"{App.ToolsBase}\\KitX_Updating\\"))
                        {
                            Directory.CreateDirectory($"{App.ToolsBase}\\KitX_Updating\\");
                        }
                        if (File.Exists($"{App.ToolsBase}\\KitX_Updating\\update.zip"))
                        {
                            File.Delete($"{App.ToolsBase}\\KitX_Updating\\update.zip");
                        }
                        Library.NetHelper.NetHelper.WebDownloadFile("https://source.catrol.cn/download/works/kitx/update.zip", $"{App.ToolsBase}\\KitX_Updating\\update.zip");
                        Process.Start($"{App.ToolsBase}\\KitX_Updating\\update.zip");
                        Process.Start(App.WorkBase);
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            HandyControl.Controls.Growl.Warning(mwh.signInfos[LangIndex][11]);
                        }));
                    }
                }
                catch (Exception p)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        HandyControl.Controls.Growl.Warning("Error:\r\n" + p.Message);
                    }));
                }
            }).Start();
        }

        /// <summary>
        /// 标记页面不能切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CantMove(object sender, RoutedEventArgs e) => CanMovePage = false;

        /// <summary>
        /// 标记页面可以切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanMove(object sender, RoutedEventArgs e) => CanMovePage = true;

        /// <summary>
        /// 设定为自启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartBySelf_Checked(object sender, RoutedEventArgs e) => Process.Start($"{App.WorkBase}\\KitX.Helper.exe", "-s[true]");

        /// <summary>
        /// 取消自启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartBySelf_Unchecked(object sender, RoutedEventArgs e) => Process.Start($"{App.WorkBase}\\KitX.Helper.exe", "-s[false]");

        /// <summary>
        /// 设置为启动时隐藏至任务栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideAtStart_Checked(object sender, RoutedEventArgs e) => Library.FileHelper.Config.WriteValue($"{App.WorkBase}\\App.config", "ShouldHideStart", "true");

        /// <summary>
        /// 取消设置为启动时隐藏至任务栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideAtStart_Unchecked(object sender, RoutedEventArgs e) => Library.FileHelper.Config.WriteValue($"{App.WorkBase}\\App.config", "ShouldHideStart", "false");

        /// <summary>
        /// 重置用户信息文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShouldRememberPWD_CheckBox_Unchecked(object sender, RoutedEventArgs e) => ReviseUserInfoFile();

        /// <summary>
        /// 搜索时事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Searching(object sender, TextChangedEventArgs e)
        {
            string text = (sender as TextBox).Text.ToUpper();
            var btn_clear = Template.FindName("btn_clear_searchBox", this) as Button;
            if (text.Length == 0)
            {
                DoubleAnimation dani = PopEye.WPF.Animation.AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 300),
                    1, 0, FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic,
                    EasingMode.EaseInOut, 0, 0);
                dani.Completed += (x, y) =>
                {
                    btn_clear.Visibility = Visibility.Hidden;
                };
                btn_clear.BeginAnimation(OpacityProperty, dani);
            }
            else if (text.Length != 0 && btn_clear.Opacity == 0)
            {
                btn_clear.Visibility = Visibility.Visible;
                DoubleAnimation dani = PopEye.WPF.Animation.AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 300),
                    0, 1, FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic,
                    EasingMode.EaseInOut, 0, 0);
                btn_clear.BeginAnimation(OpacityProperty, dani);
            }
            if (!firstSort1)
            {
                (Template.FindName("ToolTypeComboBox", this) as ComboBox).SelectedIndex = 0;
                foreach (ListBoxItem item in (Template.FindName("ToolsList", this) as ListBox).Items)
                {
                    ToolItem ti = item.Content as ToolItem;
                    IContract ic = ti.item;
                    if (ic.GetName().ToUpper().Contains(text) || ic.GetPublisher().ToUpper().Contains(text) ||
                        ic.GetVersion().ToUpper().Contains(text) || ic.GetDescribe_Simple().ToUpper().Contains(text) ||
                        ic.GetDescribe_Complex().ToUpper().Contains(text) || ic.GetHelpLink().ToUpper().Contains(text) ||
                        ic.GetHostLink().ToUpper().Contains(text))
                    {
                        ti.Show();
                        ShowItem_Height(item);
                    }
                    else
                    {
                        ti.Hide();
                        HideItem_Height(item);
                    }
                }
            }
            else
            {
                firstSort1 = false;
            }
        }

        bool firstSort = true;
        bool firstSort1 = true;

        /// <summary>
        /// 隐藏工具条
        /// </summary>
        /// <param name="lbi"></param>
        private void HideItem_Height(ListBoxItem lbi)
        {
            lbi.BeginAnimation(HeightProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 300),
                (double)lbi.Tag, 0, System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic,
                System.Windows.Media.Animation.EasingMode.EaseIn, 0, 0));
        }

        /// <summary>
        /// 显示工具条
        /// </summary>
        /// <param name="lbi"></param>
        private void ShowItem_Height(ListBoxItem lbi)
        {
            lbi.BeginAnimation(HeightProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 300),
                0, (double)lbi.Tag, System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic,
                System.Windows.Media.Animation.EasingMode.EaseIn, 0, 0));
        }

        /// <summary>
        /// 类别切换多选框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!firstSort)
            {
                foreach (ListBoxItem item in (Template.FindName("ToolsList", this) as ListBox).Items)
                {
                    (item.Content as ToolItem).Show();
                    ShowItem_Height(item);
                }
                int index = (sender as ComboBox).SelectedIndex;
                switch (index)
                {
                    case 1:
                        foreach (ListBoxItem item in (Template.FindName("ToolsList", this) as ListBox).Items)
                        {
                            if ((item.Content as ToolItem).item.GetTag() != Tags.Process)
                            {
                                (item.Content as ToolItem).Hide();
                                HideItem_Height(item);
                            }
                        }
                        break;
                    case 2:
                        foreach (ListBoxItem item in (Template.FindName("ToolsList", this) as ListBox).Items)
                        {
                            if ((item.Content as ToolItem).item.GetTag() != Tags.Program)
                            {
                                (item.Content as ToolItem).Hide();
                                HideItem_Height(item);
                            }
                        }
                        break;
                    case 3:
                        foreach (ListBoxItem item in (Template.FindName("ToolsList", this) as ListBox).Items)
                        {
                            if ((item.Content as ToolItem).item.GetTag() != Tags.Normal)
                            {
                                (item.Content as ToolItem).Hide();
                                HideItem_Height(item);
                            }
                        }
                        break;
                    case 4:
                        foreach (ListBoxItem item in (Template.FindName("ToolsList", this) as ListBox).Items)
                        {
                            if ((item.Content as ToolItem).item.GetTag() != Tags.Design)
                            {
                                (item.Content as ToolItem).Hide();
                                HideItem_Height(item);
                            }
                        }
                        break;
                    case 5:
                        foreach (ListBoxItem item in (Template.FindName("ToolsList", this) as ListBox).Items)
                        {
                            if ((item.Content as ToolItem).item.GetTag() != Tags.System)
                            {
                                (item.Content as ToolItem).Hide();
                                HideItem_Height(item);
                            }
                        }
                        break;
                }
            }
            else
            {
                firstSort = false;
            }            
        }

        /// <summary>
        /// 库工具列表滚动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolLister_ScrollChanged(object sender, ScrollChangedEventArgs e) => mwh.ToolLister_ScrollChanged_UI(sender);

        /// <summary>
        /// 鼠标进入工具列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolList_Border_MouseEnter(object sender, MouseEventArgs e) => mwh.ToolList_Border_Mouse_Event(true);

        /// <summary>
        /// 鼠标离开工具列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolList_Border_MouseLeave(object sender, MouseEventArgs e) => mwh.ToolList_Border_Mouse_Event(false);

        /// <summary>
        /// 鼠标进入视图切换列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewSelector_MouseEnter(object sender, MouseEventArgs e) => mwh.ViewSelector_Mouse_Event(true, sender);

        /// <summary>
        /// 鼠标离开视图切换列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewSelector_MouseLeave(object sender, MouseEventArgs e) => mwh.ViewSelector_Mouse_Event(false, sender);

        /// <summary>
        /// 详细信息面板鼠标进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_Panel_Grid_MouseEnter(object sender, MouseEventArgs e) => mwh.Info_Panel_Grid_Mouse_Event(true);

        /// <summary>
        /// 详细信息面板鼠标离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_Panel_Grid_MouseLeave(object sender, MouseEventArgs e) => mwh.Info_Panel_Grid_Mouse_Event(false);

        /// <summary>
        /// 刷新浏览器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebBrFresh_Click(object sender, RoutedEventArgs e)
        {
            CefSharp.Wpf.ChromiumWebBrowser tmp = Template.FindName("browser", this) as CefSharp.Wpf.ChromiumWebBrowser;
            tmp.Load(tmp.Address);
        }

        /// <summary>
        /// HC皮肤类型
        /// </summary>
        public enum SkinType
        {
            Light, Dark
        }

        /// <summary>
        /// 切换 HC皮肤
        /// </summary>
        /// <param name="st">HC皮肤类型</param>
        public void ChangeSkin(SkinType st) => ((App)Application.Current).UpdateSkin(st);
    }
}
