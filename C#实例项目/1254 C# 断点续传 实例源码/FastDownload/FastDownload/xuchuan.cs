using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace FastDownload
{
    public class xuchuan
    {
        #region 全局私有字段
        public bool stop = false;//暂停下载开关
        public string fileNameAndPath;//下载文件的路径及文件名
        public string filepath;//下载文件的路径
        public System.Collections.Generic.List<bool> lbo = new List<bool>();//判断所有线程是否全部下载完成
        public int xiancheng;//下载文件所使用线程的数量
        public List<Locations> lli;//记录续传信息的可序列化类的集合
        public bool complete = false;//文件下载是否完成
        public string filename;//下载文件的名称
        public DateTime dtbegin;//文件开始下载的时间
        public long filesize;//下载文件的大小
        public bool stop2 = false;//停止下载，并删除下载文件 开关
        public bool state = false;//续传的状态，是否为已经执行
        private AutoResetEvent are = new AutoResetEvent(true);
        public List<Thread> G_thread_Collection = new List<Thread>();
        //是否支持多线程下载
        private bool b_thread = false;
        #endregion

        #region 续传开始的第一个方法
        /// <summary>
        /// 续传开始的第一个方法
        /// </summary>
        /// <param name="sm">文件流对象</param>
        /// <param name="filenames">续传文件的文件名</param>
        public void Begin(Stream sm, string filenames)
        {
            BinaryFormatter bf = new BinaryFormatter();//实例化二进制格式对象
            lli = (List<Locations>)bf.Deserialize(sm);//反序列化，得到续传信息
            dtbegin = DateTime.Now;//设置开始续传的时间，用于显示给用户
            if (lli.Count > 0)
            {
                filesize = lli[lli.Count - 1].Filesize;//得到文件的总大小
            }
            xiancheng = lli.Count;//判断续传时需要多少线程
            string s = filenames;//得到续传文件名称
            fileNameAndPath = s.Substring(0,
                s.Length - 4);//得到续传完成后，下载到本地文件的文件路径及名称
            filename = fileNameAndPath.Substring(fileNameAndPath.LastIndexOf(@"\") + 1,
                fileNameAndPath.Length - (fileNameAndPath.LastIndexOf(@"\") + 1));//得到文件名称
            new Set().GetConfig();
            filepath = Set.Path;//得到文件路径
            for (int i = 0; i < lli.Count; i++)//为每条线程分配续传任务
            {
                lbo.Add(false);//设置续传的文件为未完成
                Thread th = new Thread(GetData);//建立线程，处理每条续传
                th.Name = i.ToString();//设置线程的名称
                th.IsBackground = true;//将线程属性设置为后台线程
                th.Start(lli[i]);//线程开始
            }
            b_thread = GetBool(lli[0].Url);
            hebinfile();//合并文件线程开始启动
            sm.Close();//关闭文件流对象
        }
        #endregion

        #region 使每条线程进行续传动作的方法
        /// <summary>
        /// 使每条线程进行续传动作的方法
        /// </summary>
        /// <param name="l">续传信息(包括续传的开始点和结束点)</param>
        public void GetData(object l)
        {
            FileStream fs = null;
            Stream ss = null;
            try
            {
                //得到续传信息对象(也就是文件下载或续传的开始点与结束点)
                Locations ll = (Locations)l;
                //根据是否支持多线程来判断是否使用线程事件控制线程下载顺序
                if (!b_thread) are.WaitOne(); else are.Set();
                //根据下载地址，创建HttpWebRequest对象
                HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create(ll.Url);
                //设置下载请求超时为200秒
                hwr.Timeout = 6000;
                if (ll.Start > ll.End || ll.Start == ll.End)
                {
                    lbo[Convert.ToInt32(System.Threading.Thread.CurrentThread.Name)] = true;
                    are.Set();
                    return;
                }
                //设置当前线程续传或下载任务的开始点与结束点
                hwr.AddRange(ll.Start, ll.End);
                //得到HttpWebResponse对象
                HttpWebResponse hwp = (HttpWebResponse)hwr.GetResponse();
                //根据HttpWebResponse对象的GetResponseStream()方法得到用于下载数据的网络流对象
                ss = hwp.GetResponseStream();
                //设置文件下载的缓冲区
                byte[] buffer = new byte[Convert.ToInt32(Set.NetValue)*8];
                //新建文件流对象，用于存放当前每个线程下载的文件
                if(filepath.EndsWith("\\"))
                    fs = new FileStream(
                    string.Format(filepath + filename + Thread.CurrentThread.Name),
                    FileMode.Append);
                else
                    fs = new FileStream(
                        string.Format(filepath + @"\" + filename + Thread.CurrentThread.Name),
                        FileMode.Append);
                //用于计数，每次下载有效字节数
                int i;
                //当前线程的索引
                int nns = Convert.ToInt32(Thread.CurrentThread.Name);
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
                    //点击删除按钮后，使下载过程强型停止
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
                lbo[Convert.ToInt32(Thread.CurrentThread.Name)] = true;
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
                if (!b_thread) are.Set(); else are.Set();
            }
        }
        #endregion

        #region 返回资源续传状态信息
        /// <summary>
        /// 返回资源下载状态信息
        /// </summary>
        /// <returns>返回字符串数组对象</returns>
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
        private int Process()//返回文件续传的百分比
        {
            long ll = 0;
            for (int i = 0; i < lli.Count; i++)
            {

                ll += lli[i].Start - lli[i].Ls.Start;
            }
            return (int)(ll * 100 / filesize);
        }
        private int Process2()//返回文件已经续传的长度
        {
            long ll = 0;
            for (int i = 0; i < lli.Count; i++)
            {

                ll += lli[i].Start - lli[i].Ls.Start;
            }
            return (int)ll;
        }
        #endregion

        #region 监控文件是否完成下载的方法
        /// <summary>
        /// 监控文件是否完成下载的方法
        /// </summary>
        private void hebinfile()
        {
            System.Threading.Thread th2 = new System.Threading.Thread(//创建线程
              delegate()//使用匿名方法
              {
                  
                  while (true)//每隔一秒，检测是否所有线程都完成了下载任务
                  {
                      if (!lbo.Contains(false))//如果所有线程都完成了下载任务
                      {
                          GetFile();//开始合并文件
                          break;//停上检测线程
                      }
                      else
                      {
                          if (this.stop2) DeleteFile();
                      }
                      System.Threading.Thread.Sleep(1000);
                  }
              });
            th2.IsBackground = true;//此线程是后台线程
            th2.Start();//线程开始
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
            else
            {
                //新建文件流对象,此流对象用于生成下载后得到的文件
                FileStream fs = new FileStream(fileNameAndPath, FileMode.Create);
                byte[] buffer = new byte[2000];//新建缓冲区对象
                //开始遍历每条线程下载后得到的文件，并从每个文件中读取内容，放入一个文件中
                new Set().GetConfig();
                filepath = Set.Path;
                if (filepath.EndsWith("\\"))
                    filepath.Remove(filepath.LastIndexOf("\\"));
                for (int i = 0; i < xiancheng; i++)
                {
                    //新建文件流对象，此流对象用于引用每一个线程下载的文件，
                    //并将所有文件按照顺序放入一个文件中去，此文件就是多线程下载的文件
                    FileStream fs2 = new FileStream(string.Format(filepath + @"\" + filename + i.ToString()), FileMode.Open);
                    int i2;
                    while ((i2 = fs2.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fs.Write(buffer, 0, i2);
                    }
                    fs2.Close();//关闭流对象
                }
                fs.Close();//关闭流对象
                DeleteFile();//调用删除文件方法
            }
        }
        #endregion

        #region 删除文件方法
        /// <summary>
        /// 删除文件方法
        /// </summary>
        private void DeleteFile()
        {
            //关闭所有下载或续传线程
            foreach (var item in G_thread_Collection)
            {
                if (item.Name != Thread.CurrentThread.Name)
                {
                    item.Abort();
                }
            }
            if (stop2)//删除所有生成的文件
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
                clear();//重置所有字段的信息
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
                clear();//重置所有字段的信息
            }
        }
        #endregion

        #region 重置所有字段信息的方法
        /// <summary>
        /// 重置所有字段信息的方法
        /// </summary>
        private void clear()
        {
            stop = false;//标记下载状态为未暂停
            fileNameAndPath = string.Empty;//重置文件路径及文件名称
            filepath = string.Empty;//重置文件路径
            lbo = new List<bool>();//重置线程完成状态
            xiancheng = 0;//重置线程数量
            lli = new List<Locations>();//重置续传信息
            complete = true;//标记当前对象，下载状态为“已完成”
        }
        #endregion

        #region 写入异常日志的方法
        /// <summary>
        /// 写入异常日志的方法
        /// </summary>
        /// <param name="s">异常信息</param>
        private void writelog(string s)
        {
                StreamWriter fs = new StreamWriter(@"c:\DownLoad.log", true);//新建文件流对象
                //将异常信息及异常出现的时间写入流中
                fs.Write(string.Format(s + DateTime.Now.ToString("yy-MM-dd  hh:mm:ss")));
                fs.Flush();//清空缓冲区，使缓冲区内数据压入流
                fs.Close();//关闭文件流对象
        }
        #endregion

        #region 保存续传信息的方法
        /// <summary>
        /// 保存续传信息的方法
        /// </summary>
        public void SaveState()
        {
            BinaryFormatter bf = new BinaryFormatter();//实例化二进制格式对象
            MemoryStream ms = new MemoryStream();//新建内存流对象
            bf.Serialize(ms, lli);//将续传信息序列化到内存流中
            ms.Seek(0, SeekOrigin.Begin);//将内存流中指针位置 置零
            byte[] bt = ms.GetBuffer();//从内存流中得到字节数组
            FileStream fs = new FileStream(fileNameAndPath + ".cfg", FileMode.Create);//创建文件流对象
            fs.Write(bt, 0, bt.Length);//向文件流中写入数据(字节数组)
            fs.Close();//关闭流对象
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
            List<Thread> lth = new List<Thread>();
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                Thread th = new Thread(
                    delegate()
                    {
                        try
                        {
                            HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create(url);
                            hwr.Timeout = 3000;
                            HttpWebResponse hwp = (HttpWebResponse)hwr.GetResponse();
                            hwr.Abort();
                        }
                        catch
                        {
                            count++;
                        }
                    });
                th.Name = i.ToString();
                th.IsBackground = true;
                th.Start();
                lth.Add(th);
            }
            foreach (var item in lth)
            {
                item.Join();
            }
            return count == 0;
        }
        #endregion
    }
}