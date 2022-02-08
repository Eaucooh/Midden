namespace FastDownload
{
    partial class LoadStart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadStart));
            this.btn_browse = new System.Windows.Forms.Button();
            this.tb_url = new System.Windows.Forms.TextBox();
            this.tb_filename = new System.Windows.Forms.TextBox();
            this.tb_savepath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbox_count = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pbox_true = new System.Windows.Forms.PictureBox();
            this.pbox_cancel = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_true)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_cancel)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(351, 151);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(51, 23);
            this.btn_browse.TabIndex = 2;
            this.btn_browse.Text = "浏览";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // tb_url
            // 
            this.tb_url.Location = new System.Drawing.Point(75, 95);
            this.tb_url.Name = "tb_url";
            this.tb_url.Size = new System.Drawing.Size(325, 21);
            this.tb_url.TabIndex = 3;
            this.tb_url.TextChanged += new System.EventHandler(this.tb_url_TextChanged);
            // 
            // tb_filename
            // 
            this.tb_filename.Location = new System.Drawing.Point(75, 122);
            this.tb_filename.Name = "tb_filename";
            this.tb_filename.Size = new System.Drawing.Size(325, 21);
            this.tb_filename.TabIndex = 4;
            // 
            // tb_savepath
            // 
            this.tb_savepath.Location = new System.Drawing.Point(75, 151);
            this.tb_savepath.Name = "tb_savepath";
            this.tb_savepath.ReadOnly = true;
            this.tb_savepath.Size = new System.Drawing.Size(271, 21);
            this.tb_savepath.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "使用线程数量：";
            // 
            // cbox_count
            // 
            this.cbox_count.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_count.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbox_count.FormattingEnabled = true;
            this.cbox_count.Items.AddRange(new object[] {
            "单线程",
            "两条线程",
            "三条线程",
            "四条线程",
            "五条线程",
            "六条线程",
            "七条线程",
            "八条线程",
            "九条线程",
            "十条线程",
            "十一条线程",
            "十二条线程"});
            this.cbox_count.Location = new System.Drawing.Point(103, 181);
            this.cbox_count.Name = "cbox_count";
            this.cbox_count.Size = new System.Drawing.Size(297, 20);
            this.cbox_count.TabIndex = 8;
            // 
            // pbox_true
            // 
            this.pbox_true.BackColor = System.Drawing.Color.Transparent;
            this.pbox_true.Image = global::FastDownload.Properties.Resources.pbox_begin2;
            this.pbox_true.Location = new System.Drawing.Point(217, 241);
            this.pbox_true.Name = "pbox_true";
            this.pbox_true.Size = new System.Drawing.Size(88, 31);
            this.pbox_true.TabIndex = 9;
            this.pbox_true.TabStop = false;
            this.pbox_true.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pbox_true.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pbox_true.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // pbox_cancel
            // 
            this.pbox_cancel.BackColor = System.Drawing.Color.Transparent;
            this.pbox_cancel.Image = global::FastDownload.Properties.Resources.pbox_cancel;
            this.pbox_cancel.Location = new System.Drawing.Point(309, 240);
            this.pbox_cancel.Name = "pbox_cancel";
            this.pbox_cancel.Size = new System.Drawing.Size(70, 32);
            this.pbox_cancel.TabIndex = 10;
            this.pbox_cancel.TabStop = false;
            this.pbox_cancel.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pbox_cancel.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.pbox_cancel.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "下载链接：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "文件名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "存储路径：";
            // 
            // LoadStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(410, 287);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbox_cancel);
            this.Controls.Add(this.pbox_true);
            this.Controls.Add(this.cbox_count);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_savepath);
            this.Controls.Add(this.tb_filename);
            this.Controls.Add(this.tb_url);
            this.Controls.Add(this.btn_browse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建下载任务";
            this.Load += new System.EventHandler(this.LoadStart_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoadStart_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoadStart_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_true)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_cancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.TextBox tb_url;
        private System.Windows.Forms.TextBox tb_filename;
        private System.Windows.Forms.TextBox tb_savepath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbox_count;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox pbox_true;
        private System.Windows.Forms.PictureBox pbox_cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}