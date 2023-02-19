using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;

namespace ZKit
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static double WorkAreaWidth = SystemParameters.WorkArea.Width;//获取工作区宽度
        public static double WorkAreaHeight = SystemParameters.WorkArea.Height;//获取工作区高度
        public static double ScreenWidth = SystemParameters.PrimaryScreenWidth;//获取屏幕宽度
        public static double ScreenHeight = SystemParameters.PrimaryScreenHeight;//获取屏幕高度
        public static string WorkBase = Environment.CurrentDirectory;//获取工作路径

        readonly Lierda.WPFHelper.LierdaCracker cracker = new Lierda.WPFHelper.LierdaCracker();
        protected override void OnStartup(StartupEventArgs e)
        {
            CheckApplicationMutex();
            LoadLanguage();

            base.OnStartup(e);

            //// 配置 IoC 容器
            //IoC.Setup();

            // 启动主窗体
            Current.MainWindow = new MainWindow
            {
                Width = Converts.Config_Size(lib_file.Config.ReadValue($"{WorkBase}\\App.config", "LastSize")).X,
                Height = Converts.Config_Size(lib_file.Config.ReadValue($"{WorkBase}\\App.config", "LastSize")).Y,
            };
            Current.MainWindow.Left = Converts.Config_Location(lib_file.Config.ReadValue($"{WorkBase}\\App.config", "LastLocation"), Current.MainWindow.Width, Current.MainWindow.Height).X;
            Current.MainWindow.Top = Converts.Config_Location(lib_file.Config.ReadValue($"{WorkBase}\\App.config", "LastLocation"), Current.MainWindow.Width, Current.MainWindow.Height).Y;
            Current.MainWindow.Show();

            cracker.Cracker(10);//垃圾回收间隔时间
            base.OnStartup(e);
        }


        /// <summary>
        /// 进程
        /// </summary>
        private Mutex mutex;

        /// <summary>
        /// 检查应用程序是否在进程中已经存在了
        /// </summary>
        private void CheckApplicationMutex()
        {

            // 第二个参数为 你的工程命名空间名。
            // out 给 ret 为 false 时，表示已有相同实例运行。
            mutex = new Mutex(true, "ZKit", out bool mutexResult);

            if (!mutexResult)
            {
                // 找到已经在运行的实例句柄(给出你的窗体标题名 “Deamon Club”)
                IntPtr hWndPtr = FindWindow(null, "ZKit");

                // 还原窗口
                ShowWindow(hWndPtr, SW_RESTORE);

                // 激活窗口
                SetForegroundWindow(hWndPtr);

                // 退出当前实例程序
                Environment.Exit(0);
            }
        }

        #region Windows API

        // ShowWindow 参数  
        public const int SW_RESTORE = 9;

        /// <summary>
        /// 在桌面窗口列表中寻找与指定条件相符的第一个窗口。
        /// </summary>
        /// <param name="lpClassName">指向指定窗口的类名。如果 lpClassName 是 NULL，所有类名匹配。</param>
        /// <param name="lpWindowName">指向指定窗口名称(窗口的标题）。如果 lpWindowName 是 NULL，所有windows命名匹配。</param>
        /// <returns>返回指定窗口句柄</returns>
        [DllImport("USER32.DLL", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 将窗口还原,可从最小化还原
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("USER32.DLL")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// 激活指定窗口
        /// </summary>
        /// <param name="hWnd">指定窗口句柄</param>
        /// <returns></returns>
        [DllImport("USER32.DLL")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        #endregion

        private void LoadLanguage()
        {
            CultureInfo currentCultureInfo = CultureInfo.CurrentCulture;
            ResourceDictionary langRd = null;
            try
            {
                langRd = LoadComponent(new Uri(currentCultureInfo.Name + ".xaml", UriKind.Relative)) as ResourceDictionary;
            }
            catch
            {

            }
            if (langRd != null)
            {
                if (Resources.MergedDictionaries.Count > 0)
                {
                    Resources.MergedDictionaries.Clear();
                }
                Resources.MergedDictionaries.Add(langRd);
            }
        }
    }
}