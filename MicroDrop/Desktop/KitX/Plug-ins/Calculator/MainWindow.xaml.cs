using KitX.Core;
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

namespace Calculator
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

            btn_fa.Click += Btn_Click;
            btn_mo.Click += Btn_Click;
            btn_hu.Click += Btn_Click;
            btn_wi.Click += Btn_Click;
            btn_eb.Click += Btn_Click;
            btn_yb.Click += Btn_Click;
            btn_es.Click += Btn_Click;
            btn_ys.Click += Btn_Click;
            btn_so.Click += Btn_Click;
            btn_da.Click += Btn_Click;
            btn_AC.Click += Btn_Click;
            btn_sum.Click += Btn_Click;
            btn_back.Click += Btn_Click;
        }

        readonly List<int> Sexes = new List<int>();
        readonly List<string> LastS = new List<string>();
        int sum = 0;
        int lastI = 0;

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "btn_fa":
                    sum += 1;
                    lastI = 1;
                    Sexes.Add(1);
                    Update_Expression("父亲");
                    break;
                case "btn_mo":
                    sum += 1;
                    lastI = 1;
                    Sexes.Add(0);
                    Update_Expression("母亲");
                    break;
                case "btn_hu":
                    sum += 0;
                    lastI = 0;
                    Sexes.Add(1);
                    Update_Expression("丈夫");
                    break;
                case "btn_wi":
                    sum += 0;
                    lastI = 0;
                    Sexes.Add(0);
                    Update_Expression("妻子");
                    break;
                case "btn_eb":
                    sum += 0;
                    lastI = 0;
                    Sexes.Add(1);
                    Update_Expression("哥哥");
                    break;
                case "btn_yb":
                    sum += 0;
                    lastI = 0;
                    Sexes.Add(1);
                    Update_Expression("弟弟");
                    break;
                case "btn_es":
                    sum += 0;
                    lastI = 0;
                    Sexes.Add(0);
                    Update_Expression("姐姐");
                    break;
                case "btn_ys":
                    sum += 0;
                    lastI = 0;
                    Sexes.Add(0);
                    Update_Expression("妹妹");
                    break;
                case "btn_so":
                    sum -= 1;
                    lastI = -1;
                    Sexes.Add(1);
                    Update_Expression("儿子");
                    break;
                case "btn_da":
                    sum -= 1;
                    lastI = -1;
                    Sexes.Add(0);
                    Update_Expression("女儿");
                    break;
                case "btn_AC":
                    Sexes.Clear();
                    LastS.Clear();
                    text_answer.Text = "";
                    text_exp.Text = "我";
                    lastI = 0;
                    sum = 0;
                    break;
                case "btn_sum":
                    Update_Answer();
                    break;
                case "btn_back":
                    try
                    {
                        text_exp.Text = LastS[LastS.Count - 1];
                        LastS.RemoveAt(LastS.Count - 1);
                        sum -= lastI;
                    }
                    catch { }
                    break;
            }
        }

        private void Update_Expression(string content)
        {
            LastS.Add(text_exp.Text);
            text_exp.Text += $"的{content}";
        }

        private void Update_Answer()
        {
            switch (sum)
            {
                case 0:
                    Set("我、兄弟或丈夫;我、姐妹或妻子");
                    break;
                case 1:
                    Set("父亲;母亲");
                    break;
                case 2:
                    Set("爷爷;奶奶");
                    break;
                case 3:
                    Set("祖父;祖母");
                    break;
                case 4:
                    Set("曾祖父;曾祖母");
                    break;
                case 5:
                    Set("高祖父;高祖母");
                    break;
                case -1:
                    Set("儿子;女儿");
                    break;
                case -2:
                    Set("孙子;孙女");
                    break;
                default:
                    break;
            }
        }

        private void Set(string content)
        {
            try
            {
                if (Sexes[Sexes.Count - 1] == 0)
                {
                    text_answer.Text = content.Split(';')[1];
                }
                else
                {
                    text_answer.Text = content.Split(';')[0];
                }
            }
            catch { }
        }

        #region 接口实现
        public string GetDescribe_Complex()
        {
            return "一个全能的计算器，实现快速普通计算、科学计算、各种转换器、各种专业计算等。";
        }

        public string GetDescribe_Simple()
        {
            return "全能计算器";
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
            return "Calculator";
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

        public void SetTheme(Theme theme)
        {
            Background = theme == Theme.Light ? new SolidColorBrush(Colors.WhiteSmoke) : new SolidColorBrush(Colors.Black);
            Foreground = theme == Theme.Light ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.WhiteSmoke);
        }

        public string GetFileName()
        {
            return "Calculator.dll";
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

        private string WorkBase = null;

        public void SetWorkBase(string path)
        {
            WorkBase = path;
            if (!Directory.Exists(WorkBase))
            {
                Directory.CreateDirectory(WorkBase);
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
        #endregion
    }
}
