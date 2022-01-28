using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTool
{
    public class Math
    {
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
        /// <returns></returns>
        public string MultiplicationChart(int start,int step)
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
        /// <returns></returns>
        public string MultiplicationChart_bottomUp(int start, int step)
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
        /// <returns></returns>
        public int GetBit(int number, int bit)
        {
            int pow = 10;
            for (int i = 0; i < bit - 1; i++)
            {
                pow *= pow;
            }
            return (number % pow) / (pow / 10);
        }

        public double RandomNum(int start, int end, int steps)
        {

            return 0.618;
        }
    }
}
