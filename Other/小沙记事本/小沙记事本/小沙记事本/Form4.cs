using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace 小沙记事本
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_SizeChanged(object sender, EventArgs e)
        {
            Width = 450;
            Height = 500;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取当前应用程序的路径
            string localPath = Application.ExecutablePath;
            if (!System.IO.File.Exists(localPath))//判断指定文件是否存在
                return;
            RegistryKey reg = Registry.LocalMachine;
            RegistryKey run = reg.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            //判断注册表中是否存在当前名称和值
            if (run.GetValue("ControlPanasonic.exe") == null)
            {
                try
                {
                    run.SetValue("ControlPanasonic.exe", localPath);
                    MessageBox.Show("小沙记事本已成功写入注册表！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reg.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.LocalMachine;
            RegistryKey run = reg.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            try
            {
                run.DeleteValue("ControlPanasonic.exe");
                MessageBox.Show("小沙记事本已成功从注册表中删除！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reg.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
