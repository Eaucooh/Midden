using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MathHelper
{
    public class Sort
    {
        /// <summary>
        /// 升序还是降序
        /// Ascending - 升序
        /// Decending - 降序
        /// </summary>
        public enum Direction { Ascending = 0, Decending = 1 }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="source">源数组</param>
        /// <param name="dir">升序还是降序</param>
        /// <returns>排序后的数组</returns>
        public static int[] BubbleSort(int[] source, Direction dir)
        {
            int[] result = source;
            switch (dir)
            {
                case Direction.Ascending:
                    for (int i = 0; i < result.Length - 1; i++)
                    {
                        for (int j = 0; j < result.Length - 1 - i; j++)
                        {
                            if (result[j] > result[j + 1])
                            {
                                int temp = result[j];
                                result[j] = result[j + 1];
                                result[j + 1] = temp;
                            }
                        }
                    }
                    break;
                case Direction.Decending:
                    for (int i = 0; i < result.Length - 1; i++)
                    {
                        for (int j = 0; j < result.Length - 1 - i; j++)
                        {
                            if (result[j] < result[j + 1])
                            {
                                int temp = result[j];
                                result[j] = result[j + 1];
                                result[j + 1] = temp;
                            }
                        }
                    }
                    break;
            }
            return result;
        }
    }
}
