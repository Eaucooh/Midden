using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace Library.Windows
{
    public class MoveHelper
    {
        public Window TargetWindow
        {
            get { return target; }
            set { target = value.Equals(null) ? null : value; }
        }
        private Window target;

        /// <summary>
        /// 获取窗体句柄
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 设置目标窗体大小，位置
        /// </summary>
        /// <param name="hWnd"> 目标句柄 </param>
        /// <param name="x"> 目标窗体新位置 X 轴坐标 </param>
        /// <param name="y"> 目标窗体新位置 Y 轴坐标 </param>
        /// <param name="nWidth"> 目标窗体新宽度 </param>
        /// <param name="nHeight"> 目标窗体新高度 </param>
        /// <param name="BRePaint"> 是否刷新窗体 </param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);

        /// <summary>
        /// 设置窗口大小和位置
        /// </summary>
        /// <param name="name">窗口名 - Title</param>
        /// <param name="x">距离屏幕左端距离</param>
        /// <param name="y">距离屏幕上端距离</param>
        /// <param name="nw">新的宽度</param>
        /// <param name="nh">新的高度</param>
        /// <returns>操作是否成功</returns>
        public bool Set_Size_Location(string name, int x, int y, int nw, int nh)
        {
            try
            {
                IntPtr intptr = FindWindow(null, name);
                MoveWindow(intptr, x, y, nw, nh, true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 设置窗口大小和位置
        /// </summary>
        /// <param name="win">窗口句柄</param>
        /// <param name="x">距离屏幕左端距离</param>
        /// <param name="y">距离屏幕上端距离</param>
        /// <param name="nw">新的宽度</param>
        /// <param name="nh">新的高度</param>
        /// <returns>操作是否成功</returns>
        public bool Set_Size_Location(IntPtr win, int x, int y, int nw, int nh)
        {
            try
            {
                MoveWindow(win, x, y, nw, nh, true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Test(Window win)
        {
            IntPtr intptr = FindWindow(null, win.Title);
            for (int i = 0; i < 400; ++ i)
            {
                Set_Size_Location(intptr, (int)(win.Left + 2), (int)win.Top, (int)win.Width, (int)win.Height);
            }
        }
    }
}
