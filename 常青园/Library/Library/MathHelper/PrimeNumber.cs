using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MathHelper
{
    public class PrimeNumber
    {
        /// <summary>
        /// 判断一个数是否为素数
        /// </summary>
        /// <param name="num">被判断的数</param>
        /// <returns>是否为素数</returns>
        public static bool? IsPrimeNumber(int num)
        {
            if (num != 1)
            {
                for (double i = 2; i < Math.Truncate(Math.Sqrt(num)); i += 0.1)
                {
                    if (i % num == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 返回指定区间内素数数量
        /// </summary>
        /// <param name="startN">区间起点</param>
        /// <param name="endN">区间终点</param>
        /// <returns>素数数量</returns>
        public static int GetCountInZone(int startN, int endN)
        {
            if (startN<endN)
            {
                int count = 0;
                for (int i = startN; i < endN; i++)
                {
                    if (i!=1)
                    {
                        count += (bool)IsPrimeNumber(i) ? 1 : 0;
                    }
                }
                return count;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// 返回指定区间内素数列表
        /// </summary>
        /// <param name="startN">区间起点</param>
        /// <param name="endN">区间终点</param>
        /// <returns>素数列表</returns>
        public static List<int> GetListInZone(int startN, int endN)
        {
            if (startN < endN)
            {
                List<int> collector = new List<int>();
                for (int i = startN; i < endN; i++)
                {
                    if (i != 1)
                    {
                        if ((bool)IsPrimeNumber(i))
                        {
                            collector.Add(i);
                        }
                    }
                }
                return collector;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
