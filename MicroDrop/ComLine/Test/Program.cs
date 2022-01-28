using System;
using System.Windows;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 加密算法调试
            //string line = Console.ReadLine();
            //Console.WriteLine("源文本:" + line);
            //string key = Console.ReadLine();
            //Console.WriteLine("加密后:" + Coder.Encrypt(line, null, key, Coder.ALG.DES).value);
            //Console.WriteLine("解密后:" + Coder.Decrypt(Coder.Encrypt(line, null, key, Coder.ALG.DES).value, null, key, Coder.ALG.DES));
            //Console.ReadLine();
            //string line2 = Console.ReadLine();
            //Console.WriteLine("源文本:" + line2);
            //string pwd2 = Console.ReadLine();
            //Console.WriteLine("加密后:" + Coder.Encrypt(line2, pwd2, "", Coder.ALG.AES).value);
            //Console.WriteLine("解密后:" + Coder.Decrypt(Coder.Encrypt(line2, pwd2, "", Coder.ALG.AES).value, pwd2, "", Coder.ALG.AES));
            //Console.ReadLine();
            #endregion

            Point p = new Point(5.0, 7);
            Console.WriteLine(p.ToString());
            Console.ReadLine();
            Console.WriteLine(Library.MathHelper.Calculate.NextChar(15, ')', "{[(4+8)*18-24]*(7+7)-188}+92"));
            Console.WriteLine(Library.MathHelper.Calculate.NextChar(0, '}', "{[(4+8)*18-24]*(7+7)-188}+92"));
            Console.WriteLine(Library.MathHelper.Calculate.IsBlockOperator_Start('['));
            Console.WriteLine(Library.MathHelper.Calculate.CutAll("{[(4+8)*18-24]*(7+7)-188}+92+{24-[18*(5+9)]}", 0));
            Console.ReadLine();
            Library.Voice.Speech speech = new Library.Voice.Speech(80, 8);
            speech.Declaim(Console.ReadLine());
            Console.ReadLine();
            int[] rt = Library.TextHelper.Compare.GetDiffrentIndexes("1234567890", "1234568709");
            for (int i = 0; i < rt.Length; i++)
            {
                Console.Write(rt[i] + ", ");
            }
            Console.ReadLine();
        }
    }
}
