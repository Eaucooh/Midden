using System;
using System.Windows.Forms;

namespace 小沙记事本
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_SizeChanged(object sender, EventArgs e)
        {
            Width = 750;
            Height = 430;
        }

        int times = 0;

        private void Form3_Load(object sender, EventArgs e)
        {
            if (times == 0)
            {
                Opacity = 0;
                timer1.Enabled = true;
                timer1.Interval = 100;
                times = times + 1;
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (times == 1)
            {
                if (Opacity == 100)
                {
                    return;
                }
                else
                {
                    Opacity = Opacity + 1;
                }
                timer2.Enabled = true;
                timer2.Interval = 100;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            timer1.Enabled = true;
            timer1.Interval = 100;
        }
    }
}
