using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ape_System
{
    public class Files
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

        /// <summary>
        /// 值追加器，将获取的content追加到指定路径（filePath）文件末尾
        /// </summary>
        /// <param name="filePath">目标文件路径</param>
        /// <param name="content">要追加的内容</param>
        /// <returns></returns>
        public bool ValueAppend(string filePath, string content)
        {
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Append);
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

        /// <summary>
        /// 删除指定文件夹下所有文件(不包括文件夹)，保留空文件夹，返回无法删除的文件个数
        /// </summary>
        /// <param name="path">指定文件夹路径</param>
        /// <returns></returns>
        public int Directory_Clear(string path)
        {
            int error = 0;
            DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(path));
            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }
                catch
                {
                    error++;
                }
            }
            return error;
        }

        /// <summary>
        /// 删除指定文件夹下所有文件(包括文件夹)，返回无法删除的文件和文件夹个数
        /// </summary>
        /// <param name="path">指定文件夹路径</param>
        /// <param name="ShouldDeleteDirectory">是否移除空文件夹</param>
        /// <returns></returns>
        public int Directory_Delete(string path, bool ShouldDeleteDirectory)
        {
            int error = 0;
            try
            {
                //删除这个目录下的所有子目录
                if (Directory.GetDirectories(path).Length > 0)
                {
                    foreach (string var in Directory.GetDirectories(path))
                    {
                        Directory.Delete(var, true);
                    }
                }
                //删除这个目录下的所有文件
                if (Directory.GetFiles(path).Length > 0)
                {
                    foreach (string var in Directory.GetFiles(path))
                    {
                        File.Delete(var);
                    }
                }
                if (ShouldDeleteDirectory)
                {
                    Directory.Delete(path);
                }
            }
            catch
            {
                error++;
            }
            return error;
        }
    }
}
