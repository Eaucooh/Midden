using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Media;
using System.Net.NetworkInformation;
using System.Globalization;

namespace FastDownload
{
    public partial class Main_form : Form
    {
        public Main_form()
        {
            //初始化组件
            InitializeComponent();
            netList = new List<NetworkInterface>();
            foreach (NetworkInterface t in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (t.OperationalStatus.ToString() == "Up")
                    if (t.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                        netList.Add(t);
            }
        }
        #region 全局字段
        public List<DownLoad> dl = new List<DownLoad>();//下载队列的集合
        public List<xuchuan> jc = new List<xuchuan>();//续传队列的集合
        public string filename = string.Empty;//文件名称
        public string filepath = string.Empty;//文件的路径
        public string fileNameAndPath = string.Empty;//文件的名称及路径
        public string downloadUrl = string.Empty;//文件下载路径
        public int xiancheng;//文件使用下载的线程数量
        private int RowProcess = -1;//下载或续传列表中选择行的索引
        Point p1;//记录鼠标坐标点变量
        #endregion

        #region 按钮状态图片
        Image imagenew1 = global::FastDownload.Properties.Resources.pbox_new;
        Image imagenew2 = global::FastDownload.Properties.Resources.pbox_new2;
        Image imagebegin1 = global::FastDownload.Properties.Resources.pbox_start;
        Image imagebegin2 = global::FastDownload.Properties.Resources.pbox_start2;
        Image imagepause1 = global::FastDownload.Properties.Resources.pbox_pause;
        Image imagepause2 = global::FastDownload.Properties.Resources.pbox_pause2;
        Image imagedel1 = global::FastDownload.Properties.Resources.pbox_delete;
        Image imagedel2 = global::FastDownload.Properties.Resources.pbox_delete2;
        Image imageopen1 = global::FastDownload.Properties.Resources.pbox_continue;
        Image imageopen2 = global::FastDownload.Properties.Resources.pbox_continue2;
        #endregion
        Set set=new Set();

        #region 窗体Load事件
        /// <summary>
        /// 窗体的Load事件
        /// </summary>
        /// <param name="sender">窗体对象</param>
        /// <param name="e">事件描述</param>
        private void Main_form_Load(object sender, EventArgs e)
        {
            set.GetConfig();
            Thread th = new Thread(
                new ThreadStart(BeginDisplay));//线程用于显示任务状态
            th.IsBackground = true;//设置线程为后台线程
            th.Start();//线程开始
            SetToolTip();//设置提示组件
            InitialListViewMenu();//初始化ListView控件菜单
            Thread th2 = new Thread(//线程用于重绘Listview控件
                new ThreadStart(DisplayListView));
            th2.IsBackground = true;//设置线程为后台线程
            th2.Start();//开始执行线程
            if (Set.ShowFlow == "1")//是否显示流量监控
            {
                pictureBox1.Visible = pictureBox2.Visible = label1.Visible = label2.Visible = true;
            }
            if (Set.Auto == "1")//是否自动开始未完成任务
            {
                DirectoryInfo dir = new DirectoryInfo(Set.Path);//指定路径
                if (dir.Exists)
                {
                    FileInfo[] files = dir.GetFiles();//获取所有文件列表
                    foreach (FileInfo file in files)
                    {
                        if (file.Extension == ".cfg")//判断是否有未下载完的文件
                        {
                            Stream sm = file.Open(FileMode.Open, FileAccess.ReadWrite);//得到续传文件的流对象
                            string s = file.Name;//得到续传文件的文件名
                            xuchuan jcc = new xuchuan();//实例化处理续传文件下载的类的实例
                            jcc.Begin(sm, s);//正式开始处理续传信息
                            jc.Add(jcc);//将续传对象加入到续传处理队列
                        }
                    }
                }
            }
        }
        #endregion

        #region 初始化菜单及提示信息
        /// <summary>
        /// 初始化ListView控件菜单
        /// </summary>
        private void InitialListViewMenu()
        {
            MenuItem mi = new MenuItem("开始");//定义菜单的开始项
            mi.Click += new EventHandler(mi_Click);//为菜单的开始项添加事件
            MenuItem mi2 = new MenuItem("暂停");//定义菜单的暂停项
            mi2.Click += new EventHandler(mi2_Click);//为菜单的暂停项添加事件
            MenuItem mi3 = new MenuItem("删除");//定义菜单的删除项
            mi3.Click += new EventHandler(mi3_Click);//为菜单的删除项添加事件
            lv_state.ContextMenu = //为ListView控件添加菜单
                new ContextMenu(new MenuItem[] { mi, mi2, mi3 });
        }
        /// <summary>
        /// 定义提示组件
        /// </summary>
        private void SetToolTip()
        {
            ToolTip ttnew = new ToolTip();//创建ToolTip对象
            ttnew.InitialDelay = 10;//设置延迟为10毫秒
            ttnew.SetToolTip(pbox_new, "新建");//为控件添加提示信息
            ToolTip ttbegin = new ToolTip();//创建ToolTip对象
            ttbegin.InitialDelay = 10;//设置延迟为10毫秒
            ttbegin.SetToolTip(pbox_start, "开始");//为控件添加提示信息
            ToolTip ttpause = new ToolTip();//创建ToolTip对象
            ttpause.InitialDelay = 10;//设置延迟为10毫秒
            ttpause.SetToolTip(pbox_pause, "暂停");//为控件添加提示信息
            ToolTip ttdel = new ToolTip();//创建ToolTip对象
            ttdel.InitialDelay = 10;//设置延迟为10毫秒
            ttdel.SetToolTip(pbox_delete, "删除");//为控件添加提示信息
            ToolTip ttopen = new ToolTip();//创建ToolTip对象
            ttopen.InitialDelay = 10;//设置延迟为10毫秒
            ttopen.SetToolTip(pbox_continue, "续传");//为控件添加提示信息
            ToolTip ttset = new ToolTip();//创建ToolTip对象
            ttset.InitialDelay = 10;//设置延迟为10毫秒
            ttset.SetToolTip(pbox_set, "设置");//为控件添加提示信息
            ToolTip ttclose = new ToolTip();//创建ToolTip对象
            ttclose.InitialDelay = 10;//设置延迟为10毫秒
            ttclose.SetToolTip(pbox_close, "关闭");//为控件添加提示信息
        }
        #endregion

        #region 定时重绘ListView控件
        /// <summary>
        /// 定时重绘ListView控件
        /// </summary>
        private void DisplayListView()
        {
            while (true)
            {
                this.Invoke(
                    (MethodInvoker)delegate
                    {
                        if (lv_state.Items.Count < 28)//lv_state发生改变则执行下面内容
                        {
                            for (int j = 0; j < 28 - lv_state.Items.Count; j++)
                            {
                                lv_state.Items.Add(
                                    new ListViewItem(new string[] {//初始化lv_state的状态
                                string.Empty,string.Empty,string.Empty,string.Empty,
                                string.Empty,string.Empty,string.Empty,string.Empty}));
                            }
                        }
                        for (int i = 0; i < lv_state.Items.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                lv_state.Items[i].BackColor =
                                    Color.FromArgb(225, 238, 255);//背景设为浅蓝色
                            }
                            else
                            {
                                lv_state.Items[i].BackColor = Color.White;//背景设为白色
                            }
                        }
                    });
                Thread.Sleep(1000);//线程挂起1秒钟
            }
        }
        #endregion

        #region ListView1右键菜单事件
        /// <summary>
        /// ListView右键菜单删除事件
        /// </summary>
        /// <param name="sender">菜单对象</param>
        /// <param name="e">事件信息</param>
        void mi3_Click(object sender, EventArgs e)
        {
            delete();//调用delete()方法删除下载或续传任务
        }

        /// <summary>
        /// ListView右键菜单暂停事件
        /// </summary>
        /// <param name="sender">菜单对象</param>
        /// <param name="e">事件信息</param>
        void mi2_Click(object sender, EventArgs e)
        {
            pause();//调用pause()方法暂停下载或续传任务
        }

        /// <summary>
        /// ListView右键菜单开始事件
        /// </summary>
        /// <param name="sender">菜单对象</param>
        /// <param name="e">事件信息</param>
        void mi_Click(object sender, EventArgs e)
        {
            start();//调用start()方法开始下载或续传任务
        }
        #endregion

        #region 开始任务
        /// <summary>
        /// 点击开始按钮时，终止暂停动作，开始下载
        /// </summary>
        void start()
        {
            if (RowProcess != -1)//判断lv_state是否选中行
            {
                if (lv_state.Items[RowProcess].Text != string.Empty)//判断选中行是否为有效行
                {
                    if (RowProcess + 1 > dl.Count)
                    {
                        jc[RowProcess - dl.Count > 0 ?//设置任务的状态为开始
                            RowProcess - dl.Count : 0].stop = false;
                    }
                    else
                    {
                        dl[RowProcess].stop = false;//设置任务的状态为开始
                    }
                }
            }
        }
        #endregion

        #region 暂停任务
        /// <summary>
        /// 点击暂停按钮时，暂停下载进程或续传任务
        /// </summary>
        void pause()
        {
            if (RowProcess != -1)//判断lv_state是否选中行
            {
                if (lv_state.Items[RowProcess].Text != string.Empty)//判断选中行是否为有效行
                {
                    if (RowProcess + 1 > dl.Count)
                    {
                        jc[RowProcess - dl.Count > 0 ?//设置任务的状态为暂停
                            RowProcess - dl.Count : 0].stop = true;
                    }
                    else
                    {
                        dl[RowProcess].stop = true;//设置任务的状态为暂停
                    }
                }
            }
        }
        #endregion

        #region 删除任务
        /// <summary>
        /// 点击删除按钮时，删除下载或续传任务
        /// </summary>
        void delete()
        {
            if (RowProcess != -1)//判断lv_state是否选中行
            {
                if (lv_state.Items[RowProcess].Text != string.Empty)//判断选中行是否为有效行
                {
                    if (RowProcess + 1 > dl.Count)
                    {
                        jc[RowProcess - dl.Count > 0 ? //设置任务的状态为暂停
                            RowProcess - dl.Count : 0].stop = false;
                        jc[RowProcess - dl.Count > 0 ? //设置任务的状态为删除
                            RowProcess - dl.Count : 0].stop2 = true;
                    }
                    else
                    {
                        dl[RowProcess].stop = false;//设置任务的状态为暂停
                        dl[RowProcess].stop2 = true;//设置任务的状态为删除
                    }
                }
            }
        }
        #endregion

        #region 显示窗体下载或续传文件的状态
        /// <summary>
        /// 显示窗体下载或续传文件的状态
        /// </summary>
        private void BeginDisplay()
        {
            //字符串集合1,用于对listview1控件中数据项进行对比
            List<string[]> ls1 = new List<string[]>();
            //字符串集合2,用于对listview1控件中数据项进行对比
            List<string[]> ls2 = new List<string[]>();
            //使用While循环，重复检查下载或续传文件的状态
            while (true)
            {
                //检测是否有异常
                try
                {
                    //如果下载队列中有数据则向下执行
                    if (dl.Count > 0)
                    {
                        //下载队列和续传队列的数量的和
                        for (int j = 0; j < dl.Count + jc.Count; j++)
                        {
                            //在窗体主线程中listview1控件中添加新的空数据项
                            this.Invoke(
                                (MethodInvoker)delegate ()
                                {
                                    if (lv_state.Items.Count < dl.Count + jc.Count)
                                    {
                                        lv_state.Items.Add(new ListViewItem(
                                            new string[] {string.Empty,string.Empty,string.Empty,string.Empty ,
                                        string.Empty,string.Empty,string.Empty}));
                                    }
                                });
                        }
                        //遍历下载列表
                        for (int i = 0; i < dl.Count; i++)
                        {
                            //检查下载列表中每一个下载进程的状态,如果为true继续执行
                            if (dl[i].state == true)
                            {
                                //如果下载列表中的下载进程的状态为:已经完成
                                if (dl[i].complete)
                                {
                                    if (Set.Play == "1")//自动播放声音
                                    {
                                        SoundPlayer player = new SoundPlayer("msg.wav");
                                        player.Play();
                                    }
                                    if (Set.SNotify == "1")//下载完成显示提示
                                    {
                                        MessageBox.Show("任务下载完成！");
                                    }
                                    //将已经完成的下载进程从下载队列中删除
                                    dl.RemoveAt(i);
                                    //将已经完成的下载进程从listview1控件中删除
                                    this.Invoke(
                                        (MethodInvoker)delegate ()
                                        {
                                            lv_state.Items.RemoveAt(i);
                                            //this.OnPaint(null);
                                        });
                                    //清空字符串集合1
                                    ls1.Clear();
                                    //清空字符串集合2
                                    ls2.Clear();
                                    //跳出此次循环
                                    break;
                                }
                                //进入主窗体线程，开始对listview1控件进行操作
                                this.Invoke(
                                    (MethodInvoker)delegate ()
                                    {
                                        //添加新的空数据项
                                        if (ls1.Count < dl.Count)
                                        {
                                            ls1.Add(
                                                new string[] {string.Empty,string.Empty,string.Empty,string.Empty ,
                                        string.Empty,string.Empty,string.Empty});
                                        }
                                        //得到新的下载状态信息
                                        ls1[i] = (dl[i].showmessage());
                                        //添加新的空数据项
                                        if (ls2.Count < ls1.Count)
                                        {
                                            ls2.Add(
                                            new string[] {string.Empty,string.Empty,string.Empty,string.Empty ,
                                        string.Empty,string.Empty,string.Empty});
                                        }
                                        //只更新新的数据项,不会造成listview1控件的闪烁
                                        for (int j = 0; j < 7; j++)
                                        {
                                            if (ls1[i][j] != ls2[i][j])
                                            {
                                                ls2[i][j] = ls1[i][j];
                                                ListViewItem lvi = lv_state.Items[i];
                                                lvi.SubItems[j] = new ListViewItem.ListViewSubItem(lvi, ls1[i][j]);
                                            }
                                        }
                                    });
                            }
                            else
                            {
                                //将下载进程的状态设置为true
                                dl[i].state = true;
                                //执行下载进程中的开始下载的方法
                                dl[i].StartLoad();
                            }
                        }
                    }

                    //续传
                    //如果续传队列中有数据，则向下执行
                    if (jc.Count > 0)
                    {
                        //下载队列和续传队列的数量的和
                        for (int j = 0; j < jc.Count + dl.Count; j++)
                        {
                            //在窗体主线程中listview1控件中添加新的空数据项
                            this.Invoke(
                                (MethodInvoker)delegate ()
                                {
                                    if (lv_state.Items.Count < jc.Count + dl.Count)
                                    {
                                        lv_state.Items.Add(new ListViewItem(
                                            new string[] {string.Empty,string.Empty,string.Empty,string.Empty ,
                                        string.Empty,string.Empty,string.Empty}));
                                    }
                                });
                        }
                        //遍历续传队列
                        for (int i = 0; i < jc.Count; i++)
                        {
                            //如果续传队列中的进程的状态为true，则向下执行
                            if (jc[i].state == true)
                            {
                                //如果续传列表中的续传进程的状态为:已经完成
                                if (jc[i].complete)
                                {
                                    if (Set.Play == "1")//自动播放声音
                                    {
                                        SoundPlayer player = new SoundPlayer("msg.wav");
                                        player.Play();
                                    }
                                    if (Set.SNotify == "1")//下载完成显示提示
                                    {
                                        MessageBox.Show("任务下载完成！");
                                    }
                                    //将已经完成的续传进程从续传队列中删除
                                    jc.RemoveAt(i);
                                    //将已经完成的下续传程从listview1控件中删除
                                    this.Invoke(
                                        (MethodInvoker)delegate ()
                                        {
                                            lv_state.Items.RemoveAt(i);
                                            //this.OnPaint(null);
                                        });
                                    //清空字符串集合1
                                    ls1.Clear();
                                    //清空字符串集合2
                                    ls2.Clear();
                                    break;
                                }
                                //进入主窗体线程，开始对listview1控件进行操作
                                this.Invoke(
                                    (MethodInvoker)delegate ()
                                    {
                                        try
                                        {
                                            //添加新的空数据项
                                            if (ls1.Count < jc.Count + dl.Count)
                                            {
                                                ls1.Add(
                                                    new string[] {string.Empty,string.Empty,string.Empty,string.Empty ,
                                        string.Empty,string.Empty,string.Empty});
                                            }
                                            //得到新的续传状态信息
                                            ls1[dl.Count + i] = (jc[i].showmessage());
                                            //添加新的空数据项
                                            if (ls2.Count < ls1.Count + dl.Count)
                                            {
                                                ls2.Add(
                                                new string[] {string.Empty,string.Empty,string.Empty,string.Empty ,
                                                   string.Empty,string.Empty,string.Empty});
                                            }
                                            //只更新新的数据项,不会造成listview1控件的闪烁
                                            for (int j = 0; j < 7; j++)
                                            {
                                                if (ls1[i + dl.Count][j] != ls2[i + dl.Count][j])
                                                {
                                                    ls2[i + dl.Count][j] = ls1[i + dl.Count][j];
                                                    ListViewItem lvi = lv_state.Items[i + dl.Count];
                                                    lvi.SubItems[j] = new ListViewItem.ListViewSubItem(lvi, ls1[i + dl.Count][j]);
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            //将出现的异常写入日志文件
                                            writelog(ex.Message);
                                        }
                                    });
                            }
                            else
                            {
                                //将续传进程的状态设置为true
                                jc[i].state = true;
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    //将出现的异常写入日志文件
                    if (ex.Message == "未能找到文件下载服务器或下载文件，请输入正确下载地址！")
                    {
                        writelog(ex.Message);
                        if (dl.Count > 0)
                            dl.RemoveAt(dl.Count - 1);
                        MessageBox.Show(ex.Message, "出错！");
                    }
                }
                catch (Exception ex2)
                {
                    writelog(ex2.Message);//将出现的异常写入日志文件
                    if (dl.Count > 0)
                        dl.RemoveAt(dl.Count - 1);
                    MessageBox.Show(ex2.Message, "出错！");
                }
                //每隔1秒种重复检查一次
                System.Threading.Thread.Sleep(1000);
            }
        }
        #endregion

        #region 保存窗体日志方法
        /// <summary>
        /// 将异常休息写入日志文件，并标明异常出现的时间和日期
        /// </summary>
        /// <param name="s">异常信息</param>
        private void writelog(string s)
        {
            //创建文件流操作对象,将文件写入方式设置为追加
            StreamWriter fs = new StreamWriter(Application.StartupPath+"\\DownLoad.log", true);
            //向日志文件中写入出现的异常信息及出现异常的时间
            fs.Write(string.Format(s + DateTime.Now.ToString("yy-MM-dd  hh:mm:ss")));
            //将数据压入流
            fs.Flush();
            //关闭流对象
            fs.Close();
        }
        #endregion

        #region 退出应用程序并保存续传信息方法
        /// <summary>
        /// 退出应用程序并保存续传信息
        /// </summary>
        private void exit()
        {
            if (Set.Continue == "1")
            {
                if (dl.Count > 0 || jc.Count > 0)//下载或续传队列有任务则继续执行
                {
                    DialogResult dr = MessageBox.Show("当前有未完成的下载，请确认继续下载(是)，还是关闭应用程序(否)!", "提示",
                        MessageBoxButtons.YesNo);//是否关闭应用程序
                    if (dr == DialogResult.Yes)//点击确认按钮向下执行
                    {
                        if (dl.Count > 0)//如果下载队列中有下载进程
                        {
                            //遍历下载队列中所有下载进程，并操作下载进程保存续传数据信息
                            for (int i = 0; i < dl.Count; i++)
                            {
                                dl[i].stop = true;//暂停下载进程的下载动作
                                System.Threading.Thread.Sleep(3000);//线程挂起三秒钟
                                dl[i].SaveState();//保存下载数据的续传信息
                                dl[i].AbortThread();
                            }
                        }
                        if (jc.Count > 0)//如果续传队列中有续传进程
                        {
                            //遍历续传队列中所有续传进程，并操作续传进程保存续传数据信息
                            for (int j = 0; j < jc.Count; j++)
                            {
                                jc[j].stop = true;//暂停续传进程的下载动作
                                System.Threading.Thread.Sleep(3000);//线程挂起三秒钟
                                jc[j].SaveState();//保存续传数据的续传信息
                                jc[j].AbortThread();
                            }
                        }
                        Environment.Exit(0);//强制退出应用程序
                    }
                }
                else
                {
                    Close();//退出应用程序
                }
            }
            else
            {
                Close();//退出应用程序
            }
        }
        #endregion

        #region 拖动窗体实现
        /// <summary>
        /// 窗体MouseDown事件
        /// </summary>
        /// <param name="sender">窗体对象</param>
        /// <param name="e">事件信息</param>
        private void main_form_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = new Point(-e.X, -e.Y);//当在窗体中点击左键时，开始记录鼠示位置
        }
        /// <summary>
        /// 窗体MouseMove事件
        /// </summary>
        /// <param name="sender">窗体对象</param>
        /// <param name="e">事件信息</param>
        private void main_form_MouseMove(object sender, MouseEventArgs e)
        {
            //当鼠标在窗体中移动并此时已经按下鼠标左键时
            if (e.Button == MouseButtons.Left)
            {
                //得到当前鼠标在操作系统工作区域的坐标
                Point p2 = Control.MousePosition;
                //得到现在窗体所在的坐标
                p2.Offset(p1);
                //设置当前窗体所在的坐标
                DesktopLocation = p2;
            }
        }
        #endregion

        #region 得到ListView控件中鼠标选择的索引
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //得到listview1控件选择的索引的集合
            ListView.SelectedIndexCollection sic = lv_state.SelectedIndices;
            //得到listview1控件点击的索引
            foreach (int s in sic)
            {
                //因为是单选，所以就算遍历集合也是得到一个数值
                RowProcess = s;
            }
        }
        #endregion

        #region 下载任务控制
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//最小化窗体
            this.ShowInTaskbar = false;
        }

        /// <summary>
        /// 添加任务按钮的Click事件
        /// </summary>
        /// <param name="sender">PictureBox对象</param>
        /// <param name="e">事件信息</param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadStart ls = new LoadStart();//实例化下载页面对象
            ls.Owner = this;//下载页面对象的Owner属性为本窗体
            ls.Show();//显示下载页面
        }

        /// <summary>
        /// 开始按钮的Click事件
        /// </summary>
        /// <param name="sender">PictureBox对象</param>
        /// <param name="e">事件信息</param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            start();//调用start()方法开始下载或续传任务
            if (Set.DClose == "1")
                set.Shutdown();//下载完成自动关机
        }

        /// <summary>
        /// 暂停按钮的Click事件
        /// </summary>
        /// <param name="sender">PictureBox对象</param>
        /// <param name="e">事件信息</param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pause();//调用pause()方法暂停下载或续传任务
        }

        /// <summary>
        /// 删除按钮的Click事件
        /// </summary>
        /// <param name="sender">PictureBox对象</param>
        /// <param name="e">事件信息</param>
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            delete();//调用delete()方法删除下载或续传任务
        }

        /// <summary>
        /// 续传按钮的Click事件
        /// </summary>
        /// <param name="sender">PictureBox对象</param>
        /// <param name="e">事件信息</param>
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = string.Empty;//重置续传文件的名称
            openFileDialog1.Filter = string.Format("cfg文件|*.cfg");//续传文件类型筛选
            DialogResult dr = openFileDialog1.ShowDialog();//打开文件浏览，选择续传文件
            if (dr == DialogResult.OK)//判断是否点下确定按钮
            {
                Stream sm = openFileDialog1.OpenFile();//得到续传文件的流对象
                string s = openFileDialog1.FileName;//得到续传文件的文件名
                xuchuan jcc = new xuchuan();//实例化处理续传文件下载的类的实例
                jcc.Begin(sm, s);//正式开始处理续传信息
                jc.Add(jcc);//将续传对象加入到续传处理队列
            }
        }
        #endregion

        #region 处理鼠标经过按钮时的状态
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pbox_new.Image = imagenew1;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pbox_new.Image = imagenew2;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pbox_start.Image = imagebegin1;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pbox_start.Image = imagebegin2;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pbox_pause.Image = imagepause1;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pbox_pause.Image = imagepause2;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pbox_delete.Image = imagedel1;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pbox_delete.Image = imagedel2;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pbox_continue.Image = imageopen1;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pbox_continue.Image = imageopen2;
        }

        #endregion

        #region 重绘窗体
        /// <summary>
        /// 重绘窗体
        /// </summary>
        /// <param name="e">事件参数</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (lv_state.Items.Count < 28)
            {
                for (int j = 0; j < 28 - lv_state.Items.Count; j++)
                {
                    lv_state.Items.Add(new ListViewItem(new string[] {
                    string.Empty,string.Empty,string.Empty,string.Empty,
                    string.Empty,string.Empty,string.Empty,string.Empty}));
                }
            }
            for (int i = 0; i < lv_state.Items.Count; i++)
            {
                if (i % 2 == 0)
                {
                    lv_state.Items[i].BackColor = Color.FromArgb(225, 238, 255);
                }
                else
                {
                    lv_state.Items[i].BackColor = Color.White;
                }
            }
        }
        #endregion

        private void pbox_set_Click(object sender, EventArgs e)
        {
            Setting set = new Setting();//创建设置窗体对象
            set.ShowDialog();//显示设置窗体
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit();//退出应用
        }

        //系统托盘
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)//判断窗体是否为最小化状态
            {
                this.Show();//显示当前窗体
                this.WindowState = FormWindowState.Normal;//还原窗体
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            set.GetConfig();//获取配置文件的值
            if (Set.TClose=="1")//定时关机
            {
                string nowTime = DateTime.Now.ToLongTimeString();//获取当前时间
                if (Set.TCloseValue.Equals(nowTime))//比较时间
                    set.Shutdown();//强制关机
            }
            if (Set.ShowFlow == "1")//显示网络流量
            {
                pictureBox1.Visible = pictureBox2.Visible = label1.Visible = label2.Visible = true;
                ShowSpeed();//显示网络流量
            }
            else
                pictureBox1.Visible = pictureBox2.Visible = label1.Visible = label2.Visible = false;
        }
        

        private List<NetworkInterface> netList;//存储网卡列表
        private long receivedBytes;//记录上一次总接收字节数
        private long sentBytes;//记录上一次总发送字节数
        /// <summary>
        /// 显示当前网络下载和上传速度
        /// </summary>
        private void ShowSpeed()
        {
            long totalReceivedbytes = 0;//记录本次总接收字节数
            long totalSentbytes = 0;//记录本次总发送字节数
            foreach (NetworkInterface net in netList)//遍历网卡列表
            {
                IPv4InterfaceStatistics interfaceStats = net.GetIPv4Statistics(); //获取IPv4统计信息
                totalReceivedbytes += interfaceStats.BytesReceived;//获取接收字节数，并累计
                totalSentbytes += interfaceStats.BytesSent;//获取发送字节数，并累计
            }
            long recivedSpeed = totalReceivedbytes - receivedBytes;//计算本次接收字节数（本次-上次）
            long sentSpeed = totalSentbytes - sentBytes;//计算本次发送字节数（本次-上次）
            //如果上一次接收和发送值为0，将下载和上传速度设置为0
            if (receivedBytes == 0 && sentBytes == 0)
            {
                recivedSpeed = 0;
                sentSpeed = 0;
            }
            label1.Text = "[" + recivedSpeed / 1024 + " KB/s]"; //显示下载速度
            label2.Text = "[" + sentSpeed / 1024 + " KB/s]";//显示上传速度
            receivedBytes = totalReceivedbytes;//记录上一次总接收字节数
            sentBytes = totalSentbytes;//记录上一次总发送字节数
        }
    }
}
