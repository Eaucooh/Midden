/**********************************************************
 * 功能：调用zxing生成和解析二维码，调用摄像头根据图片识别二维码
 * 作者：Fistone
 * 
 * ********************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using com.google.zxing.common;
using com.google.zxing;

namespace CameraQRCode
{
    public partial class FrmCamera : Form
    {
        #region 变量定义
        ///调用AForge使用摄像头
        FilterInfoCollection Use_Webcams = null;
        VideoCaptureDevice cam = null;

        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        #endregion

        public FrmCamera()
        {
            InitializeComponent();
        }

        #region 事件

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCamera_Load(object sender, EventArgs e)
        {
            ///初始化AForge内容
            Use_Webcams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (Use_Webcams.Count > 0)
            {
                //实例化对象
                cam = new VideoCaptureDevice(Use_Webcams[0].MonikerString);

                //绑定事件
                cam.NewFrame += new NewFrameEventHandler(Cam_NewFrame);
            }

        }

        /// <summary>
        /// 生成二维码并保存图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQRCode_Click(object sender, EventArgs e)
        {
            string content = txtInputForQR.Text;
            ByteMatrix byteMatrix = new MultiFormatWriter().encode(content, BarcodeFormat.QR_CODE, 300, 300);
            Bitmap bitmap = toBitmap(byteMatrix);
            pictureBox1.Image = bitmap;
            SaveFileDialog sFD = new SaveFileDialog();
            sFD.Filter = "保存图片(*.png) |*.png|所有文件(*.*) |*.*";
            sFD.DefaultExt = "*.png|*.png";
            sFD.AddExtension = true;
            if (sFD.ShowDialog() == DialogResult.OK)
            {
                if (sFD.FileName != "")
                {
                    writeToFile(byteMatrix, System.Drawing.Imaging.ImageFormat.Png, sFD.FileName);
                }

            }
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQRDeCode_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Image img = Image.FromFile(this.openFileDialog1.FileName);
            Bitmap bmap;
            try
            {
                bmap = new Bitmap(img);
            }
            catch (System.IO.IOException ioe)
            {
                MessageBox.Show(ioe.ToString());
                return;
            }
            if (bmap == null)
            {
                MessageBox.Show("Could not decode image");
                return;
            }
            LuminanceSource source = new RGBLuminanceSource(bmap, bmap.Width, bmap.Height);
            com.google.zxing.BinaryBitmap bitmap1 = new com.google.zxing.BinaryBitmap(new HybridBinarizer(source));
            Result result;
            try
            {
                result = new MultiFormatReader().decode(bitmap1);
            }
            catch (ReaderException re)
            {
                MessageBox.Show(re.ToString());
                return;
            }
            txtOutputQR.Text = result.Text;
            MessageBox.Show(result.Text);
        }

        /// <summary>
        /// 关闭摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (cam != null)
            {
                //关闭摄像头
                if (cam.IsRunning)
                {
                    cam.Stop();
                }
            }

        }


        /// <summary>
        /// 打开摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {

            cam.Start();
            if (!timer1.Enabled)
            {
                timer1.Enabled = true;
            }

        }

        /// <summary>
        /// 扫描识别二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //识别图片中的二维码

            Image img = this.pictureBox1.Image; ;// Image.FromFile(this.openFileDialog1.FileName);
            if (img == null)
                return;
            Bitmap bmap;
            try
            {
                bmap = new Bitmap(img);
            }
            catch (System.IO.IOException ioe)
            {
                MessageBox.Show(ioe.ToString());
                return;
            }
            if (bmap == null)
            {
                MessageBox.Show("Could not decode image");
                return;
            }
            LuminanceSource source = new RGBLuminanceSource(bmap, bmap.Width, bmap.Height);
            com.google.zxing.BinaryBitmap bitmap1 = new com.google.zxing.BinaryBitmap(new HybridBinarizer(source));
            Result result;
            try
            {
                result = new MultiFormatReader().decode(bitmap1);
            }
            catch (ReaderException re)
            {
                //MessageBox.Show(re.ToString());
                return;
            }
            txtOutputQR.Text = result.Text;
            this.timer1.Enabled = false;
            this.cam.Stop();
            this.pictureBox1.Image = null;
            MessageBox.Show("图中二维码：" + result.Text);
        }

        #endregion

        #region 自定义过程
        private void Cam_NewFrame(object obj, NewFrameEventArgs eventArgs)
        {
            this.pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        public static void writeToFile(ByteMatrix matrix, System.Drawing.Imaging.ImageFormat format, string file)
        {
            Bitmap bmap = toBitmap(matrix);
            bmap.Save(file, format);
        }

        public static Bitmap toBitmap(ByteMatrix matrix)
        {
            int width = matrix.Width;
            int height = matrix.Height;
            Bitmap bmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    bmap.SetPixel(x, y, matrix.get_Renamed(x, y) != -1 ? ColorTranslator.FromHtml("0xFF000000") : ColorTranslator.FromHtml("0xFFFFFFFF"));
                }
            }
            return bmap;
        }
        #endregion




    }
}
