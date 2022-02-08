using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace FastDownload
{
    public class DownLoad
    {
        #region 全局私有变量

        //文件开始下载的时间
        public DateTime dtbegin;
        //文件下载是否完成
        public bool complete = false;
        //下载文件的大小
        public long filesize;
        //下载的状态，是否为已经执行
        public bool state = false;
        //下载的地址
        public string downloadUrl;
        //暂停下载开关
        public bool stop = false;
        //下载文件的名称
        public string filename;
        //下载文件的路径及文件名
        public string fileNameAndPath;
        //下载文件的路径
        public string filepath;
        //判断所有线程是否全部下载完成
        public System.Collections.Generic.List<bool> lbo = new List<bool>();
        //下载文件所使用线程的数量
        public int xiancheng;
        //记录续传信息的可序列化类的集合
        public List<Locations> lli = new List<Locations>();
        //停止下载，并删除下载文件 开关
        public bool stop2 = false;
        //存放线程的集合，用于停止下载任务
        public List<Thread> G_thread_Collection = new List<Thread>();
        //线程事件
        private AutoResetEvent are = new AutoResetEvent(true);
        //是否支持多线程下载
        private bool b_thread = false;
        #endregion

        #region DownLoad类的构造方法
        /// <summary>
        /// DownLoad类的构造方法
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <param name="filepath">文件路径</param>
        /// <param name="downloadurl">下载资源地址</param>
        /// <param name="FileNameAndPath">文件完整路径</param>
        /// <param name="xiancheng">使用线程数量</param>
        public DownLoad(string filename, string filepath, string downloadurl, string FileNameAndPath,int xiancheng)
        {
            this.filename = filename;
            this.filepath = filepath;
            this.downloadUrl = downloadurl;
            this.fileNameAndPath = FileNameAndPath;
            this.xiancheng = xiancheng;
            dtbegin = DateTime.Now;
        }
        #endregion

        #region 开始下载网络资源方法
        /// <summary>
        /// 开始下载网络资源
        /// </summary>
        public void StartLoad()
        {
            long filelong = 0;
            try
            {
                //创建HttpWebRequest对象
                HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create(downloadUrl);
                //根据HttpWebRequest对象得到HttpWebResponse对象
                HttpWebResponse hwp = (HttpWebResponse)hwr.GetResponse();
                //得到下载文件的长度
                filelong = hwp.ContentLength;
                b_thread = GetBool(downloadUrl);
            }
            catch (WebException we)
            {
                //向上一层抛出异常
                throw new WebException("未能找到文件下载服务器或下载文件，请添入正确下载地址！");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            filesize = filelong;//filesize得到文件长度值
            int meitiao = (int)filelong / xiancheng;//开始计算每条线程要下载多少字节
            int yitiao = (int)filelong % xiancheng;//每条线程分配字节后，余出的字节
            Locations ll = new Locations(0, 0);//新建一个续传信息对象
            lbo = new List<bool>();//初始化布尔集合
            for (int i = 0; i < xiancheng; i++)//开始为每条线程分配下载区间
            {
                ll.Start = i != 0 ? ll.End + 1 : ll.End;//分配下载区间
                ll.End = i == xiancheng - 1 ?//分配下载区间
                    ll.End + meitiao + yitiao : ll.End + meitiao;

                System.Threading.Thread th = //为每一条线程分配下载区间
                    new System.Threading.Thread(GetData);
                th.Name = i.ToString();//线程的名称为下载区间排序的索引
                th.IsBackground = true;//线程为后台线程
                th.Start(ll);//线程开始，并为线程执行的方法传递参数，参数为当前线程下载的区间
                lli.Add(new Locations(ll.Start, ll.End, downloadUrl, filename, filesize,
                    new Locations(ll.Start, ll.End)));//续传状态列表添加新的续传区间
                ll = new Locations(ll.Start, ll.End);//得到新的区间对象
                G_thread_Collection.Add(th);
                lbo.Add(false);//设置每条线程的完成状态为false
            }
            //合并文件线程开始启动
            hebinfile();
        }
        #endregion

        #region 下载网络资源方法
        /// <summary>
        /// 下载网络资源方法
        /// </summary>
        /// <param name="l">下载资源区间</param>
        public void GetData(object l)
        {
            //得到续传信息对象(也就是文件下载或续传的开始点与结束点)
            Locations ll = (Locations)l;
            if (!b_thread) are.WaitOne(); else are.Set();
            //根据下载地址，创建HttpWebRequest对象
            HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create(downloadUrl);
            //设置下载请求超时为200秒
            hwr.Timeout = 15000;
            //设置当前线程续传或下载任务的开始点与结束点
            hwr.AddRange(ll.Start, ll.End);
            //得到HttpWebResponse对象
            HttpWebResponse hwp = (HttpWebResponse)hwr.GetResponse();
            //根据HttpWebResponse对象的GetResponseStream()方法得到用于下载数据的网络流对象
            Stream ss = hwp.GetResponseStream();
            //设置文件下载的缓冲区
            new Set().GetConfig();
            byte[] buffer = new byte[Convert.ToInt32(Set.NetValue) * 8];
            //新建文件流对象，用于存放当前每个线程下载的文件
            FileStream fs = new FileStream(
                string.Format(filepath + @"\" + filename + System.Threading.Thread.CurrentThread.Name),
                FileMode.Create);
            try
            {
                //用于计数，每次下载有效字节数
                int i;
                //当前线程的索引
                int nns = Convert.ToInt32(System.Threading.Thread.CurrentThread.Name);
                //开始将下载的数据放入缓冲中
                while ((i = ss.Read(buffer, 0, buffer.Length)) > 0)
                {
                    //将缓冲中的数据写到本地文件中
                    fs.Write(buffer, 0, i);
                    //计算现在下载位置，用于续传
                    lli[nns].Start += i;
                    //点击暂停按钮后，使线程暂时挂起
                    while (stop)
                    {
                        //线程挂起
                        System.Threading.Thread.Sleep(100);
                    }
                    //点击删除按钮后，使下载过程强行停止
                    if (stop2)
                    {
                        break;
                    }
                    Thread.Sleep(10);
                }
                //关闭文件流对象
                fs.Close();
                //关闭网络流对象
                ss.Close();
                //开始记录当前线程的下载状态为已经完成
                lbo[Convert.ToInt32(System.Threading.Thread.CurrentThread.Name)] = true;
            }
            catch (Exception ex)
            {
                //如果出现异常，将异常信息写入错误日志
                writelog(ex.Message);
                //保存断点续传状态
                SaveState();
            }
            finally
            {
                //关闭文件流对象
                fs.Close();
                //关闭网络流对象
                ss.Close();
                if (!b_thread) are.Set(); else are.Set();
            }
        }
        #endregion

        #region 保存续传状态方法
        /// <summary>
        /// 保存续传状态方法
        /// </summary>
        public void SaveState()
        {
            BinaryFormatter bf = new BinaryFormatter();//实例化二进制格式对象
            MemoryStream ms = new MemoryStream();//新建内存流对象
            bf.Serialize(ms, lli);//将续传信息序列化到内存流中
            ms.Seek(0, SeekOrigin.Begin);//将内存流中指针位置 置零
            byte[] bt = ms.GetBuffer();//从内存流中得到字节数组
            FileStream fs = new FileStream//创建文件流对象
                (fileNameAndPath + ".cfg", FileMode.Create);
            fs.Write(bt, 0, bt.Length);//向文件流中写入数据(字节数组)
            fs.Close();//关闭流对象
        }
        #endregion

        #region 监控文件是否完成下载的方法
        /// <summary>
        /// 监控文件是否完成下载的方法
        /// </summary>
        public void hebinfile()
        {
            //在新线程中执行
            System.Threading.Thread th2 = new System.Threading.Thread(
                //使用匿名方法
              delegate()
              {
                  //每隔一秒，检测是否所有线程都完成了下载任务
                  while (true)
                  {
                      //如果所有线程都完成了下载任务
                      if (!lbo.Contains(false))
                      {
                          //开始合并文件
                          GetFile();
                          //停上检测线程
                          break;
                      }
                      else
                      {
                          if (this.stop2)
                          {
                              DeleteFile();
                          }
                      }
                      //线程挂起1秒
                      Thread.Sleep(1000);
                  }
              });
            //此线程是后台线程
            th2.IsBackground = true;
            //线程开始
            th2.Start();
        }
        #endregion

        #region 写入异常日志的方法
        /// <summary>
        /// 写入异常日志的方法
        /// </summary>
        /// <param name="s">异常信息</param>
        private void writelog(string s)
        {
            try
            {
                //新建文件流对象
                StreamWriter fs = new StreamWriter(@"c:\DownLoad.log", true);
                //将异常信息及异常出现的时间写入流中
                fs.Write(string.Format(s + DateTime.Now.ToString("yy-MM-dd  hh:mm:ss")));
                //清空缓冲区，使缓冲区内数据压入流
                fs.Flush();
                //关闭文件流对象
                fs.Close();
            }
            catch
            { }
        }
        #endregion

        #region 文件合并方法
        /// <summary>
        /// 文件合并方法
        /// </summary>
        private void GetFile()
        {
            new Set().GetConfig();
            if (Set.Path.EndsWith("\\"))
                fileNameAndPath = Set.Path + filename;
            else
                fileNameAndPath = Set.Path + "\\" + filename;
            //如果此文件是点击删除按钮后跳转到当前方法的，那么直接删除文件
            if (stop2)
            {
                DeleteFile();//直接删除文件
            }
            //此文件不是点击删除按钮后跳转到当前方法的，那么执行下面文件合并动作
            else
            {
                //新建文件流对象,此流对象用于生成下载后得到的文件
                FileStream fs = new FileStream(fileNameAndPath, FileMode.Create);
                byte[] buffer = new byte[2000];//创建缓冲区对象
                //开始遍历每条线程下载后得到的文件，并从每个文件中读取内容，放入一个文件中
                for (int i = 0; i < xiancheng; i++)
                {
                    //新建文件流对象，此流对象用于引用每一个线程下载的文件，
                    //并将所有文件按照顺序放入一个文件中去，此文件就是多线程下载的文件
                    FileStream fs2 = new FileStream
                        (string.Format(filepath + @"\" + filename + i.ToString()), FileMode.Open);
                    int i2;//记数器
                    while ((i2 = fs2.Read(buffer, 0, buffer.Length)) > 0)
                        fs.Write(buffer, 0, i2);//读取文件中所有数据
                    fs2.Close();//关闭流对象
                }
                fs.Close();//关闭流对象
                DeleteFile();//调用删除文件方法
            }
        }
        #endregion

        #region 删除文件文法
        /// <summary>
        /// 删除文件方法
        /// </summary>
        private void DeleteFile()
        {
            //关闭所有下载或续传线程
            foreach (var item in G_thread_Collection)
            {
                if (item.Name!=Thread.CurrentThread.Name)
                {
                    item.Abort();
                }
            }
            //删除所有生成的文件
            if (stop2)
            {
                for (int i = 0; i < xiancheng; i++)
                {
                    File.Delete(string.Format(filepath + @"\" + filename + i.ToString()));
                }
                if (File.Exists(fileNameAndPath + ".cfg"))
                {
                    string ssname = string.Format(fileNameAndPath + ".cfg");
                    File.Delete(ssname);
                }
                //重置所有字段的信息
                clear();
            }
            else
            {
                for (int i = 0; i < xiancheng; i++)
                {
                    File.Delete(string.Format(filepath + @"\" + filename + i.ToString()));
                }
                if (File.Exists(fileNameAndPath + ".cfg"))
                {
                    string ssname = string.Format(fileNameAndPath + ".cfg");
                    File.Delete(ssname);
                }
                //重置所有字段的信息
                clear();
            }
        }
        #endregion

        #region 重置所有字段信息的方法
        /// <summary>
        /// 重置所有字段信息的方法
        /// </summary>
        private void clear()
        {
            downloadUrl = string.Empty;//重置下载地址
            stop = false;//标记下载状态为未暂停
            filename = string.Empty;//重置文件名称
            fileNameAndPath = string.Empty;//重置文件路径及名称
            filepath = string.Empty;//重置文件路径
            lbo = new List<bool>();//重置每条线程下载状态
            xiancheng = 0;//重置线程数量
            lli = new List<Locations>();//重置续传信息
            complete = true;//标记当前对象，下载状态为“已完成”
        }
        #endregion

        #region 返回资源下载状态信息
        /// <summary>
        /// 返回资源下载状态信息
        /// </summary>
        /// <returns>返回字符串数组</returns>
        public string[] showmessage()
        {
            TimeSpan dt2 = DateTime.Now - dtbegin;
            return new string[] { filename, ((filesize / 1024)/1024).ToString()+"MB",
            (Process()).ToString()+"%",
            (Process2()/1024).ToString()+"KB"+@"/"+(filesize/1024).ToString()+"KB",
            string.Format("{0}小时{1}分{2}秒",dt2.Hours.ToString(),dt2.Minutes.ToString(),dt2.Seconds.ToString()),
            filename.Substring(filename.LastIndexOf("."),4),
            dtbegin.ToString("yy-MM-dd  hh:mm:ss")};
        }
        /// <summary>
        /// 返回资源下载的百分比
        /// </summary>
        /// <returns>返回百分比信息</returns>
        private int Process()
        {
            try
            {
                long ll = 0;
                for (int i = 0; i < lli.Count; i++)
                {
                    ll += lli[i].Start - lli[i].Ls.Start;
                }
                int i1 = (int)(ll * 100 / filesize);
                return i1;
            }
            catch (Exception ex)
            {
                writelog(ex.Message);
                return 0;
            }
        }
        /// <summary>
        /// 返回文件已经下载的长度
        /// </summary>
        /// <returns></returns>
        private int Process2()
        {
            long ll = 0;
            for (int i = 0; i < lli.Count; i++)
            {
                ll += lli[i].Start - lli[i].Ls.Start;
            }
            return (int)ll;
        }
        #endregion

        #region 关闭所有下载或续传线程
        /// <summary>
        /// 用于关闭所有下载或续传线程
        /// </summary>
        public void AbortThread()
        {
            foreach (var item in G_thread_Collection)
            {
                item.Abort();
            }
        }
        #endregion

        #region 测试是否支持多线程下载
        bool GetBool(string url)
        {
            List<Thread> lth = new List<Thread>();//创建线程集合
            int count = 0;//临时变量
            for (int i = 0; i < 3; i++)//循环遍历
            {
                Thread th = new Thread(//创建线程对象
                    delegate()//匿名方法
                    {
                        try
                        {
                            //使用下载地址创建HttpWebRequest对象
                            HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create(url);
                            hwr.Timeout = 3000;//设置超时时间为3秒
                            HttpWebResponse hwp = (HttpWebResponse)hwr.GetResponse();//获取网络资源响应
                            hwr.Abort();//取消响应
                        }
                        catch
                        {
                            count++;//临时变量值加1
                        }
                    });
                th.Name = i.ToString();//设置线程名称
                th.IsBackground = true;//设置线程后台运行
                th.Start();//开始线程
                lth.Add(th);//将当前线程添加到线程集合中
            }
            foreach (var item in lth)//遍历线程集合
            {
                item.Join();//顺序执行线程
            }
            return count == 0;//判断是否支持多线程
        }
        #endregion
    }
}
