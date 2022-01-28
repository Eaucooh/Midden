using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.TextHelper
{
    public class Basic
    {
        /// <summary>
        /// 按格式返回序列化的数组
        /// </summary>
        /// <param name="arr">数组</param>
        /// <param name="start">开始标识符</param>
        /// <param name="end">结束标识符</param>
        /// <param name="connecter">连接符</param>
        /// <param name="shouldSpace">是否添加空格</param>
        /// <returns>格式化的字符串</returns>
        public static string ArrayPrint(int[] arr, char start, char end, char connecter, bool shouldSpace)
        {
            string rst = start.ToString();
            for (int i = 0; i < arr.Length; i++)
            {
                rst += $"{(shouldSpace ? " " : null)}{arr[i]}{(shouldSpace ? " " : null)}{(i == (arr.Length) ? connecter.ToString() : null)}";
            }
            rst += end;
            return rst;
        }

        /// <summary>
        /// 按格式返回序列化的数组
        /// </summary>
        /// <param name="arr">数组</param>
        /// <param name="start">开始标识符</param>
        /// <param name="end">结束标识符</param>
        /// <param name="connecter">连接符</param>
        /// <param name="shouldSpace">是否添加空格</param>
        /// <returns>格式化的字符串</returns>
        public static string ArrayPrint(char[] arr, char start, char end, char connecter, bool shouldSpace)
        {
            string rst = start.ToString();
            for (int i = 0; i < arr.Length; i++)
            {
                rst += $"{(shouldSpace ? " " : null)}{arr[i]}{(shouldSpace ? " " : null)}{(i == (arr.Length) ? connecter.ToString() : null)}";
            }
            rst += end;
            return rst;
        }
    }
}
