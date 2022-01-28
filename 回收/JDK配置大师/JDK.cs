using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JDK配置大师
{
    class JDK
    {
        public string workBase = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 初始化一个JDK类
        /// </summary>
        public JDK()
        {

        }

        /// <summary>
        /// 初始化一个包含版本，大小，日期，更多的JDK类
        /// </summary>
        /// <param name="version">版本</param>
        /// <param name="size">安装包大小</param>
        /// <param name="date">发布日期</param>
        /// <param name="more">更多</param>
        public JDK(string version, string name, string size, DateTime date, string more, string info)
        {
            Version = version; Name = name; Size = size; Date = date; More = more; Info = info;
        }

        public string Version;

        public string Size;

        public DateTime Date;

        public string More;

        public string Name;

        public string Info;

        public bool Install(string dir)
        {
            //1.复制压缩包到dir路径
            try
            {
                File.Copy(workBase + $@"\lib\{Version}.zip", dir, true);
                return true;
            }
            catch (Exception u)
            {
                MessageBox.Show($"复制压缩包失败！错误原因如下：\n{u.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }        
    }
}
