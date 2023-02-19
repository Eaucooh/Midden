 using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using SpeechLib;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Speech.Synthesis;


namespace WpfApplication3
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        private SpeechSynthesizer speech;
        /// <summary>
        /// 音量
        /// </summary>
        private int value = 100;
        /// <summary>
        /// 语速
        /// </summary>
        private int rate;

        public Window1()
        {
            InitializeComponent(); 
            //SpVoiceUtil SpVoiceUtil = new SpVoiceUtil();
           // this.textBox1.SelectionStart = this.textBox1.TextLength;
            textBox1.Focus();
           // this.textBox1.SelectionStart = this.textBox1.TextLength;
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox1.Focus();
           // this.textBox1.SelectionStart = this.textBox1.TextLength;
            string text = textBox1.Text;

            if (text.Trim().Length == 0)
            {
                System.Windows .MessageBox.Show("文本为空无法生成！请重新输入！", "错误提示");
                return;
            }
            SpVoice voice = new SpVoice();
            voice.Rate = -5; //语速,[-10,10]
            voice.Volume = 100; //音量,[0,100]
            voice.Voice = voice.GetVoices().Item(0); //语音库
            voice.Speak(textBox1.Text);
        }

        private void Button_Click_2(string textbox1)
        {
            speech = new SpeechSynthesizer();
            var dialog = new SaveFileDialog();
            dialog.Filter = "*.wav|*.wav|*.mp3|*.mp3";
            dialog.ShowDialog();
 
            string path = dialog.FileName;
            if (path.Trim().Length == 0)
            {
                return;
            }
            //SpVoiceUtil.WreiteToWAV(@"C:\\1.wav", textbox1.Text, DotNetSpeech.SpeechAudioFormatType.SAFT11kHz16BitMono);
            speech.SetOutputToWaveFile(@"D:\voice");
            speech.Volume = value;
            speech.Rate = rate;
            speech.Speak(textbox1);
            speech.SetOutputToNull();
            System.Windows.MessageBox.Show("生成成功！","提示");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.textBox1.Text = "";
        }

        

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            speech = new SpeechSynthesizer();
            var dialog = new SaveFileDialog();
            dialog.Filter = "*.mp3|*.mp3";
            dialog.ShowDialog();

            string path = dialog.FileName;
            if (path.Trim().Length == 0)
            {
                return;
            }
           speech.SetOutputToWaveFile(path);
            speech.Volume = value;
            speech.Rate = rate;
             speech.SetOutputToNull();
           System.Windows.MessageBox.Show("生成成功！", "提示");
            textBox1.Focus();
           // this.textBox1.SelectionStart = this.textBox1.TextInput;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            speech = new SpeechSynthesizer();
            var dialog = new SaveFileDialog();
            dialog.Filter = "*.mp3|*.mp3";
            dialog.ShowDialog();

            string path = dialog.FileName;
            if (path.Trim().Length == 0)
            {
                return;
            }
            speech.SetOutputToWaveFile(path);
            speech.Volume = value;
            speech.Rate = rate;
            speech.SetOutputToNull();
            System.Windows.MessageBox.Show("  生成成功！", "提示");
            textBox1.Focus();
            // this.textBox1.SelectionStart = this.textBox1.TextInput;
        }
    }
}