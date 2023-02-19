using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ape_System
{
    public class Mouse
    {
        /// <summary>
        /// 设置鼠标的坐标
        /// </summary>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        [DllImport("User32.dll")]
        public extern static void SetCursorPos(int x, int y);
        public struct POINT
        {
            public int X;
            public int Y;
            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            }

        }

        /// <summary>
        /// 获取鼠标的坐标
        /// </summary>
        /// <param name="lpPoint">传址参数，坐标point类型</param>
        /// <returns>获取成功返回真</returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(out POINT pt);

        public POINT GetCursorPosition_ReturnPOINT()
        {
            if (GetCursorPos(out POINT p))//API方法
            {
                //position = string.Format("X:{0}   Y:{1}", p.X, p.Y);
                return p;
            }
            else
            {
                return new POINT(0, 0);
            }
        }

        public System.Drawing.Point GetCursorPosition_ReturnPoint()
        {
            if (GetCursorPos(out POINT p))//API方法
            {
                //position = string.Format("X:{0}   Y:{1}", p.X, p.Y);
                return new System.Drawing.Point(p.X, p.Y);
            }
            else
            {
                return new System.Drawing.Point(0, 0);
            }
        }
    }
}
