namespace CameraQRCode
{
    partial class FrmCamera
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtOutputQR = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.btnQRDeCode = new System.Windows.Forms.Button();
            this.btnQRCode = new System.Windows.Forms.Button();
            this.txtInputForQR = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(143, 310);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 138;
            this.btnStop.Text = "关闭摄像头";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(31, 310);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 137;
            this.btnOpen.Text = "打开摄像头";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtOutputQR
            // 
            this.txtOutputQR.Location = new System.Drawing.Point(58, 241);
            this.txtOutputQR.Name = "txtOutputQR";
            this.txtOutputQR.Size = new System.Drawing.Size(160, 21);
            this.txtOutputQR.TabIndex = 136;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(61, 219);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(65, 12);
            this.label39.TabIndex = 135;
            this.label39.Text = "读取二维码";
            // 
            // btnQRDeCode
            // 
            this.btnQRDeCode.Location = new System.Drawing.Point(44, 132);
            this.btnQRDeCode.Name = "btnQRDeCode";
            this.btnQRDeCode.Size = new System.Drawing.Size(115, 23);
            this.btnQRDeCode.TabIndex = 134;
            this.btnQRDeCode.Text = "从图片识别二维码";
            this.btnQRDeCode.UseVisualStyleBackColor = true;
            this.btnQRDeCode.Click += new System.EventHandler(this.btnQRDeCode_Click);
            // 
            // btnQRCode
            // 
            this.btnQRCode.Location = new System.Drawing.Point(42, 90);
            this.btnQRCode.Name = "btnQRCode";
            this.btnQRCode.Size = new System.Drawing.Size(117, 23);
            this.btnQRCode.TabIndex = 133;
            this.btnQRCode.Text = "生成二维码及图片";
            this.btnQRCode.UseVisualStyleBackColor = true;
            this.btnQRCode.Click += new System.EventHandler(this.btnQRCode_Click);
            // 
            // txtInputForQR
            // 
            this.txtInputForQR.Location = new System.Drawing.Point(44, 54);
            this.txtInputForQR.Name = "txtInputForQR";
            this.txtInputForQR.Size = new System.Drawing.Size(149, 21);
            this.txtInputForQR.TabIndex = 132;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(40, 23);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(137, 12);
            this.label38.TabIndex = 131;
            this.label38.Text = "需要生成二维码的数据：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(248, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(328, 301);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 130;
            this.pictureBox1.TabStop = false;
            // 
            // FrmCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 373);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtOutputQR);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.btnQRDeCode);
            this.Controls.Add(this.btnQRCode);
            this.Controls.Add(this.txtInputForQR);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCamera";
            this.Text = "二维码识别";
            this.Load += new System.EventHandler(this.FrmCamera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtOutputQR;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button btnQRDeCode;
        private System.Windows.Forms.Button btnQRCode;
        private System.Windows.Forms.TextBox txtInputForQR;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

