using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ConverterHelper
{
    public class Converters
    {
        /// <summary>
        /// Char[] 转换到字符串类型
        /// </summary>
        /// <param name="source">你提供的 char[] </param>
        /// <returns></returns>
        public static string CharArrayToString(char[] source)
        {
            string result = null;
            for (int i = 0; i < source.Length; i++)
            {
                result += source[i];
            }
            return result;
        }
    }
}
