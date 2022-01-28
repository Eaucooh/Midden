using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MathHelper
{
    public class Basic
    {
        /// <summary>
        /// 返回指定数的符号
        /// </summary>
        /// <param name="num">数</param>
        /// <returns>符号</returns>
        public static bool Sign(decimal num)
        {
            if (num > 0)
            {
                return true;
            }
            else if (num == 0)
            {
                throw new ArgumentException();
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 打印乘法表，例如start=1，step=9时会打印出一张九九乘法表
        /// 该表如下：
        /// 1*1=1
        /// 1*2=2   2*2=4
        /// 1*3=3   2*3=6   3*3=9
        /// 1*4=4   2*4=8   3*4=12  4*4=16
        /// 1*5=5   2*5=10  3*5=15  4*5=20  5*5=25
        /// 1*6=6   2*6=12  3*6=18  4*6=24  5*6=30  6*6=36
        /// 1*7=7   2*7=14  3*7=21  4*7=28  5*7=35  6*7=42  7*7=49
        /// 1*8=8   2*8=16  3*8=24  4*8=32  5*8=40  6*8=48  7*8=56  8*8=64
        /// 1*9=9   2*9=18  3*9=27  4*9=36  5*9=45  6*9=54  7*9=63  8*9=72  9*9=81
        /// </summary>
        /// <param name="start">指示该表从哪个值开始</param>
        /// <param name="step">指示该表到哪个值结束</param>
        /// <returns>返回制表结果</returns>
        public static string MultiplicationChart(int start, int step)
        {
            string chart = null;
            for (int x = start; x <= step; x++)
            {
                for (int y = start; y <= x; y++)
                {
                    chart += $"{y}*{x}={x * y}\t";
                }
                chart += "\n";
            }
            return chart;
        }

        /// <summary>
        /// 打印反向乘法表，例如start=1，step=9时会打印出一张九九乘法表
        /// 该表如下：
        /// 1*9=9   2*9=18  3*9=27  4*9=36  5*9=45  6*9=54  7*9=63  8*9=72  9*9=81
        /// 1*8=8   2*8=16  3*8=24  4*8=32  5*8=40  6*8=48  7*8=56  8*8=64
        /// 1*7=7   2*7=14  3*7=21  4*7=28  5*7=35  6*7=42  7*7=49
        /// 1*6=6   2*6=12  3*6=18  4*6=24  5*6=30  6*6=36
        /// 1*5=5   2*5=10  3*5=15  4*5=20  5*5=25
        /// 1*4=4   2*4=8   3*4=12  4*4=16
        /// 1*3=3   2*3=6   3*3=9
        /// 1*2=2   2*2=4
        /// 1*1=1
        /// </summary>
        /// <param name="start">指示该表从哪个值开始</param>
        /// <param name="step">指示该表到哪个值结束</param>
        /// <returns>返回制表结果</returns>
        public static string MultiplicationChart_bottomUp(int start, int step)
        {
            string chart = null;
            for (int x = step; x >= start; x--)
            {
                for (int y = start; y <= x; y++)
                {
                    chart += $"{y}*{x}={x * y}\t";
                }
                chart += "\n";
            }
            return chart;
        }

        /// <summary>
        /// 获取指定位数的数字
        /// 例如：456取2位数返回5，6892取4位数返回6
        /// </summary>
        /// <param name="number">指示要被获取指定位数字的数字</param>
        /// <param name="bit">指示要获取的位数</param>
        /// <returns>返回指定位上数字</returns>
        public static int GetBit(int number, int bit)
        {
            int pow = 10;
            for (int i = 0; i < bit - 1; i++)
            {
                pow *= pow;
            }
            return (number % pow) / (pow / 10);
        }

        /// <summary>
        /// 在枚举类型中检查是否存在某个对象
        /// </summary>
        /// <param name="target">要检查的对象</param>
        /// <param name="source">从此枚举类型中检查</param>
        /// <returns>是否存在</returns>
        public static bool ExistItem(object target, List<object> list)
        {
            foreach (var item in list)
            {
                if (target.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取随机序列
        /// </summary>
        /// <param name="length">序列长度</param>
        /// <returns></returns>
        public static int[] RandomIndexList(int length)
        {
            if (Sign(length))
            {
                List<object> Registed_Index = new List<object>();
                int[] index = new int[length];
                Random random = new Random(0);
                for (int i = 0; i < index.Length; i++)
                {
                    index[i] = random.Next(0, index.Length);
                    while (ExistItem(index[i], Registed_Index))
                    {
                        index[i] = random.Next(0, index.Length);
                    }
                }
                return index;
            }
            else
            {
                throw new Exception("length should be bigger than 0.");
            }
        }

        /// <summary>
        /// 判断是否为奇数
        /// </summary>
        /// <param name="num">数</param>
        /// <returns>True - 奇数；False - 偶数</returns>
        public static bool IsOdd(int num)
        {
            return (num % 2) == 1;
        }
    }
}
