using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.TextHelper
{
    public class Text
    {

        /// <summary>
        /// 大写的26个英文字符组： char[] 类型
        /// </summary>
        public static char[] Caps = new char[26]
        {
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };

        /// <summary>
        /// 小写的26个英文字符组： char[] 类型
        /// </summary>
        public static char[] LowerCrt = new char[26]
        {
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'
        };

        /// <summary>
        /// 普通的10个阿拉伯数字
        /// </summary>
        public static char[] Numbers = new char[10]
        {
            '0','1','2','3','4','5','6','7','8','9'
        };

        /// <summary>
        /// 大写的14个中文数字单位字符组： char[] 类型
        /// </summary>
        public static char[] Caps_Number_zh_CN = new char[14]
        {
            '零','壹','贰','叁','肆','伍','陆','柒','捌','玖','拾','佰','仟','万'
        };

        /// <summary>
        /// 大写的10个中文数字字符组： char[] 类型
        /// </summary>
        public static char[] Caps_Number_zh_CN_Count = new char[10]
        {
            '零','壹','贰','叁','肆','伍','陆','柒','捌','玖'
        };

        /// <summary>
        /// 小写的14个中文数字单位字符组： char[] 类型
        /// </summary>
        public static char[] LowerCrt_Number_zh_CN = new char[14]
        {
            '〇','一','二','三','四','五','六','七','八','九','十','百','千','万'
        };

        /// <summary>
        /// 小写的10个中文数字字符组： char[] 类型
        /// </summary>
        public static char[] LowerCrt_Number_zh_CN_Count = new char[10]
        {
            '〇','一','二','三','四','五','六','七','八','九'
        };

        /// <summary>
        /// 所有的中文数字（不包括单位）
        /// </summary>
        public static char[] All_Numbers_zh_CN = new char[20]
        {
            '零','壹','贰','叁','肆','伍','陆','柒','捌','玖','〇','一','二','三','四','五','六','七','八','九'
        };

        /// <summary>
        /// 字符串中引发换行的字符
        /// </summary>
        public static char[] NewLineChar = new char[2] { '\n', '\r' };

        /// <summary>
        /// 字符串简体转繁体
        /// </summary>
        /// <param name="source">简体字符串</param>
        /// <returns></returns>
        public static string ToTraditionalChinese(string source) => Microsoft.VisualBasic.Strings.StrConv(source, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 0);

        /// <summary>
        /// 字符串繁体转简体
        /// </summary>
        /// <param name="source">繁体字符串</param>
        /// <returns></returns>
        public static string ToSimplifiedChinese(string source) => Microsoft.VisualBasic.Strings.StrConv(source, Microsoft.VisualBasic.VbStrConv.SimplifiedChinese, 0);

        /// <summary>
        /// 从头获取超出数组元素数的元素
        /// </summary>
        /// <param name="index">下标</param>
        /// <param name="source">数组</param>
        /// <returns>得到的元素</returns>
        private static char GetOverLoadChar(int index, char[] source)
        {
            if (index < source.Length)
            {
                return source[index];
            }
            else
            {
                return source[index % (source.Length - 1)];
            }
        }

        /// <summary>
        /// 将所提供的字符串中的中文数字小写部分转换为大写
        /// </summary>
        /// <param name="source">所提供的字符串</param>
        /// <returns></returns>
        public static string ToCapital_NumberIn_zh_CN(string source)
        {
            char[] chars = source.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (ExistChar(chars[i], LowerCrt_Number_zh_CN))
                {
                    chars[i] = GetOverLoadChar(GetIndexOfFirst(chars[i], LowerCrt_Number_zh_CN), Caps_Number_zh_CN);
                }
            }
            return ConverterHelper.Converters.CharArrayToString(chars);
        }

        /// <summary>
        /// 将所提供的字符串中的中文数字大写部分转换为小写
        /// </summary>
        /// <param name="source">所提供的字符串</param>
        /// <returns></returns>
        public static string ToLower_NumberIn_zh_CN(string source)
        {
            char[] chars = source.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (ExistChar(chars[i], Caps_Number_zh_CN))
                {
                    chars[i] = GetOverLoadChar(GetIndexOfFirst(chars[i], Caps_Number_zh_CN), LowerCrt_Number_zh_CN);
                }
            }
            return ConverterHelper.Converters.CharArrayToString(chars);
        }

        /// <summary>
        /// 将所提供的字符串中的小写部分转换为大写
        /// </summary>
        /// <param name="source">所提供的字符串</param>
        /// <returns></returns>
        public static string ToCapital(string source)
        {
            char[] chars = source.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (ExistChar(chars[i], LowerCrt))
                {
                    chars[i] = GetOverLoadChar(GetIndexOfFirst(chars[i], LowerCrt), Caps);
                }
            }
            return ConverterHelper.Converters.CharArrayToString(chars);
        }

        /// <summary>
        /// 将所提供的字符串中的大写部分转换为小写
        /// </summary>
        /// <param name="source">所提供的字符串</param>
        /// <returns></returns>
        public static string ToLower(string source)
        {
            char[] chars = source.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (ExistChar(chars[i], Caps))
                {
                    chars[i] = GetOverLoadChar(GetIndexOfFirst(chars[i], Caps), LowerCrt);
                }
            }
            return ConverterHelper.Converters.CharArrayToString(chars);
        }

        /// <summary>
        /// 在字符组中检查是否存在某个字符
        /// </summary>
        /// <param name="target">要检查的字符</param>
        /// <param name="source">从此字符组中检查</param>
        /// <returns>是否存在</returns>
        public static bool ExistChar(char target, char[] source)
        {
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
        /// 检查字符串中某一个字符的个数
        /// </summary>
        /// <param name="target">目标字符</param>
        /// <param name="src">源字符串</param>
        /// <returns>个数</returns>
        public static int CharCount(char target, string src)
        {
            int counts = 0;
            char[] arr = src.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                {
                    counts++;
                }
            }
            return counts;
        }

        /// <summary>
        /// 检查字符串中某一串字符的个数
        /// </summary>
        /// <param name="target">目标字符</param>
        /// <param name="src">源字符串</param>
        /// <returns>个数</returns>
        public static int CharCount(string target, string src)
        {
            int length = target.Length;
            char[] to = target.ToCharArray();
            char first = to[0];
            char[] from = src.ToCharArray();
            int counts = 0;

            for (int i = 0; i < from.Length; i++)
            {
                if (from[i] == first)
                {
                    bool isItRgt = true;
                    for (int j = 0; j < length; j++)
                    {
                        if (!(from[i+j] == to[j]))
                        {
                            isItRgt = false;
                        }
                    }
                    if (isItRgt)
                    {
                        counts++;
                    }
                }
            }

            return counts;
        }

        /// <summary>
        /// 检查一个字符串中含有另一个字符串数组中的元素的总数
        /// </summary>
        /// <param name="target">另一个字符串</param>
        /// <param name="src">一个字符串</param>
        /// <returns>包含的元素的总数</returns>
        public static int CharCount(string[] target, string src)
        {
            int counts = 0;
            for (int i = 0; i < target.Length; i++)
            {
                counts += CharCount(target[i], src);
            }
            return counts;
        }

        /// <summary>
        /// 得到目标在数组中第一次出现的脚标
        /// </summary>
        /// <param name="target">目标</param>
        /// <param name="source">数组</param>
        /// <returns>返回脚标</returns>
        public static int GetIndexOfFirst(char target, char[] source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 简单类型复制文本到剪切板
        /// </summary>
        /// <param name="content">要复制的字符串</param>
        /// <returns>返回异常信息</returns>
        public static string CopyToClipBoard_Simple(string content)
        {
            try
            {
                System.Windows.Forms.Clipboard.SetText(content);
                return "Succeed";
            }
            catch (Exception o)
            {
                return $"Error - {o.Message}";
            }
        }

        /// <summary>
        /// 返回一个随机字符串
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns>随机字符串</returns>
        public static string RandomText(int length)
        {
            Random rd = new Random();
            string rst = "";
            for (int i = 0; i < length; i++)
            {
                bool v = rd.Next(2) == 0;
                rst += v ? Caps[rd.Next(26)] : LowerCrt[rd.Next(26)];
            }
            return rst;
        }

        /// <summary>
        /// 字符串转换成数组
        /// </summary>
        /// <param name="source">字符串</param>
        /// <param name="sign">分割标志</param>
        /// <param name="wrap">包装</param>
        /// <param name="separate">是否添加空格来分离</param>
        /// <returns>字符串数组</returns>
        public static string StringToArray(string source, char sign, string wrap1, string wrap2, bool separate)
        {
            string rst = null;
            string[] arr = source.Split(sign);
            for (int i = 0; i < arr.Length; i++)
            {
                rst += $"{wrap1}{arr[i]}{wrap2}{(separate ? " " : null)}";
            }
            return rst;
        }

        /// <summary>
        /// 获取行数的方式
        /// </summary>
        public enum GetLine_Type { ByController, Calculate }

        /// <summary>
        /// 获取字符串行数
        /// </summary>
        /// <param name="content">字符串</param>
        /// <returns></returns>
        public static int GetLines(string content, GetLine_Type gt)
        {
            switch (gt)
            {
                case GetLine_Type.Calculate:
                    return GetLine_Way_1(content);
                case GetLine_Type.ByController:
                    System.Windows.Forms.RichTextBox rtb = new System.Windows.Forms.RichTextBox()
                    {
                        Text = content,
                        WordWrap = false
                    };
                    return rtb.Lines.Length;
                default:
                    return GetLine_Way_1(content);
            }
        }

        /// <summary>
        /// 通过遍历查找换行符来完成行数计算
        /// </summary>
        /// <param name="content">字符串</param>
        /// <returns>返回行数</returns>
        private static int GetLine_Way_1(string content)
        {
            int lines = 0;
            char[] chars = content.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (ExistChar(chars[i], NewLineChar))
                {
                    lines++;
                }
            }
            return lines / 2 + 1;
        }

        /// <summary>
        /// 获取奇数行
        /// </summary>
        /// <param name="content">内容</param>
        /// <returns>字符串</returns>
        public static string GetOddLines(string content)
        {
            string result = null;
            string[] lines = content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines.Length; i++)
            {
                if (MathHelper.Basic.IsOdd(i))
                {
                    result += $"{lines[i]}\r\n";
                }
            }
            return result;
        }

        /// <summary>
        /// 获取偶数行
        /// </summary>
        /// <param name="content">内容</param>
        /// <returns>字符串</returns>
        public static string GetEvenLines(string content)
        {
            string result = null;
            string[] lines = content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines.Length; i++)
            {
                if (!MathHelper.Basic.IsOdd(i))
                {
                    result += $"{lines[i]}\r\n";
                }
            }
            return result;
        }

        /// <summary>
        /// 将 List<string> 逐条逐行返回
        /// </summary>
        /// <param name="source">源序列</param>
        /// <returns>字符串</returns>
        public static string ListToLines(List<string> source)
        {
            string rst = null;
            int count = 0;
            foreach (string item in source)
            {
                count++;
                rst += $"{item}{((count == source.Count) ? null : "\r\n")}";
            }
            return rst;
        }

        /// <summary>
        /// 获取字符串中的数字数
        /// 0 : 没有
        /// </summary>
        /// <param name="content">字符串</param>
        /// <returns>数字的数量</returns>
        public static int GetNumCount(string content, NumCount_Type type)
        {
            int counts = 0;
            char[] src = content.ToCharArray();
            for (int i = 0; i < src.Length; i++)
            {
                switch (type)
                {
                    case NumCount_Type.OnlyArabiaNums:
                        if (ExistChar(src[i], Numbers))
                            counts++;
                        break;
                    case NumCount_Type.OnlyChineseNums:
                        if (ExistChar(src[i], All_Numbers_zh_CN))
                            counts++;
                        break;
                    case NumCount_Type.Both:
                        if (ExistChar(src[i], Numbers) || ExistChar(src[i], All_Numbers_zh_CN))
                            counts++;
                        break;
                }
            }
            return counts;
        }

        public enum NumCount_Type { OnlyArabiaNums, OnlyChineseNums, Both }
    }
}
