namespace 图书管理系统
{
    partial class BooksManage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.exitButtom = new System.Windows.Forms.Button();
            this.borrowRwcordButtom = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.bookNameText = new System.Windows.Forms.TextBox();
            this.authorText = new System.Windows.Forms.TextBox();
            this.publishTimeText = new System.Windows.Forms.TextBox();
            this.pressText = new System.Windows.Forms.TextBox();
            this.bookKindText = new System.Windows.Forms.TextBox();
            this.lblPress = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblBookKind = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblBookName = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.alterButtom = new System.Windows.Forms.Button();
            this.bookDigestTextBox = new System.Windows.Forms.TextBox();
            this.searchBookButtom = new System.Windows.Forms.Button();
            this.lblBookNameForSearch = new System.Windows.Forms.Label();
            this.bookNameTextBox = new System.Windows.Forms.TextBox();
            this.deleteBook = new System.Windows.Forms.Button();
            this.bookAddButtom = new System.Windows.Forms.Button();
            this.booksDVG = new System.Windows.Forms.DataGridView();
            this.searchByKindButtom = new System.Windows.Forms.Button();
            this.lblKind = new System.Windows.Forms.Label();
            this.bookClassComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.booksDVG)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bookClassComboBox);
            this.groupBox1.Controls.Add(this.lblContent);
            this.groupBox1.Controls.Add(this.bookDigestTextBox);
            this.groupBox1.Controls.Add(this.searchBookButtom);
            this.groupBox1.Controls.Add(this.lblBookNameForSearch);
            this.groupBox1.Controls.Add(this.bookNameTextBox);
            this.groupBox1.Controls.Add(this.booksDVG);
            this.groupBox1.Controls.Add(this.searchByKindButtom);
            this.groupBox1.Controls.Add(this.lblKind);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1182, 653);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图书信息";
            // 
            // exitButtom
            // 
            this.exitButtom.Location = new System.Drawing.Point(475, 87);
            this.exitButtom.Margin = new System.Windows.Forms.Padding(4);
            this.exitButtom.Name = "exitButtom";
            this.exitButtom.Size = new System.Drawing.Size(133, 40);
            this.exitButtom.TabIndex = 51;
            this.exitButtom.Text = "退出";
            this.exitButtom.UseVisualStyleBackColor = true;
            this.exitButtom.Click += new System.EventHandler(this.exitButtom_Click);
            // 
            // borrowRwcordButtom
            // 
            this.borrowRwcordButtom.Location = new System.Drawing.Point(869, 87);
            this.borrowRwcordButtom.Margin = new System.Windows.Forms.Padding(4);
            this.borrowRwcordButtom.Name = "borrowRwcordButtom";
            this.borrowRwcordButtom.Size = new System.Drawing.Size(133, 40);
            this.borrowRwcordButtom.TabIndex = 50;
            this.borrowRwcordButtom.Text = "查看借书记录";
            this.borrowRwcordButtom.UseVisualStyleBackColor = true;
            this.borrowRwcordButtom.Click += new System.EventHandler(this.borrowRwcordButtom_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(624, 53);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(133, 26);
            this.btnUpdate.TabIndex = 49;
            this.btnUpdate.Text = "刷新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // bookNameText
            // 
            this.bookNameText.Location = new System.Drawing.Point(117, 22);
            this.bookNameText.Margin = new System.Windows.Forms.Padding(4);
            this.bookNameText.Name = "bookNameText";
            this.bookNameText.Size = new System.Drawing.Size(132, 25);
            this.bookNameText.TabIndex = 48;
            // 
            // authorText
            // 
            this.authorText.Location = new System.Drawing.Point(117, 55);
            this.authorText.Margin = new System.Windows.Forms.Padding(4);
            this.authorText.Name = "authorText";
            this.authorText.Size = new System.Drawing.Size(132, 25);
            this.authorText.TabIndex = 47;
            // 
            // publishTimeText
            // 
            this.publishTimeText.Location = new System.Drawing.Point(388, 53);
            this.publishTimeText.Margin = new System.Windows.Forms.Padding(4);
            this.publishTimeText.Name = "publishTimeText";
            this.publishTimeText.Size = new System.Drawing.Size(132, 25);
            this.publishTimeText.TabIndex = 46;
            // 
            // pressText
            // 
            this.pressText.Location = new System.Drawing.Point(625, 22);
            this.pressText.Margin = new System.Windows.Forms.Padding(4);
            this.pressText.Name = "pressText";
            this.pressText.Size = new System.Drawing.Size(132, 25);
            this.pressText.TabIndex = 45;
            // 
            // bookKindText
            // 
            this.bookKindText.Location = new System.Drawing.Point(388, 20);
            this.bookKindText.Margin = new System.Windows.Forms.Padding(4);
            this.bookKindText.Name = "bookKindText";
            this.bookKindText.Size = new System.Drawing.Size(132, 25);
            this.bookKindText.TabIndex = 44;
            // 
            // lblPress
            // 
            this.lblPress.AutoSize = true;
            this.lblPress.Location = new System.Drawing.Point(550, 25);
            this.lblPress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPress.Name = "lblPress";
            this.lblPress.Size = new System.Drawing.Size(67, 15);
            this.lblPress.TabIndex = 43;
            this.lblPress.Text = "出版社：";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(298, 59);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(82, 15);
            this.lblTime.TabIndex = 42;
            this.lblTime.Text = "出版时间：";
            // 
            // lblBookKind
            // 
            this.lblBookKind.AutoSize = true;
            this.lblBookKind.Location = new System.Drawing.Point(298, 25);
            this.lblBookKind.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBookKind.Name = "lblBookKind";
            this.lblBookKind.Size = new System.Drawing.Size(82, 15);
            this.lblBookKind.TabIndex = 41;
            this.lblBookKind.Text = "图书类别：";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(54, 58);
            this.lblAuthor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(52, 15);
            this.lblAuthor.TabIndex = 40;
            this.lblAuthor.Text = "作者：";
            // 
            // lblBookName
            // 
            this.lblBookName.AutoSize = true;
            this.lblBookName.Location = new System.Drawing.Point(54, 25);
            this.lblBookName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBookName.Name = "lblBookName";
            this.lblBookName.Size = new System.Drawing.Size(52, 15);
            this.lblBookName.TabIndex = 39;
            this.lblBookName.Text = "书名：";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblContent.Location = new System.Drawing.Point(47, 287);
            this.lblContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(109, 20);
            this.lblContent.TabIndex = 38;
            this.lblContent.Text = "内容摘要：";
            // 
            // alterButtom
            // 
            this.alterButtom.Location = new System.Drawing.Point(869, 19);
            this.alterButtom.Margin = new System.Windows.Forms.Padding(4);
            this.alterButtom.Name = "alterButtom";
            this.alterButtom.Size = new System.Drawing.Size(133, 26);
            this.alterButtom.TabIndex = 37;
            this.alterButtom.Text = "修改书目";
            this.alterButtom.UseVisualStyleBackColor = true;
            this.alterButtom.Click += new System.EventHandler(this.btnAlter_Click);
            // 
            // bookDigestTextBox
            // 
            this.bookDigestTextBox.Location = new System.Drawing.Point(51, 311);
            this.bookDigestTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.bookDigestTextBox.Multiline = true;
            this.bookDigestTextBox.Name = "bookDigestTextBox";
            this.bookDigestTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.bookDigestTextBox.Size = new System.Drawing.Size(1063, 160);
            this.bookDigestTextBox.TabIndex = 36;
            // 
            // searchBookButtom
            // 
            this.searchBookButtom.Location = new System.Drawing.Point(498, 30);
            this.searchBookButtom.Margin = new System.Windows.Forms.Padding(4);
            this.searchBookButtom.Name = "searchBookButtom";
            this.searchBookButtom.Size = new System.Drawing.Size(87, 26);
            this.searchBookButtom.TabIndex = 35;
            this.searchBookButtom.Text = "查找";
            this.searchBookButtom.UseVisualStyleBackColor = true;
            this.searchBookButtom.Click += new System.EventHandler(this.btnSearchBook_Click);
            // 
            // lblBookNameForSearch
            // 
            this.lblBookNameForSearch.AutoSize = true;
            this.lblBookNameForSearch.Location = new System.Drawing.Point(48, 36);
            this.lblBookNameForSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBookNameForSearch.Name = "lblBookNameForSearch";
            this.lblBookNameForSearch.Size = new System.Drawing.Size(82, 15);
            this.lblBookNameForSearch.TabIndex = 34;
            this.lblBookNameForSearch.Text = "图书书名：";
            // 
            // bookNameTextBox
            // 
            this.bookNameTextBox.Location = new System.Drawing.Point(143, 33);
            this.bookNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.bookNameTextBox.Name = "bookNameTextBox";
            this.bookNameTextBox.Size = new System.Drawing.Size(347, 25);
            this.bookNameTextBox.TabIndex = 33;
            // 
            // deleteBook
            // 
            this.deleteBook.Location = new System.Drawing.Point(869, 53);
            this.deleteBook.Margin = new System.Windows.Forms.Padding(4);
            this.deleteBook.Name = "deleteBook";
            this.deleteBook.Size = new System.Drawing.Size(133, 26);
            this.deleteBook.TabIndex = 32;
            this.deleteBook.Text = "删除书目";
            this.deleteBook.UseVisualStyleBackColor = true;
            this.deleteBook.Click += new System.EventHandler(this.deleteBook_Click);
            // 
            // bookAddButtom
            // 
            this.bookAddButtom.Location = new System.Drawing.Point(53, 87);
            this.bookAddButtom.Margin = new System.Windows.Forms.Padding(4);
            this.bookAddButtom.Name = "bookAddButtom";
            this.bookAddButtom.Size = new System.Drawing.Size(133, 40);
            this.bookAddButtom.TabIndex = 31;
            this.bookAddButtom.Text = "新增书目";
            this.bookAddButtom.UseVisualStyleBackColor = true;
            this.bookAddButtom.Click += new System.EventHandler(this.bookAddButtom_Click);
            // 
            // booksDVG
            // 
            this.booksDVG.AllowUserToAddRows = false;
            this.booksDVG.AllowUserToDeleteRows = false;
            this.booksDVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksDVG.Location = new System.Drawing.Point(51, 75);
            this.booksDVG.Margin = new System.Windows.Forms.Padding(4);
            this.booksDVG.Name = "booksDVG";
            this.booksDVG.ReadOnly = true;
            this.booksDVG.RowTemplate.Height = 23;
            this.booksDVG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.booksDVG.Size = new System.Drawing.Size(1063, 209);
            this.booksDVG.TabIndex = 30;
            this.booksDVG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.booksDVG_CellClick);
            // 
            // searchByKindButtom
            // 
            this.searchByKindButtom.Location = new System.Drawing.Point(829, 31);
            this.searchByKindButtom.Margin = new System.Windows.Forms.Padding(4);
            this.searchByKindButtom.Name = "searchByKindButtom";
            this.searchByKindButtom.Size = new System.Drawing.Size(84, 25);
            this.searchByKindButtom.TabIndex = 29;
            this.searchByKindButtom.Text = "按类查找";
            this.searchByKindButtom.UseVisualStyleBackColor = true;
            this.searchByKindButtom.Click += new System.EventHandler(this.searchByKindButtom_Click);
            // 
            // lblKind
            // 
            this.lblKind.AutoSize = true;
            this.lblKind.Location = new System.Drawing.Point(593, 37);
            this.lblKind.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKind.Name = "lblKind";
            this.lblKind.Size = new System.Drawing.Size(82, 15);
            this.lblKind.TabIndex = 27;
            this.lblKind.Text = "书籍类别：";
            // 
            // bookClassComboBox
            // 
            this.bookClassComboBox.FormattingEnabled = true;
            this.bookClassComboBox.Items.AddRange(new object[] {
            "IT",
            "科学",
            "文化"});
            this.bookClassComboBox.Location = new System.Drawing.Point(682, 33);
            this.bookClassComboBox.Name = "bookClassComboBox";
            this.bookClassComboBox.Size = new System.Drawing.Size(140, 23);
            this.bookClassComboBox.TabIndex = 52;
            this.bookClassComboBox.Text = "IT";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.exitButtom);
            this.groupBox2.Controls.Add(this.borrowRwcordButtom);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.bookNameText);
            this.groupBox2.Controls.Add(this.authorText);
            this.groupBox2.Controls.Add(this.publishTimeText);
            this.groupBox2.Controls.Add(this.pressText);
            this.groupBox2.Controls.Add(this.bookKindText);
            this.groupBox2.Controls.Add(this.lblPress);
            this.groupBox2.Controls.Add(this.lblTime);
            this.groupBox2.Controls.Add(this.lblBookKind);
            this.groupBox2.Controls.Add(this.lblAuthor);
            this.groupBox2.Controls.Add(this.lblBookName);
            this.groupBox2.Controls.Add(this.alterButtom);
            this.groupBox2.Controls.Add(this.deleteBook);
            this.groupBox2.Controls.Add(this.bookAddButtom);
            this.groupBox2.Location = new System.Drawing.Point(51, 478);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1063, 144);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "可修改部分";
            // 
            // BooksManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BooksManage";
            this.Text = "图书管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.booksDVG)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button exitButtom;
        private System.Windows.Forms.Button borrowRwcordButtom;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox bookNameText;
        private System.Windows.Forms.TextBox authorText;
        private System.Windows.Forms.TextBox publishTimeText;
        private System.Windows.Forms.TextBox pressText;
        private System.Windows.Forms.TextBox bookKindText;
        private System.Windows.Forms.Label lblPress;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblBookKind;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblBookName;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Button alterButtom;
        private System.Windows.Forms.TextBox bookDigestTextBox;
        private System.Windows.Forms.Button searchBookButtom;
        private System.Windows.Forms.Label lblBookNameForSearch;
        private System.Windows.Forms.TextBox bookNameTextBox;
        private System.Windows.Forms.Button deleteBook;
        private System.Windows.Forms.Button bookAddButtom;
        private System.Windows.Forms.DataGridView booksDVG;
        private System.Windows.Forms.Button searchByKindButtom;
        private System.Windows.Forms.Label lblKind;
        private System.Windows.Forms.ComboBox bookClassComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}