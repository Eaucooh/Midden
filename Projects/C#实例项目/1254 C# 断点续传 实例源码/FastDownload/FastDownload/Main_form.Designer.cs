namespace FastDownload
{
    partial class Main_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_form));
            this.lv_state = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pbox_new = new System.Windows.Forms.PictureBox();
            this.pbox_start = new System.Windows.Forms.PictureBox();
            this.pbox_pause = new System.Windows.Forms.PictureBox();
            this.pbox_delete = new System.Windows.Forms.PictureBox();
            this.pbox_continue = new System.Windows.Forms.PictureBox();
            this.pbox_close = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pbox_set = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_new)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_pause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_continue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_set)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lv_state
            // 
            this.lv_state.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lv_state.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lv_state.FullRowSelect = true;
            this.lv_state.GridLines = true;
            this.lv_state.Location = new System.Drawing.Point(1, 78);
            this.lv_state.Name = "lv_state";
            this.lv_state.Size = new System.Drawing.Size(810, 419);
            this.lv_state.TabIndex = 8;
            this.lv_state.UseCompatibleStateImageBehavior = false;
            this.lv_state.View = System.Windows.Forms.View.Details;
            this.lv_state.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 88;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "文件大小";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 94;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "下载进度";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "下载完成量";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 160;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "已用时间";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 122;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "文件类型";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 110;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "创建时间";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 150;
            // 
            // pbox_new
            // 
            this.pbox_new.BackColor = System.Drawing.Color.Transparent;
            this.pbox_new.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbox_new.Image = global::FastDownload.Properties.Resources.pbox_new2;
            this.pbox_new.Location = new System.Drawing.Point(17, 28);
            this.pbox_new.Name = "pbox_new";
            this.pbox_new.Size = new System.Drawing.Size(50, 47);
            this.pbox_new.TabIndex = 16;
            this.pbox_new.TabStop = false;
            this.pbox_new.Tag = "新建";
            this.pbox_new.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pbox_new.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pbox_new.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // pbox_start
            // 
            this.pbox_start.BackColor = System.Drawing.Color.Transparent;
            this.pbox_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbox_start.Image = global::FastDownload.Properties.Resources.pbox_start2;
            this.pbox_start.Location = new System.Drawing.Point(65, 28);
            this.pbox_start.Name = "pbox_start";
            this.pbox_start.Size = new System.Drawing.Size(50, 47);
            this.pbox_start.TabIndex = 17;
            this.pbox_start.TabStop = false;
            this.pbox_start.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pbox_start.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.pbox_start.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // pbox_pause
            // 
            this.pbox_pause.BackColor = System.Drawing.Color.Transparent;
            this.pbox_pause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbox_pause.Image = global::FastDownload.Properties.Resources.pbox_pause2;
            this.pbox_pause.Location = new System.Drawing.Point(116, 28);
            this.pbox_pause.Name = "pbox_pause";
            this.pbox_pause.Size = new System.Drawing.Size(50, 47);
            this.pbox_pause.TabIndex = 18;
            this.pbox_pause.TabStop = false;
            this.pbox_pause.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pbox_pause.MouseEnter += new System.EventHandler(this.pictureBox3_MouseEnter);
            this.pbox_pause.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            // 
            // pbox_delete
            // 
            this.pbox_delete.BackColor = System.Drawing.Color.Transparent;
            this.pbox_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbox_delete.Image = global::FastDownload.Properties.Resources.pbox_delete2;
            this.pbox_delete.Location = new System.Drawing.Point(165, 28);
            this.pbox_delete.Name = "pbox_delete";
            this.pbox_delete.Size = new System.Drawing.Size(50, 48);
            this.pbox_delete.TabIndex = 19;
            this.pbox_delete.TabStop = false;
            this.pbox_delete.Click += new System.EventHandler(this.pictureBox4_Click);
            this.pbox_delete.MouseEnter += new System.EventHandler(this.pictureBox4_MouseEnter);
            this.pbox_delete.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            // 
            // pbox_continue
            // 
            this.pbox_continue.BackColor = System.Drawing.Color.Transparent;
            this.pbox_continue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbox_continue.Image = global::FastDownload.Properties.Resources.pbox_continue2;
            this.pbox_continue.Location = new System.Drawing.Point(216, 28);
            this.pbox_continue.Name = "pbox_continue";
            this.pbox_continue.Size = new System.Drawing.Size(46, 47);
            this.pbox_continue.TabIndex = 20;
            this.pbox_continue.TabStop = false;
            this.pbox_continue.Click += new System.EventHandler(this.pictureBox5_Click);
            this.pbox_continue.MouseEnter += new System.EventHandler(this.pictureBox5_MouseEnter);
            this.pbox_continue.MouseLeave += new System.EventHandler(this.pictureBox5_MouseLeave);
            // 
            // pbox_close
            // 
            this.pbox_close.BackColor = System.Drawing.Color.Transparent;
            this.pbox_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbox_close.Image = global::FastDownload.Properties.Resources.pbox_close;
            this.pbox_close.Location = new System.Drawing.Point(789, 4);
            this.pbox_close.Name = "pbox_close";
            this.pbox_close.Size = new System.Drawing.Size(20, 21);
            this.pbox_close.TabIndex = 21;
            this.pbox_close.TabStop = false;
            this.pbox_close.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pbox_set
            // 
            this.pbox_set.BackColor = System.Drawing.Color.Transparent;
            this.pbox_set.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbox_set.Image = global::FastDownload.Properties.Resources.pbox_set;
            this.pbox_set.Location = new System.Drawing.Point(264, 29);
            this.pbox_set.Name = "pbox_set";
            this.pbox_set.Size = new System.Drawing.Size(46, 47);
            this.pbox_set.TabIndex = 22;
            this.pbox_set.TabStop = false;
            this.pbox_set.Click += new System.EventHandler(this.pbox_set_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "闪电下载器";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(52, 500);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "[0 KB/s]";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(158, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 24;
            this.label2.Text = "[0 KB/s]";
            this.label2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::FastDownload.Properties.Resources.down;
            this.pictureBox1.Location = new System.Drawing.Point(36, 495);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::FastDownload.Properties.Resources.up;
            this.pictureBox2.Location = new System.Drawing.Point(141, 495);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // Main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(814, 521);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbox_set);
            this.Controls.Add(this.pbox_close);
            this.Controls.Add(this.pbox_continue);
            this.Controls.Add(this.pbox_delete);
            this.Controls.Add(this.pbox_pause);
            this.Controls.Add(this.pbox_start);
            this.Controls.Add(this.pbox_new);
            this.Controls.Add(this.lv_state);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "网络下载终结者";
            this.Load += new System.EventHandler(this.Main_form_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.main_form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.main_form_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_new)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_pause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_continue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_set)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_state;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.PictureBox pbox_new;
        private System.Windows.Forms.PictureBox pbox_start;
        private System.Windows.Forms.PictureBox pbox_pause;
        private System.Windows.Forms.PictureBox pbox_delete;
        private System.Windows.Forms.PictureBox pbox_continue;
        private System.Windows.Forms.PictureBox pbox_close;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pbox_set;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

