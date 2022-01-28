using KitX.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Stringer
{
    /// <summary>
    /// Main.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IContract))]
    public partial class Main : Window, IContract
    {
        public Main()
        {
            InitializeComponent();
            win = this;
            Closed += (x, y) =>
            {
                started = false;
            };
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

        private void FlushBack()
        {
            Library.Windows.SystemColor.DwmGetColorizationColor(out int pcrColorization, out _);
            win.Background = new SolidColorBrush(Library.Windows.SystemColor.Get_Color(pcrColorization));
        }

        public string GetDescribe_Complex() => "在这里，你可以实现字符串的基本操作，比如说：文本串对比、文本串加密解密、自动生成文本串、大小写、简繁体转换等等。";

        public string GetDescribe_Simple() => "一个字符串处理工具";

        public string GetHelpLink() => "https://docs.catrol.cn/stringer/";

        public string GetHostLink() => "https://blog.catrol.cn/";

        public BitmapImage GetIcon() => FindResource("icon") as BitmapImage;

        public Languages GetLang() => Languages.zh_CN;

        public string GetName() => "Stringer";

        public string GetPublisher() => "Catrol";

        public string GetVersion() => "v3.2.0";

        public Window GetWindow()
        {
            Main win = new Main()
            {
                Width = 1000,
                Height = 800,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ShowActivated = true,
                Title = "Stringer"
            };
            return win;
        }

        public void SetTheme(KitX.Core.Theme tm)
        {
            FlushBack();
        }

        private readonly QuickView Quicker = new QuickView();

        public UserControl GetQuickView()
        {
            Quicker.win = win;
            return Quicker;
        }

        Main win;
        bool started = true;
        bool start_st = true;

        public void Start()
        {
            if (start_st)
            {
                start_st = false;
                win.Show();
            }
            else
            {
                if (!started)
                {
                    win = new Main();
                    win.WorkBase = WorkBase;
                    win.Closed += (x, y) => started = false;
                    win.Show();
                    started = true;

                    FlushBack();
                }
                else
                {
                    if (win.Visibility == Visibility.Hidden)
                    {
                        win.Visibility = Visibility.Visible;

                        FlushBack();
                    }
                    else
                    {
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

        public string GetFileName() => "Stringer.dll";

        public Tags GetTag() => Tags.Process;

        private async void ToVoice_SingleReading_Click(object sender, RoutedEventArgs e)
        {
            await Dispatcher.BeginInvoke(new Action(delegate
            {
                switch ((sender as FrameworkElement).Tag)
                {
                    case 0:
                        string path = $"{WorkBase}\\speech\\spoke{new Random().Next()}.vbs";
                        if (!Directory.Exists(System.IO.Path.GetDirectoryName(path)))
                        {
                            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
                        }
                        Clear(System.IO.Path.GetDirectoryName(path));
                        FileStream fs = new FileStream(path, FileMode.CreateNew);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.Write($"CreateObject(\"SAPI.SpVoice\").Speak\"{ToVoice_InputBox.Text}\"", Encoding.UTF8);
                        sw.Flush();
                        sw.Close();
                        fs.Close();
                        System.Diagnostics.Process.Start(path);
                        break;
                    case 1:
                        Library.Voice.Speech speech = new Library.Voice.Speech((int)SpeechVolumner.Value, (int)SpeechRater.Value);
                        Aborter_Speech.Click += (x, y) =>
                        {
                            new System.Threading.Thread(() =>
                            {
                                speech.Abort();
                                speech.Dispose();
                            }).Start();
                        };
                        speech.Completed += () =>
                        {
                            speech.Dispose();
                        };
                        speech.Declaim(ToVoice_InputBox.Text);
                        break;
                }
            }));
        }

        private void Clear(string path)
        {
            int count = 0;
            List<FileInfo> del = new List<FileInfo>();
            foreach (FileInfo f in new DirectoryInfo(path).GetFiles())
            {
                if (Library.TextHelper.Text.ToCapital(f.Extension).Equals(".VBS"))
                {
                    count++;
                    del.Add(f);
                }
            }
            if (count > 10)
            {
                foreach (FileInfo f in del)
                {
                    f.Delete();
                }
            }
        }

        private void SaveSpeech(object sender, RoutedEventArgs e)
        {
            Library.Voice.Speech speech = new Library.Voice.Speech((int)SpeechVolumner.Value, (int)SpeechRater.Value);
            speech.Save(WPSetter.Text, ToVoice_InputBox.Text);
            speech.Dispose();
        }

        private void SpeakSavePath(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog()
            {
                AddExtension = true,
                CheckPathExists = true,
                CreatePrompt = true,
                DefaultExt = "Wave音频格式|*.wav",
                Filter = "Wave音频格式|*.wav|所有文件格式|*.*",
                InitialDirectory = "C:\\",
                OverwritePrompt = true,
                Title = "选择保存音频位置",
                ValidateNames = true
            };
            sfd.ShowDialog();
            if (sfd.SafeFileName != null)
                WPSetter.Text = sfd.FileName;
        }

        private void Format_ToB_Click(object sender, RoutedEventArgs e) => Update(Library.TextHelper.Text.ToCapital(Format_Source.Text));

        private void Update(string text)
        {
            Format_Converted.Text = text;
            Format_Source.Text = Format_Converted.Text;
        }

        private void Format_ToS_Click(object sender, RoutedEventArgs e) => Update(Library.TextHelper.Text.ToLower(Format_Source.Text));

        private void Format_ToB_CN_Click(object sender, RoutedEventArgs e) => Update(Library.TextHelper.Text.ToCapital_NumberIn_zh_CN(Format_Source.Text));

        private void Format_ToS_CN_Click(object sender, RoutedEventArgs e) => Update(Library.TextHelper.Text.ToLower_NumberIn_zh_CN(Format_Source.Text));

        private void Format_Simplify_Click(object sender, RoutedEventArgs e) => Update(Library.TextHelper.Text.ToSimplifiedChinese(Format_Source.Text));

        private void Format_Traditional_Click(object sender, RoutedEventArgs e) => Update(Library.TextHelper.Text.ToTraditionalChinese(Format_Source.Text));

        private void Format_ToArray(object sender, RoutedEventArgs e) => Update(Library.TextHelper.Text.StringToArray(Format_Source.Text, ' ', "\"", "\",", true));

        private void ToSpelling_Click(object sender, RoutedEventArgs e)
        {
            TextBox tb = new TextBox()
            {
                TextWrapping = TextWrapping.Wrap
            };
            Window win = new Window()
            {
                Content = tb,
                Title = "文字转拼音输出结果"
            };
            tb.Text = Library.TextHelper.Pronunciation.GetChineseSpell(Format_Source.Text);
            win.Show();
        }

        private void Format_Jumpto_Analyze_Click(object sender, RoutedEventArgs e)
        {
            Pager.SelectedIndex = 5;
            Analyze_Input.Text = Format_Source.Text;
        }

        private void PageSelect(object sender, RoutedEventArgs e) => Pager.SelectedIndex = Convert.ToInt32((sender as MenuItem).Tag);

        private void Crypt_ResetPWD(object sender, RoutedEventArgs e) => Crypt_pwd.Password = null;

        private void RandomPwd(object sender, RoutedEventArgs e)
        {
            string rp = Library.TextHelper.Text.RandomText(Crypt_pwd.Length);
            Crypt_pwd.Password = rp;
            Crypt_pwd_View.Content = $"本次随机密码: {rp}";
        }

        private void Crypt_SelfPWD(object sender, RoutedEventArgs e)
        {
            string pwd = Microsoft.VisualBasic.Interaction.InputBox("输入自定义密码\r\n密码长度由算法决定，请谨慎选择\r\n注意：密码长度小于4时，会导致顶部Pin框显示不正常\r\n      但不影响使用。", "自定义密码", "", -1, -1);
            if (pwd != null)
            {
                Crypt_pwd.Length = pwd.Length;
                Crypt_pwd.Password = pwd;
                Crypt_pwd_View.Content = $"自定义密码: {pwd}";
            }
        }

        private void Encrypt(object sender, RoutedEventArgs e)
        {
            switch (alg_selecter.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("该算法正在开发中...");
                    break;
                case 1:
                    MessageBox.Show("该算法正在开发中...");
                    break;
                case 2:
                    Cryptograph.Text = Library.TextHelper.Coder.Encrypt(Proclaimed.Text, null, Crypt_pwd.Password, Library.TextHelper.Coder.ALG.DES).value;
                    break;
                case 3:
                    Cryptograph.Text = Library.TextHelper.Coder.Encrypt(Proclaimed.Text, null, Crypt_pwd.Password, Library.TextHelper.Coder.ALG.AES).value;
                    break;
                default:
                    break;
            }
        }

        private void Decrypt(object sender, RoutedEventArgs e)
        {
            switch (alg_selecter.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("该算法正在开发中...");
                    break;
                case 1:
                    MessageBox.Show("该算法正在开发中...");
                    break;
                case 2:
                    Proclaimed.Text = Library.TextHelper.Coder.Decrypt(Cryptograph.Text, null, Crypt_pwd.Password, Library.TextHelper.Coder.ALG.DES);
                    break;
                case 3:
                    Proclaimed.Text = Library.TextHelper.Coder.Decrypt(Cryptograph.Text, null, Crypt_pwd.Password, Library.TextHelper.Coder.ALG.AES);
                    break;
                default:
                    break;
            }
        }

        private void Crypt_pwd_Completed(object sender, RoutedEventArgs e) => Crypt_pwd_View.Content = $"当前密码: {Crypt_pwd.Password}";

        private void Format_Copier_Click(object sender, RoutedEventArgs e) => Library.TextHelper.Clipboard.SetText(Format_Converted.Text);

        private void Format_Extract(object sender, RoutedEventArgs e)
        {
            int selection = Convert.ToInt32((sender as Button).Tag);
            switch (selection)
            {
                case 0:
                    string result_even = Library.TextHelper.Text.GetEvenLines(Format_Source.Text);
                    if (MessageBox.Show(this, $"提取结果如下：按 是 复制到剪贴板\r\n{result_even}", "提取结果", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        Library.TextHelper.Clipboard.SetText(result_even);
                    }
                    break;
                case 1:
                    string result_odd = Library.TextHelper.Text.GetOddLines(Format_Source.Text);
                    if (MessageBox.Show(this, $"提取结果如下：按 是 复制到剪贴板\r\n{result_odd}", "提取结果", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        Library.TextHelper.Clipboard.SetText(result_odd);
                    }
                    break;
                default:
                    break;
            }
        }

        bool first = true;

        private void Analyze_Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (first)
            {
                first = false;
                return;
            }
            Analyze_specialConverted.Text = Library.TextHelper.Text.CharCount(System.Convert.ToChar(Analyze_SpecialChar.Text), (sender as TextBox).Text).ToString();
        }

        private void OpenLink(object sender, RoutedEventArgs e) => System.Diagnostics.Process.Start((sender as FrameworkElement).Tag.ToString());
    }
}
