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
using System.Windows.Controls.Ribbon;
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
    public partial class MainWindow : RibbonWindow, IContract
    {
        public MainWindow()
        {
            InitializeComponent();
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

        public string GetDescribe_Complex()
        {
            return "一个全能的记事本，可以完美替代 Windows 默认的 Notepad.exe 。它支持 .txt;.note;.doc;.docx 等多种文档格式。";
        }

        public string GetDescribe_Simple()
        {
            return "今天发生了什么好玩的事呢？";
        }

        public string GetFileName()
        {
            return "NotePad.dll";
        }

        public string GetHelpLink()
        {
            return "http://docs.catrol.cn/";
        }

        public string GetHostLink()
        {
            return "http://www.catrol.cn/";
        }

        public BitmapImage GetIcon()
        {
            return FindResource("Icon") as BitmapImage;
        }

        public Languages GetLang()
        {
            return Languages.zh_CN;
        }

        public string GetName()
        {
            return "NotePad";
        }

        public string GetPublisher()
        {
            return "Catrol";
        }

        public string GetVersion()
        {
            return "Alpha";
        }

        public Window GetWindow()
        {
            return new MainWindow();
        }

        private static void ModifyTheme(Action<ITheme> modificationAction)
        {
            PaletteHelper paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();
            modificationAction?.Invoke(theme);
            paletteHelper.SetTheme(theme);
        }

        public void SetTheme(KitX.Core.Theme to)
        {
            ModifyTheme(theme => theme.SetBaseTheme(to == KitX.Core.Theme.Dark ? MaterialDesignThemes.Wpf.Theme.Dark : MaterialDesignThemes.Wpf.Theme.Light));
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
        bool started = false;

        public void Start()
        {
            if (!started)
            {
                win = new MainWindow();
                win.Closed += (x, y) => started = false;
                win.Show();
                started = true;
            }
            else
            {
                if (win.Visibility == Visibility.Hidden)
                {
                    win.Visibility = Visibility.Visible;
                }
                else
                {
                    win.Visibility = Visibility.Hidden;
                }
            }
        }

        public void End()
        {
            win.Close();
            started = false;
        }

        public Tags GetTag()
        {
            return Tags.Process;
        }
    }
}
