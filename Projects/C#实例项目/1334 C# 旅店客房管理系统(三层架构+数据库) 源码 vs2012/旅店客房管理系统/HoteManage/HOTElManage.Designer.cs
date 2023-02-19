namespace HoteManage
{
    partial class HOTElManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HOTElManage));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCheckIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBookRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancelReservation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoney = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCheckOut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPayDeposit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRoomSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCustomerSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBookSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRoomManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUserManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHotel = new System.Windows.Forms.ToolStrip();
            this.tsbtnCheckIn = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCheckOut = new System.Windows.Forms.ToolStripButton();
            this.tsbtnBookRoom = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRoomSearch = new System.Windows.Forms.ToolStripButton();
            this.tsbtnUser = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.tsHotel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCustomer,
            this.tsmiMoney,
            this.tsmiSearch,
            this.tsmiRoom,
            this.tsmiUser});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiCustomer
            // 
            this.tsmiCustomer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCheckIn,
            this.tsmiBookRoom,
            this.tsmiCancelReservation,
            this.tsmiExit});
            this.tsmiCustomer.Name = "tsmiCustomer";
            this.tsmiCustomer.Size = new System.Drawing.Size(100, 21);
            this.tsmiCustomer.Text = "宾客登记（&C）";
            this.tsmiCustomer.Click += new System.EventHandler(this.tsmiCustomer_Click);
            // 
            // tsmiCheckIn
            // 
            this.tsmiCheckIn.Name = "tsmiCheckIn";
            this.tsmiCheckIn.Size = new System.Drawing.Size(158, 22);
            this.tsmiCheckIn.Text = "宾客登记（&R）";
            this.tsmiCheckIn.Click += new System.EventHandler(this.tsmiCheckIn_Click_1);
            // 
            // tsmiBookRoom
            // 
            this.tsmiBookRoom.Name = "tsmiBookRoom";
            this.tsmiBookRoom.Size = new System.Drawing.Size(158, 22);
            this.tsmiBookRoom.Text = "宾客预定（&B）";
            this.tsmiBookRoom.Click += new System.EventHandler(this.tsmiBookRoom_Click);
            // 
            // tsmiCancelReservation
            // 
            this.tsmiCancelReservation.Name = "tsmiCancelReservation";
            this.tsmiCancelReservation.Size = new System.Drawing.Size(158, 22);
            this.tsmiCancelReservation.Text = "取消预定（&N）";
            this.tsmiCancelReservation.Click += new System.EventHandler(this.tsmiCancelReservation_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(158, 22);
            this.tsmiExit.Text = "退出系统（&X）";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiMoney
            // 
            this.tsmiMoney.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCheckOut,
            this.tsmiPayDeposit});
            this.tsmiMoney.Name = "tsmiMoney";
            this.tsmiMoney.Size = new System.Drawing.Size(83, 21);
            this.tsmiMoney.Text = "收银结算(&P)";
            // 
            // tsmiCheckOut
            // 
            this.tsmiCheckOut.Name = "tsmiCheckOut";
            this.tsmiCheckOut.Size = new System.Drawing.Size(158, 22);
            this.tsmiCheckOut.Text = "退房结算（&O）";
            this.tsmiCheckOut.Click += new System.EventHandler(this.tsmiCheckOut_Click);
            // 
            // tsmiPayDeposit
            // 
            this.tsmiPayDeposit.Name = "tsmiPayDeposit";
            this.tsmiPayDeposit.Size = new System.Drawing.Size(158, 22);
            this.tsmiPayDeposit.Text = "补交押金（&D）";
            this.tsmiPayDeposit.Click += new System.EventHandler(this.tsmiPayDeposit_Click);
            // 
            // tsmiSearch
            // 
            this.tsmiSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRoomSearch,
            this.tsmiCustomerSearch,
            this.tsmiBookSearch});
            this.tsmiSearch.Name = "tsmiSearch";
            this.tsmiSearch.Size = new System.Drawing.Size(96, 21);
            this.tsmiSearch.Text = "信息查询（&I）";
            // 
            // tsmiRoomSearch
            // 
            this.tsmiRoomSearch.Name = "tsmiRoomSearch";
            this.tsmiRoomSearch.Size = new System.Drawing.Size(156, 22);
            this.tsmiRoomSearch.Text = "房态查询（&R）";
            this.tsmiRoomSearch.Click += new System.EventHandler(this.tsmiRoomSearch_Click);
            // 
            // tsmiCustomerSearch
            // 
            this.tsmiCustomerSearch.Name = "tsmiCustomerSearch";
            this.tsmiCustomerSearch.Size = new System.Drawing.Size(156, 22);
            this.tsmiCustomerSearch.Text = "宾客查询（&C）";
            this.tsmiCustomerSearch.Click += new System.EventHandler(this.tsmiCustomerSearch_Click);
            // 
            // tsmiBookSearch
            // 
            this.tsmiBookSearch.Name = "tsmiBookSearch";
            this.tsmiBookSearch.Size = new System.Drawing.Size(156, 22);
            this.tsmiBookSearch.Text = "预订查询（&B）";
            this.tsmiBookSearch.Click += new System.EventHandler(this.tsmiBookSearch_Click);
            // 
            // tsmiRoom
            // 
            this.tsmiRoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddRoom,
            this.tsmiRoomManage});
            this.tsmiRoom.Name = "tsmiRoom";
            this.tsmiRoom.Size = new System.Drawing.Size(100, 21);
            this.tsmiRoom.Text = "宾客管理（&R）";
            // 
            // tsmiAddRoom
            // 
            this.tsmiAddRoom.Name = "tsmiAddRoom";
            this.tsmiAddRoom.Size = new System.Drawing.Size(160, 22);
            this.tsmiAddRoom.Text = "客房添加（&A）";
            this.tsmiAddRoom.Click += new System.EventHandler(this.tsmiAddRoom_Click);
            // 
            // tsmiRoomManage
            // 
            this.tsmiRoomManage.Name = "tsmiRoomManage";
            this.tsmiRoomManage.Size = new System.Drawing.Size(160, 22);
            this.tsmiRoomManage.Text = "客房管理（&M）";
            this.tsmiRoomManage.Click += new System.EventHandler(this.tsmiRoomManage_Click);
            // 
            // tsmiUser
            // 
            this.tsmiUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddUser,
            this.tsmiUserManage});
            this.tsmiUser.Name = "tsmiUser";
            this.tsmiUser.Size = new System.Drawing.Size(99, 21);
            this.tsmiUser.Text = "用户管理（&S）";
            // 
            // tsmiAddUser
            // 
            this.tsmiAddUser.Name = "tsmiAddUser";
            this.tsmiAddUser.Size = new System.Drawing.Size(160, 22);
            this.tsmiAddUser.Text = "添加用户（&A）";
            this.tsmiAddUser.Click += new System.EventHandler(this.tsmiAddUser_Click);
            // 
            // tsmiUserManage
            // 
            this.tsmiUserManage.Name = "tsmiUserManage";
            this.tsmiUserManage.Size = new System.Drawing.Size(160, 22);
            this.tsmiUserManage.Text = "管理用户（&M）";
            this.tsmiUserManage.Click += new System.EventHandler(this.tsmiUserManage_Click);
            // 
            // tsHotel
            // 
            this.tsHotel.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.tsHotel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnCheckIn,
            this.tsbtnCheckOut,
            this.tsbtnBookRoom,
            this.tsbtnRoomSearch,
            this.tsbtnUser});
            this.tsHotel.Location = new System.Drawing.Point(0, 25);
            this.tsHotel.Name = "tsHotel";
            this.tsHotel.Size = new System.Drawing.Size(1008, 58);
            this.tsHotel.TabIndex = 3;
            this.tsHotel.Text = "toolStrip1";
            // 
            // tsbtnCheckIn
            // 
            this.tsbtnCheckIn.AutoSize = false;
            this.tsbtnCheckIn.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCheckIn.Image")));
            this.tsbtnCheckIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCheckIn.Name = "tsbtnCheckIn";
            this.tsbtnCheckIn.Size = new System.Drawing.Size(53, 55);
            this.tsbtnCheckIn.Text = "宾客登记";
            this.tsbtnCheckIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnCheckIn.Click += new System.EventHandler(this.tsbtnCheckIn_Click);
            // 
            // tsbtnCheckOut
            // 
            this.tsbtnCheckOut.AutoSize = false;
            this.tsbtnCheckOut.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCheckOut.Image")));
            this.tsbtnCheckOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCheckOut.Name = "tsbtnCheckOut";
            this.tsbtnCheckOut.Size = new System.Drawing.Size(53, 55);
            this.tsbtnCheckOut.Text = "退房结算";
            this.tsbtnCheckOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnCheckOut.Click += new System.EventHandler(this.tsbtnCheckOut_Click);
            // 
            // tsbtnBookRoom
            // 
            this.tsbtnBookRoom.AutoSize = false;
            this.tsbtnBookRoom.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnBookRoom.Image")));
            this.tsbtnBookRoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnBookRoom.Name = "tsbtnBookRoom";
            this.tsbtnBookRoom.Size = new System.Drawing.Size(53, 55);
            this.tsbtnBookRoom.Text = "宾客预定";
            this.tsbtnBookRoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnBookRoom.Click += new System.EventHandler(this.tsbtnBookRoom_Click);
            // 
            // tsbtnRoomSearch
            // 
            this.tsbtnRoomSearch.AutoSize = false;
            this.tsbtnRoomSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRoomSearch.Image")));
            this.tsbtnRoomSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRoomSearch.Name = "tsbtnRoomSearch";
            this.tsbtnRoomSearch.Size = new System.Drawing.Size(53, 55);
            this.tsbtnRoomSearch.Text = "房态查询";
            this.tsbtnRoomSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnRoomSearch.Click += new System.EventHandler(this.tsbtnRoomSearch_Click);
            // 
            // tsbtnUser
            // 
            this.tsbtnUser.AutoSize = false;
            this.tsbtnUser.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUser.Image")));
            this.tsbtnUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUser.Name = "tsbtnUser";
            this.tsbtnUser.Size = new System.Drawing.Size(53, 55);
            this.tsbtnUser.Text = "用户管理";
            this.tsbtnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnUser.Click += new System.EventHandler(this.tsbtnUser_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 708);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(152, 17);
            this.toolStripStatusLabel1.Text = "欢迎进入酒店客房管理系统";
            // 
            // HOTElManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HoteManage.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsHotel);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HOTElManage";
            this.Text = "旅店客房管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tsHotel.ResumeLayout(false);
            this.tsHotel.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCustomer;
        private System.Windows.Forms.ToolStripMenuItem tsmiCheckIn;
        private System.Windows.Forms.ToolStripMenuItem tsmiBookRoom;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancelReservation;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoney;
        private System.Windows.Forms.ToolStripMenuItem tsmiCheckOut;
        private System.Windows.Forms.ToolStripMenuItem tsmiPayDeposit;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiRoomSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiCustomerSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiBookSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiRoom;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddRoom;
        private System.Windows.Forms.ToolStripMenuItem tsmiRoomManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiUserManage;
        private System.Windows.Forms.ToolStrip tsHotel;
        private System.Windows.Forms.ToolStripButton tsbtnCheckIn;
        private System.Windows.Forms.ToolStripButton tsbtnCheckOut;
        private System.Windows.Forms.ToolStripButton tsbtnBookRoom;
        private System.Windows.Forms.ToolStripButton tsbtnRoomSearch;
        private System.Windows.Forms.ToolStripButton tsbtnUser;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}