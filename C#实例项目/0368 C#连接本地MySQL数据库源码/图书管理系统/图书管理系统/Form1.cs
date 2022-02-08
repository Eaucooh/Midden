using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 图书管理系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogInlinkLabel.LinkVisited = true;
            Form logIn = new LogIn(this);
            logIn.Show();
            this.Hide();
            
        }

        private void SignInlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignInlinkLabel.LinkVisited = true;
            Form signIn = new SignIn(this);
            signIn.Show();
            this.Hide();
        }

        private void UnsubscribelinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UnsubscribelinkLabel.LinkVisited = true;
            Form unsubscribe = new Unsubscribe(this);
            unsubscribe.Show();
            this.Hide();
        }
    }
}
