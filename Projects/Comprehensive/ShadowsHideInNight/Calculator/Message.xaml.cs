using System;
using System.Text;
using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Message.xaml 的交互逻辑
    /// </summary>
    public partial class Message : Window
    {
        public string NewTitle = "消息";
        public string Text = "内容";
        public string HelpLink = "http://support.InkShadow.com/";
        public int Type = 1;
        public int ExitCode = 2;

        public Message()
        {
            InitializeComponent();
            Function();
            ok.Visibility = Visibility.Hidden;
            cancel.Visibility = Visibility.Hidden;
            yes.Visibility = Visibility.Hidden;
            no.Visibility = Visibility.Hidden;
            help.Visibility = Visibility.Hidden;
            helpFailed.Visibility = Visibility.Hidden;
            switch (Type)
            {
                case 1:
                    ok.Visibility = Visibility.Visible;
                    break;
                case 2:
                    ok.Visibility = Visibility.Visible;
                    cancel.Visibility = Visibility.Visible;
                    break;
                case 3:
                    yes.Visibility = Visibility.Visible;
                    no.Visibility = Visibility.Visible;
                    break;
                case 4:
                    yes.Visibility = Visibility.Visible;
                    no.Visibility = Visibility.Visible;
                    cancel.Visibility = Visibility.Visible;
                    break;
            }
            help.Visibility = Visibility.Visible;
        }

        int NewMessage(string title, string content, string helpLink, int buttonType)
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

        private void Function()
        {
            move.MouseDown += (x, y) =>
            {
                try { DragMove(); } catch { }
            };
            help.Click += (x, y) =>
            {
                try
                {
                    System.Net.NetworkInformation.Ping objPingSender = new System.Net.NetworkInformation.Ping();
                    System.Net.NetworkInformation.PingOptions objPinOptions = new System.Net.NetworkInformation.PingOptions();
                    objPinOptions.DontFragment = true;
                    string data = "";
                    byte[] buffer = Encoding.UTF8.GetBytes(data);
                    int intTimeout = 120;
                    string target = "183.232.231.174";
                    System.Net.NetworkInformation.PingReply objPinReply = objPingSender.Send(target, intTimeout, buffer, objPinOptions);
                    string strInfo = objPinReply.Status.ToString();
                    if (strInfo == "Success")
                    {
                        System.Diagnostics.Process.Start(HelpLink);
                    }
                    else
                    {
                        help.Visibility = Visibility.Hidden;
                        helpFailed.Visibility = Visibility.Visible;
                        helpFailed.Click += (m, n) =>
                        {
                            NewMessage("(⊙o⊙)…", "网费都交不起了呢~\n是否前往交费？", "Null", 3);
                        };
                    }
                }
                catch (Exception p)
                {
                    help.Visibility = Visibility.Hidden;
                    helpFailed.Visibility = Visibility.Visible;
                    helpFailed.Click += (a, b) =>
                    {
                        text.Text += p;
                        textDocker.ScrollToEnd();
                    };
                }
            };
            ok.Click += (x, y) =>
            {
                ExitCode = 1;
                Close();
            };
            cancel.Click += (x, y) =>
            {
                ExitCode = 2;
                Close();
            };
            yes.Click += (x, y) =>
            {
                ExitCode = 3;
                Close();
            };
            no.Click += (x, y) =>
            {
                ExitCode = 4;
                Close();
            };
        }
    }
}
