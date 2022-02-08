namespace 图书管理系统
{
    partial class Admin
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
            this.UsersManageButton = new System.Windows.Forms.Button();
            this.BookManageButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UsersManageButton
            // 
            this.UsersManageButton.Location = new System.Drawing.Point(40, 29);
            this.UsersManageButton.Name = "UsersManageButton";
            this.UsersManageButton.Size = new System.Drawing.Size(94, 46);
            this.UsersManageButton.TabIndex = 0;
            this.UsersManageButton.Text = "用户管理";
            this.UsersManageButton.UseVisualStyleBackColor = true;
            this.UsersManageButton.Click += new System.EventHandler(this.UsersManageButton_Click);
            // 
            // BookManageButton
            // 
            this.BookManageButton.Location = new System.Drawing.Point(167, 29);
            this.BookManageButton.Name = "BookManageButton";
            this.BookManageButton.Size = new System.Drawing.Size(94, 46);
            this.BookManageButton.TabIndex = 1;
            this.BookManageButton.Text = "图书管理";
            this.BookManageButton.UseVisualStyleBackColor = true;
            this.BookManageButton.Click += new System.EventHandler(this.BookManageButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(167, 100);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(94, 46);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "退出登陆";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 196);
            this.ControlBox = false;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.BookManageButton);
            this.Controls.Add(this.UsersManageButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Admin";
            this.Text = "Admin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UsersManageButton;
        private System.Windows.Forms.Button BookManageButton;
        private System.Windows.Forms.Button exitButton;
    }
}