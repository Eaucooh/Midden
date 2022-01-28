using System;
using System.Windows.Forms;

namespace 刷刷刷
{
    public partial class startup : Form
    {
        public startup()
        {
            InitializeComponent();
        }

        private void Startup_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            timer1.Enabled = true;
            timer1.Interval = 3000;
            progressBar1.Value = 86;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = 100;
            timer1.Enabled = false;
            button1.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
