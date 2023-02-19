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

        private void MenuItem_Start_Click(object sender, RoutedEventArgs e)
        {
            if (long.TryParse(nbox.Text, out long n) && long.TryParse(p1box.Text, out long p1) && long.TryParse(p2box.Text, out long p2))
            {
                fblqList.Text += $"1: {p1}{Environment.NewLine}";
                fblqList.Text += $"2: {p2}{Environment.NewLine}";
                int select = forer.IsChecked ? 1 : digui.IsChecked ? 2 : diguiMemory.IsChecked ? 3 : ceq.IsChecked ? 4 : 0;
                new Thread(() =>
                {
                    switch (select)
                    {
                        case 1:
                            List<long> list = Library.MathHelper.Fibonacci.FbnqSort2_List(n, p1, p2);
                            int index = 3;
                            foreach (long item in list)
                            {
                                Dispatcher.BeginInvoke(new Action(() =>
                                {
                                    fblqList.Text += $"{index}: {item}{Environment.NewLine}";
                                }));
                                index ++;
                            }
                            break;
                    }
                }).Start();
            }
        }

        private void MenuItem_Clear_Click(object sender, RoutedEventArgs e) => fblqList.Clear();

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
