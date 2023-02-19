using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MathHelper
{
    public class CompositeNumber
    {
        /// <summary>
        /// 判断一个数是否为合数
        /// </summary>
        /// <param name="num">被判断的数</param>
        /// <returns>是否为合数</returns>
        public static bool? IsCompositeNumber(int num)
        {
            if (num != 1)
            {
                for (double i = 2; i < Math.Truncate(Math.Sqrt(num)); i += 0.1)
                {
                    if (i % num == 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 分解质因数
        /// </summary>
        /// <param name="num">质因数</param>
        /// <returns>因子</returns>
        public static List<int> GetCompositions(int num)
        {
            List<int> collector = new List<int>();
            for (int i = 2; i <= num; i++)
            {
                if (num % i == 0)
                {
                    collector.Add(i);
                    num /= i;
                    i--;
                }
            }
            return collector;
        }
    }
}
