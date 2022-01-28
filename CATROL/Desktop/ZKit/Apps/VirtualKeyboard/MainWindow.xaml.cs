using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VirtualKeyboard
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string BaseDir = Environment.CurrentDirectory;

        public MainWindow()
        {
            InitializeComponent();

            GiveEvents();

            OutSaveButtons();
        }

        private void OutSaveButtons()
        {
            FileStream fs = new FileStream($"{BaseDir}\\Buttons.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < btnList.Count; i++)
            {
                sw.WriteLine(btnList[i].Content);
            }
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        private List<Button> btnList = new List<Button>();

        private void GiveEvents()
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(Buttons); i++)
            {
                Visual visual = (Visual)VisualTreeHelper.GetChild(Buttons, i);
                if (visual is Grid)
                {
                    for (int p = 0; p < VisualTreeHelper.GetChildrenCount(visual); p++)
                    {
                        Visual visual1 = (Visual)VisualTreeHelper.GetChild(visual, p);
                        if (visual1 is Button)
                        {
                            btnList.Add(visual1 as Button);
                        }
                        if (visual1 is Grid)
                        {
                            for (int q = 0; q < VisualTreeHelper.GetChildrenCount(visual1); q++)
                            {
                                Visual visual2 = (Visual)VisualTreeHelper.GetChild(visual1, q);
                                if (visual2 is Button)
                                {
                                    btnList.Add(visual2 as Button);
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < btnList.Count; i++)
            {
                string ctt = btnList[i].Content.ToString();
                if (ctt != "MaterialDesignThemes.Wpf.PackIcon")
                {
                    if (ctt != "ctrl" && ctt != "alt" && ctt != "shift" && !ctt.Contains("\n"))
                    {
                        btnList[i].Click += (x, y) =>
                        {
                            Send(ctt, false);
                        };
                    }
                    else
                    {
                        switch (ctt)
                        {
                            case "ctrl":
                                btnList[i].Click += (x, y) =>
                                {
                                    Send("^", true);
                                };
                                break;
                            case "alt":
                                btnList[i].Click += (x, y) =>
                                {
                                    Send("%", true);
                                };
                                break;
                            case "shift":
                                btnList[i].Click += (x, y) =>
                                {
                                    Send("+", true);
                                };
                                break;
                            default:
                                btnList[i].Click += (x, y) =>
                                {
                                    Send(ctt.ToCharArray()[0].ToString(), false);
                                };
                                break;
                        }
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 46-1:

                            break;
                        case 103-1:

                            break;
                        case 106-1:

                            break;
                        case 108 - 1:

                            break;
                        case 111 - 1:

                            break;
                        case 113 - 1:

                            break;
                        case 114 - 1:

                            break;
                        case 115 - 1:

                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void Send(string content, bool isSpecial)
        {
            System.Windows.Forms.SendKeys.SendWait("%{tab}");
            if (isSpecial)
            {
                System.Windows.Forms.SendKeys.SendWait(content);
            }
            else
            {
                System.Windows.Forms.SendKeys.SendWait($"{content}");
            }
        }
    }
}