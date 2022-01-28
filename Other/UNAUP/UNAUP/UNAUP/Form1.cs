using System;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace UNAUP
{
    public partial class Form : System.Windows.Forms.Form
    {
        public int quanxian = 0;

        public Form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Configuration version = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string lv = version.AppSettings.Settings["version"].Value.ToString();
            label14.Text = "版本号："+lv;
            Width = 331;
            Height = 521;
            this.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            this.Icon = Used.bitbug_favicon_10_;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string str = config.AppSettings.Settings["ut"].Value.ToString();
            if (str.Equals("f"))
            {
                panel2.Visible = true;
            }
            else if (str.Equals("t"))
            {
                panel1.Visible = true;
            }

            Configuration config11 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string yun = config11.AppSettings.Settings["un"].Value.ToString();
            string yup = config11.AppSettings.Settings["up"].Value.ToString();
            string zjzlm = config11.AppSettings.Settings["jz"].Value.ToString();
            if (zjzlm.Equals("y"))
            {
                textBox1.Text = yun;
                textBox2.Text = yup;
                radioButton1.Checked = true;
            }
            else if (zjzlm.Equals("n"))
            {
                textBox1.Text = "";
                textBox2.Text = "";
                radioButton1.Checked = false;
            }
        }

        public int a;

        private void button2_Click(object sender, EventArgs e)
        {
            
            string un = textBox3.Text;
            string up = textBox4.Text;
            string usp = textBox5.Text;
            bool su = radioButton2.Checked;
            if (su == true)
            {
                a = 1;
            }
            else if (su == false)
            {
                a = 0;
            }
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config1.AppSettings.Settings["un"].Value = un;
            config1.AppSettings.Settings["up"].Value = up;
            config1.AppSettings.Settings["usp"].Value = usp;
            config1.AppSettings.Settings["ut"].Value = "t";
            config1.Save(ConfigurationSaveMode.Full);
            MessageBox.Show("用户创建成功");
            if (a == 1)
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;
            }
            else if (a == 0)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Configuration config12 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            bool sfjz = radioButton1.Checked;
            if (sfjz == true)
            {
                config12.AppSettings.Settings["jz"].Value = "y";
                config12.Save(ConfigurationSaveMode.Full);
            }
            else if (sfjz == false)
            {
                config12.AppSettings.Settings["jz"].Value = "n";
                config12.Save(ConfigurationSaveMode.Full);
            }
            string nun = textBox1.Text;
            string nup = textBox2.Text;
            Configuration config2 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string tun = config2.AppSettings.Settings["un"].Value.ToString();
            string tup = config2.AppSettings.Settings["up"].Value.ToString();
            if (nun.Equals(tun) && nup.Equals(tup))
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else if (nun != (tun) || nup != (tup))
            {
                MessageBox.Show("用户名或密码输入错误","无法登陆",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            Configuration CFPBG = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string a1 = CFPBG.AppSettings.Settings["a1"].Value.ToString();
            string a2 = CFPBG.AppSettings.Settings["a2"].Value.ToString();
            string b1 = CFPBG.AppSettings.Settings["b1"].Value.ToString();
            string b2 = CFPBG.AppSettings.Settings["b2"].Value.ToString();
            string c1 = CFPBG.AppSettings.Settings["c1"].Value.ToString();
            string c2 = CFPBG.AppSettings.Settings["c2"].Value.ToString();
            string d1 = CFPBG.AppSettings.Settings["d1"].Value.ToString();
            string d2 = CFPBG.AppSettings.Settings["d2"].Value.ToString();
            string e1 = CFPBG.AppSettings.Settings["e1"].Value.ToString();
            string e2 = CFPBG.AppSettings.Settings["e2"].Value.ToString();
            string f1 = CFPBG.AppSettings.Settings["f1"].Value.ToString();
            string f2 = CFPBG.AppSettings.Settings["f2"].Value.ToString();
            string g1 = CFPBG.AppSettings.Settings["g1"].Value.ToString();
            string g2 = CFPBG.AppSettings.Settings["g2"].Value.ToString();
            string h1 = CFPBG.AppSettings.Settings["h1"].Value.ToString();
            string h2 = CFPBG.AppSettings.Settings["h2"].Value.ToString();
            string i1 = CFPBG.AppSettings.Settings["i1"].Value.ToString();
            string i2 = CFPBG.AppSettings.Settings["i2"].Value.ToString();
            string j1 = CFPBG.AppSettings.Settings["j1"].Value.ToString();
            string j2 = CFPBG.AppSettings.Settings["j2"].Value.ToString();
            string k1 = CFPBG.AppSettings.Settings["k1"].Value.ToString();
            string k2 = CFPBG.AppSettings.Settings["k2"].Value.ToString();
            string l1 = CFPBG.AppSettings.Settings["l1"].Value.ToString();
            string l2 = CFPBG.AppSettings.Settings["l2"].Value.ToString();
            string mn = "";
            if (a1 != mn && a2 != mn)
            {
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = a1;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = a2;
            }
            if (b1 != mn && b2 != mn)
            {
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = b1;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = b2;
            }
            if (c1 != mn && c2 != mn)
            {
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = c1;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = c2;
            }
            if (d1 != mn && d2 != mn)
            {
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = d1;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = d2;
            }
            if (e1 != mn && e2 != mn)
            {
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = e1;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = e2;
            }
            if (f1 != mn && f2 != mn)
            {
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = f1;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = f2;
            }
            if (g1 != mn && g2 != mn)
            {
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = g1;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = g2;
            }
            if (h1 != mn && h2 != mn)
            {
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = h1;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = h2;
            }
            if (i1 != mn && i2 != mn)
            {
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = i1;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = i2;
            }
            if (j1 != mn && j2 != mn)
            {
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = j1;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = j2;
            }
            if (k1 != mn && k2 != mn)
            {
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = k1;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = k2;
            }
            if (l1 != mn && l2 != mn)
            {
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = l1;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = l2;
            }
        }

        private void 删除该用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (quanxian == 1)
            {
                if (MessageBox.Show("您确认要删除该用户的信息吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Configuration config3 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config3.AppSettings.Settings["un"].Value = "";
                    config3.AppSettings.Settings["up"].Value = "";
                    config3.AppSettings.Settings["usp"].Value = "";
                    config3.AppSettings.Settings["ut"].Value = "f";
                    config3.Save(ConfigurationSaveMode.Full);
                    panel1.Visible = false;
                    panel2.Visible = true;
                    panel3.Visible = false;
                    Application.Exit();
                    System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                }
            }
            else if (quanxian == 0)
            {
                MessageBox.Show("您无法查看，请先获取最高权限", "无权限", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 添加一个组件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void 导出该用户登录密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (quanxian == 1)
            {
                Configuration config4 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string ds = config4.AppSettings.Settings["pd"].Value.ToString();
                if (ds.Equals("0"))
                {
                    Configuration config5 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    string tun = config5.AppSettings.Settings["un"].Value.ToString();
                    string tup = config5.AppSettings.Settings["up"].Value.ToString();
                    string data = DateTime.Now.ToString();
                    string path = @"D:\Password.txt";
                    if (!File.Exists(path))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine("用户名:" + tun + ";用户密码:" + tup + ";" + "导出日期:" + data + ";");
                        }
                    }
                    config5.AppSettings.Settings["pd"].Value = "1";
                    config5.Save(ConfigurationSaveMode.Full);
                }
                else if (ds.Equals("1"))
                {
                    Configuration config6 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    string tun = config6.AppSettings.Settings["un"].Value.ToString();
                    string tup = config6.AppSettings.Settings["up"].Value.ToString();
                    string data = DateTime.Now.ToString();
                    File.AppendAllText(@"D:\Password.txt", "用户名:" + tun + ";用户密码:" + tup + ";" + "导出日期:" + data + ";");
                }
            }
            else if (quanxian == 0)
            {
                MessageBox.Show("您无法查看，请先获取最高权限", "无权限", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int sui = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            if (sui == 0)
            {
                Width = 331;
                Height = 774;
                sui = 1;
            }
            else if (sui == 1)
            {
                Width = 331;
                Height = 711;
                sui = 0;
            }            
        }

        public int iop = 0;

        private void button4_Click(object sender, EventArgs e)
        {
            if (iop == 0)
            {
                Width = 331;
                Height = 635;
                iop = 1;
            }
            else if (iop == 1)
            {
                Width = 331;
                Height = 521;
                iop = 0;
            }
        }

        public int aisudf = 0;
        public int cishu = 0;

        private void button6_Click(object sender, EventArgs e)
        {
            Configuration CFP = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cishu = cishu + 1;
            if(cishu==1)
            {
                string zz = textBox6.Text;
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = zz;
                string password = textBox7.Text;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = password;
                textBox6.Text = "";
                textBox7.Text = "";
                aisudf = 1;
                CFP.AppSettings.Settings["a1"].Value = zz;
                CFP.AppSettings.Settings["a2"].Value = password;
                CFP.Save(ConfigurationSaveMode.Full);
            }
            if (cishu == 2)
            {
                string zz = textBox6.Text;
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = zz;
                string password = textBox7.Text;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = password;
                textBox6.Text = "";
                textBox7.Text = "";
                aisudf = 1;
                CFP.AppSettings.Settings["b1"].Value = zz;
                CFP.AppSettings.Settings["b2"].Value = password;
                CFP.Save(ConfigurationSaveMode.Full);
            }
            if (cishu == 3)
            {
                string zz = textBox6.Text;
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = zz;
                string password = textBox7.Text;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = password;
                textBox6.Text = "";
                textBox7.Text = "";
                aisudf = 1;
                CFP.AppSettings.Settings["c1"].Value = zz;
                CFP.AppSettings.Settings["c2"].Value = password;
                CFP.Save(ConfigurationSaveMode.Full);
            }
            if (cishu == 4)
            {
                string zz = textBox6.Text;
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = zz;
                string password = textBox7.Text;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = password;
                textBox6.Text = "";
                textBox7.Text = "";
                aisudf = 1;
                CFP.AppSettings.Settings["d1"].Value = zz;
                CFP.AppSettings.Settings["d2"].Value = password;
                CFP.Save(ConfigurationSaveMode.Full);
            }
            if (cishu == 5)
            {
                string zz = textBox6.Text;
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = zz;
                string password = textBox7.Text;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = password;
                textBox6.Text = "";
                textBox7.Text = "";
                aisudf = 1;
                CFP.AppSettings.Settings["e1"].Value = zz;
                CFP.AppSettings.Settings["e2"].Value = password;
                CFP.Save(ConfigurationSaveMode.Full);
            }
            if (cishu == 6)
            {
                string zz = textBox6.Text;
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = zz;
                string password = textBox7.Text;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = password;
                textBox6.Text = "";
                textBox7.Text = "";
                aisudf = 1;
                CFP.AppSettings.Settings["f1"].Value = zz;
                CFP.AppSettings.Settings["f2"].Value = password;
                CFP.Save(ConfigurationSaveMode.Full);
            }
            if (cishu == 7)
            {
                string zz = textBox6.Text;
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = zz;
                string password = textBox7.Text;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = password;
                textBox6.Text = "";
                textBox7.Text = "";
                aisudf = 1;
                CFP.AppSettings.Settings["g1"].Value = zz;
                CFP.AppSettings.Settings["g2"].Value = password;
                CFP.Save(ConfigurationSaveMode.Full);
            }
            if (cishu == 8)
            {
                string zz = textBox6.Text;
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = zz;
                string password = textBox7.Text;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = password;
                textBox6.Text = "";
                textBox7.Text = "";
                aisudf = 1;
                CFP.AppSettings.Settings["h1"].Value = zz;
                CFP.AppSettings.Settings["h2"].Value = password;
                CFP.Save(ConfigurationSaveMode.Full);
            }
            if (cishu == 9)
            {
                string zz = textBox6.Text;
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = zz;
                string password = textBox7.Text;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = password;
                textBox6.Text = "";
                textBox7.Text = "";
                aisudf = 1;
                CFP.AppSettings.Settings["i1"].Value = zz;
                CFP.AppSettings.Settings["i2"].Value = password;
                CFP.Save(ConfigurationSaveMode.Full);
            }
            if (cishu == 10)
            {
                string zz = textBox6.Text;
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = zz;
                string password = textBox7.Text;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = password;
                textBox6.Text = "";
                textBox7.Text = "";
                aisudf = 1;
                CFP.AppSettings.Settings["j1"].Value = zz;
                CFP.AppSettings.Settings["j2"].Value = password;
                CFP.Save(ConfigurationSaveMode.Full);
            }
            if (cishu == 11)
            {
                string zz = textBox6.Text;
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = zz;
                string password = textBox7.Text;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = password;
                textBox6.Text = "";
                textBox7.Text = "";
                aisudf = 1;
                CFP.AppSettings.Settings["k1"].Value = zz;
                CFP.AppSettings.Settings["k2"].Value = password;
                CFP.Save(ConfigurationSaveMode.Full);
            }
            if (cishu == 12)
            {
                string zz = textBox6.Text;
                TextBox z = new TextBox();
                flowLayoutPanel1.Controls.Add(z);
                z.ReadOnly = true;
                z.Text = zz;
                string password = textBox7.Text;
                TextBox p = new TextBox();
                flowLayoutPanel1.Controls.Add(p);
                p.ReadOnly = true;
                p.Text = password;
                textBox6.Text = "";
                textBox7.Text = "";
                aisudf = 1;
                CFP.AppSettings.Settings["l1"].Value = zz;
                CFP.AppSettings.Settings["l2"].Value = password;
                CFP.Save(ConfigurationSaveMode.Full);
            }            
            if (cishu >= 13)
            {
                MessageBox.Show("密码组存储最多12组，您可以安装另一个密码管理大师", "无权限", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 查看该用户登录密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (quanxian == 1)
            {
                Configuration config7 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string tun = config7.AppSettings.Settings["un"].Value.ToString();
                string tup = config7.AppSettings.Settings["up"].Value.ToString();
                string data = DateTime.Now.ToString();
                string path = @"D:\Password.txt";
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("用户名:" + tun + ";用户密码:" + tup + ";" + "导出日期:" + data + ";");
                    }
                }
                System.Diagnostics.Process.Start(path);
            }
            else if (quanxian == 0)
            {
                MessageBox.Show("您无法查看，请先获取最高权限", "无权限", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 删除本地文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration config8 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string darts = config8.AppSettings.Settings["pd"].Value.ToString();
            if (darts.Equals("1"))
            {
                File.Delete(@"D:\Password.txt");
                config8.AppSettings.Settings["pd"].Value = "1";
                config8.Save(ConfigurationSaveMode.Full);
                MessageBox.Show("删除成功");
            }
            else if (darts.Equals("0"))
            {
                MessageBox.Show("您尚未导出本地文件", "无法删除", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void 退出密码管理大师ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (aisudf == 1)
            {
                if (MessageBox.Show("您想要保存最后的更改吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Configuration config9 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    
                }
            }
        }

        private void 获取本次使用期间的最高权限ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (quanxian == 0)
            {
                Width = 331;
                Height = 711;
            }
            else if (quanxian == 1)
            {
                MessageBox.Show("您已经获取最高权限", "以获取权限", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Configuration config10 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string tsup = config10.AppSettings.Settings["usp"].Value.ToString();
            string sup = textBox8.Text;
            if (sup.Equals(tsup))
            {
                quanxian = 1;
                Width = 331;
                Height = 521;
                MessageBox.Show("您获取了权限", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("请检查您二级密码的正确性", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Configuration del = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string chbyus = textBox9.Text;
            if (chbyus.Equals("1"))
            {
                del.AppSettings.Settings["a1"].Value = "";
                del.AppSettings.Settings["a2"].Value = "";
                del.Save(ConfigurationSaveMode.Full);
            }
            else if (chbyus.Equals("2"))
            {
                del.AppSettings.Settings["b1"].Value = "";
                del.AppSettings.Settings["b2"].Value = "";
                del.Save(ConfigurationSaveMode.Full);
            }
            else if (chbyus.Equals("3"))
            {
                del.AppSettings.Settings["c1"].Value = "";
                del.AppSettings.Settings["c2"].Value = "";
                del.Save(ConfigurationSaveMode.Full);
            }
            else if (chbyus.Equals("4"))
            {
                del.AppSettings.Settings["d1"].Value = "";
                del.AppSettings.Settings["d2"].Value = "";
                del.Save(ConfigurationSaveMode.Full);
            }
            else if (chbyus.Equals("5"))
            {
                del.AppSettings.Settings["e1"].Value = "";
                del.AppSettings.Settings["e2"].Value = "";
                del.Save(ConfigurationSaveMode.Full);
            }
            else if (chbyus.Equals("6"))
            {
                del.AppSettings.Settings["f1"].Value = "";
                del.AppSettings.Settings["f2"].Value = "";
                del.Save(ConfigurationSaveMode.Full);
            }
            else if (chbyus.Equals("7"))
            {
                del.AppSettings.Settings["g1"].Value = "";
                del.AppSettings.Settings["g2"].Value = "";
                del.Save(ConfigurationSaveMode.Full);
            }
            else if (chbyus.Equals("8"))
            {
                del.AppSettings.Settings["h1"].Value = "";
                del.AppSettings.Settings["h2"].Value = "";
                del.Save(ConfigurationSaveMode.Full);
            }
            else if (chbyus.Equals("9"))
            {
                del.AppSettings.Settings["i1"].Value = "";
                del.AppSettings.Settings["i2"].Value = "";
                del.Save(ConfigurationSaveMode.Full);
            }
            else if (chbyus.Equals("10"))
            {
                del.AppSettings.Settings["j1"].Value = "";
                del.AppSettings.Settings["j2"].Value = "";
                del.Save(ConfigurationSaveMode.Full);
            }
            else if (chbyus.Equals("11"))
            {
                del.AppSettings.Settings["k1"].Value = "";
                del.AppSettings.Settings["k2"].Value = "";
                del.Save(ConfigurationSaveMode.Full);
            }
            else if (chbyus.Equals("12"))
            {
                del.AppSettings.Settings["l1"].Value = "";
                del.AppSettings.Settings["l2"].Value = "";
                del.Save(ConfigurationSaveMode.Full);
            }
            else if (chbyus != ("1") || chbyus != ("2") || chbyus != ("3") || chbyus != ("4") || chbyus != ("5") || chbyus != ("6") || chbyus != ("7") || chbyus != ("8") || chbyus != ("9") || chbyus != ("10") || chbyus != ("11") || chbyus != ("12"))
            {
                MessageBox.Show("最多只有12组密码，亲", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //重启
            Application.Exit();
            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        private void 密码管理大师ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Width = 1299;
            Height = 774;
            panel7.Visible = true;
            panel9.Visible = false;
            panel10.Visible = false;
        }

        private void 创作组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Width = 1299;
            Height = 774;
            panel9.Visible = true;
            panel7.Visible = false;
            panel10.Visible = false;
        }

        private void 激活信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Width = 1299;
            Height = 774;
            panel7.Visible = false;
            panel9.Visible = false;
            panel10.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
            panel9.Visible = false;
            panel10.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 100;
            if (MessageBox.Show("有可用的新更新，需要安装吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("请检查您的网络连接，无法连接到服务器", "无网络连接", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            panel8.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            progressBar2.Value = 80;
            MessageBox.Show("请检查您的网络连接，无法连接到服务器", "无网络连接", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            progressBar2.Value = 0;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Width = 331;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
            panel7.Visible = false;
            panel10.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Configuration jhzt = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string tjhzt = jhzt.AppSettings.Settings["jihuo"].Value.ToString();
            if (tjhzt.Equals("n"))
            {
                panel7.Visible = false;
                panel9.Visible = false;
                panel10.Visible = true;
                panel11.Visible = true;
                panel12.Visible = false;
            }
            else if (tjhzt.Equals("y"))
            {
                panel7.Visible = false;
                panel9.Visible = false;
                panel10.Visible = true;
                panel11.Visible = false;
                panel12.Visible = true;
            }            
        }

        private void button17_Click(object sender, EventArgs e)
        {  
            string nsn = textBox10.Text;
            string nsp = textBox11.Text;
            string jnsp = nsn + "gan" + nsn + "xie" + nsn + "gou" + nsn + "mai" + nsn;
            if (nsn.Equals("") || nsp.Equals(""))
            {
                MessageBox.Show("请确认您填写的信息正确","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            if (nsp.Equals(jnsp))
            {
                richTextBox1.Text = "正在激活产品";
                //awdsjuhfgfszvde
                timer1.Enabled = true;
                timer1.Interval = 1000;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Configuration cji = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cji.AppSettings.Settings["jihuo"].Value = "y";
            cji.Save(ConfigurationSaveMode.Full);
            string infor = "激活成功";
            string fenge = "----------------------------------------------";
            string newfenge = fenge + Environment.NewLine;
            string newLine = infor + Environment.NewLine;
            // 将内容插入到第一行
            // 索引0是 richText1 第一行位置
            richTextBox1.Text = richTextBox1.Text.Insert(0, newfenge);
            richTextBox1.Text = richTextBox1.Text.Insert(0, newLine);
        }
        
        private void 重置密码大师ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //修改config
            Configuration cjier = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cjier.AppSettings.Settings["jihuo"].Value = "n";
            cjier.AppSettings.Settings["un"].Value = "";
            cjier.AppSettings.Settings["up"].Value = "";
            cjier.AppSettings.Settings["usp"].Value = "";
            cjier.AppSettings.Settings["pd"].Value = "";
            cjier.AppSettings.Settings["jz"].Value = "";
            cjier.AppSettings.Settings["ut"].Value = "f";

            cjier.AppSettings.Settings["a1"].Value = "";
            cjier.AppSettings.Settings["a2"].Value = "";
            cjier.AppSettings.Settings["b1"].Value = "";
            cjier.AppSettings.Settings["b2"].Value = "";
            cjier.AppSettings.Settings["c1"].Value = "";
            cjier.AppSettings.Settings["c2"].Value = "";
            cjier.AppSettings.Settings["d1"].Value = "";
            cjier.AppSettings.Settings["d2"].Value = "";
            cjier.AppSettings.Settings["e1"].Value = "";
            cjier.AppSettings.Settings["e2"].Value = "";
            cjier.AppSettings.Settings["f1"].Value = "";
            cjier.AppSettings.Settings["f2"].Value = "";
            cjier.AppSettings.Settings["g1"].Value = "";
            cjier.AppSettings.Settings["g2"].Value = "";
            cjier.AppSettings.Settings["h1"].Value = "";
            cjier.AppSettings.Settings["h2"].Value = "";
            cjier.AppSettings.Settings["i1"].Value = "";
            cjier.AppSettings.Settings["i2"].Value = "";
            cjier.AppSettings.Settings["j1"].Value = "";
            cjier.AppSettings.Settings["j2"].Value = "";
            cjier.AppSettings.Settings["k1"].Value = "";
            cjier.AppSettings.Settings["k2"].Value = "";
            cjier.AppSettings.Settings["l1"].Value = "";
            cjier.AppSettings.Settings["l2"].Value = "";
            cjier.Save(ConfigurationSaveMode.Full);
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
            panel7.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            Width = 331;
            Height = 521;
            Application.Exit();
            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}
