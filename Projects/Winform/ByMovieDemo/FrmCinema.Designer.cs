namespace 青鸟影院
{
    partial class FrmCinema
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
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tpToday = new System.Windows.Forms.TabPage();
            this.tvMovies = new System.Windows.Forms.TreeView();
            this.lblCalcPrice = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblActor = new System.Windows.Forms.Label();
            this.lblDirector = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoNormal = new System.Windows.Forms.RadioButton();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbDisCount = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.rdoStudent = new System.Windows.Forms.RadioButton();
            this.rdoFree = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiBuy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMovies = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSeat = new System.Windows.Forms.TabControl();
            this.tpCinema = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picMovie = new System.Windows.Forms.PictureBox();
            this.lblMovieName = new System.Windows.Forms.Label();
            this.片名 = new System.Windows.Forms.Label();
            this.tabControl2.SuspendLayout();
            this.tpToday.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.msMain.SuspendLayout();
            this.tbSeat.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMovie)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tpToday);
            this.tabControl2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl2.Location = new System.Drawing.Point(0, 25);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(247, 674);
            this.tabControl2.TabIndex = 14;
            // 
            // tpToday
            // 
            this.tpToday.Controls.Add(this.tvMovies);
            this.tpToday.Location = new System.Drawing.Point(4, 24);
            this.tpToday.Name = "tpToday";
            this.tpToday.Padding = new System.Windows.Forms.Padding(3);
            this.tpToday.Size = new System.Drawing.Size(239, 646);
            this.tpToday.TabIndex = 0;
            this.tpToday.Text = "放映列表";
            this.tpToday.UseVisualStyleBackColor = true;
            // 
            // tvMovies
            // 
            this.tvMovies.Location = new System.Drawing.Point(11, 14);
            this.tvMovies.Name = "tvMovies";
            this.tvMovies.Size = new System.Drawing.Size(210, 604);
            this.tvMovies.TabIndex = 1;
            this.tvMovies.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMovies_AfterSelect);
            // 
            // lblCalcPrice
            // 
            this.lblCalcPrice.AutoSize = true;
            this.lblCalcPrice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCalcPrice.ForeColor = System.Drawing.Color.Red;
            this.lblCalcPrice.Location = new System.Drawing.Point(319, 188);
            this.lblCalcPrice.Name = "lblCalcPrice";
            this.lblCalcPrice.Size = new System.Drawing.Size(0, 14);
            this.lblCalcPrice.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(221, 188);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 14);
            this.label14.TabIndex = 13;
            this.label14.Text = "优惠价：";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrice.Location = new System.Drawing.Point(319, 155);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(0, 14);
            this.lblPrice.TabIndex = 12;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.Location = new System.Drawing.Point(319, 124);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 14);
            this.lblTime.TabIndex = 11;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblType.Location = new System.Drawing.Point(319, 92);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(0, 14);
            this.lblType.TabIndex = 10;
            // 
            // lblActor
            // 
            this.lblActor.AutoSize = true;
            this.lblActor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblActor.Location = new System.Drawing.Point(319, 57);
            this.lblActor.Name = "lblActor";
            this.lblActor.Size = new System.Drawing.Size(0, 14);
            this.lblActor.TabIndex = 9;
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDirector.Location = new System.Drawing.Point(319, 26);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(0, 14);
            this.lblDirector.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(235, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 14);
            this.label10.TabIndex = 7;
            this.label10.Text = "类型：";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(153, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 23);
            this.label5.TabIndex = 17;
            this.label5.Text = "1-2";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(59, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "1-1";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoNormal);
            this.groupBox2.Controls.Add(this.txtCustomer);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cmbDisCount);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.rdoStudent);
            this.groupBox2.Controls.Add(this.rdoFree);
            this.groupBox2.Location = new System.Drawing.Point(744, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 121);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "特殊票：";
            // 
            // rdoNormal
            // 
            this.rdoNormal.AutoSize = true;
            this.rdoNormal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoNormal.Location = new System.Drawing.Point(37, 21);
            this.rdoNormal.Name = "rdoNormal";
            this.rdoNormal.Size = new System.Drawing.Size(67, 18);
            this.rdoNormal.TabIndex = 4;
            this.rdoNormal.TabStop = true;
            this.rdoNormal.Text = "普通票";
            this.rdoNormal.UseVisualStyleBackColor = true;
            this.rdoNormal.CheckedChanged += new System.EventHandler(this.rdoNormal_CheckedChanged);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCustomer.Location = new System.Drawing.Point(110, 87);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(100, 23);
            this.txtCustomer.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(41, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 14);
            this.label13.TabIndex = 6;
            this.label13.Text = "赠送者：";
            // 
            // cmbDisCount
            // 
            this.cmbDisCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDisCount.FormattingEnabled = true;
            this.cmbDisCount.Items.AddRange(new object[] {
            "7",
            "8"});
            this.cmbDisCount.Location = new System.Drawing.Point(110, 50);
            this.cmbDisCount.Name = "cmbDisCount";
            this.cmbDisCount.Size = new System.Drawing.Size(100, 22);
            this.cmbDisCount.TabIndex = 7;
            this.cmbDisCount.SelectedIndexChanged += new System.EventHandler(this.cmbDisCount_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(31, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 14);
            this.label12.TabIndex = 4;
            this.label12.Text = "学生折扣：";
            // 
            // rdoStudent
            // 
            this.rdoStudent.AutoSize = true;
            this.rdoStudent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoStudent.Location = new System.Drawing.Point(169, 21);
            this.rdoStudent.Name = "rdoStudent";
            this.rdoStudent.Size = new System.Drawing.Size(67, 18);
            this.rdoStudent.TabIndex = 6;
            this.rdoStudent.TabStop = true;
            this.rdoStudent.Text = "学生票";
            this.rdoStudent.UseVisualStyleBackColor = true;
            this.rdoStudent.CheckedChanged += new System.EventHandler(this.rdoStudent_CheckedChanged);
            // 
            // rdoFree
            // 
            this.rdoFree.AutoSize = true;
            this.rdoFree.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoFree.Location = new System.Drawing.Point(110, 21);
            this.rdoFree.Name = "rdoFree";
            this.rdoFree.Size = new System.Drawing.Size(53, 18);
            this.rdoFree.TabIndex = 5;
            this.rdoFree.TabStop = true;
            this.rdoFree.Text = "赠票";
            this.rdoFree.UseVisualStyleBackColor = true;
            this.rdoFree.CheckedChanged += new System.EventHandler(this.rdoFree_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(744, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(235, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 6;
            this.label9.Text = "主演：";
            // 
            // msMain
            // 
            this.msMain.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBuy,
            this.tsmiHelp});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(1013, 24);
            this.msMain.TabIndex = 16;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmiBuy
            // 
            this.tsmiBuy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.tsmiMovies,
            this.toolStripSeparator1,
            this.tsmiSave,
            this.toolStripSeparator2,
            this.tsmiExit});
            this.tsmiBuy.Name = "tsmiBuy";
            this.tsmiBuy.Size = new System.Drawing.Size(47, 20);
            this.tsmiBuy.Text = "购票";
            // 
            // tsmiNew
            // 
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(172, 22);
            this.tsmiNew.Text = "获取新放映列表";
            this.tsmiNew.Click += new System.EventHandler(this.tsmiNew_Click);
            // 
            // tsmiMovies
            // 
            this.tsmiMovies.Name = "tsmiMovies";
            this.tsmiMovies.Size = new System.Drawing.Size(172, 22);
            this.tsmiMovies.Text = "继续销售";
            this.tsmiMovies.Click += new System.EventHandler(this.tsmiMovies_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(172, 22);
            this.tsmiSave.Text = "保存";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(172, 22);
            this.tsmiExit.Text = "退出";
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(47, 20);
            this.tsmiHelp.Text = "系统";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(221, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "原票价：";
            // 
            // tbSeat
            // 
            this.tbSeat.Controls.Add(this.tpCinema);
            this.tbSeat.Location = new System.Drawing.Point(253, 261);
            this.tbSeat.Name = "tbSeat";
            this.tbSeat.SelectedIndex = 0;
            this.tbSeat.Size = new System.Drawing.Size(751, 438);
            this.tbSeat.TabIndex = 23;
            // 
            // tpCinema
            // 
            this.tpCinema.Location = new System.Drawing.Point(4, 22);
            this.tpCinema.Name = "tpCinema";
            this.tpCinema.Padding = new System.Windows.Forms.Padding(3);
            this.tpCinema.Size = new System.Drawing.Size(743, 412);
            this.tpCinema.TabIndex = 0;
            this.tpCinema.Text = "放映厅";
            this.tpCinema.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCalcPrice);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblPrice);
            this.groupBox1.Controls.Add(this.lblTime);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.lblActor);
            this.groupBox1.Controls.Add(this.lblDirector);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.picMovie);
            this.groupBox1.Controls.Add(this.lblMovieName);
            this.groupBox1.Controls.Add(this.片名);
            this.groupBox1.Location = new System.Drawing.Point(253, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 230);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "详情";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(235, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 5;
            this.label8.Text = "导演：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(207, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "放映时间：";
            // 
            // picMovie
            // 
            this.picMovie.BackColor = System.Drawing.SystemColors.Control;
            this.picMovie.Location = new System.Drawing.Point(22, 42);
            this.picMovie.Name = "picMovie";
            this.picMovie.Size = new System.Drawing.Size(128, 172);
            this.picMovie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMovie.TabIndex = 2;
            this.picMovie.TabStop = false;
            // 
            // lblMovieName
            // 
            this.lblMovieName.AutoSize = true;
            this.lblMovieName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMovieName.Location = new System.Drawing.Point(101, 21);
            this.lblMovieName.Name = "lblMovieName";
            this.lblMovieName.Size = new System.Drawing.Size(0, 14);
            this.lblMovieName.TabIndex = 1;
            // 
            // 片名
            // 
            this.片名.AutoSize = true;
            this.片名.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.片名.Location = new System.Drawing.Point(20, 21);
            this.片名.Name = "片名";
            this.片名.Size = new System.Drawing.Size(49, 14);
            this.片名.TabIndex = 0;
            this.片名.Text = "片名：";
            // 
            // FrmCinema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 710);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.msMain);
            this.Controls.Add(this.tbSeat);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCinema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCinema";
            this.Load += new System.EventHandler(this.FrmCinema_Load);
            this.tabControl2.ResumeLayout(false);
            this.tpToday.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tbSeat.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMovie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tpToday;
        private System.Windows.Forms.TreeView tvMovies;
        private System.Windows.Forms.Label lblCalcPrice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblActor;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoNormal;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbDisCount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rdoStudent;
        private System.Windows.Forms.RadioButton rdoFree;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiBuy;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiMovies;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tbSeat;
        private System.Windows.Forms.TabPage tpCinema;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picMovie;
        private System.Windows.Forms.Label lblMovieName;
        private System.Windows.Forms.Label 片名;
    }
}