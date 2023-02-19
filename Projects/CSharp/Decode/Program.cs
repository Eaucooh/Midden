using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Decode
{
    class Program
    {
        static readonly string[] chars = { 
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        };

        static void Main(string[] args)
        {
            Out("毕导下期视频破译程序已启动");

            Separate();

            Out("读取源内容");
            string sourceContent = Read(@"E:\Development\Projects\Show\我又双叒叕破译了毕导的视频\Sources\ocr1601861276_wgsEMe3KAY5HEW_3_ok.txt");
            Separate();

            Out("统计最高频词");
            //已知COCBKPI对应AMAZING，此处我们假定不知道 COCBKPI == AMAZING
            //但是我们知道毕导最爱说Amazing，所以我们只要找到最常出现且字数为7的词就可确定上述等式
            //A-M-A-Z-I-N-G : 1-13-1-26-9-14-7 (位数)
            string savePath = @"E:\Development\Projects\Show\我又双叒叕破译了毕导的视频\Sources\Output.txt";
            string source = Regex.Replace(sourceContent, @"\s", "");
            IDictionary<string, int> idc = new Dictionary<string, int>();
            int[] counts = new int[26];

            #region 统计词数
            for (int i = 0; i < 26; i++)
            {
                string word = chars[i] + chars[i + 13 - 1] + chars[i] + chars[i + 26 - 1] + chars[i + 9 - 1] + chars[i + 14 - 1] + chars[i + 7 - 1];
                int index = 0;
                int count = 0;
                while ((index = source.IndexOf(word, index)) != -1)
                {
                    count++;
                    index += word.Length;
                }
                //var matchQuery = from a in source
                //                 where a.ToString() == word
                //                 select a;
                //int count = matchQuery.Count();
                idc.Add(word, count);
                counts[i] = count;
            }
            #endregion

            #region 排序 - 冒泡排序
            for (int i = 0; i < counts.Length; i++)
            {
                for (int j = 0; j < counts.Length - i - 1; j++)
                {
                    if (counts[j] > counts[j + 1])
                    {
                        int temp = counts[j];
                        counts[j] = counts[j + 1];
                        counts[j + 1] = temp;
                    }
                }
            }
            #endregion

            #region 分析得出统计结果
            Out("统计结果:\n");
            foreach (var item in idc)
            {
                Out($"所有可能词汇: {item.Key}; 出现次数: {item.Value}\t");
            }
            Out("\n");
            foreach (var item in idc)
            {
                if (item.Value == counts[25])
                {
                    Out($"最频繁词汇: {item.Key}; 出现次数: {item.Value}\t");
                    Out($"综上所述，得出等式：{item.Key} == AMAZING\t");
                    Out($"即：{item.Key.ToCharArray()[0]} == A\t");
                    int a = 0;
                    for (int i = 0; i < chars.Length; i++)
                    {
                        if (chars[i] == item.Key.ToCharArray()[0].ToString())
                        {
                            a = i;
                            break;
                        }
                    }
                    Out($"在凯撒密码中的差值为：{a}\t");
                }
            }
            #endregion

            Separate();

            #region 翻译原文
            Out($"根据所求得的凯撒密码的差值对原文翻译\t");
            char[] source_char = source.ToCharArray();
            string[] translated = new string[source_char.Length];
            for (int i = 0; i < source_char.Length; i++)
            {
                for (int p = chars.Length - 1; p >= 0; p--)
                {
                    if (chars[p] == source_char[i].ToString())
                    {
                        translated[i] = chars[p - 2];
                        break;
                    }
                }
            }
            Out("\n译文如下：");
            Separate();
            string translatedToString = null;
            for (int i = 0; i < translated.Length; i++)
            {
                translatedToString += translated[i];
            }
            Console.WriteLine(translatedToString);
            Separate();
            FileStream fs = new FileStream(savePath, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(translatedToString);
            sw.Flush();
            sw.Close();
            fs.Close();
            Out($"译文如上，已保存到：{savePath}");
            #endregion

            Separate();
            Console.ReadLine();
        }

        /// <summary>
        /// 读取源文件
        /// </summary>
        /// <param name="fileName">源文件路径</param>
        /// <returns>返回内容</returns>
        static string Read(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string content = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return content;
        }

        /// <summary>
        /// 简化输出语句
        /// </summary>
        /// <param name="content">要输出的内容</param>
        static void Out(string content)
        {
            Console.WriteLine(content);
        }

        /// <summary>
        /// 在控制台上打印分隔符
        /// </summary>
        static void Separate()
        {
            Console.WriteLine();
            for (int i = 0; i < 120; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
    }
}