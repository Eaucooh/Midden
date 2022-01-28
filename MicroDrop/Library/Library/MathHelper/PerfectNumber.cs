using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MathHelper
{
    public class PerfectNumber
    {
        /// <summary>
        /// 判断是否为合数
        /// </summary>
        /// <param name="num">被判断的数</param>
        /// <returns>返回是否为合数</returns>
        public static bool IsPerfectNumber(int num)
        {
            if (num != 1 && num > 1 && (bool)CompositeNumber.IsCompositeNumber(num))
            {
                int sum = 0;
                foreach (int item in CompositeNumber.GetCompositions(num))
                {
                    sum += item;
                }
                return sum == num;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 返回指定区间内合数数量
        /// </summary>
        /// <param name="startN">区间起点</param>
        /// <param name="endN">区间终点</param>
        /// <returns>合数数量</returns>
        public static int GetCountInZone(int startN, int endN)
        {
            if (startN < endN)
            {
                int count = 0;
                for (int i = startN; i < endN; i++)
                {
                    if (i > 1)
                    {
                        count += IsPerfectNumber(i) ? 1 : 0;
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
        /// 返回指定区间内合数列表
        /// </summary>
        /// <param name="startN">区间起点</param>
        /// <param name="endN">区间终点</param>
        /// <returns>合数列表</returns>
        public static List<int> GetListInZone(int startN, int endN)
        {
            if (startN < endN)
            {
                List<int> collector = new List<int>();
                for (int i = startN; i < endN; i++)
                {
                    if (i > 1)
                    {
                        if (IsPerfectNumber(i))
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
