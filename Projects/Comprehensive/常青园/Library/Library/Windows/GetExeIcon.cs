using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Library.Windows
{
    public class GetExeIcon
    {
        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        private static extern int ExtractIconEx(string lpszFile, int niconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, int nIcons);
        private static extern int ExtractIcon(string lpszFile, int niconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, int nIcons);

        public IntPtr[][] GetIcon(string appPath)
        {
            IntPtr[] largeIcons, smallIcons;  //存放大/小图标的指针数组

            //第一步：获取程序中的图标数

            int IconCount = ExtractIconEx(appPath, -1, null, null, 0);

            //第二步：创建存放大/小图标的空间

            largeIcons = new IntPtr[IconCount];

            smallIcons = new IntPtr[IconCount];

            //第三步：抽取所有的大小图标保存到largeIcons和smallIcons中

            ExtractIconEx(appPath, 0, largeIcons, smallIcons, IconCount);

            return new IntPtr[2][]
            {
                largeIcons, smallIcons
            };
        }
    }

    public class GetAppIcon
    {
        /// <summary>
        /// 获取应用程序的图标
        /// </summary>
        /// <param name="fileName">应用路径</param>
        /// <returns>图片</returns>
        public static ImageSource GetIcon(string fileName)
        {
            System.Drawing.Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileName);
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                  icon.Handle,
                  new Int32Rect(0, 0, icon.Width, icon.Height),
                  BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
