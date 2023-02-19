using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            max.Visibility = Visibility.Hidden;
            mini.Visibility = Visibility.Hidden;
            FunctionIt();
            Clear();
        }

        void Clear()
        {
            homePage.Visibility = Visibility.Hidden;
            menuDocker.Visibility = Visibility.Hidden;
            methods.Visibility = Visibility.Hidden;
            scienceWin.Visibility = Visibility.Hidden;
            programWin.Visibility = Visibility.Hidden;
            passwordWin.Visibility = Visibility.Hidden;
            dateWin.Visibility = Visibility.Hidden;
            timeWin.Visibility = Visibility.Hidden;
            currencyWin.Visibility = Visibility.Hidden;
            lengthWin.Visibility = Visibility.Hidden;
            areaWin.Visibility = Visibility.Hidden;
            volumeWin.Visibility = Visibility.Hidden;
            weightWin.Visibility = Visibility.Hidden;
            temperatureWin.Visibility = Visibility.Hidden;
            speedWin.Visibility = Visibility.Hidden;
            forceWin.Visibility = Visibility.Hidden;
            energyWin.Visibility = Visibility.Hidden;
            powerWin.Visibility = Visibility.Hidden;
            colorWin.Visibility = Visibility.Hidden;
            angleWin.Visibility = Visibility.Hidden;
            equationWin.Visibility = Visibility.Hidden;
            functionWin.Visibility = Visibility.Hidden;
            formularyWin.Visibility = Visibility.Hidden;
        }

        void FunctionIt()
        {
            MenuFunction();
            close.Click += (x, y) =>
            {
                Close();
            };
            size.Click += (x, y) =>
            {
                if(max.Visibility == Visibility.Visible)
                {
                    max.Visibility = Visibility.Hidden;
                    mini.Visibility = Visibility.Hidden;
                    size.Content = "";
                }
                else
                {
                    max.Visibility = Visibility.Visible;
                    mini.Visibility = Visibility.Visible;
                    size.Content = "";
                }
            };
            max.Click += (x, y) =>
            {
                if(WindowState == WindowState.Normal)
                {
                    WindowState = WindowState.Maximized;
                }
                else
                {
                    WindowState = WindowState.Normal;
                }                
            };
            mini.Click += (x, y) =>
            {
                WindowState = WindowState.Minimized;
            };
            mainMenu.Click += (x, y) =>
            {
                if (menuDocker.Visibility == Visibility.Visible)
                {
                    menuDocker.Visibility = Visibility.Hidden;
                }
                else
                {
                    menuDocker.Visibility = Visibility.Visible;
                }
            };
            menu.Click += (x, y) =>
            {
                if (methods.Visibility == Visibility.Visible)
                {
                    methods.Visibility = Visibility.Hidden;
                }
                else
                {
                    methods.Visibility = Visibility.Visible;
                }
                menuDocker.Visibility = Visibility.Hidden;
            };
            num1.Click += (x, y) => { inputNum(1); };
            num2.Click += (x, y) => { inputNum(2); };
            num3.Click += (x, y) => { inputNum(3); };
            num4.Click += (x, y) => { inputNum(4); };
            num5.Click += (x, y) => { inputNum(5); };
            num6.Click += (x, y) => { inputNum(6); };
            num7.Click += (x, y) => { inputNum(7); };
            num8.Click += (x, y) => { inputNum(8); };
            num9.Click += (x, y) => { inputNum(9); };
            num0.Click += (x, y) => { inputNum(0); };
            plus.Click += (x, y) => { Count(1); };
            subtract.Click += (x, y) => { Count(2); };
            multiply.Click += (x, y) => { Count(3); };
            divide.Click += (x, y) => { Count(4); };
            plus.Click += (x, y) => { Count(0); };
            del.Click += (x, y) => { DelLastChar(); };
            leftBrackets.Click += (x, y) => { inputsign("("); };
            rightBrackets.Click += (x, y) => { inputsign(")"); };
        }

        void MenuFunction()
        {
            host.Click += (x, y) =>
            {
                Clear();
                homePage.Visibility = Visibility.Visible;
            };
            science.Click += (x, y) =>
            {
                Clear();
                scienceWin.Visibility = Visibility.Visible;
            };
            program.Click += (x, y) =>
            {
                Clear();
                programWin.Visibility = Visibility.Visible;
            };
            password.Click += (x, y) =>
            {
                Clear();
                passwordWin.Visibility = Visibility.Visible;
            };
            date.Click += (x, y) =>
            {
                Clear();
                dateWin.Visibility = Visibility.Visible;
            };
            time.Click += (x, y) =>
            {
                Clear();
                timeWin.Visibility = Visibility.Visible;
            };
            currency.Click += (x, y) =>
            {
                Clear();
                currencyWin.Visibility = Visibility.Visible;
            };
            length.Click += (x, y) =>
            {
                Clear();
                lengthWin.Visibility = Visibility.Visible;
            };
            area.Click += (x, y) =>
            {
                Clear();
                areaWin.Visibility = Visibility.Visible;
            };
            volume.Click += (x, y) =>
            {
                Clear();
                volumeWin.Visibility = Visibility.Visible;
            };
            weight.Click += (x, y) =>
            {
                Clear();
                weightWin.Visibility = Visibility.Visible;
            };
            temperature.Click += (x, y) =>
            {
                Clear();
                temperatureWin.Visibility = Visibility.Visible;
            };
            speed.Click += (x, y) =>
            {
                Clear();
                speedWin.Visibility = Visibility.Visible;
            };
            force.Click += (x, y) =>
            {
                Clear();
                forceWin.Visibility = Visibility.Visible;
            };
            energy.Click += (x, y) =>
            {
                Clear();
                energyWin.Visibility = Visibility.Visible;
            };
            power.Click += (x, y) =>
            {
                Clear();
                powerWin.Visibility = Visibility.Visible;
            };
            color.Click += (x, y) =>
            {
                Clear();
                colorWin.Visibility = Visibility.Visible;
            };
            angle.Click += (x, y) =>
            {
                Clear();
                angleWin.Visibility = Visibility.Visible;
            };
            equation.Click += (x, y) =>
            {
                Clear();
                equationWin.Visibility = Visibility.Visible;
            };
            function.Click += (x, y) =>
            {
                Clear();
                functionWin.Visibility = Visibility.Visible;
            };
            formulary.Click += (x, y) =>
            {
                Clear();
                formularyWin.Visibility = Visibility.Visible;
            };
        }

        private void WindowMove(object sender, MouseButtonEventArgs e)
        {
            try { DragMove(); } catch { }
        }

        private void SinceWin_KeyDown(object sender, KeyEventArgs e)
        {
            var input = e.KeyStates;
            if (input == Keyboard.GetKeyStates(Key.NumPad1))
            {
                inputNum(1);
            }
            if (input == Keyboard.GetKeyStates(Key.NumPad2))
            {
                inputNum(2);
            }
            if (input == Keyboard.GetKeyStates(Key.NumPad3))
            {
                inputNum(3);
            }
            if (input == Keyboard.GetKeyStates(Key.NumPad4))
            {
                inputNum(4);
            }
            if (input == Keyboard.GetKeyStates(Key.NumPad5))
            {
                inputNum(5);
            }
            if (input == Keyboard.GetKeyStates(Key.NumPad6))
            {
                inputNum(6);
            }
            if (input == Keyboard.GetKeyStates(Key.NumPad7))
            {
                inputNum(7);
            }
            if (input == Keyboard.GetKeyStates(Key.NumPad8))
            {
                inputNum(8);
            }
            if (input == Keyboard.GetKeyStates(Key.NumPad9))
            {
                inputNum(9);
            }
            if (input == Keyboard.GetKeyStates(Key.NumPad0))
            {
                inputNum(0);
            }
            if (input == Keyboard.GetKeyStates(Key.Back))
            {
                DelLastChar();
            }
            if (input == Keyboard.GetKeyStates(Key.Add))
            {
                Count(1);
            }
            if (input == Keyboard.GetKeyStates(Key.Subtract))
            {
                Count(2);
            }
            if (input == Keyboard.GetKeyStates(Key.Multiply))
            {
                Count(3);
            }
            if (input == Keyboard.GetKeyStates(Key.Divide))
            {
                Count(4);
            }
            if (input == Keyboard.GetKeyStates(Key.Enter))
            {
                Count(0);
            }
            if (input == Keyboard.GetKeyStates(Key.OemCloseBrackets))
            {
                inputsign(")");
            }
            if (input == Keyboard.GetKeyStates(Key.OemOpenBrackets))
            {
                inputsign("(");
            }
        }

        void Count(int type)
        {
            try
            {
                if (type == 1)
                {
                    countBox.Text += inputBox.Text + "+";
                    inputBox.Text = "0";
                }
                if(type == 2)
                {
                    countBox.Text += inputBox.Text + "-";
                    inputBox.Text = "0";
                }
                if (type == 3)
                {
                    countBox.Text += inputBox.Text + "×";
                    inputBox.Text = "0";
                }
                if (type == 4)
                {
                    countBox.Text += inputBox.Text + "÷";
                    inputBox.Text = "0";
                }
                if (type == 0)
                {
                    countBox.Text += inputBox.Text;
                    CountIt(countBox.Text);
                    countBox.Text += "=";
                }
            }
            catch (Exception p)
            {

            }
        }

        void CountIt(string sentences)
        {
            forceBox.Text = sentences;
            
        }

        void inputsign(string sign)
        {
            countBox.Text += sign;
        }

        void inputNum(int num)
        {
            if(countBox.Text.Contains("="))
            {
                ClearUsed();
            }
            if(inputBox.Text=="0")
            {
                inputBox.Text = "";
            }
            inputBox.Text += num;
        }

        void ClearUsed()
        {
            countBox.Text = null;
            inputBox.Text = "0";
        }

        void FontSizeCheck()
        {
            
        }

        void DelLastChar()
        {
            if (inputBox.Text.Length == 1)
            {
                inputBox.Text = "0";
            }
            else
            {
                try
                {
                    char[] temp = inputBox.Text.ToCharArray();
                    char[] value = new char[temp.Length - 1];
                    for (int i = 0; i < value.Length; i++)
                    {
                        value[i] = temp[i];
                    }
                    inputBox.Text = null;
                    for (int i = 0; i < value.Length; i++)
                    {
                        inputBox.Text += value[i];
                    }
                }
                catch (Exception p)
                {

                }
            }
        }

        bool IsNum(char input)
        {
            return true;
        }

        private void addFunction_Click(object sender, RoutedEventArgs e)
        {
            var dictionary = new ResourceDictionary
            {
                Source = new Uri("/Calculator;component/Button.xaml", UriKind.RelativeOrAbsolute) // 指定样式文件的路径
            };
            var style = dictionary["TransparentButton"] as Style;
            WrapPanel wrap = new WrapPanel()
            {
                Height = 30
            };
            TextBox input = new TextBox()
            {
                Text = "y=x",
                FontSize = 20,
                Height = 28,
                Width = 344
            };
            input.TextChanged += (x, y) =>
            {
                try
                {
                    /*分析表达式*/
                    string value = input.Text;
                    char[] temp = value.ToCharArray();
                    double k = 1, cs = 1;
                    double Y1, Y2;
                    double X1 = 100, X2 = -100;
                    char[] xsList = new char[100];
                    #region 获取系数部分
                    for (int i = 0; i < temp.Length; i++)
                    {
                        //获取“y=”和“x”之间的字符
                        char temp1 = temp[i];
                        if (temp1 == 'x')
                        {
                            break;
                        }
                        else if (temp1 != 'y' || temp1 != '=')
                        {
                            xsList[i] = temp1;
                        }
                    }
                    #endregion
                    #region 计算系数
                    string fz = null;
                    string fm = null;
                    bool isfm = false;
                    bool isF = false;
                    for (int i = 0; i < xsList.Length; i++)
                    {
                        if (xsList[i] == '/')
                        {
                            isfm = true;
                        }
                        if (xsList[i] == '-')
                        {
                            if (isF)
                            {
                                isF = false;
                            }
                            else
                            {
                                isF = true;
                            }
                        }
                        if (!isfm)
                        {
                            if (IsNum(xsList[i]))
                            {
                                fz += xsList[i];
                            }
                            else if (xsList[i] == '.')
                            {
                                fz += xsList[i];
                            }
                        }
                        else
                        {
                            if (IsNum(xsList[i]))
                            {
                                fm += xsList[i];
                            }
                            else if (xsList[i] == '.')
                            {
                                fm += xsList[i];
                            }
                        }
                    }
                    if (isF && isfm)
                    {
                        k = double.Parse(fz) / double.Parse(fm) * -1;
                    }
                    else if (isfm)
                    {
                        k = double.Parse(fz) / double.Parse(fm);
                    }
                    else
                    {
                        if (isF)
                        {
                            k = double.Parse(fz) * -1;
                        }
                        else
                        {
                            k = double.Parse(fz);
                        }
                    }
                    #endregion
                    #region 计算Y值
                    Y1 = k * X1; Y2 = k * X2;
                    #endregion
                    /*绘制函数图形*/
                    Line l = new Line()
                    {
                        Stroke = basicLine.Stroke,
                        StrokeThickness = basicLine.StrokeThickness,
                        X1 = X1,
                        X2 = X2,
                        Y1 = Y1,
                        Y2 = Y2
                    };
                    funcBoard.Children.Add(l);
                }
                catch (Exception p)
                {
                    NewMessage("错误", "原因如下：\n" + p, "http://sopport.InkShadow.com/Calculator/Function/", 1);
                }
            };
            Button button = new Button()
            {
                Width = 30, Height = 30, Background = func_but_base.Background, FontSize = 18,
                BorderBrush = func_but_base.BorderBrush, Foreground = func_but_base.Foreground,
                FontFamily = func_but_base.FontFamily, Content = func_but_base.Content, Style = style
            };
            button.Click += (x, y) =>
            {
                funcs.Children.Remove(wrap);
            };
            wrap.Children.Add(input);
            wrap.Children.Add(button);
            funcs.Children.Add(wrap);
        }

        int NewMessage(string title,string content,string helpLink,int buttonType)
        {
            Message msg = new Message();
            msg.title.Content = title;
            msg.text.Text = content;
            msg.Type = buttonType;
            msg.Left = Left + (Width - msg.Width) / 2;
            msg.Top = Top + (Height - msg.Height) / 2;
            if (!helpLink.Equals("Null"))
                msg.HelpLink = helpLink;
            msg.ShowDialog();
            return msg.ExitCode;
        }
    }
    /*四则混合运算尝试
    ///<summary>
    ///CalUtility的摘要说明
    ///四则混合运算
    ///</summary>

    public class CalUtility
    {
        StringBuilder StrB;
        private int iCurr = 0;
        private int iCount = 0;

        ///<summary>
        ///构造方法
        ///</summary>        
        public CalUtility(string calStr)
        {
            StrB = new StringBuilder(calStr.Trim());
            iCount = Encoding.Default.GetByteCount(calStr.Trim());
        }
        ///<summary>
        ///取段，自动分析数值或计算数值
        ///</summary>
        public string getItem()
        {
            //End
            if (iCurr == iCount)
                return "";
            char ChTmp = StrB[iCurr];
            bool b = IsNum(ChTmp);
            if(!b)
            {
                iCurr++;
                return ChTmp.ToString();
            }
            string strTmp = "";
            while (IsNum(ChTmp)==b&&iCurr<iCount)
            {
                ChTmp = StrB[iCurr];
                if (IsNum(ChTmp) == b)
                    strTmp += ChTmp;
                else
                    break;
                iCurr++;
            }

            return "";
        }
    }
    */
}