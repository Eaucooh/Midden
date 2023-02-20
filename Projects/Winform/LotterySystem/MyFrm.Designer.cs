namespace WindowsFormsTest2
{
    partial class MyFrm
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
            this.lstNums = new System.Windows.Forms.ListBox();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstNums
            // 
            this.lstNums.FormattingEnabled = true;
            this.lstNums.ItemHeight = 12;
            this.lstNums.Location = new System.Drawing.Point(13, 13);
            this.lstNums.Name = "lstNums";
            this.lstNums.Size = new System.Drawing.Size(211, 508);
            this.lstNums.TabIndex = 0;
            // 
            // lstResult
            // 
            this.lstResult.FormattingEnabled = true;
            this.lstResult.ItemHeight = 12;
            this.lstResult.Location = new System.Drawing.Point(249, 47);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(196, 472);
            this.lstResult.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(249, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "创建彩池";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(370, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "抽奖";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MyFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 532);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.lstNums);
            this.Name = "MyFrm";
            this.Text = "MyFrm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstNums;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}