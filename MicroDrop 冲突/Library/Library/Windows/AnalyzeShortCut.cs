using IWshRuntimeLibrary;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Library.Windows
{
    public class AnalyzeShortCut
    {

        [DllImport("shfolder.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, StringBuilder lpszPath);
        private const int MAX_PATH = 260;
        private const int CSIDL_COMMON_DESKTOPDIRECTORY = 0x0019;

        public static string GetAllUsersDesktopFolderPath()
        {
            StringBuilder sbPath = new StringBuilder(MAX_PATH);
            SHGetFolderPath(IntPtr.Zero, CSIDL_COMMON_DESKTOPDIRECTORY, IntPtr.Zero, 0, sbPath);
            return sbPath.ToString();
        }

        public class FilePathModel
        {
            public string Name { get; set; }
            public string Filepath { get; set; }
            public string FileTargetPath { get; set; }
        }

        /// <summary>
        /// 从快捷方式路径获取快捷方式
        /// </summary>
        /// <param name="path">快捷方式路径</param>
        /// <returns>快捷方式类</returns>
        public static IWshShortcut GetShortCut(string path)
        {
            if (System.IO.File.Exists(path))
            {
                IWshShortcut nowShort = (IWshShortcut)new WshShell().CreateShortcut(path);
                return nowShort;
            }
            else
            {
                return null;
            }
        }
    }
}
