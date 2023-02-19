using System.Windows;
using System.Windows.Controls;

namespace PopEye.WPF.Controls
{
    /// <summary>
    /// TextBoxLines.xaml 的交互逻辑
    /// </summary>
    public partial class TextBoxLines : UserControl
    {
        public int lines;
        public string Content { get; set; }

        public TextBox ContentBox { get => content; set => content = value; }

        public TextBoxLines()
        {
            InitializeComponent();
            ContentBox.TextChanged += ContentBox_TextChanged;
        }

        public string Text
        {
            get { return Content; }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextBoxLines), new PropertyMetadata(""));

        public bool EffectiveLiner
        {
            get { return (bool)GetValue(EffectiveLinerProperty); }
            set { SetValue(EffectiveLinerProperty, value); }
        }

        public static readonly DependencyProperty EffectiveLinerProperty =
            DependencyProperty.Register("EffectiveLiner", typeof(bool), typeof(TextBoxLines), new PropertyMetadata(false));

        public bool ShowLines
        {
            get { return (bool)GetValue(ShowLinesProperty); }
            set { SetValue(ShowLinesProperty, value); }
        }

        public static readonly DependencyProperty ShowLinesProperty =
            DependencyProperty.Register("ShowLines", typeof(bool), typeof(TextBoxLines), new PropertyMetadata(true));

        public TextWrapping TextWrap
        {
            get { return (TextWrapping)GetValue(TextWrapProperty); }
            set { SetValue(TextWrapProperty, value); }
        }

        public static readonly DependencyProperty TextWrapProperty =
            DependencyProperty.Register("TextWrap", typeof(TextWrapping), typeof(TextBoxLines), new PropertyMetadata(TextWrapping.Wrap));

        private void ContentBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ShowLines)
            {
                int nowLine = liner.LineCount; //更改前行数
                lines = ContentBox.LineCount; //更改后行数
                if (EffectiveLiner)
                {
                    if (lines < 200)
                    {
                        liner.Text = "";
                        for (int i = 0; i < lines; i++)
                        {
                            liner.Text += $"{i + 1}\r\n";
                        }
                    }
                    else
                    {
                        int deltaLine = lines - nowLine;
                        if (deltaLine > 0)
                        {
                            int lastLine = System.Convert.ToInt32(liner.GetLineText(liner.LineCount - 1));
                            for (int p = lastLine; p < deltaLine; p++)
                            {
                                liner.Text += $"{p + 1}\r\n";
                            }
                        }
                        else
                        {
                            string linesTxt = liner.Text.Replace("\r\n", "↹");
                            string[] linetxt = linesTxt.Split('↹');
                            string[] newtxt = new string[linetxt.Length + deltaLine];
                            for (int i = 0; i < newtxt.Length; i++)
                            {
                                newtxt[i] = linetxt[i];
                            }
                            liner.Text = "";
                            for (int i = 0; i < newtxt.Length; i++)
                            {
                                liner.Text += $"{i + 1}\r\n";
                            }
                        }
                    }
                }
                else
                {
                    liner.Text = "";
                    for (int i = 0; i < lines; i++)
                    {
                        liner.Text += $"{i + 1}\r\n";
                    }
                }
            }            
        }

        private void content_TextChanged(object sender, TextChangedEventArgs e) => Content = (sender as TextBox).Text.ToString();
    }
}
