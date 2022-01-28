using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.FileHelper
{
    public class FileWin
    {
        /// <summary>
        /// 打开一个窗口让用户可以选择一个文件
        /// 返回用户选择的文件位置
        /// </summary>
        /// <param name="format">所能选择的文件格式</param>
        /// <param name="title">选择窗的标题</param>
        /// <returns>用户选择的文件位置</returns>
        public static string OpenFile_Single(Dictionary<string, string> format, string title)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog()
            {
                Multiselect = false,
                CheckFileExists = true,
                InitialDirectory = "C:\\",
                Title = title,
                DereferenceLinks = true
            };
            string mat = null;
            int count = 0;
            foreach (var item in format)
            {
                count++;
                if (count == format.Count)
                {
                    mat += $"{item.Key}|{item.Value}";
                }
                else
                {
                    mat += $"{item.Key}|{item.Value}|";
                }
            }
            ofd.Filter = mat;
            ofd.ShowDialog();
            return ofd.FileName;
        }
    }
}
