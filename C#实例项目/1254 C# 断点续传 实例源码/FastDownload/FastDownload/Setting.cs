using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FastDownload
{
    public partial class Setting : Form
    {
        
        public Setting()
        {
            InitializeComponent();
        }
        Set set = new Set();//创建系统设置类的对象
        private void Setting_Load(object sender, EventArgs e)
        {
            set.GetConfig();//获取设置信息
            if (Set.Start == "1")//判断是否开机自动启动
                cboxStart.Checked = true;
            else
                cboxStart.Checked = false;
            if (Set.Auto == "1")//判断是否自动开始未完成任务
                cboxAuto.Checked = true;
            else
                cboxAuto.Checked = false;
            txtPath.Text = Set.Path;//获取默认下载路径
            //显示默认下载路径的剩余空间
            lblSpace.Text = set.GetSpace(txtPath.Text.Substring(0, txtPath.Text.IndexOf("\\") + 1));
            if (Set.Net == "1")//判断网络限制
                cboxNet.Checked = true;
            else
                cboxNet.Checked = false;
            txtNet.Text = Set.NetValue;//获取网速限制值
            if (Set.DClose == "1")//判断是否下载完成自动关机
                cboxDClose.Checked = true;
            else
                cboxDClose.Checked = false;
            if (Set.TClose == "1")//判断是否定时关机
                cboxTClose.Checked = true;
            else
                cboxTClose.Checked = false;
            dtpickerTime.Text = Set.TCloseValue;//获取定时关机时间
            if (Set.SNotify == "1")//判断是否下载完成显示提示
                cboxSNotify.Checked = true;
            else
                cboxSNotify.Checked = false;
            if (Set.Play == "1")//判断是否下载完成播放提示音
                cboxPlay.Checked = true;
            else
                cboxPlay.Checked = false;
            if (Set.Continue == "1")//判断是否在有未完成的下载时显示继续提示
                cboxContinue.Checked = true;
            else
                cboxContinue.Checked = false;
            if (Set.ShowFlow == "1")//判断是否显示流量监控
                cboxShowFlow.Checked = true;
            else
                cboxShowFlow.Checked = false;
            btnSet_Click(sender, e);//显示常规设置选项卡
        }

        private void btnSet_Click(object sender, EventArgs e)//常规设置
        {
            gboxSet.Visible = true;//显示常规设置容器
            gboxSet.Dock = DockStyle.Fill;//设置常规设置容器填充窗体
            gboxDownload.Visible = gboxNotify.Visible = false;//隐藏下载设置和消息提醒容器
        }

        private void btnDownload_Click(object sender, EventArgs e)//下载设置
        {
            gboxDownload.Visible = true;//显示下载设置容器
            gboxDownload.Dock = DockStyle.Fill;//设置下载设置容器填充窗体
            gboxSet.Visible = gboxNotify.Visible = false;//隐藏常规设置和消息提醒容器
        }

        private void btnNotify_Click(object sender, EventArgs e)//消息提醒
        {
            gboxNotify.Visible = true;//显示消息提醒容器
            gboxNotify.Dock = DockStyle.Fill;//设置消息提醒容器填充窗体
            gboxDownload.Visible = gboxSet.Visible = false;//隐藏常规设置和下载设置容器
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //定义变量，用来存储INI配置文件中的相应值
            string start,auto,path,net, dclose,tclose, snotify,play,contin, showflow;
            //记录是否开机自动启动
            if (cboxStart.Checked)
                start = "1";
            else
                start = "0";
            set.AutoRun(Set.Start);//设置开机启动
            //记录是否自动开始未完成任务
            if (cboxAuto.Checked)
                auto = "1";
            else
                auto = "0";
            //记录默认下载路径
            if (txtPath.Text !="")
                path = txtPath.Text;
            else
                path = "C:\\";//默认路径
            if (cboxNet.Checked)
            {
                if (txtNet.Text == "")
                {
                    MessageBox.Show("请输入限制网速！");
                    return;
                }
                else
                    net = 1 + " " + txtNet.Text.Trim();//记录限制的网速
            }
            else
                net = "0 256";//记录默认网速
            //记录是否下载完成自动关机
            if (cboxDClose.Checked)
                dclose = "1";
            else
                dclose = "0";
            //记录是否定时关机
            if (cboxTClose.Checked)
            {
                if (dtpickerTime.Text == "")
                {
                    MessageBox.Show("请设置时间！");
                    return;
                }
                    
                else
                    tclose = 1 + " " + dtpickerTime.Text;
            }
            else
                tclose = "0 00:00:00";
            //记录是否下载完成显示提示
            if (cboxSNotify.Checked)
                snotify = "1";
            else
                snotify = "0";
            //记录是否下载完成播放提示音
            if (cboxPlay.Checked)
                play = "1";
            else
                play = "0";
            //记录是否在有未完成的下载时显示继续提示
            if (cboxContinue.Checked)
                contin = "1";
            else
                contin = "0";
            //记录是否显示流量监控
            if (cboxShowFlow.Checked)
                showflow = "1";
            else
                showflow = "0";
            //写入是否开机自动启动的值
            Set.WritePrivateProfileString(Set.strNode, "Start", start, Set.strPath);
            //写入是否自动开始未完成任务的值
            Set.WritePrivateProfileString(Set.strNode, "Auto", auto, Set.strPath);
            //写入默认下载路径的值
            Set.WritePrivateProfileString(Set.strNode, "Path", path, Set.strPath);
            //写入网络限制的值
            Set.WritePrivateProfileString(Set.strNode, "Net", net, Set.strPath);
            //写入是否下载完成自动关机的值
            Set.WritePrivateProfileString(Set.strNode, "DClose", dclose, Set.strPath);
            //写入是否定时关机的值
            Set.WritePrivateProfileString(Set.strNode, "TClose", tclose, Set.strPath);
            //写入是否下载完成显示提示的值
            Set.WritePrivateProfileString(Set.strNode, "SNotify", snotify, Set.strPath);
            //写入是否下载完成播放提示音的值
            Set.WritePrivateProfileString(Set.strNode, "Play", play, Set.strPath);
            //写入是否在有未完成的下载时显示继续提示的值
            Set.WritePrivateProfileString(Set.strNode, "Continue", contin, Set.strPath);
            //写入是否显示流量监控的值
            Set.WritePrivateProfileString(Set.strNode, "ShowFlow", showflow, Set.strPath);
            MessageBox.Show("设置保存成功！");
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboxTClose_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxTClose.Checked)
                cboxDClose.Checked = false;
            dtpickerTime.Text = DateTime.Today.ToLongTimeString();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folder.SelectedPath;
                lblSpace.Text = set.GetSpace(txtPath.Text.Substring(0, txtPath.Text.IndexOf("\\") + 1));
            }
        }

        private void cboxNet_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxNet.Checked)
                txtNet.ReadOnly = false;
            else
                txtNet.ReadOnly = true;
        }

        private void cboxDClose_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxDClose.Checked)
                cboxTClose.Checked = false;
        }
    }
}
