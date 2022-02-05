using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using MenuItem = System.Windows.Controls.MenuItem;

namespace PPTHelper
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double WorkWidth = SystemParameters.WorkArea.Width,
            WorkHeight = SystemParameters.WorkArea.Height;
        public static string workdir = Environment.CurrentDirectory;

        private void OnSourceInitialized(object sender, EventArgs e)
        {
            var handle = new WindowInteropHelper(this).Handle;
            var exstyle = GetWindowLong(handle, GWL_EXSTYLE);
            SetWindowLong(handle, GWL_EXSTYLE, new IntPtr(exstyle.ToInt32() | WS_EX_NOACTIVATE));
        }

        #region Native Methods

        private const int WS_EX_NOACTIVATE = 0x08000000;
        private const int GWL_EXSTYLE = -20;

        public static IntPtr GetWindowLong(IntPtr hWnd, int nIndex)
        {
            return Environment.Is64BitProcess
                ? GetWindowLong64(hWnd, nIndex)
                : GetWindowLong32(hWnd, nIndex);
        }

        public static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            return Environment.Is64BitProcess
                ? SetWindowLong64(hWnd, nIndex, dwNewLong)
                : SetWindowLong32(hWnd, nIndex, dwNewLong);
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern IntPtr GetWindowLong32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        private static extern IntPtr GetWindowLong64(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        private static extern IntPtr SetWindowLong32(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        private static extern IntPtr SetWindowLong64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        #endregion

        private void GoPrevious(object sender, RoutedEventArgs e)
        {
            SendKeys.SendWait("{UP}");
        }
        private void GoNext(object sender, RoutedEventArgs e)
        {
            SendKeys.SendWait("{DOWN}");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            WorkWidth = SystemParameters.WorkArea.Width;
            WorkHeight = SystemParameters.WorkArea.Height;
            Width = WorkWidth;
            Height = WorkHeight / 5;
            Left = 0;
            Top = WorkHeight - Height;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            foreach (MenuItem item in opacity_setter.Items)
            {
                item.IsChecked = false;
            }
            (sender as MenuItem).IsChecked = true;
            double opacity = (double)int.Parse((sender as System.Windows.Controls.HeaderedItemsControl).Header.ToString().Replace("%", "")) / 100;
            Opacity = opacity;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            new Window()
            {
                Content = new Image()
                {
                    Source = new BitmapImage(new Uri($"{workdir}\\header.png"))
                },
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Width = 250,
                SizeToContent = SizeToContent.Height,
                Topmost = true,
                Title = "关于作者"
            }.ShowDialog();
        }

        public MainWindow()
        {
            InitializeComponent();
            Width = WorkWidth;
            Height = WorkHeight / 5;
            Left = 0;
            Top = WorkHeight - Height;
            SourceInitialized += OnSourceInitialized;

            new Thread(() =>
            {
                VoiceInit();
            }).Start();
        }

        public static void VoiceInit()
        {
            using (
               SpeechRecognitionEngine recognizer =
                 new SpeechRecognitionEngine(
                   new System.Globalization.CultureInfo("zh-CN")))
            {
                Choices choices = new Choices(new string[] { "返回", "前进", "退出", "滚蛋", "我错了" });
                GrammarBuilder gb = new GrammarBuilder(choices);

                // Create and load a dictation grammar.  
                recognizer.LoadGrammar(new Grammar(gb));

                // Add a handler for the speech recognized event.  
                recognizer.SpeechRecognized +=
                  new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

                // Configure input to the speech recognizer.  
                recognizer.SetInputToDefaultAudioDevice();

                // Start asynchronous, continuous speech recognition.  
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                while (true)
                {

                }
            }
        }

        public static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text.IndexOf("返回") != -1)
                SendKeys.SendWait("{UP}");
            else if (e.Result.Text.IndexOf("前进") != -1)
                SendKeys.SendWait("{DOWN}");
            else if (e.Result.Text.IndexOf("退出") != -1)
                SendKeys.SendWait("{ESC}");
            else if (e.Result.Text.IndexOf("滚蛋") != -1)
                ExecuteCommand("shutdown -s -t 60");
            else if (e.Result.Text.IndexOf("我错了") != -1)
                ExecuteCommand("shutdown -a");
        }

        private static void ExecuteCommand(string cmd)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(cmd);
            p.StandardInput.AutoFlush = true;
            p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
        }
    }
}
