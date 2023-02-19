using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;

namespace DownloadSample
{
    /// <summary>
    /// 
    /// </summary>
    public class Downloader:IDisposable
    {
        /// <summary>
        /// 默认存储路径
        /// </summary>
        private static string defaultDirectory;
        /// <summary>
        /// 默认存储路径
        /// </summary>
        public static string DefaultDirectory
        {
            get
            {
                return defaultDirectory;
            }
            set 
            {
                defaultDirectory = value;
            }
        }
        /// <summary>
        /// 链接地址
        /// </summary>
        private string url;
        /// <summary>
        /// 文件名
        /// </summary>
        private string fileName;
        /// <summary>
        /// 总大小
        /// </summary>
        private long totalSize;
        /// <summary>
        /// 文件路径
        /// </summary>
        private string filePath;
        /// <summary>
        /// 文件存储目录
        /// </summary>
        private string directory;
        /// <summary>
        /// 下载起始位置
        /// </summary>
        private long rangeFrom;
        /// <summary>
        /// 一次请求大小
        /// </summary>
        private long step;
        /// <summary>
        /// 当前进度
        /// </summary>
        private long currentSize;
        /// <summary>
        /// 是否完成
        /// </summary>
        private bool isFinished;
        /// <summary>
        /// 文件流对象，用于生成文件
        /// </summary>
        private FileStream fs;
        /// <summary>
        /// 
        /// </summary>
        private int bufferSize = 1024;
        /// <summary>
        /// 是否已完成
        /// </summary>
        public bool IsFinished
        {
            get
            {
                return isFinished;
            }
        }
        /// <summary>
        /// 总大小
        /// </summary>
        public long TotalSize 
        { 
            get { return totalSize; } 
        }
        /// <summary>
        /// 当前文件大小
        /// </summary>
        public long CurrentSize
        {
            get { return this.currentSize; }
        }
        /// <summary>
        /// 当前进度的百分数
        /// </summary>
        public float CurrentProgress
        {
            get
            {
                if (this.totalSize != 0)
                {
                    return (float)this.currentSize * 100 / (float)this.totalSize;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 目录地址
        /// </summary>
        public string Directory 
        {
            get { return directory; }
            set { this.directory = value; }
        }
        /// <summary>
        /// 生成文件路径
        /// </summary>
        public string FilePath 
        {
            get { return filePath; }
        }
        /// <summary>
        /// 一次请求大小
        /// 根据带宽及文件大小确定合理的值
        /// 如果带宽：1M,那下载速率约为100KB/秒，那step可设置为12500
        /// </summary>
        public long Step 
        {
            get { return this.step; }
            set { this.step = value; }
        }
        /// <summary>
        /// 缓冲池大小
        /// </summary>
        public int BufferSize
        {
            get { return this.bufferSize; }
            set 
            {
                if (value > 0)
                {
                    this.bufferSize = value; 
                }                
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url"></param>
        public Downloader(string url,string directory)
        {            
            Init(url,directory);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="url"></param>
        /// <param name="directory"></param>
        private void Init(string url, string directory)
        {
            if (string.IsNullOrEmpty(url))
            {
                return;
            }

            this.url = url;
            this.directory = directory;
            this.fileName = url.Substring(url.LastIndexOf('/') + 1);
            string fullName = Path.Combine(this.directory, fileName);
            int num = 1;
            while (File.Exists(fullName))
            {
                fullName = fullName.Insert(fullName.LastIndexOf('.'), num.ToString());
            }
            this.filePath = fullName;

            this.fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }
        /// <summary>
        /// 下载
        /// </summary>
        public void Download()
        {
            //从0计数，需要减一
            long from = this.currentSize;
            if (from < 0)
            {
                from = 0;
            }

            long to = this.currentSize + this.step - 1;
            if (to >= this.totalSize && this.totalSize > 0)
            {
                to = this.totalSize - 1;
            }
            this.Download(from, to);
        }
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="range"></param>
        public void Download(long from,long to)
        {
            if (this.totalSize == 0)
            {
                GetTotalSize();
            }
            if (from >= this.totalSize || this.currentSize >= this.totalSize)
            {
                this.isFinished = true;
                return;
            }


            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            //request.Method = "GET";            
            request.AddRange("bytes", from, to);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string result = string.Empty;
            if (response != null)
            {
                byte[] buffer = this.Buffer;
                using (Stream stream = response.GetResponseStream())
                {
                    int readTotalSize = 0;
                    int size = stream.Read(buffer, 0, buffer.Length);
                    while (size > 0)
                    {
                        //只将读出的字节写入文件
                        fs.Write(buffer, 0, size);
                        readTotalSize += size;
                        size = stream.Read(buffer, 0, buffer.Length);
                    }

                    //更新当前进度
                    this.currentSize += readTotalSize;

                    //如果返回的response头中Content-Range值为空，说明服务器不支持Range属性，不支持断点续传,返回的是所有数据
                    if (response.Headers["Content-Range"] == null)
                    {
                        this.isFinished = true;
                    }
                }
            }
        }
        /// <summary>
        /// 获取文件总大小
        /// </summary>
        public void GetTotalSize()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.url);
            WebResponse response = request.GetResponse();
            this.totalSize = response.ContentLength;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private byte[] Buffer
        {
            get
            {
                if (this.bufferSize <= 0)
                {
                    this.bufferSize = 1024;
                }
                return new byte[this.bufferSize];
            }
        }
        /// <summary>
        /// 释放对象
        /// </summary>
        public void Dispose()
        {
            if (this.fs != null)
            {
                this.fs.Close();
            }
        }
    }
}