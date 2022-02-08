using System.Windows.Forms;

namespace CnBlogs.Youzai.ScreenKeyboard {
    partial class ScreenKeyboard {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing) {
                foreach (Control ctrl in this.Controls) {
                    KeyboardButton button = ctrl as KeyboardButton;
                    if (button != null) {
                        button.Click -= ButtonOnClick;
                    }
                }

                HookEvents(false);
                this.hook.Stop();
                this.hook = null;

                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenKeyboard));
            this.btnRA = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnNUM3 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnNUMENT = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnNUM6 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnPDN = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnNUMPlus = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnNUM9 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnPUP = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnNUMMinus = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnMultiply = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnBRK = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnUP = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnDN = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnLA = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnNUMDot = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnNUM2 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnNUM0 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnNUM5 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnNUM1 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnEND = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnNUM4 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnDEL = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnNUM8 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnHM = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnNUM7 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnINS = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnNUMDivide = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnNLK = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnSLK = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnPSC = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnF12 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnF11 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnF10 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnF9 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnF8 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnF7 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnF6 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnF5 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnF4 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnF3 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnF2 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnF1 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnPath = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnEqual = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnLCTRL = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnLSHFT = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnLOCK = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnTAB = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnBKSP = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnRSHFT = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnENT = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnRBracket = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnMinus = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnFullStop = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnL = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnO = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btn8 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnMU = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnN = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnH = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnY = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnSpace = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnC = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnD = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnE = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btn5 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnQute = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnLBracket = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btn2 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnDivide = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnSem = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnP = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btn0 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnComma = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnK = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnI = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btn9 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnRCTRL = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnM = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnJ = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnU = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btn7 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnRW = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnB = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnG = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnRALT = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnV = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnT = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnF = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnLALT = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btn6 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnX = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnR = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnS = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnLW = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btn4 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnZ = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnW = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnA = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btn3 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnQ = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btn1 = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnWave = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.btnESC = new CnBlogs.Youzai.ScreenKeyboard.KeyboardButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lightCapsLock = new CnBlogs.Youzai.ScreenKeyboard.KeyboardLight();
            this.lightNumLock = new CnBlogs.Youzai.ScreenKeyboard.KeyboardLight();
            this.lightScrollLock = new CnBlogs.Youzai.ScreenKeyboard.KeyboardLight();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRA
            // 
            this.btnRA.AntiAlias = true;
            this.btnRA.BackColor = System.Drawing.SystemColors.Control;
            this.btnRA.Checked = false;
            this.btnRA.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnRA.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnRA.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnRA.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRA.Location = new System.Drawing.Point(604, 187);
            this.btnRA.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnRA.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnRA.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnRA.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnRA.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnRA.Name = "btnRA";
            this.btnRA.ShowFocusRectangle = false;
            this.btnRA.Size = new System.Drawing.Size(35, 30);
            this.btnRA.TabIndex = 110;
            this.btnRA.TabStop = false;
            this.btnRA.Text = "→";
            this.btnRA.UseCompatibleTextRendering = true;
            this.btnRA.UseMnemonic = false;
            this.btnRA.UseVisualStyleBackColor = false;
            this.btnRA.VKCode = ((short)(0));
            // 
            // btnNUM3
            // 
            this.btnNUM3.AntiAlias = true;
            this.btnNUM3.BackColor = System.Drawing.SystemColors.Control;
            this.btnNUM3.Checked = false;
            this.btnNUM3.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnNUM3.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnNUM3.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnNUM3.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNUM3.Location = new System.Drawing.Point(718, 157);
            this.btnNUM3.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnNUM3.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnNUM3.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnNUM3.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnNUM3.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnNUM3.Name = "btnNUM3";
            this.btnNUM3.ShowFocusRectangle = false;
            this.btnNUM3.Size = new System.Drawing.Size(35, 30);
            this.btnNUM3.TabIndex = 98;
            this.btnNUM3.TabStop = false;
            this.btnNUM3.Text = "3";
            this.btnNUM3.UseCompatibleTextRendering = true;
            this.btnNUM3.UseMnemonic = false;
            this.btnNUM3.UseVisualStyleBackColor = false;
            this.btnNUM3.VKCode = ((short)(0));
            // 
            // btnNUMENT
            // 
            this.btnNUMENT.AntiAlias = true;
            this.btnNUMENT.BackColor = System.Drawing.SystemColors.Control;
            this.btnNUMENT.Checked = false;
            this.btnNUMENT.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnNUMENT.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnNUMENT.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnNUMENT.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNUMENT.Location = new System.Drawing.Point(753, 157);
            this.btnNUMENT.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnNUMENT.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnNUMENT.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnNUMENT.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnNUMENT.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnNUMENT.Name = "btnNUMENT";
            this.btnNUMENT.ShowFocusRectangle = false;
            this.btnNUMENT.Size = new System.Drawing.Size(35, 60);
            this.btnNUMENT.TabIndex = 99;
            this.btnNUMENT.TabStop = false;
            this.btnNUMENT.Text = "ent";
            this.btnNUMENT.UseCompatibleTextRendering = true;
            this.btnNUMENT.UseMnemonic = false;
            this.btnNUMENT.UseVisualStyleBackColor = false;
            this.btnNUMENT.VKCode = ((short)(0));
            // 
            // btnNUM6
            // 
            this.btnNUM6.AntiAlias = true;
            this.btnNUM6.BackColor = System.Drawing.SystemColors.Control;
            this.btnNUM6.Checked = false;
            this.btnNUM6.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnNUM6.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnNUM6.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnNUM6.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNUM6.Location = new System.Drawing.Point(718, 127);
            this.btnNUM6.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnNUM6.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnNUM6.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnNUM6.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnNUM6.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnNUM6.Name = "btnNUM6";
            this.btnNUM6.ShowFocusRectangle = false;
            this.btnNUM6.Size = new System.Drawing.Size(35, 30);
            this.btnNUM6.TabIndex = 82;
            this.btnNUM6.TabStop = false;
            this.btnNUM6.Text = "6";
            this.btnNUM6.UseCompatibleTextRendering = true;
            this.btnNUM6.UseMnemonic = false;
            this.btnNUM6.UseVisualStyleBackColor = false;
            this.btnNUM6.VKCode = ((short)(0));
            // 
            // btnPDN
            // 
            this.btnPDN.AntiAlias = true;
            this.btnPDN.BackColor = System.Drawing.SystemColors.Control;
            this.btnPDN.Checked = false;
            this.btnPDN.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnPDN.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnPDN.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnPDN.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDN.Location = new System.Drawing.Point(604, 97);
            this.btnPDN.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnPDN.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnPDN.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnPDN.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnPDN.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnPDN.Name = "btnPDN";
            this.btnPDN.ShowFocusRectangle = false;
            this.btnPDN.Size = new System.Drawing.Size(35, 30);
            this.btnPDN.TabIndex = 62;
            this.btnPDN.TabStop = false;
            this.btnPDN.Text = "pdn";
            this.btnPDN.UseCompatibleTextRendering = true;
            this.btnPDN.UseMnemonic = false;
            this.btnPDN.UseVisualStyleBackColor = false;
            this.btnPDN.VKCode = ((short)(0));
            // 
            // btnNUMPlus
            // 
            this.btnNUMPlus.AntiAlias = true;
            this.btnNUMPlus.BackColor = System.Drawing.SystemColors.Control;
            this.btnNUMPlus.Checked = false;
            this.btnNUMPlus.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnNUMPlus.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnNUMPlus.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnNUMPlus.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNUMPlus.Location = new System.Drawing.Point(753, 97);
            this.btnNUMPlus.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnNUMPlus.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnNUMPlus.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnNUMPlus.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnNUMPlus.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnNUMPlus.Name = "btnNUMPlus";
            this.btnNUMPlus.ShowFocusRectangle = false;
            this.btnNUMPlus.Size = new System.Drawing.Size(35, 60);
            this.btnNUMPlus.TabIndex = 66;
            this.btnNUMPlus.TabStop = false;
            this.btnNUMPlus.Text = "+";
            this.btnNUMPlus.UseCompatibleTextRendering = true;
            this.btnNUMPlus.UseMnemonic = false;
            this.btnNUMPlus.UseVisualStyleBackColor = false;
            this.btnNUMPlus.VKCode = ((short)(0));
            // 
            // btnNUM9
            // 
            this.btnNUM9.AntiAlias = true;
            this.btnNUM9.BackColor = System.Drawing.SystemColors.Control;
            this.btnNUM9.Checked = false;
            this.btnNUM9.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnNUM9.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnNUM9.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnNUM9.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNUM9.Location = new System.Drawing.Point(718, 97);
            this.btnNUM9.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnNUM9.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnNUM9.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnNUM9.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnNUM9.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnNUM9.Name = "btnNUM9";
            this.btnNUM9.ShowFocusRectangle = false;
            this.btnNUM9.Size = new System.Drawing.Size(35, 30);
            this.btnNUM9.TabIndex = 65;
            this.btnNUM9.TabStop = false;
            this.btnNUM9.Text = "9";
            this.btnNUM9.UseCompatibleTextRendering = true;
            this.btnNUM9.UseMnemonic = false;
            this.btnNUM9.UseVisualStyleBackColor = false;
            this.btnNUM9.VKCode = ((short)(0));
            // 
            // btnPUP
            // 
            this.btnPUP.AntiAlias = true;
            this.btnPUP.BackColor = System.Drawing.SystemColors.Control;
            this.btnPUP.Checked = false;
            this.btnPUP.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnPUP.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnPUP.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnPUP.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPUP.Location = new System.Drawing.Point(604, 67);
            this.btnPUP.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnPUP.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnPUP.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnPUP.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnPUP.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnPUP.Name = "btnPUP";
            this.btnPUP.ShowFocusRectangle = false;
            this.btnPUP.Size = new System.Drawing.Size(35, 30);
            this.btnPUP.TabIndex = 41;
            this.btnPUP.TabStop = false;
            this.btnPUP.Text = "pup";
            this.btnPUP.UseCompatibleTextRendering = true;
            this.btnPUP.UseMnemonic = false;
            this.btnPUP.UseVisualStyleBackColor = false;
            this.btnPUP.VKCode = ((short)(0));
            // 
            // btnNUMMinus
            // 
            this.btnNUMMinus.AntiAlias = true;
            this.btnNUMMinus.BackColor = System.Drawing.SystemColors.Control;
            this.btnNUMMinus.Checked = false;
            this.btnNUMMinus.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnNUMMinus.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnNUMMinus.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnNUMMinus.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNUMMinus.Location = new System.Drawing.Point(753, 67);
            this.btnNUMMinus.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnNUMMinus.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnNUMMinus.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnNUMMinus.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnNUMMinus.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnNUMMinus.Name = "btnNUMMinus";
            this.btnNUMMinus.ShowFocusRectangle = false;
            this.btnNUMMinus.Size = new System.Drawing.Size(35, 30);
            this.btnNUMMinus.TabIndex = 45;
            this.btnNUMMinus.TabStop = false;
            this.btnNUMMinus.Text = "-";
            this.btnNUMMinus.UseCompatibleTextRendering = true;
            this.btnNUMMinus.UseMnemonic = false;
            this.btnNUMMinus.UseVisualStyleBackColor = false;
            this.btnNUMMinus.VKCode = ((short)(0));
            // 
            // btnMultiply
            // 
            this.btnMultiply.AntiAlias = true;
            this.btnMultiply.BackColor = System.Drawing.SystemColors.Control;
            this.btnMultiply.Checked = false;
            this.btnMultiply.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnMultiply.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnMultiply.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnMultiply.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiply.Location = new System.Drawing.Point(718, 67);
            this.btnMultiply.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnMultiply.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnMultiply.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnMultiply.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnMultiply.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.ShowFocusRectangle = false;
            this.btnMultiply.Size = new System.Drawing.Size(35, 30);
            this.btnMultiply.TabIndex = 44;
            this.btnMultiply.TabStop = false;
            this.btnMultiply.Text = "*";
            this.btnMultiply.UseCompatibleTextRendering = true;
            this.btnMultiply.UseMnemonic = false;
            this.btnMultiply.UseVisualStyleBackColor = false;
            this.btnMultiply.VKCode = ((short)(0));
            // 
            // btnBRK
            // 
            this.btnBRK.AntiAlias = true;
            this.btnBRK.BackColor = System.Drawing.SystemColors.Control;
            this.btnBRK.Checked = false;
            this.btnBRK.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnBRK.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnBRK.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnBRK.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBRK.Location = new System.Drawing.Point(604, 37);
            this.btnBRK.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnBRK.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnBRK.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnBRK.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnBRK.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnBRK.Name = "btnBRK";
            this.btnBRK.ShowFocusRectangle = false;
            this.btnBRK.Size = new System.Drawing.Size(35, 30);
            this.btnBRK.TabIndex = 21;
            this.btnBRK.TabStop = false;
            this.btnBRK.Text = "brk";
            this.btnBRK.UseCompatibleTextRendering = true;
            this.btnBRK.UseMnemonic = false;
            this.btnBRK.UseVisualStyleBackColor = false;
            this.btnBRK.VKCode = ((short)(0));
            // 
            // btnUP
            // 
            this.btnUP.AntiAlias = true;
            this.btnUP.BackColor = System.Drawing.SystemColors.Control;
            this.btnUP.Checked = false;
            this.btnUP.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnUP.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnUP.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnUP.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUP.Location = new System.Drawing.Point(569, 157);
            this.btnUP.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnUP.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnUP.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnUP.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnUP.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnUP.Name = "btnUP";
            this.btnUP.ShowFocusRectangle = false;
            this.btnUP.Size = new System.Drawing.Size(35, 30);
            this.btnUP.TabIndex = 95;
            this.btnUP.TabStop = false;
            this.btnUP.Text = "↑";
            this.btnUP.UseCompatibleTextRendering = true;
            this.btnUP.UseMnemonic = false;
            this.btnUP.UseVisualStyleBackColor = false;
            this.btnUP.VKCode = ((short)(0));
            // 
            // btnDN
            // 
            this.btnDN.AntiAlias = true;
            this.btnDN.BackColor = System.Drawing.SystemColors.Control;
            this.btnDN.Checked = false;
            this.btnDN.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnDN.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnDN.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnDN.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDN.Location = new System.Drawing.Point(569, 187);
            this.btnDN.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnDN.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnDN.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnDN.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnDN.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnDN.Name = "btnDN";
            this.btnDN.ShowFocusRectangle = false;
            this.btnDN.Size = new System.Drawing.Size(35, 30);
            this.btnDN.TabIndex = 109;
            this.btnDN.TabStop = false;
            this.btnDN.Text = "↓";
            this.btnDN.UseCompatibleTextRendering = true;
            this.btnDN.UseMnemonic = false;
            this.btnDN.UseVisualStyleBackColor = false;
            this.btnDN.VKCode = ((short)(0));
            // 
            // btnLA
            // 
            this.btnLA.AntiAlias = true;
            this.btnLA.BackColor = System.Drawing.SystemColors.Control;
            this.btnLA.Checked = false;
            this.btnLA.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnLA.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnLA.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnLA.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLA.Location = new System.Drawing.Point(534, 187);
            this.btnLA.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnLA.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnLA.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnLA.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnLA.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnLA.Name = "btnLA";
            this.btnLA.ShowFocusRectangle = false;
            this.btnLA.Size = new System.Drawing.Size(35, 30);
            this.btnLA.TabIndex = 108;
            this.btnLA.TabStop = false;
            this.btnLA.Text = "←";
            this.btnLA.UseCompatibleTextRendering = true;
            this.btnLA.UseMnemonic = false;
            this.btnLA.UseVisualStyleBackColor = false;
            this.btnLA.VKCode = ((short)(0));
            // 
            // btnNUMDot
            // 
            this.btnNUMDot.AntiAlias = true;
            this.btnNUMDot.BackColor = System.Drawing.SystemColors.Control;
            this.btnNUMDot.Checked = false;
            this.btnNUMDot.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnNUMDot.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnNUMDot.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnNUMDot.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNUMDot.Location = new System.Drawing.Point(718, 187);
            this.btnNUMDot.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnNUMDot.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnNUMDot.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnNUMDot.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnNUMDot.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnNUMDot.Name = "btnNUMDot";
            this.btnNUMDot.ShowFocusRectangle = false;
            this.btnNUMDot.Size = new System.Drawing.Size(35, 30);
            this.btnNUMDot.TabIndex = 112;
            this.btnNUMDot.TabStop = false;
            this.btnNUMDot.Text = ".";
            this.btnNUMDot.UseCompatibleTextRendering = true;
            this.btnNUMDot.UseMnemonic = false;
            this.btnNUMDot.UseVisualStyleBackColor = false;
            this.btnNUMDot.VKCode = ((short)(0));
            // 
            // btnNUM2
            // 
            this.btnNUM2.AntiAlias = true;
            this.btnNUM2.BackColor = System.Drawing.SystemColors.Control;
            this.btnNUM2.Checked = false;
            this.btnNUM2.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnNUM2.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnNUM2.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnNUM2.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNUM2.Location = new System.Drawing.Point(683, 157);
            this.btnNUM2.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnNUM2.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnNUM2.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnNUM2.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnNUM2.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnNUM2.Name = "btnNUM2";
            this.btnNUM2.ShowFocusRectangle = false;
            this.btnNUM2.Size = new System.Drawing.Size(35, 30);
            this.btnNUM2.TabIndex = 97;
            this.btnNUM2.TabStop = false;
            this.btnNUM2.Text = "2";
            this.btnNUM2.UseCompatibleTextRendering = true;
            this.btnNUM2.UseMnemonic = false;
            this.btnNUM2.UseVisualStyleBackColor = false;
            this.btnNUM2.VKCode = ((short)(0));
            // 
            // btnNUM0
            // 
            this.btnNUM0.AntiAlias = true;
            this.btnNUM0.BackColor = System.Drawing.SystemColors.Control;
            this.btnNUM0.Checked = false;
            this.btnNUM0.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnNUM0.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnNUM0.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnNUM0.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNUM0.Location = new System.Drawing.Point(648, 187);
            this.btnNUM0.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnNUM0.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnNUM0.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnNUM0.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnNUM0.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnNUM0.Name = "btnNUM0";
            this.btnNUM0.ShowFocusRectangle = false;
            this.btnNUM0.Size = new System.Drawing.Size(70, 30);
            this.btnNUM0.TabIndex = 111;
            this.btnNUM0.TabStop = false;
            this.btnNUM0.Text = "0";
            this.btnNUM0.UseCompatibleTextRendering = true;
            this.btnNUM0.UseMnemonic = false;
            this.btnNUM0.UseVisualStyleBackColor = false;
            this.btnNUM0.VKCode = ((short)(0));
            // 
            // btnNUM5
            // 
            this.btnNUM5.AntiAlias = true;
            this.btnNUM5.BackColor = System.Drawing.SystemColors.Control;
            this.btnNUM5.Checked = false;
            this.btnNUM5.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnNUM5.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnNUM5.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnNUM5.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNUM5.Location = new System.Drawing.Point(683, 127);
            this.btnNUM5.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnNUM5.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnNUM5.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnNUM5.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnNUM5.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnNUM5.Name = "btnNUM5";
            this.btnNUM5.ShowFocusRectangle = false;
            this.btnNUM5.Size = new System.Drawing.Size(35, 30);
            this.btnNUM5.TabIndex = 81;
            this.btnNUM5.TabStop = false;
            this.btnNUM5.Text = "5";
            this.btnNUM5.UseCompatibleTextRendering = true;
            this.btnNUM5.UseMnemonic = false;
            this.btnNUM5.UseVisualStyleBackColor = false;
            this.btnNUM5.VKCode = ((short)(0));
            // 
            // btnNUM1
            // 
            this.btnNUM1.AntiAlias = true;
            this.btnNUM1.BackColor = System.Drawing.SystemColors.Control;
            this.btnNUM1.Checked = false;
            this.btnNUM1.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnNUM1.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnNUM1.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnNUM1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNUM1.Location = new System.Drawing.Point(648, 157);
            this.btnNUM1.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnNUM1.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnNUM1.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnNUM1.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnNUM1.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnNUM1.Name = "btnNUM1";
            this.btnNUM1.ShowFocusRectangle = false;
            this.btnNUM1.Size = new System.Drawing.Size(35, 30);
            this.btnNUM1.TabIndex = 96;
            this.btnNUM1.TabStop = false;
            this.btnNUM1.Text = "1";
            this.btnNUM1.UseCompatibleTextRendering = true;
            this.btnNUM1.UseMnemonic = false;
            this.btnNUM1.UseVisualStyleBackColor = false;
            this.btnNUM1.VKCode = ((short)(0));
            // 
            // btnEND
            // 
            this.btnEND.AntiAlias = true;
            this.btnEND.BackColor = System.Drawing.SystemColors.Control;
            this.btnEND.Checked = false;
            this.btnEND.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnEND.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnEND.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnEND.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEND.Location = new System.Drawing.Point(569, 97);
            this.btnEND.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnEND.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnEND.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnEND.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnEND.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnEND.Name = "btnEND";
            this.btnEND.ShowFocusRectangle = false;
            this.btnEND.Size = new System.Drawing.Size(35, 30);
            this.btnEND.TabIndex = 61;
            this.btnEND.TabStop = false;
            this.btnEND.Text = "end";
            this.btnEND.UseCompatibleTextRendering = true;
            this.btnEND.UseMnemonic = false;
            this.btnEND.UseVisualStyleBackColor = false;
            this.btnEND.VKCode = ((short)(0));
            // 
            // btnNUM4
            // 
            this.btnNUM4.AntiAlias = true;
            this.btnNUM4.BackColor = System.Drawing.SystemColors.Control;
            this.btnNUM4.Checked = false;
            this.btnNUM4.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnNUM4.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnNUM4.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnNUM4.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNUM4.Location = new System.Drawing.Point(648, 127);
            this.btnNUM4.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnNUM4.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnNUM4.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnNUM4.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnNUM4.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnNUM4.Name = "btnNUM4";
            this.btnNUM4.ShowFocusRectangle = false;
            this.btnNUM4.Size = new System.Drawing.Size(35, 30);
            this.btnNUM4.TabIndex = 80;
            this.btnNUM4.TabStop = false;
            this.btnNUM4.Text = "4";
            this.btnNUM4.UseCompatibleTextRendering = true;
            this.btnNUM4.UseMnemonic = false;
            this.btnNUM4.UseVisualStyleBackColor = false;
            this.btnNUM4.VKCode = ((short)(0));
            // 
            // btnDEL
            // 
            this.btnDEL.AntiAlias = true;
            this.btnDEL.BackColor = System.Drawing.SystemColors.Control;
            this.btnDEL.Checked = false;
            this.btnDEL.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnDEL.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnDEL.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnDEL.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDEL.Location = new System.Drawing.Point(534, 97);
            this.btnDEL.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnDEL.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnDEL.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnDEL.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnDEL.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnDEL.Name = "btnDEL";
            this.btnDEL.ShowFocusRectangle = false;
            this.btnDEL.Size = new System.Drawing.Size(35, 30);
            this.btnDEL.TabIndex = 60;
            this.btnDEL.TabStop = false;
            this.btnDEL.Text = "del";
            this.btnDEL.UseCompatibleTextRendering = true;
            this.btnDEL.UseMnemonic = false;
            this.btnDEL.UseVisualStyleBackColor = false;
            this.btnDEL.VKCode = ((short)(0));
            // 
            // btnNUM8
            // 
            this.btnNUM8.AntiAlias = true;
            this.btnNUM8.BackColor = System.Drawing.SystemColors.Control;
            this.btnNUM8.Checked = false;
            this.btnNUM8.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnNUM8.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnNUM8.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnNUM8.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNUM8.Location = new System.Drawing.Point(683, 97);
            this.btnNUM8.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnNUM8.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnNUM8.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnNUM8.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnNUM8.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnNUM8.Name = "btnNUM8";
            this.btnNUM8.ShowFocusRectangle = false;
            this.btnNUM8.Size = new System.Drawing.Size(35, 30);
            this.btnNUM8.TabIndex = 64;
            this.btnNUM8.TabStop = false;
            this.btnNUM8.Text = "8";
            this.btnNUM8.UseCompatibleTextRendering = true;
            this.btnNUM8.UseMnemonic = false;
            this.btnNUM8.UseVisualStyleBackColor = false;
            this.btnNUM8.VKCode = ((short)(0));
            // 
            // btnHM
            // 
            this.btnHM.AntiAlias = true;
            this.btnHM.BackColor = System.Drawing.SystemColors.Control;
            this.btnHM.Checked = false;
            this.btnHM.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnHM.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnHM.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnHM.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHM.Location = new System.Drawing.Point(569, 67);
            this.btnHM.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnHM.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnHM.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnHM.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnHM.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnHM.Name = "btnHM";
            this.btnHM.ShowFocusRectangle = false;
            this.btnHM.Size = new System.Drawing.Size(35, 30);
            this.btnHM.TabIndex = 40;
            this.btnHM.TabStop = false;
            this.btnHM.Text = "hm";
            this.btnHM.UseCompatibleTextRendering = true;
            this.btnHM.UseMnemonic = false;
            this.btnHM.UseVisualStyleBackColor = false;
            this.btnHM.VKCode = ((short)(0));
            // 
            // btnNUM7
            // 
            this.btnNUM7.AntiAlias = true;
            this.btnNUM7.BackColor = System.Drawing.SystemColors.Control;
            this.btnNUM7.Checked = false;
            this.btnNUM7.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnNUM7.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnNUM7.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnNUM7.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNUM7.Location = new System.Drawing.Point(648, 97);
            this.btnNUM7.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnNUM7.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnNUM7.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnNUM7.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnNUM7.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnNUM7.Name = "btnNUM7";
            this.btnNUM7.ShowFocusRectangle = false;
            this.btnNUM7.Size = new System.Drawing.Size(35, 30);
            this.btnNUM7.TabIndex = 63;
            this.btnNUM7.TabStop = false;
            this.btnNUM7.Text = "7";
            this.btnNUM7.UseCompatibleTextRendering = true;
            this.btnNUM7.UseMnemonic = false;
            this.btnNUM7.UseVisualStyleBackColor = false;
            this.btnNUM7.VKCode = ((short)(0));
            // 
            // btnINS
            // 
            this.btnINS.AntiAlias = true;
            this.btnINS.BackColor = System.Drawing.SystemColors.Control;
            this.btnINS.Checked = false;
            this.btnINS.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnINS.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnINS.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnINS.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnINS.Location = new System.Drawing.Point(534, 67);
            this.btnINS.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnINS.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnINS.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnINS.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnINS.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnINS.Name = "btnINS";
            this.btnINS.ShowFocusRectangle = false;
            this.btnINS.Size = new System.Drawing.Size(35, 30);
            this.btnINS.TabIndex = 39;
            this.btnINS.TabStop = false;
            this.btnINS.Text = "ins";
            this.btnINS.UseCompatibleTextRendering = true;
            this.btnINS.UseMnemonic = false;
            this.btnINS.UseVisualStyleBackColor = false;
            this.btnINS.VKCode = ((short)(0));
            // 
            // btnNUMDivide
            // 
            this.btnNUMDivide.AntiAlias = true;
            this.btnNUMDivide.BackColor = System.Drawing.SystemColors.Control;
            this.btnNUMDivide.Checked = false;
            this.btnNUMDivide.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnNUMDivide.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnNUMDivide.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnNUMDivide.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNUMDivide.Location = new System.Drawing.Point(683, 67);
            this.btnNUMDivide.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnNUMDivide.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnNUMDivide.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnNUMDivide.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnNUMDivide.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnNUMDivide.Name = "btnNUMDivide";
            this.btnNUMDivide.ShowFocusRectangle = false;
            this.btnNUMDivide.Size = new System.Drawing.Size(35, 30);
            this.btnNUMDivide.TabIndex = 43;
            this.btnNUMDivide.TabStop = false;
            this.btnNUMDivide.Text = "/";
            this.btnNUMDivide.UseCompatibleTextRendering = true;
            this.btnNUMDivide.UseMnemonic = false;
            this.btnNUMDivide.UseVisualStyleBackColor = false;
            this.btnNUMDivide.VKCode = ((short)(0));
            // 
            // btnNLK
            // 
            this.btnNLK.AntiAlias = true;
            this.btnNLK.BackColor = System.Drawing.SystemColors.Control;
            this.btnNLK.Checked = false;
            this.btnNLK.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnNLK.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnNLK.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnNLK.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNLK.Location = new System.Drawing.Point(648, 67);
            this.btnNLK.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnNLK.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnNLK.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnNLK.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnNLK.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnNLK.Name = "btnNLK";
            this.btnNLK.ShowFocusRectangle = false;
            this.btnNLK.Size = new System.Drawing.Size(35, 30);
            this.btnNLK.TabIndex = 42;
            this.btnNLK.TabStop = false;
            this.btnNLK.Text = "nlk";
            this.btnNLK.UseCompatibleTextRendering = true;
            this.btnNLK.UseMnemonic = false;
            this.btnNLK.UseVisualStyleBackColor = false;
            this.btnNLK.VKCode = ((short)(0));
            // 
            // btnSLK
            // 
            this.btnSLK.AntiAlias = true;
            this.btnSLK.BackColor = System.Drawing.SystemColors.Control;
            this.btnSLK.Checked = false;
            this.btnSLK.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnSLK.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnSLK.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnSLK.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSLK.Location = new System.Drawing.Point(569, 37);
            this.btnSLK.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnSLK.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnSLK.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnSLK.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnSLK.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnSLK.Name = "btnSLK";
            this.btnSLK.ShowFocusRectangle = false;
            this.btnSLK.Size = new System.Drawing.Size(35, 30);
            this.btnSLK.TabIndex = 20;
            this.btnSLK.TabStop = false;
            this.btnSLK.Text = "slk";
            this.btnSLK.UseCompatibleTextRendering = true;
            this.btnSLK.UseMnemonic = false;
            this.btnSLK.UseVisualStyleBackColor = false;
            this.btnSLK.VKCode = ((short)(0));
            // 
            // btnPSC
            // 
            this.btnPSC.AntiAlias = true;
            this.btnPSC.BackColor = System.Drawing.SystemColors.Control;
            this.btnPSC.Checked = false;
            this.btnPSC.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnPSC.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnPSC.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnPSC.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPSC.Location = new System.Drawing.Point(534, 37);
            this.btnPSC.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnPSC.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnPSC.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnPSC.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnPSC.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnPSC.Name = "btnPSC";
            this.btnPSC.ShowFocusRectangle = false;
            this.btnPSC.Size = new System.Drawing.Size(35, 30);
            this.btnPSC.TabIndex = 19;
            this.btnPSC.TabStop = false;
            this.btnPSC.Text = "psc";
            this.btnPSC.UseCompatibleTextRendering = true;
            this.btnPSC.UseMnemonic = false;
            this.btnPSC.UseVisualStyleBackColor = false;
            this.btnPSC.VKCode = ((short)(0));
            // 
            // btnF12
            // 
            this.btnF12.AntiAlias = true;
            this.btnF12.BackColor = System.Drawing.SystemColors.Control;
            this.btnF12.Checked = false;
            this.btnF12.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnF12.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnF12.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnF12.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF12.Location = new System.Drawing.Point(490, 37);
            this.btnF12.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnF12.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnF12.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnF12.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnF12.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnF12.Name = "btnF12";
            this.btnF12.ShowFocusRectangle = false;
            this.btnF12.Size = new System.Drawing.Size(35, 30);
            this.btnF12.TabIndex = 18;
            this.btnF12.TabStop = false;
            this.btnF12.Text = "F12";
            this.btnF12.UseCompatibleTextRendering = true;
            this.btnF12.UseMnemonic = false;
            this.btnF12.UseVisualStyleBackColor = false;
            this.btnF12.VKCode = ((short)(0));
            // 
            // btnF11
            // 
            this.btnF11.AntiAlias = true;
            this.btnF11.BackColor = System.Drawing.SystemColors.Control;
            this.btnF11.Checked = false;
            this.btnF11.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnF11.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnF11.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnF11.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF11.Location = new System.Drawing.Point(455, 37);
            this.btnF11.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnF11.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnF11.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnF11.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnF11.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnF11.Name = "btnF11";
            this.btnF11.ShowFocusRectangle = false;
            this.btnF11.Size = new System.Drawing.Size(35, 30);
            this.btnF11.TabIndex = 17;
            this.btnF11.TabStop = false;
            this.btnF11.Text = "F11";
            this.btnF11.UseCompatibleTextRendering = true;
            this.btnF11.UseMnemonic = false;
            this.btnF11.UseVisualStyleBackColor = false;
            this.btnF11.VKCode = ((short)(0));
            // 
            // btnF10
            // 
            this.btnF10.AntiAlias = true;
            this.btnF10.BackColor = System.Drawing.SystemColors.Control;
            this.btnF10.Checked = false;
            this.btnF10.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnF10.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnF10.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnF10.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF10.Location = new System.Drawing.Point(420, 37);
            this.btnF10.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnF10.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnF10.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnF10.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnF10.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnF10.Name = "btnF10";
            this.btnF10.ShowFocusRectangle = false;
            this.btnF10.Size = new System.Drawing.Size(35, 30);
            this.btnF10.TabIndex = 16;
            this.btnF10.TabStop = false;
            this.btnF10.Text = "F10";
            this.btnF10.UseCompatibleTextRendering = true;
            this.btnF10.UseMnemonic = false;
            this.btnF10.UseVisualStyleBackColor = false;
            this.btnF10.VKCode = ((short)(0));
            // 
            // btnF9
            // 
            this.btnF9.AntiAlias = true;
            this.btnF9.BackColor = System.Drawing.SystemColors.Control;
            this.btnF9.Checked = false;
            this.btnF9.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnF9.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnF9.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnF9.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF9.Location = new System.Drawing.Point(385, 37);
            this.btnF9.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnF9.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnF9.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnF9.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnF9.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnF9.Name = "btnF9";
            this.btnF9.ShowFocusRectangle = false;
            this.btnF9.Size = new System.Drawing.Size(35, 30);
            this.btnF9.TabIndex = 15;
            this.btnF9.TabStop = false;
            this.btnF9.Text = "F9";
            this.btnF9.UseCompatibleTextRendering = true;
            this.btnF9.UseMnemonic = false;
            this.btnF9.UseVisualStyleBackColor = false;
            this.btnF9.VKCode = ((short)(0));
            // 
            // btnF8
            // 
            this.btnF8.AntiAlias = true;
            this.btnF8.BackColor = System.Drawing.SystemColors.Control;
            this.btnF8.Checked = false;
            this.btnF8.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnF8.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnF8.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnF8.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF8.Location = new System.Drawing.Point(328, 37);
            this.btnF8.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnF8.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnF8.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnF8.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnF8.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnF8.Name = "btnF8";
            this.btnF8.ShowFocusRectangle = false;
            this.btnF8.Size = new System.Drawing.Size(35, 30);
            this.btnF8.TabIndex = 14;
            this.btnF8.TabStop = false;
            this.btnF8.Text = "F8";
            this.btnF8.UseCompatibleTextRendering = true;
            this.btnF8.UseMnemonic = false;
            this.btnF8.UseVisualStyleBackColor = false;
            this.btnF8.VKCode = ((short)(0));
            // 
            // btnF7
            // 
            this.btnF7.AntiAlias = true;
            this.btnF7.BackColor = System.Drawing.SystemColors.Control;
            this.btnF7.Checked = false;
            this.btnF7.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnF7.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnF7.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnF7.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF7.Location = new System.Drawing.Point(293, 37);
            this.btnF7.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnF7.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnF7.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnF7.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnF7.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnF7.Name = "btnF7";
            this.btnF7.ShowFocusRectangle = false;
            this.btnF7.Size = new System.Drawing.Size(35, 30);
            this.btnF7.TabIndex = 13;
            this.btnF7.TabStop = false;
            this.btnF7.Text = "F7";
            this.btnF7.UseCompatibleTextRendering = true;
            this.btnF7.UseMnemonic = false;
            this.btnF7.UseVisualStyleBackColor = false;
            this.btnF7.VKCode = ((short)(0));
            // 
            // btnF6
            // 
            this.btnF6.AntiAlias = true;
            this.btnF6.BackColor = System.Drawing.SystemColors.Control;
            this.btnF6.Checked = false;
            this.btnF6.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnF6.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnF6.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnF6.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF6.Location = new System.Drawing.Point(258, 37);
            this.btnF6.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnF6.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnF6.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnF6.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnF6.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnF6.Name = "btnF6";
            this.btnF6.ShowFocusRectangle = false;
            this.btnF6.Size = new System.Drawing.Size(35, 30);
            this.btnF6.TabIndex = 12;
            this.btnF6.TabStop = false;
            this.btnF6.Text = "F6";
            this.btnF6.UseCompatibleTextRendering = true;
            this.btnF6.UseMnemonic = false;
            this.btnF6.UseVisualStyleBackColor = false;
            this.btnF6.VKCode = ((short)(0));
            // 
            // btnF5
            // 
            this.btnF5.AntiAlias = true;
            this.btnF5.BackColor = System.Drawing.SystemColors.Control;
            this.btnF5.Checked = false;
            this.btnF5.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnF5.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnF5.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnF5.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF5.Location = new System.Drawing.Point(223, 37);
            this.btnF5.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnF5.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnF5.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnF5.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnF5.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnF5.Name = "btnF5";
            this.btnF5.ShowFocusRectangle = false;
            this.btnF5.Size = new System.Drawing.Size(35, 30);
            this.btnF5.TabIndex = 11;
            this.btnF5.TabStop = false;
            this.btnF5.Text = "F5";
            this.btnF5.UseCompatibleTextRendering = true;
            this.btnF5.UseMnemonic = false;
            this.btnF5.UseVisualStyleBackColor = false;
            this.btnF5.VKCode = ((short)(0));
            // 
            // btnF4
            // 
            this.btnF4.AntiAlias = true;
            this.btnF4.BackColor = System.Drawing.SystemColors.Control;
            this.btnF4.Checked = false;
            this.btnF4.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnF4.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnF4.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnF4.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF4.Location = new System.Drawing.Point(165, 37);
            this.btnF4.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnF4.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnF4.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnF4.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnF4.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnF4.Name = "btnF4";
            this.btnF4.ShowFocusRectangle = false;
            this.btnF4.Size = new System.Drawing.Size(35, 30);
            this.btnF4.TabIndex = 10;
            this.btnF4.TabStop = false;
            this.btnF4.Text = "F4";
            this.btnF4.UseCompatibleTextRendering = true;
            this.btnF4.UseMnemonic = false;
            this.btnF4.UseVisualStyleBackColor = false;
            this.btnF4.VKCode = ((short)(0));
            // 
            // btnF3
            // 
            this.btnF3.AntiAlias = true;
            this.btnF3.BackColor = System.Drawing.SystemColors.Control;
            this.btnF3.Checked = false;
            this.btnF3.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnF3.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnF3.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnF3.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF3.Location = new System.Drawing.Point(130, 37);
            this.btnF3.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnF3.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnF3.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnF3.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnF3.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnF3.Name = "btnF3";
            this.btnF3.ShowFocusRectangle = false;
            this.btnF3.Size = new System.Drawing.Size(35, 30);
            this.btnF3.TabIndex = 9;
            this.btnF3.TabStop = false;
            this.btnF3.Text = "F3";
            this.btnF3.UseCompatibleTextRendering = true;
            this.btnF3.UseMnemonic = false;
            this.btnF3.UseVisualStyleBackColor = false;
            this.btnF3.VKCode = ((short)(0));
            // 
            // btnF2
            // 
            this.btnF2.AntiAlias = true;
            this.btnF2.BackColor = System.Drawing.SystemColors.Control;
            this.btnF2.Checked = false;
            this.btnF2.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnF2.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnF2.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnF2.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF2.Location = new System.Drawing.Point(95, 37);
            this.btnF2.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnF2.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnF2.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnF2.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnF2.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnF2.Name = "btnF2";
            this.btnF2.ShowFocusRectangle = false;
            this.btnF2.Size = new System.Drawing.Size(35, 30);
            this.btnF2.TabIndex = 8;
            this.btnF2.TabStop = false;
            this.btnF2.Text = "F2";
            this.btnF2.UseCompatibleTextRendering = true;
            this.btnF2.UseMnemonic = false;
            this.btnF2.UseVisualStyleBackColor = false;
            this.btnF2.VKCode = ((short)(0));
            // 
            // btnF1
            // 
            this.btnF1.AntiAlias = true;
            this.btnF1.BackColor = System.Drawing.SystemColors.Control;
            this.btnF1.Checked = false;
            this.btnF1.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnF1.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnF1.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnF1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF1.Location = new System.Drawing.Point(60, 37);
            this.btnF1.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnF1.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnF1.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnF1.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnF1.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnF1.Name = "btnF1";
            this.btnF1.ShowFocusRectangle = false;
            this.btnF1.Size = new System.Drawing.Size(35, 30);
            this.btnF1.TabIndex = 7;
            this.btnF1.TabStop = false;
            this.btnF1.Text = "F1";
            this.btnF1.UseCompatibleTextRendering = true;
            this.btnF1.UseMnemonic = false;
            this.btnF1.UseVisualStyleBackColor = false;
            this.btnF1.VKCode = ((short)(0));
            // 
            // btnPath
            // 
            this.btnPath.AntiAlias = true;
            this.btnPath.BackColor = System.Drawing.SystemColors.Control;
            this.btnPath.Checked = false;
            this.btnPath.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnPath.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnPath.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnPath.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPath.Location = new System.Drawing.Point(474, 97);
            this.btnPath.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnPath.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnPath.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnPath.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnPath.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnPath.Name = "btnPath";
            this.btnPath.ShowFocusRectangle = false;
            this.btnPath.Size = new System.Drawing.Size(52, 30);
            this.btnPath.TabIndex = 59;
            this.btnPath.TabStop = false;
            this.btnPath.Text = "\\";
            this.btnPath.UseCompatibleTextRendering = true;
            this.btnPath.UseMnemonic = false;
            this.btnPath.UseVisualStyleBackColor = false;
            this.btnPath.VKCode = ((short)(0));
            // 
            // btnEqual
            // 
            this.btnEqual.AntiAlias = true;
            this.btnEqual.BackColor = System.Drawing.SystemColors.Control;
            this.btnEqual.Checked = false;
            this.btnEqual.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnEqual.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnEqual.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnEqual.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEqual.Location = new System.Drawing.Point(422, 67);
            this.btnEqual.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnEqual.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnEqual.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnEqual.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnEqual.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.ShowFocusRectangle = false;
            this.btnEqual.Size = new System.Drawing.Size(35, 30);
            this.btnEqual.TabIndex = 37;
            this.btnEqual.TabStop = false;
            this.btnEqual.Text = "=";
            this.btnEqual.UseCompatibleTextRendering = true;
            this.btnEqual.UseMnemonic = false;
            this.btnEqual.UseVisualStyleBackColor = false;
            this.btnEqual.VKCode = ((short)(0));
            // 
            // btnLCTRL
            // 
            this.btnLCTRL.AntiAlias = true;
            this.btnLCTRL.BackColor = System.Drawing.SystemColors.Control;
            this.btnLCTRL.Checked = false;
            this.btnLCTRL.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnLCTRL.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnLCTRL.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnLCTRL.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLCTRL.Location = new System.Drawing.Point(2, 187);
            this.btnLCTRL.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnLCTRL.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnLCTRL.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnLCTRL.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnLCTRL.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnLCTRL.Name = "btnLCTRL";
            this.btnLCTRL.ShowFocusRectangle = false;
            this.btnLCTRL.Size = new System.Drawing.Size(50, 30);
            this.btnLCTRL.TabIndex = 100;
            this.btnLCTRL.TabStop = false;
            this.btnLCTRL.Text = "ctrl";
            this.btnLCTRL.UseCompatibleTextRendering = true;
            this.btnLCTRL.UseMnemonic = false;
            this.btnLCTRL.UseVisualStyleBackColor = false;
            this.btnLCTRL.VKCode = ((short)(0));
            // 
            // btnLSHFT
            // 
            this.btnLSHFT.AntiAlias = true;
            this.btnLSHFT.BackColor = System.Drawing.SystemColors.Control;
            this.btnLSHFT.Checked = false;
            this.btnLSHFT.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnLSHFT.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnLSHFT.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnLSHFT.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLSHFT.Location = new System.Drawing.Point(2, 157);
            this.btnLSHFT.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnLSHFT.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnLSHFT.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnLSHFT.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnLSHFT.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnLSHFT.Name = "btnLSHFT";
            this.btnLSHFT.ShowFocusRectangle = false;
            this.btnLSHFT.Size = new System.Drawing.Size(86, 30);
            this.btnLSHFT.TabIndex = 83;
            this.btnLSHFT.TabStop = false;
            this.btnLSHFT.Text = "shft";
            this.btnLSHFT.UseCompatibleTextRendering = true;
            this.btnLSHFT.UseMnemonic = false;
            this.btnLSHFT.UseVisualStyleBackColor = false;
            this.btnLSHFT.VKCode = ((short)(0));
            // 
            // btnLOCK
            // 
            this.btnLOCK.AntiAlias = true;
            this.btnLOCK.BackColor = System.Drawing.SystemColors.Control;
            this.btnLOCK.Checked = false;
            this.btnLOCK.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnLOCK.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnLOCK.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnLOCK.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLOCK.Location = new System.Drawing.Point(2, 127);
            this.btnLOCK.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnLOCK.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnLOCK.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnLOCK.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnLOCK.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnLOCK.Name = "btnLOCK";
            this.btnLOCK.ShowFocusRectangle = false;
            this.btnLOCK.Size = new System.Drawing.Size(69, 30);
            this.btnLOCK.TabIndex = 67;
            this.btnLOCK.TabStop = false;
            this.btnLOCK.Text = "lock";
            this.btnLOCK.UseCompatibleTextRendering = true;
            this.btnLOCK.UseMnemonic = false;
            this.btnLOCK.UseVisualStyleBackColor = false;
            this.btnLOCK.VKCode = ((short)(0));
            // 
            // btnTAB
            // 
            this.btnTAB.AntiAlias = true;
            this.btnTAB.BackColor = System.Drawing.SystemColors.Control;
            this.btnTAB.Checked = false;
            this.btnTAB.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnTAB.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnTAB.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnTAB.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTAB.Location = new System.Drawing.Point(2, 97);
            this.btnTAB.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnTAB.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnTAB.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnTAB.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnTAB.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnTAB.Name = "btnTAB";
            this.btnTAB.ShowFocusRectangle = false;
            this.btnTAB.Size = new System.Drawing.Size(52, 30);
            this.btnTAB.TabIndex = 46;
            this.btnTAB.TabStop = false;
            this.btnTAB.Text = "tab";
            this.btnTAB.UseCompatibleTextRendering = true;
            this.btnTAB.UseMnemonic = false;
            this.btnTAB.UseVisualStyleBackColor = false;
            this.btnTAB.VKCode = ((short)(0));
            // 
            // btnBKSP
            // 
            this.btnBKSP.AntiAlias = true;
            this.btnBKSP.BackColor = System.Drawing.SystemColors.Control;
            this.btnBKSP.Checked = false;
            this.btnBKSP.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnBKSP.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnBKSP.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnBKSP.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBKSP.Location = new System.Drawing.Point(457, 67);
            this.btnBKSP.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnBKSP.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnBKSP.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnBKSP.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnBKSP.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnBKSP.Name = "btnBKSP";
            this.btnBKSP.ShowFocusRectangle = false;
            this.btnBKSP.Size = new System.Drawing.Size(68, 30);
            this.btnBKSP.TabIndex = 38;
            this.btnBKSP.TabStop = false;
            this.btnBKSP.Text = "bksp";
            this.btnBKSP.UseCompatibleTextRendering = true;
            this.btnBKSP.UseMnemonic = false;
            this.btnBKSP.UseVisualStyleBackColor = false;
            this.btnBKSP.VKCode = ((short)(0));
            // 
            // btnRSHFT
            // 
            this.btnRSHFT.AntiAlias = true;
            this.btnRSHFT.BackColor = System.Drawing.SystemColors.Control;
            this.btnRSHFT.Checked = false;
            this.btnRSHFT.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnRSHFT.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnRSHFT.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnRSHFT.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRSHFT.Location = new System.Drawing.Point(440, 157);
            this.btnRSHFT.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnRSHFT.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnRSHFT.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnRSHFT.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnRSHFT.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnRSHFT.Name = "btnRSHFT";
            this.btnRSHFT.ShowFocusRectangle = false;
            this.btnRSHFT.Size = new System.Drawing.Size(86, 30);
            this.btnRSHFT.TabIndex = 94;
            this.btnRSHFT.TabStop = false;
            this.btnRSHFT.Text = "shft";
            this.btnRSHFT.UseCompatibleTextRendering = true;
            this.btnRSHFT.UseMnemonic = false;
            this.btnRSHFT.UseVisualStyleBackColor = false;
            this.btnRSHFT.VKCode = ((short)(0));
            // 
            // btnENT
            // 
            this.btnENT.AntiAlias = true;
            this.btnENT.BackColor = System.Drawing.SystemColors.Control;
            this.btnENT.Checked = false;
            this.btnENT.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnENT.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnENT.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnENT.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnENT.Location = new System.Drawing.Point(457, 127);
            this.btnENT.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnENT.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnENT.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnENT.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnENT.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnENT.Name = "btnENT";
            this.btnENT.ShowFocusRectangle = false;
            this.btnENT.Size = new System.Drawing.Size(69, 30);
            this.btnENT.TabIndex = 79;
            this.btnENT.TabStop = false;
            this.btnENT.Text = "ent";
            this.btnENT.UseCompatibleTextRendering = true;
            this.btnENT.UseMnemonic = false;
            this.btnENT.UseVisualStyleBackColor = false;
            this.btnENT.VKCode = ((short)(0));
            // 
            // btnRBracket
            // 
            this.btnRBracket.AntiAlias = true;
            this.btnRBracket.BackColor = System.Drawing.SystemColors.Control;
            this.btnRBracket.Checked = false;
            this.btnRBracket.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnRBracket.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnRBracket.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnRBracket.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRBracket.Location = new System.Drawing.Point(439, 97);
            this.btnRBracket.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnRBracket.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnRBracket.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnRBracket.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnRBracket.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnRBracket.Name = "btnRBracket";
            this.btnRBracket.ShowFocusRectangle = false;
            this.btnRBracket.Size = new System.Drawing.Size(35, 30);
            this.btnRBracket.TabIndex = 58;
            this.btnRBracket.TabStop = false;
            this.btnRBracket.Text = "]";
            this.btnRBracket.UseCompatibleTextRendering = true;
            this.btnRBracket.UseMnemonic = false;
            this.btnRBracket.UseVisualStyleBackColor = false;
            this.btnRBracket.VKCode = ((short)(0));
            // 
            // btnMinus
            // 
            this.btnMinus.AntiAlias = true;
            this.btnMinus.BackColor = System.Drawing.SystemColors.Control;
            this.btnMinus.Checked = false;
            this.btnMinus.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnMinus.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnMinus.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnMinus.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinus.Location = new System.Drawing.Point(387, 67);
            this.btnMinus.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnMinus.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnMinus.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnMinus.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnMinus.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.ShowFocusRectangle = false;
            this.btnMinus.Size = new System.Drawing.Size(35, 30);
            this.btnMinus.TabIndex = 36;
            this.btnMinus.TabStop = false;
            this.btnMinus.Text = "-";
            this.btnMinus.UseCompatibleTextRendering = true;
            this.btnMinus.UseMnemonic = false;
            this.btnMinus.UseVisualStyleBackColor = false;
            this.btnMinus.VKCode = ((short)(0));
            // 
            // btnFullStop
            // 
            this.btnFullStop.AntiAlias = true;
            this.btnFullStop.BackColor = System.Drawing.SystemColors.Control;
            this.btnFullStop.Checked = false;
            this.btnFullStop.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnFullStop.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnFullStop.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnFullStop.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFullStop.Location = new System.Drawing.Point(369, 157);
            this.btnFullStop.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnFullStop.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnFullStop.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnFullStop.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnFullStop.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnFullStop.Name = "btnFullStop";
            this.btnFullStop.ShowFocusRectangle = false;
            this.btnFullStop.Size = new System.Drawing.Size(35, 30);
            this.btnFullStop.TabIndex = 92;
            this.btnFullStop.TabStop = false;
            this.btnFullStop.Text = ".";
            this.btnFullStop.UseCompatibleTextRendering = true;
            this.btnFullStop.UseMnemonic = false;
            this.btnFullStop.UseVisualStyleBackColor = false;
            this.btnFullStop.VKCode = ((short)(0));
            // 
            // btnL
            // 
            this.btnL.AntiAlias = true;
            this.btnL.BackColor = System.Drawing.SystemColors.Control;
            this.btnL.Checked = false;
            this.btnL.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnL.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnL.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnL.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnL.Location = new System.Drawing.Point(351, 127);
            this.btnL.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnL.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnL.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnL.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnL.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnL.Name = "btnL";
            this.btnL.ShowFocusRectangle = false;
            this.btnL.Size = new System.Drawing.Size(35, 30);
            this.btnL.TabIndex = 76;
            this.btnL.TabStop = false;
            this.btnL.Text = "l";
            this.btnL.UseCompatibleTextRendering = true;
            this.btnL.UseMnemonic = false;
            this.btnL.UseVisualStyleBackColor = false;
            this.btnL.VKCode = ((short)(0));
            // 
            // btnO
            // 
            this.btnO.AntiAlias = true;
            this.btnO.BackColor = System.Drawing.SystemColors.Control;
            this.btnO.Checked = false;
            this.btnO.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnO.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnO.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnO.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnO.Location = new System.Drawing.Point(334, 97);
            this.btnO.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnO.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnO.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnO.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnO.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnO.Name = "btnO";
            this.btnO.ShowFocusRectangle = false;
            this.btnO.Size = new System.Drawing.Size(35, 30);
            this.btnO.TabIndex = 55;
            this.btnO.TabStop = false;
            this.btnO.Text = "o";
            this.btnO.UseCompatibleTextRendering = true;
            this.btnO.UseMnemonic = false;
            this.btnO.UseVisualStyleBackColor = false;
            this.btnO.VKCode = ((short)(0));
            // 
            // btn8
            // 
            this.btn8.AntiAlias = true;
            this.btn8.BackColor = System.Drawing.SystemColors.Control;
            this.btn8.Checked = false;
            this.btn8.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btn8.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btn8.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btn8.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.Location = new System.Drawing.Point(282, 67);
            this.btn8.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btn8.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btn8.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btn8.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btn8.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btn8.Name = "btn8";
            this.btn8.ShowFocusRectangle = false;
            this.btn8.Size = new System.Drawing.Size(35, 30);
            this.btn8.TabIndex = 33;
            this.btn8.TabStop = false;
            this.btn8.Text = "8";
            this.btn8.UseCompatibleTextRendering = true;
            this.btn8.UseMnemonic = false;
            this.btn8.UseVisualStyleBackColor = false;
            this.btn8.VKCode = ((short)(0));
            // 
            // btnMU
            // 
            this.btnMU.AntiAlias = true;
            this.btnMU.BackColor = System.Drawing.SystemColors.Control;
            this.btnMU.Checked = false;
            this.btnMU.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnMU.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnMU.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnMU.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMU.Location = new System.Drawing.Point(441, 187);
            this.btnMU.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnMU.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnMU.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnMU.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnMU.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnMU.Name = "btnMU";
            this.btnMU.ShowFocusRectangle = false;
            this.btnMU.Size = new System.Drawing.Size(35, 30);
            this.btnMU.TabIndex = 106;
            this.btnMU.TabStop = false;
            this.btnMU.Text = "mu";
            this.btnMU.UseCompatibleTextRendering = true;
            this.btnMU.UseMnemonic = false;
            this.btnMU.UseVisualStyleBackColor = false;
            this.btnMU.VKCode = ((short)(0));
            // 
            // btnN
            // 
            this.btnN.AntiAlias = true;
            this.btnN.BackColor = System.Drawing.SystemColors.Control;
            this.btnN.Checked = false;
            this.btnN.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnN.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnN.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnN.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnN.Location = new System.Drawing.Point(264, 157);
            this.btnN.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnN.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnN.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnN.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnN.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnN.Name = "btnN";
            this.btnN.ShowFocusRectangle = false;
            this.btnN.Size = new System.Drawing.Size(35, 30);
            this.btnN.TabIndex = 89;
            this.btnN.TabStop = false;
            this.btnN.Text = "n";
            this.btnN.UseCompatibleTextRendering = true;
            this.btnN.UseMnemonic = false;
            this.btnN.UseVisualStyleBackColor = false;
            this.btnN.VKCode = ((short)(0));
            // 
            // btnH
            // 
            this.btnH.AntiAlias = true;
            this.btnH.BackColor = System.Drawing.SystemColors.Control;
            this.btnH.Checked = false;
            this.btnH.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnH.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnH.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnH.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnH.Location = new System.Drawing.Point(246, 127);
            this.btnH.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnH.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnH.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnH.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnH.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnH.Name = "btnH";
            this.btnH.ShowFocusRectangle = false;
            this.btnH.Size = new System.Drawing.Size(35, 30);
            this.btnH.TabIndex = 73;
            this.btnH.TabStop = false;
            this.btnH.Text = "h";
            this.btnH.UseCompatibleTextRendering = true;
            this.btnH.UseMnemonic = false;
            this.btnH.UseVisualStyleBackColor = false;
            this.btnH.VKCode = ((short)(0));
            // 
            // btnY
            // 
            this.btnY.AntiAlias = true;
            this.btnY.BackColor = System.Drawing.SystemColors.Control;
            this.btnY.Checked = false;
            this.btnY.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnY.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnY.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnY.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnY.Location = new System.Drawing.Point(229, 97);
            this.btnY.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnY.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnY.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnY.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnY.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnY.Name = "btnY";
            this.btnY.ShowFocusRectangle = false;
            this.btnY.Size = new System.Drawing.Size(35, 30);
            this.btnY.TabIndex = 52;
            this.btnY.TabStop = false;
            this.btnY.Text = "y";
            this.btnY.UseCompatibleTextRendering = true;
            this.btnY.UseMnemonic = false;
            this.btnY.UseVisualStyleBackColor = false;
            this.btnY.VKCode = ((short)(0));
            // 
            // btnSpace
            // 
            this.btnSpace.AntiAlias = true;
            this.btnSpace.BackColor = System.Drawing.SystemColors.Control;
            this.btnSpace.Checked = false;
            this.btnSpace.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnSpace.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnSpace.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnSpace.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpace.Location = new System.Drawing.Point(137, 187);
            this.btnSpace.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnSpace.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnSpace.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnSpace.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnSpace.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnSpace.Name = "btnSpace";
            this.btnSpace.ShowFocusRectangle = false;
            this.btnSpace.Size = new System.Drawing.Size(219, 30);
            this.btnSpace.TabIndex = 103;
            this.btnSpace.TabStop = false;
            this.btnSpace.UseCompatibleTextRendering = true;
            this.btnSpace.UseMnemonic = false;
            this.btnSpace.UseVisualStyleBackColor = false;
            this.btnSpace.VKCode = ((short)(0));
            // 
            // btnC
            // 
            this.btnC.AntiAlias = true;
            this.btnC.BackColor = System.Drawing.SystemColors.Control;
            this.btnC.Checked = false;
            this.btnC.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnC.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnC.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnC.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnC.Location = new System.Drawing.Point(159, 157);
            this.btnC.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnC.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnC.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnC.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnC.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnC.Name = "btnC";
            this.btnC.ShowFocusRectangle = false;
            this.btnC.Size = new System.Drawing.Size(35, 30);
            this.btnC.TabIndex = 86;
            this.btnC.TabStop = false;
            this.btnC.Text = "c";
            this.btnC.UseCompatibleTextRendering = true;
            this.btnC.UseMnemonic = false;
            this.btnC.UseVisualStyleBackColor = false;
            this.btnC.VKCode = ((short)(0));
            // 
            // btnD
            // 
            this.btnD.AntiAlias = true;
            this.btnD.BackColor = System.Drawing.SystemColors.Control;
            this.btnD.Checked = false;
            this.btnD.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnD.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnD.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnD.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnD.Location = new System.Drawing.Point(141, 127);
            this.btnD.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnD.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnD.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnD.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnD.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnD.Name = "btnD";
            this.btnD.ShowFocusRectangle = false;
            this.btnD.Size = new System.Drawing.Size(35, 30);
            this.btnD.TabIndex = 70;
            this.btnD.TabStop = false;
            this.btnD.Text = "d";
            this.btnD.UseCompatibleTextRendering = true;
            this.btnD.UseMnemonic = false;
            this.btnD.UseVisualStyleBackColor = false;
            this.btnD.VKCode = ((short)(0));
            // 
            // btnE
            // 
            this.btnE.AntiAlias = true;
            this.btnE.BackColor = System.Drawing.SystemColors.Control;
            this.btnE.Checked = false;
            this.btnE.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnE.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnE.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnE.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE.Location = new System.Drawing.Point(124, 97);
            this.btnE.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnE.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnE.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnE.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnE.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnE.Name = "btnE";
            this.btnE.ShowFocusRectangle = false;
            this.btnE.Size = new System.Drawing.Size(35, 30);
            this.btnE.TabIndex = 49;
            this.btnE.TabStop = false;
            this.btnE.Text = "e";
            this.btnE.UseCompatibleTextRendering = true;
            this.btnE.UseMnemonic = false;
            this.btnE.UseVisualStyleBackColor = false;
            this.btnE.VKCode = ((short)(0));
            // 
            // btn5
            // 
            this.btn5.AntiAlias = true;
            this.btn5.BackColor = System.Drawing.SystemColors.Control;
            this.btn5.Checked = false;
            this.btn5.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btn5.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btn5.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btn5.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.Location = new System.Drawing.Point(177, 67);
            this.btn5.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btn5.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btn5.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btn5.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btn5.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btn5.Name = "btn5";
            this.btn5.ShowFocusRectangle = false;
            this.btn5.Size = new System.Drawing.Size(35, 30);
            this.btn5.TabIndex = 30;
            this.btn5.TabStop = false;
            this.btn5.Text = "5";
            this.btn5.UseCompatibleTextRendering = true;
            this.btn5.UseMnemonic = false;
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.VKCode = ((short)(0));
            // 
            // btnQute
            // 
            this.btnQute.AntiAlias = true;
            this.btnQute.BackColor = System.Drawing.SystemColors.Control;
            this.btnQute.Checked = false;
            this.btnQute.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnQute.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnQute.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnQute.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQute.Location = new System.Drawing.Point(421, 127);
            this.btnQute.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnQute.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnQute.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnQute.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnQute.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnQute.Name = "btnQute";
            this.btnQute.ShowFocusRectangle = false;
            this.btnQute.Size = new System.Drawing.Size(35, 30);
            this.btnQute.TabIndex = 78;
            this.btnQute.TabStop = false;
            this.btnQute.Text = "\'";
            this.btnQute.UseCompatibleTextRendering = true;
            this.btnQute.UseMnemonic = false;
            this.btnQute.UseVisualStyleBackColor = false;
            this.btnQute.VKCode = ((short)(0));
            // 
            // btnLBracket
            // 
            this.btnLBracket.AntiAlias = true;
            this.btnLBracket.BackColor = System.Drawing.SystemColors.Control;
            this.btnLBracket.Checked = false;
            this.btnLBracket.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnLBracket.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnLBracket.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnLBracket.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLBracket.Location = new System.Drawing.Point(404, 97);
            this.btnLBracket.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnLBracket.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnLBracket.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnLBracket.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnLBracket.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnLBracket.Name = "btnLBracket";
            this.btnLBracket.ShowFocusRectangle = false;
            this.btnLBracket.Size = new System.Drawing.Size(35, 30);
            this.btnLBracket.TabIndex = 57;
            this.btnLBracket.TabStop = false;
            this.btnLBracket.Text = "[";
            this.btnLBracket.UseCompatibleTextRendering = true;
            this.btnLBracket.UseMnemonic = false;
            this.btnLBracket.UseVisualStyleBackColor = false;
            this.btnLBracket.VKCode = ((short)(0));
            // 
            // btn2
            // 
            this.btn2.AntiAlias = true;
            this.btn2.BackColor = System.Drawing.SystemColors.Control;
            this.btn2.Checked = false;
            this.btn2.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btn2.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btn2.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btn2.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(72, 67);
            this.btn2.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btn2.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btn2.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btn2.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btn2.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btn2.Name = "btn2";
            this.btn2.ShowFocusRectangle = false;
            this.btn2.Size = new System.Drawing.Size(35, 30);
            this.btn2.TabIndex = 27;
            this.btn2.TabStop = false;
            this.btn2.Text = "2";
            this.btn2.UseCompatibleTextRendering = true;
            this.btn2.UseMnemonic = false;
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.VKCode = ((short)(0));
            // 
            // btnDivide
            // 
            this.btnDivide.AntiAlias = true;
            this.btnDivide.BackColor = System.Drawing.SystemColors.Control;
            this.btnDivide.Checked = false;
            this.btnDivide.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnDivide.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnDivide.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnDivide.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDivide.Location = new System.Drawing.Point(404, 157);
            this.btnDivide.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnDivide.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnDivide.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnDivide.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnDivide.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.ShowFocusRectangle = false;
            this.btnDivide.Size = new System.Drawing.Size(35, 30);
            this.btnDivide.TabIndex = 93;
            this.btnDivide.TabStop = false;
            this.btnDivide.Text = "/";
            this.btnDivide.UseCompatibleTextRendering = true;
            this.btnDivide.UseMnemonic = false;
            this.btnDivide.UseVisualStyleBackColor = false;
            this.btnDivide.VKCode = ((short)(0));
            // 
            // btnSem
            // 
            this.btnSem.AntiAlias = true;
            this.btnSem.BackColor = System.Drawing.SystemColors.Control;
            this.btnSem.Checked = false;
            this.btnSem.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnSem.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnSem.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnSem.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSem.Location = new System.Drawing.Point(386, 127);
            this.btnSem.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnSem.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnSem.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnSem.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnSem.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnSem.Name = "btnSem";
            this.btnSem.ShowFocusRectangle = false;
            this.btnSem.Size = new System.Drawing.Size(35, 30);
            this.btnSem.TabIndex = 77;
            this.btnSem.TabStop = false;
            this.btnSem.Text = ";";
            this.btnSem.UseCompatibleTextRendering = true;
            this.btnSem.UseMnemonic = false;
            this.btnSem.UseVisualStyleBackColor = false;
            this.btnSem.VKCode = ((short)(0));
            // 
            // btnP
            // 
            this.btnP.AntiAlias = true;
            this.btnP.BackColor = System.Drawing.SystemColors.Control;
            this.btnP.Checked = false;
            this.btnP.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnP.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnP.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnP.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnP.Location = new System.Drawing.Point(369, 97);
            this.btnP.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnP.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnP.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnP.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnP.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnP.Name = "btnP";
            this.btnP.ShowFocusRectangle = false;
            this.btnP.Size = new System.Drawing.Size(35, 30);
            this.btnP.TabIndex = 56;
            this.btnP.TabStop = false;
            this.btnP.Text = "p";
            this.btnP.UseCompatibleTextRendering = true;
            this.btnP.UseMnemonic = false;
            this.btnP.UseVisualStyleBackColor = false;
            this.btnP.VKCode = ((short)(0));
            // 
            // btn0
            // 
            this.btn0.AntiAlias = true;
            this.btn0.BackColor = System.Drawing.SystemColors.Control;
            this.btn0.Checked = false;
            this.btn0.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btn0.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btn0.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btn0.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.Location = new System.Drawing.Point(352, 67);
            this.btn0.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btn0.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btn0.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btn0.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btn0.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btn0.Name = "btn0";
            this.btn0.ShowFocusRectangle = false;
            this.btn0.Size = new System.Drawing.Size(35, 30);
            this.btn0.TabIndex = 35;
            this.btn0.TabStop = false;
            this.btn0.Text = "0";
            this.btn0.UseCompatibleTextRendering = true;
            this.btn0.UseMnemonic = false;
            this.btn0.UseVisualStyleBackColor = false;
            this.btn0.VKCode = ((short)(0));
            // 
            // btnComma
            // 
            this.btnComma.AntiAlias = true;
            this.btnComma.BackColor = System.Drawing.SystemColors.Control;
            this.btnComma.Checked = false;
            this.btnComma.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnComma.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnComma.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnComma.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComma.Location = new System.Drawing.Point(334, 157);
            this.btnComma.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnComma.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnComma.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnComma.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnComma.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnComma.Name = "btnComma";
            this.btnComma.ShowFocusRectangle = false;
            this.btnComma.Size = new System.Drawing.Size(35, 30);
            this.btnComma.TabIndex = 91;
            this.btnComma.TabStop = false;
            this.btnComma.Text = ",";
            this.btnComma.UseCompatibleTextRendering = true;
            this.btnComma.UseMnemonic = false;
            this.btnComma.UseVisualStyleBackColor = false;
            this.btnComma.VKCode = ((short)(0));
            // 
            // btnK
            // 
            this.btnK.AntiAlias = true;
            this.btnK.BackColor = System.Drawing.SystemColors.Control;
            this.btnK.Checked = false;
            this.btnK.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnK.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnK.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnK.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnK.Location = new System.Drawing.Point(316, 127);
            this.btnK.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnK.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnK.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnK.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnK.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnK.Name = "btnK";
            this.btnK.ShowFocusRectangle = false;
            this.btnK.Size = new System.Drawing.Size(35, 30);
            this.btnK.TabIndex = 75;
            this.btnK.TabStop = false;
            this.btnK.Text = "k";
            this.btnK.UseCompatibleTextRendering = true;
            this.btnK.UseMnemonic = false;
            this.btnK.UseVisualStyleBackColor = false;
            this.btnK.VKCode = ((short)(0));
            // 
            // btnI
            // 
            this.btnI.AntiAlias = true;
            this.btnI.BackColor = System.Drawing.SystemColors.Control;
            this.btnI.Checked = false;
            this.btnI.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnI.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnI.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnI.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnI.Location = new System.Drawing.Point(299, 97);
            this.btnI.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnI.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnI.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnI.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnI.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnI.Name = "btnI";
            this.btnI.ShowFocusRectangle = false;
            this.btnI.Size = new System.Drawing.Size(35, 30);
            this.btnI.TabIndex = 54;
            this.btnI.TabStop = false;
            this.btnI.Text = "i";
            this.btnI.UseCompatibleTextRendering = true;
            this.btnI.UseMnemonic = false;
            this.btnI.UseVisualStyleBackColor = false;
            this.btnI.VKCode = ((short)(0));
            // 
            // btn9
            // 
            this.btn9.AntiAlias = true;
            this.btn9.BackColor = System.Drawing.SystemColors.Control;
            this.btn9.Checked = false;
            this.btn9.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btn9.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btn9.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btn9.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.Location = new System.Drawing.Point(317, 67);
            this.btn9.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btn9.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btn9.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btn9.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btn9.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btn9.Name = "btn9";
            this.btn9.ShowFocusRectangle = false;
            this.btn9.Size = new System.Drawing.Size(35, 30);
            this.btn9.TabIndex = 34;
            this.btn9.TabStop = false;
            this.btn9.Text = "9";
            this.btn9.UseCompatibleTextRendering = true;
            this.btn9.UseMnemonic = false;
            this.btn9.UseVisualStyleBackColor = false;
            this.btn9.VKCode = ((short)(0));
            // 
            // btnRCTRL
            // 
            this.btnRCTRL.AntiAlias = true;
            this.btnRCTRL.BackColor = System.Drawing.SystemColors.Control;
            this.btnRCTRL.Checked = false;
            this.btnRCTRL.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnRCTRL.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnRCTRL.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnRCTRL.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRCTRL.Location = new System.Drawing.Point(476, 187);
            this.btnRCTRL.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnRCTRL.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnRCTRL.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnRCTRL.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnRCTRL.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnRCTRL.Name = "btnRCTRL";
            this.btnRCTRL.ShowFocusRectangle = false;
            this.btnRCTRL.Size = new System.Drawing.Size(50, 30);
            this.btnRCTRL.TabIndex = 107;
            this.btnRCTRL.TabStop = false;
            this.btnRCTRL.Text = "ctrl";
            this.btnRCTRL.UseCompatibleTextRendering = true;
            this.btnRCTRL.UseMnemonic = false;
            this.btnRCTRL.UseVisualStyleBackColor = false;
            this.btnRCTRL.VKCode = ((short)(0));
            // 
            // btnM
            // 
            this.btnM.AntiAlias = true;
            this.btnM.BackColor = System.Drawing.SystemColors.Control;
            this.btnM.Checked = false;
            this.btnM.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnM.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnM.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnM.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnM.Location = new System.Drawing.Point(299, 157);
            this.btnM.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnM.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnM.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnM.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnM.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnM.Name = "btnM";
            this.btnM.ShowFocusRectangle = false;
            this.btnM.Size = new System.Drawing.Size(35, 30);
            this.btnM.TabIndex = 90;
            this.btnM.TabStop = false;
            this.btnM.Text = "m";
            this.btnM.UseCompatibleTextRendering = true;
            this.btnM.UseMnemonic = false;
            this.btnM.UseVisualStyleBackColor = false;
            this.btnM.VKCode = ((short)(0));
            // 
            // btnJ
            // 
            this.btnJ.AntiAlias = true;
            this.btnJ.BackColor = System.Drawing.SystemColors.Control;
            this.btnJ.Checked = false;
            this.btnJ.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnJ.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnJ.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnJ.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJ.Location = new System.Drawing.Point(281, 127);
            this.btnJ.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnJ.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnJ.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnJ.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnJ.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnJ.Name = "btnJ";
            this.btnJ.ShowFocusRectangle = false;
            this.btnJ.Size = new System.Drawing.Size(35, 30);
            this.btnJ.TabIndex = 74;
            this.btnJ.TabStop = false;
            this.btnJ.Text = "j";
            this.btnJ.UseCompatibleTextRendering = true;
            this.btnJ.UseMnemonic = false;
            this.btnJ.UseVisualStyleBackColor = false;
            this.btnJ.VKCode = ((short)(0));
            // 
            // btnU
            // 
            this.btnU.AntiAlias = true;
            this.btnU.BackColor = System.Drawing.SystemColors.Control;
            this.btnU.Checked = false;
            this.btnU.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnU.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnU.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnU.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnU.Location = new System.Drawing.Point(264, 97);
            this.btnU.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnU.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnU.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnU.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnU.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnU.Name = "btnU";
            this.btnU.ShowFocusRectangle = false;
            this.btnU.Size = new System.Drawing.Size(35, 30);
            this.btnU.TabIndex = 53;
            this.btnU.TabStop = false;
            this.btnU.Text = "u";
            this.btnU.UseCompatibleTextRendering = true;
            this.btnU.UseMnemonic = false;
            this.btnU.UseVisualStyleBackColor = false;
            this.btnU.VKCode = ((short)(0));
            // 
            // btn7
            // 
            this.btn7.AntiAlias = true;
            this.btn7.BackColor = System.Drawing.SystemColors.Control;
            this.btn7.Checked = false;
            this.btn7.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btn7.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btn7.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btn7.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.Location = new System.Drawing.Point(247, 67);
            this.btn7.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btn7.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btn7.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btn7.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btn7.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btn7.Name = "btn7";
            this.btn7.ShowFocusRectangle = false;
            this.btn7.Size = new System.Drawing.Size(35, 30);
            this.btn7.TabIndex = 32;
            this.btn7.TabStop = false;
            this.btn7.Text = "7";
            this.btn7.UseCompatibleTextRendering = true;
            this.btn7.UseMnemonic = false;
            this.btn7.UseVisualStyleBackColor = false;
            this.btn7.VKCode = ((short)(0));
            // 
            // btnRW
            // 
            this.btnRW.AntiAlias = true;
            this.btnRW.BackColor = System.Drawing.SystemColors.Control;
            this.btnRW.Checked = false;
            this.btnRW.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnRW.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnRW.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnRW.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRW.Location = new System.Drawing.Point(406, 187);
            this.btnRW.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnRW.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnRW.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnRW.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnRW.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnRW.Name = "btnRW";
            this.btnRW.ShowFocusRectangle = false;
            this.btnRW.Size = new System.Drawing.Size(35, 30);
            this.btnRW.TabIndex = 105;
            this.btnRW.TabStop = false;
            this.btnRW.Text = "rw";
            this.btnRW.UseCompatibleTextRendering = true;
            this.btnRW.UseMnemonic = false;
            this.btnRW.UseVisualStyleBackColor = false;
            this.btnRW.VKCode = ((short)(0));
            // 
            // btnB
            // 
            this.btnB.AntiAlias = true;
            this.btnB.BackColor = System.Drawing.SystemColors.Control;
            this.btnB.Checked = false;
            this.btnB.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnB.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnB.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnB.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnB.Location = new System.Drawing.Point(229, 157);
            this.btnB.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnB.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnB.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnB.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnB.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnB.Name = "btnB";
            this.btnB.ShowFocusRectangle = false;
            this.btnB.Size = new System.Drawing.Size(35, 30);
            this.btnB.TabIndex = 88;
            this.btnB.TabStop = false;
            this.btnB.Text = "b";
            this.btnB.UseCompatibleTextRendering = true;
            this.btnB.UseMnemonic = false;
            this.btnB.UseVisualStyleBackColor = false;
            this.btnB.VKCode = ((short)(0));
            // 
            // btnG
            // 
            this.btnG.AntiAlias = true;
            this.btnG.BackColor = System.Drawing.SystemColors.Control;
            this.btnG.Checked = false;
            this.btnG.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnG.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnG.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnG.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnG.Location = new System.Drawing.Point(211, 127);
            this.btnG.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnG.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnG.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnG.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnG.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnG.Name = "btnG";
            this.btnG.ShowFocusRectangle = false;
            this.btnG.Size = new System.Drawing.Size(35, 30);
            this.btnG.TabIndex = 72;
            this.btnG.TabStop = false;
            this.btnG.Text = "g";
            this.btnG.UseCompatibleTextRendering = true;
            this.btnG.UseMnemonic = false;
            this.btnG.UseVisualStyleBackColor = false;
            this.btnG.VKCode = ((short)(0));
            // 
            // btnRALT
            // 
            this.btnRALT.AntiAlias = true;
            this.btnRALT.BackColor = System.Drawing.SystemColors.Control;
            this.btnRALT.Checked = false;
            this.btnRALT.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnRALT.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnRALT.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnRALT.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRALT.Location = new System.Drawing.Point(356, 187);
            this.btnRALT.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnRALT.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnRALT.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnRALT.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnRALT.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnRALT.Name = "btnRALT";
            this.btnRALT.ShowFocusRectangle = false;
            this.btnRALT.Size = new System.Drawing.Size(50, 30);
            this.btnRALT.TabIndex = 104;
            this.btnRALT.TabStop = false;
            this.btnRALT.Text = "alt";
            this.btnRALT.UseCompatibleTextRendering = true;
            this.btnRALT.UseMnemonic = false;
            this.btnRALT.UseVisualStyleBackColor = false;
            this.btnRALT.VKCode = ((short)(0));
            // 
            // btnV
            // 
            this.btnV.AntiAlias = true;
            this.btnV.BackColor = System.Drawing.SystemColors.Control;
            this.btnV.Checked = false;
            this.btnV.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnV.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnV.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnV.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnV.Location = new System.Drawing.Point(194, 157);
            this.btnV.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnV.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnV.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnV.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnV.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnV.Name = "btnV";
            this.btnV.ShowFocusRectangle = false;
            this.btnV.Size = new System.Drawing.Size(35, 30);
            this.btnV.TabIndex = 87;
            this.btnV.TabStop = false;
            this.btnV.Text = "v";
            this.btnV.UseCompatibleTextRendering = true;
            this.btnV.UseMnemonic = false;
            this.btnV.UseVisualStyleBackColor = false;
            this.btnV.VKCode = ((short)(0));
            // 
            // btnT
            // 
            this.btnT.AntiAlias = true;
            this.btnT.BackColor = System.Drawing.SystemColors.Control;
            this.btnT.Checked = false;
            this.btnT.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnT.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnT.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnT.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnT.Location = new System.Drawing.Point(194, 97);
            this.btnT.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnT.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnT.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnT.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnT.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnT.Name = "btnT";
            this.btnT.ShowFocusRectangle = false;
            this.btnT.Size = new System.Drawing.Size(35, 30);
            this.btnT.TabIndex = 51;
            this.btnT.TabStop = false;
            this.btnT.Text = "t";
            this.btnT.UseCompatibleTextRendering = true;
            this.btnT.UseMnemonic = false;
            this.btnT.UseVisualStyleBackColor = false;
            this.btnT.VKCode = ((short)(0));
            // 
            // btnF
            // 
            this.btnF.AntiAlias = true;
            this.btnF.BackColor = System.Drawing.SystemColors.Control;
            this.btnF.Checked = false;
            this.btnF.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnF.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnF.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnF.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF.Location = new System.Drawing.Point(176, 127);
            this.btnF.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnF.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnF.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnF.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnF.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnF.Name = "btnF";
            this.btnF.ShowFocusRectangle = false;
            this.btnF.Size = new System.Drawing.Size(35, 30);
            this.btnF.TabIndex = 71;
            this.btnF.TabStop = false;
            this.btnF.Text = "f";
            this.btnF.UseCompatibleTextRendering = true;
            this.btnF.UseMnemonic = false;
            this.btnF.UseVisualStyleBackColor = false;
            this.btnF.VKCode = ((short)(0));
            // 
            // btnLALT
            // 
            this.btnLALT.AntiAlias = true;
            this.btnLALT.BackColor = System.Drawing.SystemColors.Control;
            this.btnLALT.Checked = false;
            this.btnLALT.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnLALT.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnLALT.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnLALT.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLALT.Location = new System.Drawing.Point(87, 187);
            this.btnLALT.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnLALT.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnLALT.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnLALT.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnLALT.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnLALT.Name = "btnLALT";
            this.btnLALT.ShowFocusRectangle = false;
            this.btnLALT.Size = new System.Drawing.Size(50, 30);
            this.btnLALT.TabIndex = 102;
            this.btnLALT.TabStop = false;
            this.btnLALT.Text = "alt";
            this.btnLALT.UseCompatibleTextRendering = true;
            this.btnLALT.UseMnemonic = false;
            this.btnLALT.UseVisualStyleBackColor = false;
            this.btnLALT.VKCode = ((short)(0));
            // 
            // btn6
            // 
            this.btn6.AntiAlias = true;
            this.btn6.BackColor = System.Drawing.SystemColors.Control;
            this.btn6.Checked = false;
            this.btn6.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btn6.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btn6.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btn6.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.Location = new System.Drawing.Point(212, 67);
            this.btn6.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btn6.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btn6.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btn6.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btn6.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btn6.Name = "btn6";
            this.btn6.ShowFocusRectangle = false;
            this.btn6.Size = new System.Drawing.Size(35, 30);
            this.btn6.TabIndex = 31;
            this.btn6.TabStop = false;
            this.btn6.Text = "6";
            this.btn6.UseCompatibleTextRendering = true;
            this.btn6.UseMnemonic = false;
            this.btn6.UseVisualStyleBackColor = false;
            this.btn6.VKCode = ((short)(0));
            // 
            // btnX
            // 
            this.btnX.AntiAlias = true;
            this.btnX.BackColor = System.Drawing.SystemColors.Control;
            this.btnX.Checked = false;
            this.btnX.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnX.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnX.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnX.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX.Location = new System.Drawing.Point(124, 157);
            this.btnX.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnX.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnX.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnX.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnX.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnX.Name = "btnX";
            this.btnX.ShowFocusRectangle = false;
            this.btnX.Size = new System.Drawing.Size(35, 30);
            this.btnX.TabIndex = 85;
            this.btnX.TabStop = false;
            this.btnX.Text = "x";
            this.btnX.UseCompatibleTextRendering = true;
            this.btnX.UseMnemonic = false;
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.VKCode = ((short)(0));
            // 
            // btnR
            // 
            this.btnR.AntiAlias = true;
            this.btnR.BackColor = System.Drawing.SystemColors.Control;
            this.btnR.Checked = false;
            this.btnR.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnR.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnR.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnR.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnR.Location = new System.Drawing.Point(159, 97);
            this.btnR.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnR.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnR.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnR.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnR.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnR.Name = "btnR";
            this.btnR.ShowFocusRectangle = false;
            this.btnR.Size = new System.Drawing.Size(35, 30);
            this.btnR.TabIndex = 50;
            this.btnR.TabStop = false;
            this.btnR.Text = "r";
            this.btnR.UseCompatibleTextRendering = true;
            this.btnR.UseMnemonic = false;
            this.btnR.UseVisualStyleBackColor = false;
            this.btnR.VKCode = ((short)(0));
            // 
            // btnS
            // 
            this.btnS.AntiAlias = true;
            this.btnS.BackColor = System.Drawing.SystemColors.Control;
            this.btnS.Checked = false;
            this.btnS.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnS.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnS.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnS.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnS.Location = new System.Drawing.Point(106, 127);
            this.btnS.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnS.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnS.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnS.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnS.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnS.Name = "btnS";
            this.btnS.ShowFocusRectangle = false;
            this.btnS.Size = new System.Drawing.Size(35, 30);
            this.btnS.TabIndex = 69;
            this.btnS.TabStop = false;
            this.btnS.Text = "s";
            this.btnS.UseCompatibleTextRendering = true;
            this.btnS.UseMnemonic = false;
            this.btnS.UseVisualStyleBackColor = false;
            this.btnS.VKCode = ((short)(0));
            // 
            // btnLW
            // 
            this.btnLW.AntiAlias = true;
            this.btnLW.BackColor = System.Drawing.SystemColors.Control;
            this.btnLW.Checked = false;
            this.btnLW.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnLW.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnLW.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnLW.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLW.Location = new System.Drawing.Point(52, 187);
            this.btnLW.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnLW.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnLW.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnLW.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnLW.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnLW.Name = "btnLW";
            this.btnLW.ShowFocusRectangle = false;
            this.btnLW.Size = new System.Drawing.Size(35, 30);
            this.btnLW.TabIndex = 101;
            this.btnLW.TabStop = false;
            this.btnLW.Text = "lw";
            this.btnLW.UseCompatibleTextRendering = true;
            this.btnLW.UseMnemonic = false;
            this.btnLW.UseVisualStyleBackColor = false;
            this.btnLW.VKCode = ((short)(0));
            // 
            // btn4
            // 
            this.btn4.AntiAlias = true;
            this.btn4.BackColor = System.Drawing.SystemColors.Control;
            this.btn4.Checked = false;
            this.btn4.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btn4.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btn4.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btn4.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.Location = new System.Drawing.Point(142, 67);
            this.btn4.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btn4.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btn4.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btn4.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btn4.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btn4.Name = "btn4";
            this.btn4.ShowFocusRectangle = false;
            this.btn4.Size = new System.Drawing.Size(35, 30);
            this.btn4.TabIndex = 29;
            this.btn4.TabStop = false;
            this.btn4.Text = "4";
            this.btn4.UseCompatibleTextRendering = true;
            this.btn4.UseMnemonic = false;
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.VKCode = ((short)(0));
            // 
            // btnZ
            // 
            this.btnZ.AntiAlias = true;
            this.btnZ.BackColor = System.Drawing.SystemColors.Control;
            this.btnZ.Checked = false;
            this.btnZ.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnZ.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnZ.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnZ.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZ.Location = new System.Drawing.Point(89, 157);
            this.btnZ.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnZ.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnZ.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnZ.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnZ.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnZ.Name = "btnZ";
            this.btnZ.ShowFocusRectangle = false;
            this.btnZ.Size = new System.Drawing.Size(35, 30);
            this.btnZ.TabIndex = 84;
            this.btnZ.TabStop = false;
            this.btnZ.Text = "z";
            this.btnZ.UseCompatibleTextRendering = true;
            this.btnZ.UseMnemonic = false;
            this.btnZ.UseVisualStyleBackColor = false;
            this.btnZ.VKCode = ((short)(0));
            // 
            // btnW
            // 
            this.btnW.AntiAlias = true;
            this.btnW.BackColor = System.Drawing.SystemColors.Control;
            this.btnW.Checked = false;
            this.btnW.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnW.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnW.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnW.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnW.Location = new System.Drawing.Point(89, 97);
            this.btnW.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnW.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnW.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnW.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnW.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnW.Name = "btnW";
            this.btnW.ShowFocusRectangle = false;
            this.btnW.Size = new System.Drawing.Size(35, 30);
            this.btnW.TabIndex = 48;
            this.btnW.TabStop = false;
            this.btnW.Text = "w";
            this.btnW.UseCompatibleTextRendering = true;
            this.btnW.UseMnemonic = false;
            this.btnW.UseVisualStyleBackColor = false;
            this.btnW.VKCode = ((short)(0));
            // 
            // btnA
            // 
            this.btnA.AntiAlias = true;
            this.btnA.BackColor = System.Drawing.SystemColors.Control;
            this.btnA.Checked = false;
            this.btnA.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnA.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnA.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnA.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnA.Location = new System.Drawing.Point(71, 127);
            this.btnA.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnA.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnA.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnA.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnA.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnA.Name = "btnA";
            this.btnA.ShowFocusRectangle = false;
            this.btnA.Size = new System.Drawing.Size(35, 30);
            this.btnA.TabIndex = 68;
            this.btnA.TabStop = false;
            this.btnA.Text = "a";
            this.btnA.UseCompatibleTextRendering = true;
            this.btnA.UseMnemonic = false;
            this.btnA.UseVisualStyleBackColor = false;
            this.btnA.VKCode = ((short)(0));
            // 
            // btn3
            // 
            this.btn3.AntiAlias = true;
            this.btn3.BackColor = System.Drawing.SystemColors.Control;
            this.btn3.Checked = false;
            this.btn3.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btn3.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btn3.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btn3.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Location = new System.Drawing.Point(107, 67);
            this.btn3.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btn3.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btn3.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btn3.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btn3.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btn3.Name = "btn3";
            this.btn3.ShowFocusRectangle = false;
            this.btn3.Size = new System.Drawing.Size(35, 30);
            this.btn3.TabIndex = 28;
            this.btn3.TabStop = false;
            this.btn3.Text = "3";
            this.btn3.UseCompatibleTextRendering = true;
            this.btn3.UseMnemonic = false;
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.VKCode = ((short)(0));
            // 
            // btnQ
            // 
            this.btnQ.AntiAlias = true;
            this.btnQ.BackColor = System.Drawing.SystemColors.Control;
            this.btnQ.Checked = false;
            this.btnQ.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnQ.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnQ.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnQ.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQ.Location = new System.Drawing.Point(54, 97);
            this.btnQ.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnQ.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnQ.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnQ.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnQ.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnQ.Name = "btnQ";
            this.btnQ.ShowFocusRectangle = false;
            this.btnQ.Size = new System.Drawing.Size(35, 30);
            this.btnQ.TabIndex = 47;
            this.btnQ.TabStop = false;
            this.btnQ.Text = "q";
            this.btnQ.UseCompatibleTextRendering = true;
            this.btnQ.UseMnemonic = false;
            this.btnQ.UseVisualStyleBackColor = false;
            this.btnQ.VKCode = ((short)(0));
            // 
            // btn1
            // 
            this.btn1.AntiAlias = true;
            this.btn1.BackColor = System.Drawing.SystemColors.Control;
            this.btn1.Checked = false;
            this.btn1.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btn1.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btn1.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btn1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(37, 67);
            this.btn1.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btn1.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btn1.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btn1.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btn1.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btn1.Name = "btn1";
            this.btn1.ShowFocusRectangle = false;
            this.btn1.Size = new System.Drawing.Size(35, 30);
            this.btn1.TabIndex = 26;
            this.btn1.TabStop = false;
            this.btn1.Text = "1";
            this.btn1.UseCompatibleTextRendering = true;
            this.btn1.UseMnemonic = false;
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.VKCode = ((short)(0));
            // 
            // btnWave
            // 
            this.btnWave.AntiAlias = true;
            this.btnWave.BackColor = System.Drawing.SystemColors.Control;
            this.btnWave.Checked = false;
            this.btnWave.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnWave.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnWave.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnWave.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWave.Location = new System.Drawing.Point(2, 67);
            this.btnWave.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnWave.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnWave.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnWave.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnWave.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnWave.Name = "btnWave";
            this.btnWave.ShowFocusRectangle = false;
            this.btnWave.Size = new System.Drawing.Size(35, 30);
            this.btnWave.TabIndex = 25;
            this.btnWave.TabStop = false;
            this.btnWave.Text = "~";
            this.btnWave.UseCompatibleTextRendering = true;
            this.btnWave.UseMnemonic = false;
            this.btnWave.UseVisualStyleBackColor = false;
            this.btnWave.VKCode = ((short)(0));
            // 
            // btnESC
            // 
            this.btnESC.AntiAlias = true;
            this.btnESC.BackColor = System.Drawing.SystemColors.Control;
            this.btnESC.Checked = false;
            this.btnESC.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnESC.DefaultStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.btnESC.DefautEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.btnESC.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnESC.Location = new System.Drawing.Point(2, 37);
            this.btnESC.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnESC.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnESC.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnESC.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnESC.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnESC.Name = "btnESC";
            this.btnESC.ShowFocusRectangle = false;
            this.btnESC.Size = new System.Drawing.Size(35, 30);
            this.btnESC.TabIndex = 6;
            this.btnESC.TabStop = false;
            this.btnESC.Text = "esc";
            this.btnESC.UseCompatibleTextRendering = true;
            this.btnESC.UseMnemonic = false;
            this.btnESC.UseVisualStyleBackColor = false;
            this.btnESC.VKCode = ((short)(0));
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemEdit,
            this.menuItemHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(788, 40);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemExit});
            this.menuItemEdit.Name = "menuItemEdit";
            this.menuItemEdit.Size = new System.Drawing.Size(103, 36);
            this.menuItemEdit.Text = "&编辑";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(269, 38);
            this.menuItemExit.Text = "E退出";
            this.menuItemExit.Click += new System.EventHandler(this.MenuItemOnClick);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAbout});
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(103, 36);
            this.menuItemHelp.Text = "&帮助";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Size = new System.Drawing.Size(269, 38);
            this.menuItemAbout.Text = "&关于";
            this.menuItemAbout.Click += new System.EventHandler(this.MenuItemOnClick);
            // 
            // lightCapsLock
            // 
            this.lightCapsLock.BackColor = System.Drawing.Color.Transparent;
            this.lightCapsLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lightCapsLock.Location = new System.Drawing.Point(707, 44);
            this.lightCapsLock.Name = "lightCapsLock";
            this.lightCapsLock.Size = new System.Drawing.Size(16, 16);
            this.lightCapsLock.TabIndex = 23;
            // 
            // lightNumLock
            // 
            this.lightNumLock.BackColor = System.Drawing.Color.Transparent;
            this.lightNumLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lightNumLock.Location = new System.Drawing.Point(674, 44);
            this.lightNumLock.Name = "lightNumLock";
            this.lightNumLock.Size = new System.Drawing.Size(16, 16);
            this.lightNumLock.TabIndex = 22;
            // 
            // lightScrollLock
            // 
            this.lightScrollLock.BackColor = System.Drawing.Color.Transparent;
            this.lightScrollLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lightScrollLock.Location = new System.Drawing.Point(740, 44);
            this.lightScrollLock.Name = "lightScrollLock";
            this.lightScrollLock.Size = new System.Drawing.Size(16, 16);
            this.lightScrollLock.TabIndex = 24;
            // 
            // lblSeparator
            // 
            this.lblSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeparator.BackColor = System.Drawing.SystemColors.Window;
            this.lblSeparator.Location = new System.Drawing.Point(3, 30);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(785, 2);
            this.lblSeparator.TabIndex = 5;
            // 
            // ScreenKeyboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(788, 218);
            this.Controls.Add(this.lblSeparator);
            this.Controls.Add(this.lightScrollLock);
            this.Controls.Add(this.lightCapsLock);
            this.Controls.Add(this.lightNumLock);
            this.Controls.Add(this.btnRA);
            this.Controls.Add(this.btnNUM3);
            this.Controls.Add(this.btnNUMENT);
            this.Controls.Add(this.btnNUM6);
            this.Controls.Add(this.btnPDN);
            this.Controls.Add(this.btnNUMPlus);
            this.Controls.Add(this.btnNUM9);
            this.Controls.Add(this.btnPUP);
            this.Controls.Add(this.btnNUMMinus);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btnBRK);
            this.Controls.Add(this.btnUP);
            this.Controls.Add(this.btnDN);
            this.Controls.Add(this.btnLA);
            this.Controls.Add(this.btnNUMDot);
            this.Controls.Add(this.btnNUM2);
            this.Controls.Add(this.btnNUM0);
            this.Controls.Add(this.btnNUM5);
            this.Controls.Add(this.btnNUM1);
            this.Controls.Add(this.btnEND);
            this.Controls.Add(this.btnNUM4);
            this.Controls.Add(this.btnDEL);
            this.Controls.Add(this.btnNUM8);
            this.Controls.Add(this.btnHM);
            this.Controls.Add(this.btnNUM7);
            this.Controls.Add(this.btnINS);
            this.Controls.Add(this.btnNUMDivide);
            this.Controls.Add(this.btnNLK);
            this.Controls.Add(this.btnSLK);
            this.Controls.Add(this.btnPSC);
            this.Controls.Add(this.btnF12);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF10);
            this.Controls.Add(this.btnF9);
            this.Controls.Add(this.btnF8);
            this.Controls.Add(this.btnF7);
            this.Controls.Add(this.btnF6);
            this.Controls.Add(this.btnF5);
            this.Controls.Add(this.btnF4);
            this.Controls.Add(this.btnF3);
            this.Controls.Add(this.btnF2);
            this.Controls.Add(this.btnF1);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.btnEqual);
            this.Controls.Add(this.btnLCTRL);
            this.Controls.Add(this.btnLSHFT);
            this.Controls.Add(this.btnLOCK);
            this.Controls.Add(this.btnTAB);
            this.Controls.Add(this.btnBKSP);
            this.Controls.Add(this.btnRSHFT);
            this.Controls.Add(this.btnENT);
            this.Controls.Add(this.btnRBracket);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnFullStop);
            this.Controls.Add(this.btnL);
            this.Controls.Add(this.btnO);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btnMU);
            this.Controls.Add(this.btnN);
            this.Controls.Add(this.btnH);
            this.Controls.Add(this.btnY);
            this.Controls.Add(this.btnSpace);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnE);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btnQute);
            this.Controls.Add(this.btnLBracket);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.btnSem);
            this.Controls.Add(this.btnP);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnComma);
            this.Controls.Add(this.btnK);
            this.Controls.Add(this.btnI);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btnRCTRL);
            this.Controls.Add(this.btnM);
            this.Controls.Add(this.btnJ);
            this.Controls.Add(this.btnU);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btnRW);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.btnG);
            this.Controls.Add(this.btnRALT);
            this.Controls.Add(this.btnV);
            this.Controls.Add(this.btnT);
            this.Controls.Add(this.btnF);
            this.Controls.Add(this.btnLALT);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.btnR);
            this.Controls.Add(this.btnS);
            this.Controls.Add(this.btnLW);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btnZ);
            this.Controls.Add(this.btnW);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btnQ);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btnWave);
            this.Controls.Add(this.btnESC);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "ScreenKeyboard";
            this.Text = "键盘对应记录";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KeyboardLight lightScrollLock;
        private KeyboardLight lightCapsLock;
        private KeyboardLight lightNumLock;
        private KeyboardButton btnRA;
        private KeyboardButton btnNUM3;
        private KeyboardButton btnNUMENT;
        private KeyboardButton btnNUM6;
        private KeyboardButton btnPDN;
        private KeyboardButton btnNUMPlus;
        private KeyboardButton btnNUM9;
        private KeyboardButton btnPUP;
        private KeyboardButton btnNUMMinus;
        private KeyboardButton btnMultiply;
        private KeyboardButton btnBRK;
        private KeyboardButton btnUP;
        private KeyboardButton btnDN;
        private KeyboardButton btnLA;
        private KeyboardButton btnNUMDot;
        private KeyboardButton btnNUM2;
        private KeyboardButton btnNUM0;
        private KeyboardButton btnNUM5;
        private KeyboardButton btnNUM1;
        private KeyboardButton btnEND;
        private KeyboardButton btnNUM4;
        private KeyboardButton btnDEL;
        private KeyboardButton btnNUM8;
        private KeyboardButton btnHM;
        private KeyboardButton btnNUM7;
        private KeyboardButton btnINS;
        private KeyboardButton btnNUMDivide;
        private KeyboardButton btnNLK;
        private KeyboardButton btnSLK;
        private KeyboardButton btnPSC;
        private KeyboardButton btnF12;
        private KeyboardButton btnF11;
        private KeyboardButton btnF10;
        private KeyboardButton btnF9;
        private KeyboardButton btnF8;
        private KeyboardButton btnF7;
        private KeyboardButton btnF6;
        private KeyboardButton btnF5;
        private KeyboardButton btnF4;
        private KeyboardButton btnF3;
        private KeyboardButton btnF2;
        private KeyboardButton btnF1;
        private KeyboardButton btnPath;
        private KeyboardButton btnEqual;
        private KeyboardButton btnLCTRL;
        private KeyboardButton btnLSHFT;
        private KeyboardButton btnLOCK;
        private KeyboardButton btnTAB;
        private KeyboardButton btnBKSP;
        private KeyboardButton btnRSHFT;
        private KeyboardButton btnENT;
        private KeyboardButton btnRBracket;
        private KeyboardButton btnMinus;
        private KeyboardButton btnFullStop;
        private KeyboardButton btnL;
        private KeyboardButton btnO;
        private KeyboardButton btn8;
        private KeyboardButton btnMU;
        private KeyboardButton btnN;
        private KeyboardButton btnH;
        private KeyboardButton btnY;
        private KeyboardButton btnSpace;
        private KeyboardButton btnC;
        private KeyboardButton btnD;
        private KeyboardButton btnE;
        private KeyboardButton btn5;
        private KeyboardButton btnQute;
        private KeyboardButton btnLBracket;
        private KeyboardButton btn2;
        private KeyboardButton btnDivide;
        private KeyboardButton btnSem;
        private KeyboardButton btnP;
        private KeyboardButton btn0;
        private KeyboardButton btnComma;
        private KeyboardButton btnK;
        private KeyboardButton btnI;
        private KeyboardButton btn9;
        private KeyboardButton btnRCTRL;
        private KeyboardButton btnM;
        private KeyboardButton btnJ;
        private KeyboardButton btnU;
        private KeyboardButton btn7;
        private KeyboardButton btnRW;
        private KeyboardButton btnB;
        private KeyboardButton btnG;
        private KeyboardButton btnRALT;
        private KeyboardButton btnV;
        private KeyboardButton btnT;
        private KeyboardButton btnF;
        private KeyboardButton btnLALT;
        private KeyboardButton btn6;
        private KeyboardButton btnX;
        private KeyboardButton btnR;
        private KeyboardButton btnS;
        private KeyboardButton btnLW;
        private KeyboardButton btn4;
        private KeyboardButton btnZ;
        private KeyboardButton btnW;
        private KeyboardButton btnA;
        private KeyboardButton btn3;
        private KeyboardButton btnQ;
        private KeyboardButton btn1;
        private KeyboardButton btnWave;
        private KeyboardButton btnESC;
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuItemEdit;
        private ToolStripMenuItem menuItemHelp;
        private ToolStripMenuItem menuItemAbout;
        private ToolStripMenuItem menuItemExit;
        private Label lblSeparator;
    }
}

