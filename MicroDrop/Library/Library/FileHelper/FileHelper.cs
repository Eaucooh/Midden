using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.FileHelper
{
    public class FileHelper
    {
        /// <summary>
        /// 向指定的路径文件写入内容
        /// </summary>
        /// <param name="path">指定的路径</param>
        /// <param name="content">内容</param>
        /// <returns>写入是否成功以及异常信息</returns>
        public static Exp.Exception_Simple.Returning WriteIn(string path, string content)
        {
            try
            {
                if (File.Exists(path))
                    File.Delete(path);
                FileStream fs = new FileStream(path, FileMode.CreateNew);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(content); sw.Flush();
                sw.Close(); sw.Dispose();
                fs.Close(); fs.Dispose();
                return new Exp.Exception_Simple.Returning() { SoF = true, Ex = null };
            }
            catch (Exception o)
            {
                return new Exp.Exception_Simple.Returning() { SoF = false, Ex = o };
            }
        }

        /// <summary>
        /// 向指定路径追加文本，如果路径不存在，则创造该路径
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="content">要追加的内容</param>
        public static void Append(string path, string content)
        {
            File.AppendAllText(path, content);
        }

        /// <summary>
        /// 读取指定路径的全部内容
        /// </summary>
        /// <param name="path">指定路径</param>
        /// <returns>内容或异常信息</returns>
        public static string ReadAll(string path)
        {
            string content;
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                content = sr.ReadToEnd();
                sr.Close(); sr.Dispose();
                fs.Close(); fs.Dispose();
                return content;
            }
            else
            {
                return "File didn't exists.";
            }
        }
    }
}
