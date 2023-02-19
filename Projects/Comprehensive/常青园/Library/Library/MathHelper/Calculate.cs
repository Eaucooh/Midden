using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MathHelper
{
    public class Calculate
    {
        /// <summary>
        /// 最高级区块符
        /// </summary>
        public static char[] Block_HighestLevel = new char[2] { '{', '}' };

        /// <summary>
        /// 中级区块符
        /// </summary>
        public static char[] Block_MiddleLevel = new char[2] { '[', ']' };

        /// <summary>
        /// 低级区块符
        /// </summary>
        public static char[] Block_LowestLevel = new char[2] { '(', ')' };

        /// <summary>
        /// 区块符 - 二维数组
        /// </summary>
        public static char[][] Blocks = new char[3][] { Block_HighestLevel, Block_MiddleLevel, Block_LowestLevel };

        /// <summary>
        /// 判断所给字符是否是区块符，如果是，则返回区块符层级
        /// 0 - 最高级
        /// 1 - 中级
        /// 2 - 最低级
        /// </summary>
        /// <param name="car">所给字符</param>
        /// <returns>层级</returns>
        public static int IsBlockOperator(char car)
        {
            for (int i = 0; i < Blocks.Length; i++)
            {
                for (int j = 0; j < Blocks[i].Length; j++)
                {
                    if (car.Equals(Blocks[i][j]))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// 判断所给字符是否是区块开始符，如果是，则返回区块符层级
        /// 0 - 最高级;
        /// 1 - 中级;
        /// 2 - 最低级;
        /// </summary>
        /// <param name="car">所给字符</param>
        /// <returns>层级</returns>
        public static int IsBlockOperator_Start(char car)
        {
            for (int i = 0; i < Blocks.Length; i++)
            {
                if (car.Equals(Blocks[i][0]))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 在资源中从所给位置寻找下一个目标字符
        /// </summary>
        /// <param name="startIndex">所给位置</param>
        /// <param name="tar">目标字符</param>
        /// <param name="src">资源</param>
        /// <returns>目标字符在资源中的位置</returns>
        public static int NextChar(int startIndex, char tar, string src)
        {
            char[] cuts = src.Substring(startIndex).ToCharArray();
            for (int i = 0; i < cuts.Length; i++)
            {
                if (cuts[i] == tar)
                {
                    return i + startIndex;
                }
            }
            return -1;
        }

        /// <summary>
        /// 在字符串中检查是否存在某个字符
        /// </summary>
        /// <param name="target">要检查的字符</param>
        /// <param name="source">从此字符串中检查</param>
        /// <returns>是否存在</returns>
        public static bool ExistChar(char target, string src)
        {
            char[] source = src.ToCharArray();
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == target)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 分段
        /// </summary>
        /// <param name="exp">字符串</param>
        /// <param name="level">分段依据的区块符等级</param>
        /// <returns>字符串中匹配的第一个区块</returns>
        public static string Cut(string exp, int level)
        {
            char[] sec = exp.ToCharArray();
            for (int i = 0; i < sec.Length; i++)
            {
                if (IsBlockOperator(sec[i]) == level)
                {
                    return exp.Substring(i, NextChar(i, '}', exp) - i + 1);
                }
            }
            return string.Empty;
        }

        public static string CutAll(string exp, int level)
        {
            List<string> blocks = new List<string>();
            while (Library.TextHelper.Text.ExistChar(Blocks[level][0], exp))
            {

            }
            return null;
        }
    }
}
