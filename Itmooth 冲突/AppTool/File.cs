using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace AppTool
{
    public class File
    {
        /// <summary>
        /// 值读取器，会读取给定路径文件的全部内容
        /// </summary>
        /// <param name="filePath">目标文件路径</param>
        /// <returns></returns>
        public string ValueReader(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string value = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return value;
        }

        /// <summary>
        /// 值写入器，将获取的content写入指定路径（filePath）文件
        /// </summary>
        /// <param name="filePath">目标文件路径</param>
        /// <param name="content">要写入的内容</param>
        /// <returns></returns>
        public bool ValueWriter(string filePath, string content)
        {
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(content);
                sw.Flush();
                sw.Close();
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}