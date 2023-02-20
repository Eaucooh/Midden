using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESBasic;
using Oraycn.MCapture;

namespace MCaptureDemo
{
    /*
    * 本demo采用的是 语音视频采集组件MCapture 的免费版本。若想获取MCapture其它版本，请联系 www.oraycn.com 。
    * 
    */
    public partial class Form1 : Form
    {
        private ICapturer capturer;
        public Form1()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;

            Oraycn.MCapture.GlobalUtil.SetAuthorizedUser("FreeUser", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {       
                //根据选择创建对应的采集器
                if (this.comboBox1.SelectedIndex == 0)
                {
                    this.capturer = CapturerFactory.CreateCameraCapturer(0, new Size(int.Parse(this.textBox_width.Text), int.Parse(this.textBox_height.Text)), 20);
                    ((ICameraCapturer)this.capturer).ImageCaptured += new ESBasic.CbGeneric<Bitmap>(Form1_ImageCaptured);
                }
                else if (this.comboBox1.SelectedIndex == 1)
                {
                    this.capturer = CapturerFactory.CreateDesktopCapturer(20, false);
                    ((IDesktopCapturer)this.capturer).ImageCaptured += new ESBasic.CbGeneric<Bitmap>(Form1_ImageCaptured);
                }
                else if (this.comboBox1.SelectedIndex == 2)
                {
                    this.capturer = CapturerFactory.CreateMicrophoneCapturer(0);
                    ((IMicrophoneCapturer)this.capturer).AudioCaptured += new ESBasic.CbGeneric<byte[]>(Form1_AudioCaptured);
                }
                else
                {
                    this.capturer = CapturerFactory.CreateSoundcardCapturer();
                    ((ISoundcardCapturer)this.capturer).AudioCaptured += new ESBasic.CbGeneric<byte[]>(Form1_AudioCaptured);
                }
                this.button1.Enabled = false;
                this.button2.Enabled = true;
                this.comboBox1.Enabled = false;
                this.autioDataTotalLen = 0;
                this.label_audioDataTotal.Text = "0";

                //开始采集
                this.capturer.Start();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //停止采集
            this.capturer.Stop();     
            this.button2.Enabled = false;
            this.button1.Enabled = true;
            this.comboBox1.Enabled = true;

            //清除最后一帧的显示
            CbGeneric cb = new CbGeneric(this.AfterStop);
            cb.BeginInvoke(null, null);
        }

        private void AfterStop()
        {            
            if (this.InvokeRequired)
            {
                System.Threading.Thread.Sleep(60);
                this.BeginInvoke(new CbGeneric(this.AfterStop));
            }
            else
            {
                //清除最后一帧的显示
                this.pictureBox1.BackgroundImage = null;
                this.pictureBox1.Invalidate();
            }
        }

        private int autioDataTotalLen = 0;
        private int captureAudioCount = 0;
        void Form1_AudioCaptured(byte[] audioData) //采集到的声音数据
        {
           this.autioDataTotalLen += audioData.Length ;
           ++this.captureAudioCount;
           if (this.captureAudioCount >= 20)
           {
               this.captureAudioCount = 0;
               this.ShowAudioDataTotalLen(this.autioDataTotalLen);
           }
        }

        private void ShowAudioDataTotalLen(int totalLen)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ESBasic.CbGeneric<int>(this.ShowAudioDataTotalLen), totalLen);
            }
            else
            {
                this.label_audioDataTotal.Text = totalLen.ToString();
            }
        }

        //采集到的视频或桌面图像
        void Form1_ImageCaptured(Bitmap img)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ESBasic.CbGeneric<Bitmap>(this.Form1_ImageCaptured), img);
            }
            else
            {
                Bitmap old = (Bitmap)this.pictureBox1.BackgroundImage;                
                this.pictureBox1.BackgroundImage = img;
                if (old != null) 
                {
                    old.Dispose(); //立即释放不再使用的视频帧
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.panel_camera.Visible = this.comboBox1.SelectedIndex == 0;
            this.panel_microphone.Visible = this.comboBox1.SelectedIndex == 2 || this.comboBox1.SelectedIndex == 3;
        }        
    }
}
