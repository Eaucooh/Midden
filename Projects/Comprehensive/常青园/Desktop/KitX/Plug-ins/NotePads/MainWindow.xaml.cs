using KitX.Core;
using MaterialDesignThemes.Wpf;
using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Threading;

namespace NotePads
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IContract))]
    public partial class MainWindow : Window, IContract
    {
        public string Text { get; set; }

        private string filePath;

        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                if (File.Exists(value))
                {
                    filePath = value;
                    Title = $"NotePads - {value}";
                    new Thread(() =>
                    {
                        Text = Library.FileHelper.FileHelper.ReadAll(value);
                        Dispatcher.Invoke(new Action(() =>
                        {
                            ContentBox.Text = Text;
                        }));
                    }).Start();
                }
                else
                {
                    Title = $"NotePads - 未打开文件";
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            win = this;
            Width = SystemParameters.WorkArea.Width / 3 + SystemParameters.WorkArea.Width / 18;
            Height = SystemParameters.WorkArea.Height / 3 + SystemParameters.WorkArea.Height / 10;
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

        public string GetDescribe_Complex() => "一个全能的记事本，可以完美替代 Windows 默认的 Notepad.exe 。它支持 .txt;.note;.doc;.docx 等多种文档格式。";

        public string GetDescribe_Simple() => "今天发生了什么好玩的事呢？";

        public string GetFileName() => "NotePad.dll";

        public string GetHelpLink() => "https://docs.catrol.cn/";

        public string GetHostLink() => "https://blog.catrol.cn/";

        public BitmapImage GetIcon() => FindResource("Icon") as BitmapImage;

        public Languages GetLang() => Languages.zh_CN;

        public string GetName() => "NotePad";

        public string GetPublisher() => "Catrol";

        public string GetVersion() => "v1.0.6";

        public Window GetWindow() => new MainWindow();

        private static void ModifyTheme(Action<ITheme> modificationAction)
        {
            PaletteHelper paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();
            modificationAction?.Invoke(theme);
            paletteHelper.SetTheme(theme);
        }

        public void SetTheme(KitX.Core.Theme to)
        {
            //FlushBack();
        }

        QuickView quicker = new QuickView();

        public UserControl GetQuickView()
        {
            quicker.win = win;
            if (started)
            {
                return quicker;
            }
            else
            {
                return null;
            }
        }

        MainWindow win;
        bool started = true;
        bool start_st = true;

        public void Start()
        {
            if (start_st)
            {
                start_st = false;
                win.Show();
                //FlushBack();
            }
            else
            {
                if (!started)
                {
                    win = new MainWindow();
                    win.Closed += (x, y) => started = false;
                    win.Show();
                    //FlushBack();
                    started = true;
                }
                else
                {
                    if (win.Visibility == Visibility.Hidden)
                    {
                        //FlushBack();
                        win.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        //FlushBack();
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

        public Tags GetTag() => Tags.Process;

        #endregion

        private void OpenLink(object sender, RoutedEventArgs e)
        {
            string tag = (sender as FrameworkElement).Tag.ToString();
            if (tag.StartsWith("cmd"))
                DoCMD(tag.Split(':')[1]);
        }

        private void DoCMD(string cmd)
        {
            switch (cmd)
            {
                case "new":

                    break;
                case "open":
                    FilePath = Library.FileHelper.FileWin.OpenFile_Single(new Dictionary<string, string>
                    {
                        { "文本文件","*.txt" },
                        { "所有文件","*.*" }
                    }, "打开文件：");
                    break;
                case "save":
                    if (File.Exists(FilePath))
                    {
                        try
                        {
                            Library.FileHelper.FileHelper.WriteIn(FilePath, ContentBox.Content);
                            var messageQueue = new SnackbarMessageQueue(new TimeSpan(0, 0, 0, 1, 500));
                            Snackbar_SaveSucceed.MessageQueue = messageQueue;
                            messageQueue.Enqueue("保存成功");
                        }
                        catch (Exception q)
                        {
                            var messageQueue = new SnackbarMessageQueue(new TimeSpan(0, 0, 0, 1, 500));
                            Snackbar_SaveSucceed.MessageQueue = messageQueue;
                            messageQueue.Enqueue($"保存失败 - {q.Message}");
                        }
                    }
                    break;
                case "exit":
                    Close();
                    break;
                case "stater":
                    if (Stater.Height == 0)
                    {
                        Stater.BeginAnimation(HeightProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 500),
                            0, 40, System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic,
                            System.Windows.Media.Animation.EasingMode.EaseInOut, 0, 0));
                        Stater.BeginAnimation(OpacityProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 500),
                            0, 1, System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic,
                            System.Windows.Media.Animation.EasingMode.EaseInOut, 0, 0));
                    }
                    else
                    {
                        Stater.BeginAnimation(HeightProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 500),
                            40, 0, System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic,
                            System.Windows.Media.Animation.EasingMode.EaseInOut, 0, 0));
                        Stater.BeginAnimation(OpacityProperty, PopEye.WPF.Animation.AnimationHelper.CreateAnimation(new TimeSpan(0, 0, 0, 0, 500),
                            1, 0, System.Windows.Media.Animation.FillBehavior.HoldEnd, PopEye.WPF.Animation.AnimationHelper.EasingFunction.Cubic,
                            System.Windows.Media.Animation.EasingMode.EaseInOut, 0, 0));
                    }
                    break;
            }
        }

        private void FontSizeSlider_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e) => (sender as Slider).Value = 12;
    }
}
