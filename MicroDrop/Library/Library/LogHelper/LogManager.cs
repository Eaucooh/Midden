using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LogHelper
{
    public class LogManager
    {
        public string Name { get; set; }

        public LogManager()
        {

        }

        public LogManager(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 向指定日志文件中追加日志,返回是否追加成功
        /// </summary>
        /// <param name="path">日志文件路径</param>
        /// <param name="content">日志内容</param>
        /// <param name="isNewLine">是否换行</param>
        /// <returns></returns>
        public static bool SimpleWrite(string path, string content, bool isNewLine)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                }
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                FileStream fs = new FileStream(path, FileMode.Append);
                StreamWriter sm = new StreamWriter(fs);
                if (isNewLine)
                {
                    sm.WriteLine(content);
                }
                else
                {
                    sm.Write(content);
                }
                sm.Flush();
                sm.Close();
                fs.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
