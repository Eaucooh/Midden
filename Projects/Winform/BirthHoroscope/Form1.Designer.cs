namespace BrithdayEigth
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtBrithday = new System.Windows.Forms.TextBox();
            this.Day = new System.Windows.Forms.DateTimePicker();
            this.hourDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请在下面选择你的生日,并输入时间.然后点击确定";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(138, 214);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtBrithday
            // 
            this.txtBrithday.Location = new System.Drawing.Point(71, 255);
            this.txtBrithday.Name = "txtBrithday";
            this.txtBrithday.Size = new System.Drawing.Size(247, 21);
            this.txtBrithday.TabIndex = 3;
            // 
            // Day
            // 
            this.Day.Location = new System.Drawing.Point(87, 60);
            this.Day.Name = "Day";
            this.Day.Size = new System.Drawing.Size(117, 21);
            this.Day.TabIndex = 4;
            // 
            // hourDate
            // 
            this.hourDate.Location = new System.Drawing.Point(87, 124);
            this.hourDate.Name = "hourDate";
            this.hourDate.Size = new System.Drawing.Size(77, 21);
            this.hourDate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "请输入小时:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "请选择时间:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 297);
            this.Controls.Add(this.hourDate);
            this.Controls.Add(this.Day);
            this.Controls.Add(this.txtBrithday);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtBrithday;
        private System.Windows.Forms.DateTimePicker Day;
        private System.Windows.Forms.TextBox hourDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

