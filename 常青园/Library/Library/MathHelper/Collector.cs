using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MathHelper
{
    public class Collector
    {
        public enum Direct { Left, Right }

        /// <summary>
        /// 将矩阵数组按角度旋转后输出，一次为九十度
        /// </summary>
        /// <param name="source">源数组</param>
        /// <param name="diret">旋转方向</param>
        /// <param name="times">旋转次数</param>
        /// <returns></returns>
        public static string[][] Rotate_SimpleScale(string[][] source, Direct diret, int times)
        {
            //判断源数组是否为矩阵
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i].Length != source.Length)
                {
                    return null;
                }
            }

            //计算角度
            int angle = 0;
            switch (diret)
            {
                case Direct.Left:
                    angle = 90 * times;
                    break;
                case Direct.Right:
                    angle = -90 * times;
                    break;
            }

            //化简角度
            angle = Basic.Sign(angle) ? angle - (360 * angle % 360) : angle + (360 * -angle % 360);

            //旋转
            switch (angle)
            {
                case 90:

                    break;
                case 180:
                    return Rotate_SimpleScale(source, Direct.Left, 2);
                case 270:
                    return Rotate_SimpleScale(source, Direct.Right, 1);
                case -90:

                    break;
                case -180:
                    return Rotate_SimpleScale(source, Direct.Right, 2);
                case -270:
                    return Rotate_SimpleScale(source, Direct.Left, 1);
            }

            return null;
        }
    }
}
