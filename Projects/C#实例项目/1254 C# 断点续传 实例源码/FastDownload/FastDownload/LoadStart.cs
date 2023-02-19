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
    public partial class LoadStart : Form
    {
        public LoadStart()
        {
            //初始化组件
            InitializeComponent();
        }
        #region 按钮状态图片
        Image imagecancel1 = global::FastDownload.Properties.Resources.pbox_cancel;
        Image imagecancel2 = global::FastDownload.Properties.Resources.pbox_cancel2;
        Image imageload1 = global::FastDownload.Properties.Resources.pbox_begin;
        Image imageload2 = global::FastDownload.Properties.Resources.pbox_begin2;
        #endregion

        #region 窗体Load事件
        /// <summary>
        /// 窗体Load事件
        /// </summary>
        /// <param name="sender">窗体对象</param>
        /// <param name="e">事件信息</param>
        private void LoadStart_Load(object sender, EventArgs e)
        {
            cbox_count.SelectedIndex = 5;//默认选择使用六条线程下载
            tb_savepath.Text = Set.Path;//显示默认路径
            bs2 = Owner as Main_form;//得到主窗体的实例的引用
        }
        #endregion

        #region 私有字段
        private Point p1;//记录鼠标位置，用于移动窗体
        private Main_form bs2;//用于得到主窗体对象
        #endregion

        #region 移动窗体
        private void LoadStart_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = new Point(-e.X, -e.Y);
        }
        private void LoadStart_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p2 = Control.MousePosition;
                p2.Offset(p1);
                DesktopLocation = p2;
            }
        }
        #endregion

        #region 选择文件保存位置
        /// <summary>
        /// 选择文件保存位置
        /// </summary>
        /// <param name="sender">Button对象</param>
        /// <param name="e">事件信息</param>
        private void btn_browse_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();//选择下载文件保存到的文件夹
            if (dr == DialogResult.OK)//如果选定了文件夹，那么
            {
                tb_savepath.Text = folderBrowserDialog1.SelectedPath;//显示下载路径
                bs2.filepath = tb_savepath.Text;//得到下载路径
                Set.WritePrivateProfileString(Set.strNode, "Path", tb_savepath.Text, Set.strPath);
            }
        }
        #endregion

        #region 确认下载信息
        /// <summary>
        /// PictureBox对象Click事件
        /// </summary>
        /// <param name="sender">PictureBox对象</param>
        /// <param name="e">事件信息</param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_url.Text) || String.IsNullOrEmpty(tb_filename.Text))
            {
                MessageBox.Show("请输入下载地址及路径！");
            }
            else
            {
                if (!System.IO.Directory.Exists(tb_savepath.Text))//判断路径是否存在
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(tb_savepath.Text);//创建路径
                    }
                    catch
                    {
                        MessageBox.Show("默认磁盘不存在，请重新选择保存路径");
                        btn_browse_Click(sender, e);
                    }
                }
                bs2.downloadUrl = tb_url.Text;//设置下载地址
                bs2.filename = bs2.downloadUrl.Substring(bs2.downloadUrl.LastIndexOf("/") + 1,//设置文件名称
                           bs2.downloadUrl.Length - (bs2.downloadUrl.LastIndexOf("/") + 1));
                tb_filename.Text = bs2.filename;
                bs2.xiancheng = cbox_count.SelectedIndex + 1;//设置下载文件时使用的线程数量
                                                             //设置文件全路径
                if (tb_savepath.Text.EndsWith("\\"))
                    bs2.fileNameAndPath = tb_savepath.Text + bs2.filename;
                else
                    bs2.fileNameAndPath = tb_savepath.Text + @"\" + bs2.filename;
                if (tb_savepath.Text != string.Empty)//如果文件保存路径不等于空字符串
                {
                    Set.WritePrivateProfileString(Set.strNode, "Path", tb_savepath.Text, Set.strPath);
                    DownLoad dll = new DownLoad(bs2.filename,//创建下载类型的实例
                        tb_savepath.Text,
                        bs2.downloadUrl,
                        bs2.fileNameAndPath, bs2.xiancheng);
                    bs2.dl.Add(dll);//将下载类型的实例放入下载列表
                    this.Close();//关闭当前窗体
                }
                else
                {
                    //如果没有设置文件保存的路径，那么提示选择文件保存路径
                    MessageBox.Show("请选择下载文件保存的位置");
                }
            }
        }        
        #endregion

        #region 关闭当前窗体
        /// <summary>
        /// 关闭当前窗体
        /// </summary>
        /// <param name="sender">窗体对象</param>
        /// <param name="e">事件信息</param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }
        #endregion

        #region 定义鼠标经过按钮时的动态效果
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pbox_true.Image = imageload1;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pbox_true.Image = imageload2;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pbox_cancel.Image = imagecancel2;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pbox_cancel.Image = imagecancel1;
        }
        #endregion

        private void tb_url_TextChanged(object sender, EventArgs e)
        {
            string strUrl = tb_url.Text;
            if (strUrl.IndexOf("/") > 0)//自动获取下载文件名
                tb_filename.Text = strUrl.Substring(strUrl.LastIndexOf("/") + 1);
        }
    }
}
