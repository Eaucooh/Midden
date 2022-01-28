using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Algorithm_List.Controls
{
    /// <summary>
    /// somemathque.xaml 的交互逻辑
    /// </summary>
    public partial class somemathque : UserControl
    {
        public somemathque()
        {
            InitializeComponent();
        }

        struct item
        {
            public int index;
            public string value;
        }

        private void MenuItem_Start_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(nbox.Text, out int n) && int.TryParse(p1box.Text, out int p1) && int.TryParse(p2box.Text, out int p2))
            {
                fblqList.Items.Add(new ListViewItem()
                {
                    Content = $"1: {p1}"
                });
                fblqList.Items.Add(new ListViewItem()
                {
                    Content = $"2: {p2}"
                });
                new Thread(() =>
                {
                    List<item> ls = new List<item>();
                    string p11 = p1.ToString();
                    string p22 = p2.ToString();
                    for (int i = 3; i <= n; i++)
                    {
                        string tmp = Library.MathHelper.Hpc.Sum(p11, p22).TrimStart('0');
                        p11 = p22;
                        p22 = tmp;
                        ls.Add(new item
                        {
                            index = i,
                            value = tmp
                        });
                    }
                    Dispatcher.Invoke(new Action(() =>
                    {
                        AddItem(ls);
                    }));
                }).Start();
            }
        }

        private void AddItem(List<item> ls)
        {
            foreach (item i in ls)
            {
                fblqList.Items.Add(new ListViewItem() { Content = $"{i.index}: {i.value}" });
            }
        }

        private void MenuItem_Clear_Click(object sender, RoutedEventArgs e) => fblqList.Items.Clear();

        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(calCount.Text, out int count))
            {
                calResult.Text = Library.MathHelper.Pi.GetPi(count);
            }
        }

        private void Button_Do_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(levelBox.Text, out double lel) && double.TryParse(targetBox.Text, out double tar))
            {
                new Thread(() =>
                {
                    double A = 1;
                    double D = 0.1;
                    bool con = true;
                    while (con)
                    {
                        if ((A + D) * (A + D) < tar)
                        {
                            A = A + D;
                        }
                        else
                        {
                            //输出 A
                            D = D / 10;
                            if (!(D > lel))
                            {
                                con = false;
                                Dispatcher.BeginInvoke(new Action(() =>
                                {
                                    answerBox.Text = A.ToString();
                                }));
                            }
                        }
                    }
                }).Start();
            }
        }
    }
}
