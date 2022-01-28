using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace 刷刷刷
{
    public partial class Form1 : Form
    {
        public int qx = 0;

        public Form1()
        {
            InitializeComponent();
        }

        FlowLayoutPanel fp1 = new FlowLayoutPanel();
        TextBox tb1 = new TextBox();

        private void Form1_Load(object sender, EventArgs e)
        {          
            Icon = soce.favicon_20190501082203512;
            startup aut = new startup();
            aut.ShowDialog();
            Hide();

            tb1.ReadOnly = true;
            tb1.Dock = DockStyle.Fill;
            fp1.Dock = DockStyle.Fill;
            fp1.AutoScroll = true;
            panel1.Controls.Add(tb1);
            panel1.Controls.Add(fp1);

            for (int i = 1; i < 13; i++)
            {
                Button srt = new Button();
                srt.Width = 128;
                srt.Height = 168;
                srt.FlatStyle = FlatStyle.Flat;
                srt.FlatAppearance.BorderColor = Color.Black;
                srt.FlatAppearance.BorderSize = 1;
                srt.FlatAppearance.MouseOverBackColor = Color.DarkGray;
                srt.FlatAppearance.MouseDownBackColor = Color.Transparent;
                if (i == 1)
                {
                    srt.Text = soce.g1;
                }
                else if (i == 2)
                {
                    srt.Text = soce.g2;
                }
                else if (i == 3)
                {
                    srt.Text = soce.g3;
                }
                else if (i == 4)
                {
                    srt.Text = soce.g4;
                }
                else if (i == 5)
                {
                    srt.Text = soce.g5;
                }
                else if (i == 6)
                {
                    srt.Text = soce.g6;
                }
                else if (i == 7)
                {
                    srt.Text = soce.g7;
                }
                else if (i == 8)
                {
                    srt.Text = soce.g8;
                }
                else if (i == 9)
                {
                    srt.Text = soce.g9;
                }
                else if (i == 10)
                {
                    srt.Text = soce.g10;
                }
                else if (i == 11)
                {
                    srt.Text = soce.g11;
                }
                else if (i == 12)
                {
                    srt.Text = soce.g12;
                }

                fp1.Controls.Add(srt);
                srt.Click += delegate
                {
                    string zh = ConfigurationManager.AppSettings["zh"].ToString();
                    tb1.Text = "当前路径->->'" + srt.Text + "'";
                    if (zh != "none")
                    {
                        if (qx == 1)
                        {
                            if (MessageBox.Show("确定要给" + zh + "这个账号开启所有人民币项目？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                Form result = new Form();
                                result.Text = "创建结果";
                                result.Width = 260;
                                result.Height = 80;
                                result.Icon = soce.favicon_20190501082203512;
                                result.StartPosition = FormStartPosition.CenterScreen;

                                FlowLayoutPanel fl1 = new FlowLayoutPanel();
                                fl1.Dock = DockStyle.Fill;

                                Label lz = new Label();
                                Label lp = new Label();
                                lp.Width = 400;
                                lz.Text = "账号:" + zh;
                                lp.Text = "状况:已经为这个账号开通了全人民币内容！";

                                result.Controls.Add(fl1);
                                fl1.Controls.Add(lz);
                                fl1.Controls.Add(lp);
                                result.Show();
                            }
                        }
                        else
                        {
                            
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("您尚未添加账号，是否现在添加？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            if (qx == 1)
                            {
                                az.Width = 300;
                                az.Height = 200;
                                az.StartPosition = FormStartPosition.CenterScreen;
                                az.Icon = soce.favicon_20190501082203512;

                                fl2.Dock = DockStyle.Fill;

                                ru.Text = "添加...";
                                ru.Click += rCli;

                                az.Controls.Add(fl2);
                                fl2.Controls.Add(t1);
                                fl2.Controls.Add(ru);

                                az.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("请先激活程序!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return;
                        }
                    }
                };
            }
            try
            {
                if (File.Exists(@"C:\ProgramData\ShuaX3\Key\Yes.Keygen"))
                {
                    StreamReader auti = new StreamReader(@"C:\ProgramData\ShuaX3\Key\Yes.Keygen");
                    string zw = auti.ReadLine();
                    string zd = "YjclCvklrNmXaFXz5WSP4nNKx";
                    if (zw == zd)
                    {
                        qx = 1;
                    }
                    else
                    {
                        qx = 0;
                        OpenFileDialog upf = new OpenFileDialog();
                        upf.Filter = "激活文件(keygen)|*.keygen";
                        upf.ShowDialog();
                        string path = upf.FileName;
                        if (File.Exists(@"C:\ProgramData\ShuaX3\Key\"))
                        {
                            StreamReader aauti = new StreamReader(path);
                            string zaw = aauti.ReadLine();
                            string zad = "YjclCvklrNmXaFXz5WSP4nNKx";
                            if (zaw == zad)
                            {
                                MessageBox.Show("激活成功!" + "\r\n" + "感谢购买!", "成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                qx = 1;
                                File.Copy(path, @"C:\ProgramData\ShuaX3\Key\Yes.Keygen", true);
                                Process aru = new Process();
                                aru.StartInfo.FileName = Application.ExecutablePath;
                                aru.Start();
                                Environment.Exit(0);
                            }
                            else
                            {
                                MessageBox.Show("这不是一个有效的激活文件!", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                try
                                {
                                    Directory.Delete(@"C:\ProgramData\ShuaX3");
                                    qx = 0;
                                }
                                catch
                                {

                                }
                            }
                            auti.Close();
                        }
                        else
                        {
                            StreamReader auati = new StreamReader(path);
                            string zew = auati.ReadLine();
                            string zed = "YjclCvklrNmXaFXz5WSP4nNKx";
                            if (zew == zed)
                            {
                                auti.Close();
                                Directory.CreateDirectory(@"C:\ProgramData\ShuaX3\Key\");
                                File.Copy(path, @"C:\ProgramData\ShuaX3\Key\Yes.Keygen", true);
                                MessageBox.Show("激活成功!" + "\r\n" + "感谢购买!", "成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                qx = 1;
                                File.Copy(path, @"C:\ProgramData\ShuaX3\Key\Yes.Keygen", true);
                                Process aru = new Process();
                                aru.StartInfo.FileName = Application.ExecutablePath;
                                aru.Start();
                                Environment.Exit(0);
                            }
                            else
                            {
                                MessageBox.Show("这不是一个有效的激活文件!", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                try
                                {
                                    Directory.Delete(@"C:\ProgramData\ShuaX3");
                                    qx = 0;
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                    auti.Close();
                }
                else
                {
                    qx = 0;
                    if (MessageBox.Show("您的产品尚未激活!" + "\r\n" + "是否现在激活?", "激活产品", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        OpenFileDialog upf = new OpenFileDialog();
                        upf.Filter = "激活文件(keygen)|*.keygen";
                        upf.ShowDialog();
                        string path = upf.FileName;
                        if (File.Exists(@"C:\ProgramData\ShuaX3\Key\"))
                        {
                            StreamReader auti = new StreamReader(path);
                            string zw = auti.ReadLine();
                            string zd = "YjclCvklrNmXaFXz5WSP4nNKx";
                            if (zw == zd)
                            {
                                MessageBox.Show("激活成功!" + "\r\n" + "感谢购买!", "成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                qx = 1;
                                File.Copy(path, @"C:\ProgramData\ShuaX3\Key\Yes.Keygen", true);
                                Process aru = new Process();
                                aru.StartInfo.FileName = Application.ExecutablePath;
                                aru.Start();
                                Environment.Exit(0);
                            }
                            else
                            {
                                MessageBox.Show("这不是一个有效的激活文件!", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                try
                                {
                                    Directory.Delete(@"C:\ProgramData\ShuaX3");
                                    qx = 0;
                                }
                                catch
                                {

                                }
                            }
                            auti.Close();
                        }
                        else
                        {
                            StreamReader auti = new StreamReader(path);
                            string zw = auti.ReadLine();
                            string zd = "YjclCvklrNmXaFXz5WSP4nNKx";
                            if (zw == zd)
                            {
                                auti.Close();
                                Directory.CreateDirectory(@"C:\ProgramData\ShuaX3\Key\");
                                File.Copy(path, @"C:\ProgramData\ShuaX3\Key\Yes.Keygen", true);
                                MessageBox.Show("激活成功!" + "\r\n" + "感谢购买!", "成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                qx = 1;
                                File.Copy(path, @"C:\ProgramData\ShuaX3\Key\Yes.Keygen", true);
                                Process aru = new Process();
                                aru.StartInfo.FileName = Application.ExecutablePath;
                                aru.Start();
                                Environment.Exit(0);
                            }
                            else
                            {
                                MessageBox.Show("这不是一个有效的激活文件!", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                try
                                {
                                    Directory.Delete(@"C:\ProgramData\ShuaX3");
                                    qx = 0;
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }
            }
            catch
            {

            }            
        }

        private void 取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出程序？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Environment.Exit(0);
            }
        }

        TextBox t1 = new TextBox();
        Form az = new Form();
        FlowLayoutPanel fl2 = new FlowLayoutPanel();
        Button ru = new Button();

        private void 添加账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (qx == 1)
            {
                az.Width = 300;
                az.Height = 200;
                az.StartPosition = FormStartPosition.CenterScreen;
                az.Icon = soce.favicon_20190501082203512;

                fl2.Dock = DockStyle.Fill;

                ru.Text = "添加...";
                ru.Click += rCli;

                az.Controls.Add(fl2);
                fl2.Controls.Add(t1);
                fl2.Controls.Add(ru);

                az.ShowDialog();
            }
            else
            {
                MessageBox.Show("请先激活程序!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rCli(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection app = config.AppSettings;
            app.Settings["zh"].Value = t1.Text.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            Close();
            Process aru = new Process();
            aru.StartInfo.FileName = Application.ExecutablePath;
            aru.Start();
            Environment.Exit(0);
        }

        private void 配置文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process m_Process = new Process();
            string selfPath = Application.StartupPath;
            string helpPath = selfPath + @"\刷刷刷.exe.config";
            m_Process.StartInfo.FileName = helpPath;
            m_Process.Start();
        }

        private void 多刷模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process sP = new Process();
            sP.StartInfo.FileName = Application.ExecutablePath;
            sP.Start();
        }

        private void 清除账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string zh = ConfigurationManager.AppSettings["zh"].ToString();
            if (zh != "none")
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection app = config.AppSettings;
                app.Settings["zh"].Value = "none";
                config.Save(ConfigurationSaveMode.Modified);
                MessageBox.Show("清除成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Process aru = new Process();
                aru.StartInfo.FileName = Application.ExecutablePath;
                aru.Start();
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("源位置无账号，您尚未添加!" + "\r\n" + "重置账号信息为:none", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        
        Timer t2 = new Timer();

        private void 账号安全性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t2.Interval = 1000;
            t2.Tick += T2_Tick;
            t2.Enabled = true;
        }

        private void T2_Tick(object sender, EventArgs e)
        {
            t2.Enabled = false;
            string zh = ConfigurationManager.AppSettings["zh"].ToString();
            if (zh != "none")
            {
                string ad = "无封禁及盗号危险存在!(Highest)";
                MessageBox.Show("账号:" + "\r\n" + zh + "\r\n" + "您的账户的安全等级为:" + "\r\n" + ad, "反馈", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("您尚未添加账号，是否现在添加？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    if (qx == 1)
                    {
                        az.Width = 300;
                        az.Height = 200;
                        az.StartPosition = FormStartPosition.CenterScreen;
                        az.Icon = soce.favicon_20190501082203512;

                        fl2.Dock = DockStyle.Fill;

                        ru.Text = "添加...";
                        ru.Click += rCli;

                        az.Controls.Add(fl2);
                        fl2.Controls.Add(t1);
                        fl2.Controls.Add(ru);

                        az.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("请先激活程序!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
            }
        }

        private void 注册产品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog upf = new OpenFileDialog();
                upf.Filter = "激活文件(keygen)|*.keygen";
                upf.ShowDialog();
                string path = upf.FileName;
                if (File.Exists(@"C:\ProgramData\ShuaX3\Key\"))
                {
                    StreamReader auti = new StreamReader(path);
                    string zw = auti.ReadLine();
                    string zd = "YjclCvklrNmXaFXz5WSP4nNKx";
                    if (zw == zd)
                    {
                        MessageBox.Show("激活成功!" + "\r\n" + "感谢购买!", "成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        qx = 1;
                        File.Copy(path, @"C:\ProgramData\ShuaX3\Key\Yes.Keygen", true);
                        Process aru = new Process();
                        aru.StartInfo.FileName = Application.ExecutablePath;
                        aru.Start();
                        Environment.Exit(0);
                    }
                    else
                    {
                        MessageBox.Show("这不是一个有效的激活文件!", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        try
                        {
                            Directory.Delete(@"C:\ProgramData\ShuaX3");
                            qx = 0;
                        }
                        catch
                        {

                        }
                    }
                    auti.Close();
                }
                else
                {
                    StreamReader auti = new StreamReader(path);
                    string zw = auti.ReadLine();
                    string zd = "YjclCvklrNmXaFXz5WSP4nNKx";
                    if (zw == zd)
                    {
                        auti.Close();
                        Directory.CreateDirectory(@"C:\ProgramData\ShuaX3\Key\");
                        File.Copy(path, @"C:\ProgramData\ShuaX3\Key\Yes.Keygen", true);
                        MessageBox.Show("激活成功!" + "\r\n" + "感谢购买!", "成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        qx = 1;
                        File.Copy(path, @"C:\ProgramData\ShuaX3\Key\Yes.Keygen", true);
                        Process aru = new Process();
                        aru.StartInfo.FileName = Application.ExecutablePath;
                        aru.Start();
                        Environment.Exit(0);
                    }
                    else
                    {
                        MessageBox.Show("这不是一个有效的激活文件!", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        try
                        {
                            Directory.Delete(@"C:\ProgramData\ShuaX3");
                            qx = 0;
                        }
                        catch
                        {

                        }
                    }
                }
            }
            catch
            {

            }            
        }

        private void 连接服务器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("服务器连接是正常的!", "检查", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 账号属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t2.Interval = 1000;
            t2.Tick += T2_Tick;
            t2.Enabled = true;
        }

        private void 在线购买产品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form uit = new Form();
            uit.StartPosition = FormStartPosition.CenterScreen;
            uit.Width = 500;
            uit.Height = 600;
            uit.Text = "购买产品";
            uit.Icon = soce.favicon_20190501082203512;
            uit.BackColor = Color.White;
            uit.BackgroundImage = soce.Buy64;
            uit.BackgroundImageLayout = ImageLayout.Zoom;

            uit.ShowDialog();
        }

        private void 我的刷刷刷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about cu = new about();
            cu.Icon = soce.favicon_20190501082203512;
            cu.StartPosition = FormStartPosition.CenterScreen;
            cu.Show();
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process m_Process = new Process();
                string selfPath = Application.StartupPath;
                string helpPath = selfPath + @"\bin\help.txt";
                m_Process.StartInfo.FileName = helpPath;
                m_Process.Start();
            }
            catch
            {

            }            
        }

        private void 声明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process m_Process = new Process();
                string selfPath = Application.StartupPath;
                string helpPath = selfPath + @"\bin\readme.txt";
                m_Process.StartInfo.FileName = helpPath;
                m_Process.Start();
            }
            catch
            {

            }            
        }

        private void 首选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("注册表文件丢失!" + "\r\n" + "重新安装程序或许能解决这个问题。", "首选项无法打开!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}