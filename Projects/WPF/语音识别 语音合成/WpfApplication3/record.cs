using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace WpfApplication3
{
    public partial class record : Form
    {
        int sum = 0;
        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        public static extern int mciSendString(
          string lpstrCommand,
          string lpstrReturnString,
          int uReturnLength,
          int hwndCallback
        );
        public record()
        {

            InitializeComponent();
        }
       
        private void record_Load(object sender, EventArgs e)
        {

        }
         List<string> listSong = new List<string>();
        //开始录音
        private void button1_Click(object sender, EventArgs e)
        {
            mciSendString("set wave bitpersample 8", "", 0, 0);
            mciSendString("set wave samplespersec 20000", "", 0, 0);
            mciSendString("set wave channels 2", "", 0, 0);
            mciSendString("set wave format tag pcm", "", 0, 0);
            mciSendString("open new type WAVEAudio alias movie", "", 0, 0);
            //this.timer1.Start();
            mciSendString("record movie", "", 0, 0);
        }
        //暂停录音
        private void button2_Click(object sender, EventArgs e)
        {
            mciSendString("stop movie", "", 0, 0);
            //mciSendString("save movie 1.wav", "", 0, 0);
           // this.timer1.Stop();
        }
        //保存录音
        private void button3_Click(object sender, EventArgs e)
        {
            //按日期保存文件
            string file = "save movie"   " "   DateTime.Now.ToString("yyyyMMddhhmmss")   ".wav";
            mciSendString(file, "", 0, 0);
            currentCount = 0;
            mciSendString("close movie", "", 0, 0);
        }
        public int currentCount = 0;
        //显示录制时间
        
    }
}
