using KitX.Helper;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace KitX
{
    public class MainWindowHelper
    {
        public MainWindow win;

        /// <summary>
        /// 登录信息 - 中文简体
        /// </summary>
        public string[] signInfo_cn = new string[12]
        {
            "登录成功", "登陆失败", "用户标识符或密码不正确", "该账户不存在", "账户标识符或密码不能为空",
            "不符合登录标识符格式", "该账号已经被封停", "最近可登录时间", "卡片截图已经复制到剪贴板", "截图复制失败",
            "最新版本安装包已经开始下载", "请解压压缩包内所有文件到 KitX 目录"
        };

        /// <summary>
        /// 登录信息 - 中文繁体
        /// </summary>
        public string[] signInfo_cnt = new string[12]
        {
            "登錄成功", "登陸失敗", "用戶標識符或密碼不正確", "該賬戶不存在", "賬戶標識符或密碼不能為空",
            "不符合登錄標識符格式", "該賬號已經被封停", "最近可登錄時間", "卡片截圖已經復製到剪貼板", "截圖復製失敗",
            "最新版本安裝包已經開始下載", "請解壓壓縮包內所有文件到 KitX 目錄"
        };

        /// <summary>
        /// 登录信息 - 英文
        /// </summary>
        public string[] signInfo_en = new string[12]
        {
            "Sign in succeeded", "Sign in failed", "ID or password is wrong", "This account doesn't exist", "ID or password can't be null",
            "It doesn't match the format", "This account is forbiddened", "The next time you can sign",
            "The screenshot of the ID Card had been copied to the clipboard", "Copy screenshot failed",
            "The latest version installer has started downloading", "Unzip all files in the package to the KitX directory please"
        };

        /// <summary>
        /// 登录信息 - 日语
        /// </summary>
        public string[] signInfo_jp = new string[12]
        {
            "ログインに成功する", "上陸に失敗する", "ユーザ識別子またはパスワードが正しくありません", "この口座は存在しません", "アカウントの識別子やパスワードは空欄にしてはいけません",
            "ログイン識別子フォーマットに準拠していない", "このアカウントは既に停止されている", "直近のログイン可能時間",
            "カードのスクリーンショットがクリップボードにコピーされています", "スクリーンショットのコピーに失敗しました",
            "最新バージョンのインストール パッケージのダウンロードが開始されました", "圧縮パッケージ内のすべてのファイルを KitX ディレクトリに解凍してください"
        };

        public string[][] signInfos;

        /// <summary>
        /// 注册提示 - 中文简体
        /// </summary>
        public string[] signUpInfo_cn = new string[17]
        {
            "ID不符合身份证格式（要求 11 位）", "两次密码不一致", "请检查表单，无法为您完成注册", "注册失败", "该账户已经存在", "选择用户头像", "上传失败", "注册成功", "保存信息失败", "下载成功，请重启 KitX",
            "上传成功", "下载失败", "上传失败", "您的 KitX 已经是最新版了", "有新的版本待您更新", "更新版本的安装包已经开始下载",
            "请勾选“我已阅读并同意《用户隐私政策》”"
        };

        /// <summary>
        /// 注册提示 - 中文繁体
        /// </summary>
        public string[] signUpInfo_cnt = new string[17]
        {
            "ID不符合身份證格式（要求 11 位）", "兩次密碼不壹致", "請檢查表單，無法為您完成註冊", "註冊失敗", "該賬戶已經存在", "選擇用戶頭像", "上傳失敗", "註冊成功", "保存信息失敗", "下載成功，請重啟 KitX",
            "上傳成功", "下載失敗", "上傳失敗", "您的 KitX 已經是最新版了", "有新的版本待您更新", "更新版本的安裝包已經開始下載",
            "請勾選“我已閱讀並同意《用戶隱私政策》”"
        };

        /// <summary>
        /// 注册提示 - 英文
        /// </summary>
        public string[] signUpInfo_en = new string[17]
        {
            "ID does not match ID format（For 11 Length）", "The two passwords don't match", "Please check the form, the registration cannot be completed for you",
            "Sign up failed", "The account already exists", "Select the user avatar.", "Uploading failed", "Sign Up Succeed", "Save info failed",
            "Download config file succeeded, please restart the KitX App.", "Upload succeeded.", "Download failed", "Upload failed", "Your KitX is already the latest version.",
            "There is a new version for you to update.", "The installer of the latest version has started been download.",
            "Please check \"I had read and agree with 《用户隐私政策》\""
        };

        /// <summary>
        /// 注册提示 - 日语
        /// </summary>
        public string[] signUpInfo_jp = new string[17]
        {
            "idが身分証明書の形式に合っていません（要求 11 位）", "2度パスワードが一致しません", "フォームをチェックしてください。登録が完了しません", "登録に失敗する", "この口座は既に存在します",
            "ユーザーのプロフィール画像を選択する", "アップロード失敗", "登録が成功する", "情報保存に失敗する", "ダウンロード成功、KitX を再起動してください", "アップロード成功", "ダウンロードに失敗する",
            "アップロード失敗", "あなたのkitxはもう最新版です", "新しいバージョンがあります", "アップデートバージョンのインストールパッケージのダウンロードが開始されました",
            "「《用户隐私政策》を読み、同意しました」にチェックを入れてください。"
        };

        public string[][] signUpInfos;

        /// <summary>
        /// 窗体初始化事件
        /// </summary>
        public void init()
        {
            //加载用户界面
            win.InitializeComponent();
            
            //设定语言组合
            signInfos = new string[4][]
            {
                signInfo_cn, signInfo_cnt, signInfo_en, signInfo_jp
            };
            signUpInfos = new string[4][]
            {
                signUpInfo_cn, signUpInfo_cnt, signUpInfo_en, signUpInfo_jp
            };

            //设定用户名为系统登录用户名
            win.Resources["UserName"] = Environment.UserName;

            //设定窗体键盘事件
            win.KeyDown += (x, y) =>
            {
                init_key(y, win.Template.FindName("Facer", win) as MaterialDesignThemes.Wpf.Transitions.Transitioner,
                   win.Template.FindName("Cog_Pages", win) as MaterialDesignThemes.Wpf.Transitions.Transitioner,
                   win.Template.FindName("LibViewer", win) as MaterialDesignThemes.Wpf.Transitions.Transitioner);
            };
            win.Activated += (x, y) =>
            {
                (win.Template.FindName("TitleIcon", win) as Image).Source = new BitmapImage(new Uri("../Source/KitX.png", UriKind.Relative));
            };
            win.Deactivated += (x, y) =>
            {
                (win.Template.FindName("TitleIcon", win) as Image).Source = new BitmapImage(new Uri("../Source/KitX_NoFocus.png", UriKind.Relative));
            };

            //启动加载完毕后事件
            win.Loaded += (x, y) =>
            {
                WindowLoaded();
                NetChecker();
            };
        }
        
        /// <summary>
        /// 窗体按键事件
        /// </summary>
        /// <param name="e"></param>
        /// <param name="facer"></param>
        /// <param name="cog"></param>
        /// <param name="lib"></param>
        public void init_key(KeyEventArgs e, MaterialDesignThemes.Wpf.Transitions.Transitioner facer,
            MaterialDesignThemes.Wpf.Transitions.Transitioner cog, MaterialDesignThemes.Wpf.Transitions.Transitioner lib)
        {
            if (e.KeyStates == e.KeyboardDevice.GetKeyStates(Key.P) && e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                Command.NormalCommand(App.Input_Normal("输入调试命令", "调试"), win);
            }
            if (win.CanMovePage)
            {
                if (e.KeyStates == e.KeyboardDevice.GetKeyStates(Key.W) && facer.SelectedIndex != 0)
                    facer.SelectedIndex--;
                if (e.KeyStates == e.KeyboardDevice.GetKeyStates(Key.S) && facer.SelectedIndex != facer.Items.Count)
                    facer.SelectedIndex++;

                if (e.KeyStates == e.KeyboardDevice.GetKeyStates(Key.A) && cog.SelectedIndex != 0)
                    cog.SelectedIndex--;
                if (e.KeyStates == e.KeyboardDevice.GetKeyStates(Key.D) && cog.SelectedIndex != cog.Items.Count)
                    cog.SelectedIndex++;

                if (e.KeyStates == e.KeyboardDevice.GetKeyStates(Key.Q) && lib.SelectedIndex != 0)
                    lib.SelectedIndex--;
                if (e.KeyStates == e.KeyboardDevice.GetKeyStates(Key.E) && lib.SelectedIndex != lib.Items.Count)
                    lib.SelectedIndex++;
            }
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="e"></param>
        public void OnClosingHelp(CancelEventArgs e)
        {
            if (win.CanClose)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                win.Hide();
                SaveLocationConfig();
            }
        }

        /// <summary>
        /// 窗体移动事件
        /// </summary>
        public void WindowMove()
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                win.DragMove();
            }
        }

        /// <summary>
        /// 保存窗体位置配置信息
        /// </summary>
        public void SaveLocationConfig()
        {
            Library.FileHelper.Config.WriteValue($"{App.WorkBase}\\App.config", "LastSize", $"{win.ActualWidth},{win.ActualHeight}"); //储存窗体大小
            Library.FileHelper.Config.WriteValue($"{App.WorkBase}\\App.config", "LastLocation", $"{win.Left},{win.Top}"); //储存窗体位置
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        public void WindowLoaded()
        {
            win.Resources["KitX-Version"] = App.MyVersion;
            //启动时加载插件
            win.ReFresher_Click(null, null);
            //启动时重置主题
            if (MainWindow.StartTheme.Equals("Dark"))
            {
                //ModifyTheme(theme => theme.SetBaseTheme(MaterialDesignThemes.Wpf.Theme.Dark));
                (win.Template.FindName("ToggleButton_Theme", win) as ToggleButton).IsChecked = true;
                win.abc.SetForeground(AppsBar_Controller.Fore.white);
                win.ToastToolThemeChanged(Core.Theme.Dark);
                win.ChangeSkin(MainWindow.SkinType.Dark);
            }

            //更新语言选择器
            //LangIndex = ((App)Application.Current).LangIndex;
            win.LangIndex = Convert.ToInt32(Library.FileHelper.Config.ReadValue($"{App.WorkBase}\\App.config", "LastLang"));
            (win.Template.FindName("LangS", win) as ComboBox).SelectedIndex = win.LangIndex;

            //更新工具栏控制按钮状态
            //检查启动时是否显示工具栏
            ToggleButton tb = win.Template.FindName("AppsBarManager", win) as ToggleButton;
            if (win.ShouldShow_AppsBar)
            {
                win.AppsBarManager_Checked(tb, null);
            }

            //解决 ScrollViewer 内嵌 ListBox 鼠标滚动失效的问题
            ListBox libox = win.Template.FindName("ToolsList", win) as ListBox;
            libox.PreviewMouseWheel += (sender, e) =>
            {
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                {
                    RoutedEvent = UIElement.MouseWheelEvent,
                    Source = sender
                };
                libox.RaiseEvent(eventArg);
            };

            (win.Template.FindName("HideAtStart", win) as CheckBox).IsChecked = Convert.ToBoolean(Library.FileHelper.Config.ReadValue($"{App.WorkBase}\\App.config", "ShouldHideStart"));
            (win.Template.FindName("StartBySelf", win) as CheckBox).IsChecked = Convert.ToBoolean(Library.FileHelper.Config.ReadValue($"{App.WorkBase}\\App.config", "IsStartWithOS"));

            if (File.Exists($"{App.WorkBase}\\Config\\userinfo.bin"))
            {
                (win.Template.FindName("ShouldRememberPWD_CheckBox", win) as CheckBox).IsChecked = true;
                string tid = Library.FileHelper.FileHelper.ReadAll($"{App.WorkBase}\\Config\\userinfo.acc");
                string c_pwd = Library.FileHelper.FileHelper.ReadAll($"{App.WorkBase}\\Config\\userinfo.bin");
                string b_pwd = Library.TextHelper.Coder.Decrypt(c_pwd, null, tid.Substring(0, 8), Library.TextHelper.Coder.ALG.DES);
                string a_pwd = Library.TextHelper.Coder.Decrypt(b_pwd, null, tid.Substring(0, 8), Library.TextHelper.Coder.ALG.DES);
                string tpwd = Library.TextHelper.Coder.Decrypt(a_pwd, null, tid.Substring(0, 8), Library.TextHelper.Coder.ALG.DES);
                (win.Template.FindName("SignIn_ID_Box", win) as TextBox).Text = tid;
                (win.Template.FindName("SignIn_Pwd_Box", win) as PasswordBox).Password = tpwd;
                win.SignIn();
            }

            //刷新路径界面设定
            win.RefreshPathSetting();

            win.SetBinding(FrameworkElement.FlowDirectionProperty, new Binding("SelectedIndex")
            {
                Source = win.Template.FindName("FlowDirectionSelector", win) as ComboBox,
                Mode = BindingMode.TwoWay,
                Converter = win.Resources["FlowDir_Converter"] as IValueConverter
            });

            (win.Template.FindName("btn_clear_searchBox", win) as Button).Click += (m, n) =>
            {
                (win.Template.FindName("SearchingBox", win) as TextBox).Clear();
            };
        }

        /// <summary>
        /// 第一次启动事件
        /// </summary>
        public void FirstStart()
        {
            #region 第一次启动事件
            if (File.Exists($"{App.WorkBase}\\FirstRun.signal"))
            {
                Process.Start($"{App.WorkBase}\\KitX.Helper.exe", "-f");

                App.WriteLineLog(App.MainLogFile, "Hello World!");
                App.WriteLineLog(App.MainLogFile, "It's my first running on your computer.");
                App.WriteLineLog(App.MainLogFile, "What's your name?");

                File.Delete($"{App.WorkBase}\\FirstRun.signal");
                new FirstStartTeacher().ShowDialog();
            }
            #endregion
        }

        /// <summary>
        /// 网络状况检查
        /// </summary>
        public void NetChecker()
        {
            new Thread(() =>
            {
                if (Library.NetHelper.NetHelper.IsWebConected("catrol.cn", 3 * 1000))
                {
                    win.msc = new MySQLConnection();
                }
            }).Start();
        }

        /// <summary>
        /// 信息面板鼠标事件
        /// </summary>
        /// <param name="Expand"></param>
        public void Info_Panel_Grid_Mouse_Event(bool Expand)
        {
            Button btn = win.Template.FindName("WebBrFresh", win) as Button;
            if (Expand)
            {
                if (btn.Opacity == 0)
                {
                    btn.BeginAnimation(UIElement.OpacityProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(
                            new TimeSpan(0, 0, 0, 0, 300), 0, 1, FillBehavior.HoldEnd,
                            PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
                }
            }
            else
            {
                if (btn.Opacity == 1)
                {
                    btn.BeginAnimation(UIElement.OpacityProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(
                            new TimeSpan(0, 0, 0, 0, 300), 1, 0, FillBehavior.HoldEnd,
                            PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
                }
            }
        }

        /// <summary>
        /// 视图切换器鼠标事件
        /// </summary>
        /// <param name="Expand"></param>
        public void ViewSelector_Mouse_Event(bool Expand, object sender)
        {
            if (Expand)
            {
                if ((sender as Grid).Width == 60)
                {
                    (sender as Grid).BeginAnimation(FrameworkElement.WidthProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(
                            new TimeSpan(0, 0, 0, 0, 300), 60, 200, FillBehavior.HoldEnd,
                            PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic,
                            EasingMode.EaseOut, 0, 0));
                }
            }
            else
            {
                if ((sender as Grid).Width == 200)
                {
                    (sender as Grid).BeginAnimation(FrameworkElement.WidthProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(
                            new TimeSpan(0, 0, 0, 0, 300), 200, 60, FillBehavior.HoldEnd,
                            PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic,
                            EasingMode.EaseOut, 0, 0));
                }
            }
        }

        /// <summary>
        /// 工具列表鼠标事件
        /// </summary>
        /// <param name="Expand"></param>
        public void ToolList_Border_Mouse_Event(bool Expand)
        {
            Button adder = win.Template.FindName("Adder", win) as Button;
            if (Expand)
            {
                adder.BeginAnimation(UIElement.OpacityProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(
                        new TimeSpan(0, 0, 0, 0, 300), 0, 1, FillBehavior.HoldEnd,
                        PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
                (win.Template.FindName("FilterListBox", win) as Grid).BeginAnimation(FrameworkElement.HeightProperty,
                    PopEye.WPF.Animation.AnimationHelper.CreateAnimation(
                        new TimeSpan(0, 0, 0, 0, 300), 0, 125, FillBehavior.HoldEnd,
                        PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
                (win.Template.FindName("FilterListBox", win) as Grid).BeginAnimation(UIElement.OpacityProperty,
                    PopEye.WPF.Animation.AnimationHelper.CreateAnimation(
                        new TimeSpan(0, 0, 0, 0, 300), 0, 1, fillBehavior: FillBehavior.HoldEnd,
                        PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
                (win.Template.FindName("toolLister", win) as ScrollViewer).BeginAnimation(FrameworkElement.MarginProperty,
                    PopEye.WPF.Animation.AnimationHelper.CreateAnimation(
                        new TimeSpan(0, 0, 0, 0, 300), new Thickness(0, 0, 0, 10), new Thickness(0, 130, 0, 10), FillBehavior.HoldEnd,
                        PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
            }
            else
            {
                adder.BeginAnimation(UIElement.OpacityProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(
                        new TimeSpan(0, 0, 0, 0, 300), 1, 0, FillBehavior.HoldEnd,
                        PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
                (win.Template.FindName("FilterListBox", win) as Grid).BeginAnimation(FrameworkElement.HeightProperty,
                    PopEye.WPF.Animation.AnimationHelper.CreateAnimation(
                        new TimeSpan(0, 0, 0, 0, 300), 125, 0, FillBehavior.HoldEnd,
                        PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
                (win.Template.FindName("FilterListBox", win) as Grid).BeginAnimation(UIElement.OpacityProperty,
                    PopEye.WPF.Animation.AnimationHelper.CreateAnimation(
                        new TimeSpan(0, 0, 0, 0, 300), 1, 0, FillBehavior.HoldEnd,
                        PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
                (win.Template.FindName("toolLister", win) as ScrollViewer).BeginAnimation(FrameworkElement.MarginProperty,
                    PopEye.WPF.Animation.AnimationHelper.CreateAnimation(
                        new TimeSpan(0, 0, 0, 0, 300), new Thickness(0, 130, 0, 10), new Thickness(0, 0, 0, 10), fillBehavior: System.Windows.Media.Animation.FillBehavior.HoldEnd,
                        PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
            }
        }

        /// <summary>
        /// 回到顶部按钮控制器
        /// </summary>
        public void ToolLister_ScrollChanged_UI(object sender)
        {
            Button goTop = win.Template.FindName("btn_goTop", win) as Button;
            if ((sender as ScrollViewer).ContentVerticalOffset == 0)
            {
                if (goTop.Opacity == 1)
                {
                    goTop.BeginAnimation(UIElement.OpacityProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(
                        new TimeSpan(0, 0, 0, 0, 300), 1, 0, FillBehavior.HoldEnd,
                        PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
                }
            }
            else
            {
                if (goTop.Opacity == 0)
                {
                    goTop.BeginAnimation(UIElement.OpacityProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(
                        new TimeSpan(0, 0, 0, 0, 300), 0, 1, FillBehavior.HoldEnd,
                        PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
                }
            }
        }
    }
}
