using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MathHelper
{
    public class Fibonacci
    {
        /// <summary>
        /// 斐波那契数列,递归算法
        /// </summary>
        /// <param name="num">第num位数的值</param>
        /// <returns>返回第num位数</returns>
        public static int FbnqSort(int num)
        {
            if (num <= 0)
                return 0;
            else if (num > 0 && num <= 2)
                return 1;
            else
                return FbnqSort(num - 1) + FbnqSort(num - 2);
        }

        /// <summary>
        /// 斐波那契数列,普通算法
        /// </summary>
        /// <param name="num">第num位数的值</param>
        /// <returns>返回第num位数</returns>
        public static int FbnqSort2(int num)
        {
            int ret = 0;
            int num1 = 1;
            int num2 = 1;
            for (int i = 0; i < num - 2; i++)
            {
                ret = num1 + num2;
                num1 = num2;
                num2 = ret;
            }
            return ret;
        }
    }
}
