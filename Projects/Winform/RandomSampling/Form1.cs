using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
// 下载于www.mycodes.net
namespace 随机点名
{
    public partial class Form1 : Form
    {
        List<string> users = new List<string>();
        List<Label> labels1 = new List<Label>();
        List<Label> labels2 = new List<Label>();
        List<Label> labels3 = new List<Label>();

        Point point1 = new Point(210,60);
        Point point2 = new Point(210,290);
        Point point3 = new Point(210, 500);

        int x = 130;
        int y = 40;
        public Form1()
        {
            InitializeComponent();
            string content = "";
            using (StreamReader sr = new StreamReader(Application.StartupPath + @"\data.txt"))
            {
                content = sr.ReadToEnd();
                sr.Close();
            }
            string[] list = content.Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (string name in list)
            {
                if (string.IsNullOrEmpty(name.Trim()) == false)
                    users.Add(name.Trim());
            }
            listBox1.Items.Clear();
            foreach (string name in users)
                listBox1.Items.Add(name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (Int32.TryParse(textBox1.Text, out count) == false)
                count = 0;
            if (count == 0 || count > users.Count)
            {
                MessageBox.Show("参数有误");
                return;
            }

            Thread thread = new Thread(Run1);
            thread.Start();
        }

        private void Run1() {
            int count = 0;
            if (Int32.TryParse(textBox1.Text, out count) == false)
                count = 0;
            for (int i = 0; i < count; i++)
            {
                string name = GetRandName(0);
                if (string.IsNullOrEmpty(name) == false)
                {
                    users.Remove(name);
                    this.Invoke(new EventHandler(delegate { listBox1.Items.Remove(name); }));
                    SetLabelPosition1(name);
                }
                Thread.Sleep(1000);
            }
        }

        private string GetRandName(int key) {
            string name = "";
            if (users.Count > 1)
            {
                int randcount = 0;
                while (randcount < 60)
                {
                    int index = new Random().Next(1, users.Count);
                    name = users[index - 1];
                    randcount = randcount + 1;
                    if(key ==0)
                        this.Invoke(new EventHandler(delegate { label3.Text = name; }));
                    else if (key == 1)
                        this.Invoke(new EventHandler(delegate { label4.Text = name; }));
                    else if (key == 2)
                        this.Invoke(new EventHandler(delegate { label7.Text = name; }));
                    Thread.Sleep(10);
                }
            }
            else {
                name = users[0];
            }
            return name;
        }

        private void SetLabelPosition1(string name)
        {
            Label label = new Label();
            label.ForeColor = Color.Red;
            Font font = new System.Drawing.Font("宋体", 17, FontStyle.Bold);
            label.Font = font;
            label.Text = name;
            label.Location = new Point(point1.X + 130 * (labels1.Count%6), point1.Y+y*(labels1.Count/6));
            this.Invoke(new EventHandler(delegate { this.Controls.Add(label); }));
            labels1.Add(label);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (Int32.TryParse(textBox2.Text, out count) == false)
                count = 0;
            if (count == 0 || count > users.Count)
            {
                MessageBox.Show("参数有误");
                return;
            }
            Thread thread = new Thread(Run2);
            thread.Start();

        }

        private void Run2()
        {
            int count = 0;
            if (Int32.TryParse(textBox2.Text, out count) == false)
                count = 0;

            for (int i = 0; i < count; i++)
            {
                string name = GetRandName(1);
                if (string.IsNullOrEmpty(name) == false)
                {
                    users.Remove(name);
                    this.Invoke(new EventHandler(delegate { listBox1.Items.Remove(name); }));
                    SetLabelPosition2(name);
                }
                Thread.Sleep(1000);
            }
        }

        private void SetLabelPosition2(string name)
        {
            Label label = new Label();
            label.ForeColor = Color.Red;
            Font font = new System.Drawing.Font("宋体", 17, FontStyle.Bold);
            label.Font = font;
            label.Text = name;
            label.Location = new Point(point2.X + 130 * (labels2.Count % 6), point2.Y + y * (labels2.Count / 6));
            this.Invoke(new EventHandler(delegate { this.Controls.Add(label); }));
            labels2.Add(label);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string txt = "";
            foreach (Label label in labels1)
            {
                txt += label.Text + "\r\n";
            }
            txt = txt.Trim();
            using (StreamWriter sw = new StreamWriter(Application.StartupPath + @"\names1.txt"))
            {
                sw.Write(txt);
                sw.Close();
            }
            txt = "";
            foreach (Label label in labels2)
            {
                txt += label.Text + "\r\n";
            }
            txt = txt.Trim();
            using (StreamWriter sw = new StreamWriter(Application.StartupPath + @"\names2.txt"))
            {
                sw.Write(txt);
                sw.Close();
            }
            txt = "";
            foreach (Label label in labels3)
            {
                txt += label.Text + "\r\n";
            }
            txt = txt.Trim();
            using (StreamWriter sw = new StreamWriter(Application.StartupPath + @"\names3.txt"))
            {
                sw.Write(txt);
                sw.Close();
            }
            MessageBox.Show("保存成功");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (Int32.TryParse(textBox3.Text, out count) == false)
                count = 0;
            if (count == 0 || count > users.Count)
            {
                MessageBox.Show("参数有误");
                return;
            }
            Thread thread = new Thread(Run3);
            thread.Start();
        }

        private void SetLabelPosition3(string name)
        {
            Label label = new Label();
            label.ForeColor = Color.Red;
            Font font = new System.Drawing.Font("宋体", 17, FontStyle.Bold);
            label.Font = font;
            label.Text = name;
            label.Location = new Point(point3.X + 130 * (labels3.Count % 6), point3.Y + y * (labels3.Count / 6));
            this.Invoke(new EventHandler(delegate { this.Controls.Add(label); }));
            labels3.Add(label);
        }
        private void Run3()
        {
            int count = 0;
            if (Int32.TryParse(textBox3.Text, out count) == false)
                count = 0;

            for (int i = 0; i < count; i++)
            {
                string name = GetRandName(2);
                if (string.IsNullOrEmpty(name) == false)
                {
                    users.Remove(name);
                    this.Invoke(new EventHandler(delegate { listBox1.Items.Remove(name); }));
                    SetLabelPosition3(name);
                }
                Thread.Sleep(1000);
            }
        }

    }
}
