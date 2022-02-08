namespace FastDownload
{
    partial class Setting
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNotify = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.gboxSet = new System.Windows.Forms.GroupBox();
            this.cboxAuto = new System.Windows.Forms.CheckBox();
            this.gboxDownload = new System.Windows.Forms.GroupBox();
            this.gboxNotify = new System.Windows.Forms.GroupBox();
            this.cboxContinue = new System.Windows.Forms.CheckBox();
            this.cboxShowFlow = new System.Windows.Forms.CheckBox();
            this.cboxPlay = new System.Windows.Forms.CheckBox();
            this.cboxSNotify = new System.Windows.Forms.CheckBox();
            this.lblSpace = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxTClose = new System.Windows.Forms.CheckBox();
            this.cboxDClose = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNet = new System.Windows.Forms.TextBox();
            this.cboxNet = new System.Windows.Forms.CheckBox();
            this.dtpickerTime = new System.Windows.Forms.DateTimePicker();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxStart = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gboxSet.SuspendLayout();
            this.gboxDownload.SuspendLayout();
            this.gboxNotify.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(183)))), ((int)(((byte)(148)))));
            this.panel1.Controls.Add(this.btnNotify);
            this.panel1.Controls.Add(this.btnDownload);
            this.panel1.Controls.Add(this.btnSet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(90, 219);
            this.panel1.TabIndex = 0;
            // 
            // btnNotify
            // 
            this.btnNotify.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNotify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotify.Location = new System.Drawing.Point(8, 72);
            this.btnNotify.Name = "btnNotify";
            this.btnNotify.Size = new System.Drawing.Size(75, 31);
            this.btnNotify.TabIndex = 2;
            this.btnNotify.Text = "消息提醒";
            this.btnNotify.UseVisualStyleBackColor = true;
            this.btnNotify.Click += new System.EventHandler(this.btnNotify_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Location = new System.Drawing.Point(8, 42);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 31);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "下载设置";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnSet
            // 
            this.btnSet.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Location = new System.Drawing.Point(8, 12);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 31);
            this.btnSet.TabIndex = 2;
            this.btnSet.Text = "常规设置";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // gboxSet
            // 
            this.gboxSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(210)))), ((int)(((byte)(178)))));
            this.gboxSet.Controls.Add(this.cboxAuto);
            this.gboxSet.Controls.Add(this.cboxStart);
            this.gboxSet.Location = new System.Drawing.Point(98, 12);
            this.gboxSet.Name = "gboxSet";
            this.gboxSet.Size = new System.Drawing.Size(80, 20);
            this.gboxSet.TabIndex = 1;
            this.gboxSet.TabStop = false;
            this.gboxSet.Text = "常规设置";
            // 
            // cboxAuto
            // 
            this.cboxAuto.AutoSize = true;
            this.cboxAuto.Location = new System.Drawing.Point(26, 57);
            this.cboxAuto.Name = "cboxAuto";
            this.cboxAuto.Size = new System.Drawing.Size(168, 16);
            this.cboxAuto.TabIndex = 0;
            this.cboxAuto.Text = "启动时自动开始未完成任务";
            this.cboxAuto.UseVisualStyleBackColor = true;
            // 
            // gboxDownload
            // 
            this.gboxDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(210)))), ((int)(((byte)(178)))));
            this.gboxDownload.Controls.Add(this.lblSpace);
            this.gboxDownload.Controls.Add(this.label3);
            this.gboxDownload.Controls.Add(this.cboxTClose);
            this.gboxDownload.Controls.Add(this.cboxDClose);
            this.gboxDownload.Controls.Add(this.label2);
            this.gboxDownload.Controls.Add(this.txtNet);
            this.gboxDownload.Controls.Add(this.cboxNet);
            this.gboxDownload.Controls.Add(this.dtpickerTime);
            this.gboxDownload.Controls.Add(this.btnSelect);
            this.gboxDownload.Controls.Add(this.txtPath);
            this.gboxDownload.Controls.Add(this.label1);
            this.gboxDownload.Location = new System.Drawing.Point(318, 12);
            this.gboxDownload.Name = "gboxDownload";
            this.gboxDownload.Size = new System.Drawing.Size(69, 16);
            this.gboxDownload.TabIndex = 2;
            this.gboxDownload.TabStop = false;
            this.gboxDownload.Text = "下载设置";
            this.gboxDownload.Visible = false;
            // 
            // gboxNotify
            // 
            this.gboxNotify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(210)))), ((int)(((byte)(178)))));
            this.gboxNotify.Controls.Add(this.cboxContinue);
            this.gboxNotify.Controls.Add(this.cboxShowFlow);
            this.gboxNotify.Controls.Add(this.cboxPlay);
            this.gboxNotify.Controls.Add(this.cboxSNotify);
            this.gboxNotify.Location = new System.Drawing.Point(208, 12);
            this.gboxNotify.Name = "gboxNotify";
            this.gboxNotify.Size = new System.Drawing.Size(84, 16);
            this.gboxNotify.TabIndex = 3;
            this.gboxNotify.TabStop = false;
            this.gboxNotify.Text = "消息提醒";
            this.gboxNotify.Visible = false;
            // 
            // cboxContinue
            // 
            this.cboxContinue.AutoSize = true;
            this.cboxContinue.Location = new System.Drawing.Point(26, 78);
            this.cboxContinue.Name = "cboxContinue";
            this.cboxContinue.Size = new System.Drawing.Size(204, 16);
            this.cboxContinue.TabIndex = 10;
            this.cboxContinue.Text = "有未完成任务时显示继续下载提示";
            this.cboxContinue.UseVisualStyleBackColor = true;
            // 
            // cboxShowFlow
            // 
            this.cboxShowFlow.AutoSize = true;
            this.cboxShowFlow.Location = new System.Drawing.Point(26, 104);
            this.cboxShowFlow.Name = "cboxShowFlow";
            this.cboxShowFlow.Size = new System.Drawing.Size(96, 16);
            this.cboxShowFlow.TabIndex = 9;
            this.cboxShowFlow.Text = "显示流量监控";
            this.cboxShowFlow.UseVisualStyleBackColor = true;
            // 
            // cboxPlay
            // 
            this.cboxPlay.AutoSize = true;
            this.cboxPlay.Location = new System.Drawing.Point(26, 52);
            this.cboxPlay.Name = "cboxPlay";
            this.cboxPlay.Size = new System.Drawing.Size(168, 16);
            this.cboxPlay.TabIndex = 8;
            this.cboxPlay.Text = "任务下载完成后播放提示音";
            this.cboxPlay.UseVisualStyleBackColor = true;
            // 
            // cboxSNotify
            // 
            this.cboxSNotify.AutoSize = true;
            this.cboxSNotify.Location = new System.Drawing.Point(26, 26);
            this.cboxSNotify.Name = "cboxSNotify";
            this.cboxSNotify.Size = new System.Drawing.Size(168, 16);
            this.cboxSNotify.TabIndex = 7;
            this.cboxSNotify.Text = "任务下载完成显示提示窗口";
            this.cboxSNotify.UseVisualStyleBackColor = true;
            // 
            // lblSpace
            // 
            this.lblSpace.AutoSize = true;
            this.lblSpace.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSpace.ForeColor = System.Drawing.Color.Teal;
            this.lblSpace.Location = new System.Drawing.Point(96, 57);
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Size = new System.Drawing.Size(0, 15);
            this.lblSpace.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "剩余空间：";
            // 
            // cboxTClose
            // 
            this.cboxTClose.AutoSize = true;
            this.cboxTClose.Location = new System.Drawing.Point(24, 137);
            this.cboxTClose.Name = "cboxTClose";
            this.cboxTClose.Size = new System.Drawing.Size(108, 16);
            this.cboxTClose.TabIndex = 11;
            this.cboxTClose.Text = "定时关闭计算机";
            this.cboxTClose.UseVisualStyleBackColor = true;
            this.cboxTClose.CheckedChanged += new System.EventHandler(this.cboxTClose_CheckedChanged);
            // 
            // cboxDClose
            // 
            this.cboxDClose.AutoSize = true;
            this.cboxDClose.Location = new System.Drawing.Point(24, 111);
            this.cboxDClose.Name = "cboxDClose";
            this.cboxDClose.Size = new System.Drawing.Size(156, 16);
            this.cboxDClose.TabIndex = 10;
            this.cboxDClose.Text = "下载完成自动关闭计算机";
            this.cboxDClose.UseVisualStyleBackColor = true;
            this.cboxDClose.CheckedChanged += new System.EventHandler(this.cboxDClose_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "KB/s";
            // 
            // txtNet
            // 
            this.txtNet.Location = new System.Drawing.Point(112, 82);
            this.txtNet.Name = "txtNet";
            this.txtNet.Size = new System.Drawing.Size(47, 21);
            this.txtNet.TabIndex = 8;
            // 
            // cboxNet
            // 
            this.cboxNet.AutoSize = true;
            this.cboxNet.Location = new System.Drawing.Point(24, 85);
            this.cboxNet.Name = "cboxNet";
            this.cboxNet.Size = new System.Drawing.Size(72, 16);
            this.cboxNet.TabIndex = 7;
            this.cboxNet.Text = "网速保护";
            this.cboxNet.UseVisualStyleBackColor = true;
            this.cboxNet.CheckedChanged += new System.EventHandler(this.cboxNet_CheckedChanged);
            // 
            // dtpickerTime
            // 
            this.dtpickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpickerTime.Location = new System.Drawing.Point(151, 136);
            this.dtpickerTime.Name = "dtpickerTime";
            this.dtpickerTime.ShowUpDown = true;
            this.dtpickerTime.Size = new System.Drawing.Size(84, 21);
            this.dtpickerTime.TabIndex = 6;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(324, 27);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(46, 25);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(94, 30);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(213, 21);
            this.txtPath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "下载路径：";
            // 
            // cboxStart
            // 
            this.cboxStart.AutoSize = true;
            this.cboxStart.Location = new System.Drawing.Point(26, 26);
            this.cboxStart.Name = "cboxStart";
            this.cboxStart.Size = new System.Drawing.Size(72, 16);
            this.cboxStart.TabIndex = 0;
            this.cboxStart.Text = "开机启动";
            this.cboxStart.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(185)))), ((int)(((byte)(146)))));
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(90, 188);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(410, 31);
            this.panel2.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(311, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(228, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 219);
            this.Controls.Add(this.gboxNotify);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gboxDownload);
            this.Controls.Add(this.gboxSet);
            this.Controls.Add(this.panel1);
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.panel1.ResumeLayout(false);
            this.gboxSet.ResumeLayout(false);
            this.gboxSet.PerformLayout();
            this.gboxDownload.ResumeLayout(false);
            this.gboxDownload.PerformLayout();
            this.gboxNotify.ResumeLayout(false);
            this.gboxNotify.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNotify;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.GroupBox gboxSet;
        private System.Windows.Forms.CheckBox cboxAuto;
        private System.Windows.Forms.CheckBox cboxStart;
        private System.Windows.Forms.GroupBox gboxDownload;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNet;
        private System.Windows.Forms.CheckBox cboxNet;
        private System.Windows.Forms.DateTimePicker dtpickerTime;
        private System.Windows.Forms.GroupBox gboxNotify;
        private System.Windows.Forms.CheckBox cboxShowFlow;
        private System.Windows.Forms.CheckBox cboxPlay;
        private System.Windows.Forms.CheckBox cboxSNotify;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cboxTClose;
        private System.Windows.Forms.CheckBox cboxDClose;
        private System.Windows.Forms.CheckBox cboxContinue;
        private System.Windows.Forms.Label lblSpace;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}