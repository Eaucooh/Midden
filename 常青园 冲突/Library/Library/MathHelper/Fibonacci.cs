using System.Collections.Generic;

namespace Library.MathHelper
{
    public class Fibonacci
    {
        /// <summary>
        /// 斐波那契数列,递归算法
        /// </summary>
        /// <param name="num">第num位数的值</param>
        /// <returns>返回第num位数</returns>
        public static string FbnqSort(string num, string n1, string n2)
        {
            if (num.Equals(n1)) return n1;
            else if(num.Equals(n2)) return n2;
            else return Hpc.Sum(FbnqSort((long.Parse(num) - 1).ToString(), n1, n2), FbnqSort((long.Parse(num) - 2).ToString(), n1, n2).TrimStart('0'));
        }

        /// <summary>
        /// 斐波那契数列,循环算法
        /// </summary>
        /// <param name="num">第num位数的值</param>
        /// <returns>返回第num位数</returns>
        public static string FbnqSort2(long num, string num1, string num2)
        {
            string ret = "0";
            for (int i = 0; i < num - 2; i++)
            {
                ret = Hpc.Sum(num1, num2).TrimStart('0');
                num1 = num2;
                num2 = ret;
            }
            return ret;
        }

        /// <summary>
        /// 斐波那契数列,循环算法
        /// </summary>
        /// <param name="num">第num位数的值</param>
        /// <returns>返回第num位数</returns>
        public static List<long> FbnqSort2_List(long num, long num1, long num2)
        {
            List<long> res = new List<long>();
            long ret;
            for (long i = 0; i < num - 2; i++)
            {
                ret = num1 + num2;
                res.Add(ret);
                num1 = num2;
                num2 = ret;
            }
            return res;
        }

        public static long[] via = new long[long.MaxValue];

        /// <summary>
        /// 斐波那契数列, 记忆化递归
        /// </summary>
        /// <param name="n">f(n)</param>
        /// <param name="num1">f(1)</param>
        /// <param name="num2">f(2)</param>
        /// <returns></returns>
        public static long FbnqSortMemort(long n, long num1, long num2)
        {
            if (n == num1 || n == num2) return 1;
            else
            {
                long tmp = (via[n - 1] == 0 ? FbnqSortMemort(n - 1, num1, num2) : via[n - 1]) + (via[n - 2] == 0 ? FbnqSortMemort(n - 2, num1, num2) : via[n - 2]);
                via[n] = tmp;
                return tmp;
            }
        }
    }
}
