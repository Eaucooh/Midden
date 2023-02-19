using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.MathHelper
{
    /// <summary>
    /// high precision computation - 高精度计算
    /// </summary>
    public class Hpc
    {
        /// <summary>
        /// 检查字符串是否每一个字符都是数字
        /// </summary>
        /// <param name="p">给定字符串</param>
        /// <returns>是否全为数字</returns>
        public static bool Check_IsAllNum(string p)
        {
            char[] arr = p.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                int unmatchNum = 0;
                for (int q = 0; q < TextHelper.Text.Numbers.Length; q++)
                {
                    if (arr[i] != TextHelper.Text.Numbers[q])
                    {
                        unmatchNum++;
                    }
                }
                if (unmatchNum == 10)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Char 数组 转 Int 数组
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public static int[] CharArrayToIntArray(char[] u)
        {
            int[] rst = new int[u.Length];
            for (int i = 0; i < rst.Length; i++)
            {
                rst[i] = Convert.ToInt32(u[i]);
            }
            return rst;
        }

        /// <summary>
        /// 字符串转 Int 数组
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int[] StringToIntArray(string p)
        {
            char[] t = p.ToCharArray();
            int[] rst = new int[t.Length];
            for (int i = 0; i < rst.Length; i++)
            {
                rst[i] = Convert.ToInt32(t[i].ToString());
            }
            return rst;
        }

        /// <summary>
        /// 将两个 字符数组 互相补位
        /// </summary>
        /// <param name="m">字符数组 m</param>
        /// <param name="n">字符数组 n</param>
        /// <returns>补位好的新数组</returns>
        public static string[] FillPosition(char[] m, char[] n)
        {
            char[][] rst = new char[2][];

            int big_length = ((m.Length - n.Length) >= 0) ? m.Length : n.Length;
            char[] m1 = new char[big_length];
            char[] n1 = new char[big_length];
            if (big_length == m.Length)
            {
                for (int i = 0; i < m.Length; i++)
                {
                    m1[i] = m[i];
                }
                int delta = m.Length - n.Length;
                for (int i = 0; i < big_length; i++)
                {
                    if (i < delta)
                    {
                        n1[i] = '0';
                    }
                    else
                    {
                        n1[i] = n[i - delta];
                    }
                }
            }
            else
            {
                for (int i = 0; i < n.Length; i++)
                {
                    n1[i] = n[i];
                }
                int delta = n.Length - m.Length;
                for (int i = 0; i < big_length; i++)
                {
                    if (i < delta)
                    {
                        m1[i] = '0';
                    }
                    else
                    {
                        m1[i] = m[i - delta];
                    }
                }
            }
            rst[0] = m1; rst[1] = n1;

            string[] result = new string[2];
            string r1 = "";
            for (int i = 0; i < rst[0].Length; i++)
            {
                r1 += rst[0][i];
            }
            string r2 = "";
            for (int i = 0; i < rst[1].Length; i++)
            {
                r2 += rst[1][i];
            }
            result[0] = r1; result[1] = r2;
            return result;
        }

        /// <summary>
        /// 补位
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string[] FillPosition(string m, string n) => FillPosition(m.ToCharArray(), n.ToCharArray());

        /// <summary>
        /// 获取个位
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int GetUnit(int num) => Convert.ToInt32(num.ToString().ToCharArray()[num.ToString().ToCharArray().Length - 1].ToString());

        /// <summary>
        /// 高精度加法
        /// 不支持小数点
        /// </summary>
        /// <param name="a">加数 a</param>
        /// <param name="b">加数 b</param>
        /// <returns>和</returns>
        public static string Sum(string a, string b)
        {
            if (Check_IsAllNum(a) && Check_IsAllNum(b))
            {
                string result = "";
                string[] coverd = FillPosition(a, b);

                int[] a1 = StringToIntArray(coverd[0]), b1 = StringToIntArray(coverd[1]);

                int[] tmp = new int[a1.Length + 1];

                bool cb = false; // carry-bit 进位
                for (int i = a1.Length - 1; i >= 0; i--)
                {
                    int l = a1[i], r = b1[i];
                    tmp[i + 1] = cb ? GetUnit(l + r) + 1 : GetUnit(l + r);
                    cb = l + r > 9;
                }
                if (cb)
                {
                    tmp[0] = 1;
                }

                for (int i = 0; i < tmp.Length; i++)
                {
                    result += tmp[i].ToString();
                }

                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 高精度加法 (不推荐)
        /// 支持小数点
        /// </summary>
        /// <param name="a">加数 a</param>
        /// <param name="b">加数 b</param>
        /// <returns>和</returns>
        public static char[] Sum(char[] a, char[] b)
        {
            char[] c = a;//补位后的a
            char[] d = b;//补位后的b
            int alength = a.Count();//a长度
            int blength = b.Count();//b长度
            int adot = alength;//a小数点位置
            int bdot = blength;//b小数点位置
            #region 小数点补位
            for (int i = 0; i < alength; i++)
            {
                if (a[i] == '.')
                {
                    adot = i;
                    break;
                }
            }
            for (int i = 0; i < blength; i++)
            {
                if (b[i] == '.')
                {
                    bdot = i;
                    break;
                }
            }
            if (adot != alength || bdot != blength)
            {
                if (adot == alength)
                {
                    c = new char[alength + 1 + blength - bdot - 1];
                    for (int i = 0; i < c.Length; i++)
                    {
                        if (i < alength)
                        {
                            c[i] = a[i];
                        }
                        else if (i == alength)
                        {
                            c[i] = '.';
                        }
                        else
                        {
                            c[i] = '0';
                        }
                    }

                }
                else if (bdot == blength)
                {
                    d = new char[blength + 1 + alength - adot - 1];
                    for (int i = 0; i < d.Length; i++)
                    {
                        if (i < blength)
                        {
                            d[i] = b[i];
                        }
                        else if (i == blength)
                        {
                            d[i] = '.';
                        }
                        else
                        {
                            d[i] = '0';
                        }
                    }
                }
                else
                {
                    if (alength - adot > blength - bdot)
                    {
                        d = new char[blength + ((alength - adot) - (blength - bdot))];
                        for (int i = 0; i < d.Length; i++)
                        {
                            if (i < blength)
                            {
                                d[i] = b[i];
                            }
                            else
                            {
                                d[i] = '0';
                            }
                        }
                    }
                    else
                    {
                        c = new char[alength + ((blength - bdot) - (alength - adot))];
                        for (int i = 0; i < c.Length; i++)
                        {
                            if (i < alength)
                            {
                                c[i] = a[i];
                            }
                            else
                            {
                                c[i] = '0';
                            }
                        }
                    }
                }
            }

            #endregion

            List<char> item = new List<char>();
            int cl = c.Length;
            int dl = d.Length;
            int r = 0;
            int jw = 0;//进位
            do
            {
                if (cl > 0 && dl > 0)
                {
                    if (c[cl - 1] == '.')
                    {
                        r = '.';
                    }
                    else
                    {
                        r = (int)c[cl - 1] + (int)d[dl - 1] - 96 + jw;
                        jw = 0;
                        if (r >= 10)
                        {
                            jw++;
                            r = r - 10;
                        }
                    }
                }
                else if (cl <= 0 && dl > 0)
                {
                    r = d[dl - 1] - 48 + jw;
                    jw = 0;
                    if (r >= 10)
                    {
                        jw++;
                        r = r - 10;
                    }
                }
                else if (cl > 0 && dl <= 0)
                {
                    r = c[cl - 1] - 48 + jw;
                    jw = 0;
                    if (r >= 10)
                    {
                        jw++;
                        r = r - 10;
                    }
                }

                if (r == 46)
                {
                    item.Add(Convert.ToChar(r));
                }
                else
                {
                    item.Add(Convert.ToChar(r.ToString()));
                }
                cl--; dl--;
            } while (cl > 0 || dl > 0);
            if (jw == 1)
            {
                item.Add('1');
            }
            return item.ToArray();
        }
    }
}
