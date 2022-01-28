using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTool
{
    public class Other
    {
        /// <summary>
        /// 返回小写字母、大写字母、数字以及符号和它们在ASCII中的编码， 用conectionSign连接
        /// </summary>
        /// <param name="conectionSign">连接原字符与编码的字符</param>
        /// <returns></returns>
        public string ASCIIChart(string conectionSign)
        {
            char[] chars_lower = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] chars_upper = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] number = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] sign = { '`', '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '[', '{', ']', '}', '\\', '|', ';', ':', '\'', '"', ',', '>', '.', '>', '/', '?', };
            char[][] ascii = { number, chars_upper, chars_lower, sign };
            string chart = null;
            for (int i = 0; i < ascii.Length; i++)
            {
                for (int o = 0; o < ascii[i].Length; o++)
                {
                    chart += $"{ascii[i][o].ToString()} {conectionSign} {(int)ascii[i][o]}\t  ";
                }
                chart += "\n";
            }
            return chart;
        }
    }
}
