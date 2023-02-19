using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RelativeCalculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly List<int> Sexes = new List<int>();
        readonly List<string> LastS = new List<string>();
        int sum = 0;
        int lastI = 0;

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
    }
}