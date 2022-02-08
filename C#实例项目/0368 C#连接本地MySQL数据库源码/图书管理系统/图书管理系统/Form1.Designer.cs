namespace 图书管理系统
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LogInlinkLabel = new System.Windows.Forms.LinkLabel();
            this.SignInlinkLabel = new System.Windows.Forms.LinkLabel();
            this.UnsubscribelinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(170, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 93);
            this.label1.TabIndex = 0;
            this.label1.Text = "图书管理系统";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(267, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "学生创新基地";
            // 
            // LogInlinkLabel
            // 
            this.LogInlinkLabel.AutoSize = true;
            this.LogInlinkLabel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogInlinkLabel.Location = new System.Drawing.Point(212, 415);
            this.LogInlinkLabel.Name = "LogInlinkLabel";
            this.LogInlinkLabel.Size = new System.Drawing.Size(106, 24);
            this.LogInlinkLabel.TabIndex = 2;
            this.LogInlinkLabel.TabStop = true;
            this.LogInlinkLabel.Text = "登陆系统";
            this.LogInlinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // SignInlinkLabel
            // 
            this.SignInlinkLabel.AutoSize = true;
            this.SignInlinkLabel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SignInlinkLabel.Location = new System.Drawing.Point(343, 415);
            this.SignInlinkLabel.Name = "SignInlinkLabel";
            this.SignInlinkLabel.Size = new System.Drawing.Size(106, 24);
            this.SignInlinkLabel.TabIndex = 3;
            this.SignInlinkLabel.TabStop = true;
            this.SignInlinkLabel.Text = "用户注册";
            this.SignInlinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SignInlinkLabel_LinkClicked);
            // 
            // UnsubscribelinkLabel
            // 
            this.UnsubscribelinkLabel.AutoSize = true;
            this.UnsubscribelinkLabel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UnsubscribelinkLabel.Location = new System.Drawing.Point(474, 415);
            this.UnsubscribelinkLabel.Name = "UnsubscribelinkLabel";
            this.UnsubscribelinkLabel.Size = new System.Drawing.Size(106, 24);
            this.UnsubscribelinkLabel.TabIndex = 4;
            this.UnsubscribelinkLabel.TabStop = true;
            this.UnsubscribelinkLabel.Text = "账户注销";
            this.UnsubscribelinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UnsubscribelinkLabel_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(795, 545);
            this.Controls.Add(this.UnsubscribelinkLabel);
            this.Controls.Add(this.SignInlinkLabel);
            this.Controls.Add(this.LogInlinkLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "欢迎使用";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel LogInlinkLabel;
        private System.Windows.Forms.LinkLabel SignInlinkLabel;
        private System.Windows.Forms.LinkLabel UnsubscribelinkLabel;
    }
}

