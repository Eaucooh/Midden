using KitX.Core;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
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

namespace NotePad
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

        public string GetHelpLink() => "http://docs.catrol.cn/";

        public string GetHostLink() => "http://www.catrol.cn/";

        public BitmapImage GetIcon() => FindResource("Icon") as BitmapImage;

        public Languages GetLang() => Languages.zh_CN;

        public string GetName() => "NotePad";

        public string GetPublisher() => "Catrol";

        public string GetVersion() => "Still developing";

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
            FlushBack();
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
                FlushBack();
            }
            else
            {
                if (!started)
                {
                    win = new MainWindow();
                    win.Closed += (x, y) => started = false;
                    win.Show();
                    FlushBack();
                    started = true;
                }
                else
                {
                    if (win.Visibility == Visibility.Hidden)
                    {
                        FlushBack();
                        win.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        FlushBack();
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
    }
}
