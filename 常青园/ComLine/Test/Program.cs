using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Library.TextHelper.Coder.Encrypt("20051117", "", "12345678", Library.TextHelper.Coder.ALG.DES).value);
            Console.ReadLine();
            string ver;
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                ver = wc.DownloadString($"https://source.catrol.cn/download/works/kitx/KitX.exe.txt");
            }
            Console.WriteLine(ver);
            if (ver.StartsWith("v"))
            {
                ver = ver.Substring(1);
            }
            string[] vers = ver.Split('.');
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(vers[i]);
            }
            Console.ReadLine();
            //for (int i = 0; i < 800; i++)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.ReadKey();
            //Console.WriteLine(2 - 5);
            //Console.ReadKey();
            //string up = Console.ReadLine();
            //Console.WriteLine(Library.MathHelper.Hpc.Check_IsAllNum(up).ToString());
            //Console.ReadKey();

            string a = Console.ReadLine();
            string b = Console.ReadLine();

            int[] aa = Library.MathHelper.Hpc.StringToIntArray(a);
            int[] bb = Library.MathHelper.Hpc.StringToIntArray(b);

            Console.WriteLine();

            for (int i = 0; i < aa.Length; i++)
            {
                Console.Write(aa[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < bb.Length; i++)
            {
                Console.Write(bb[i]);
            }

            Console.ReadKey();

            string[] tp = Library.MathHelper.Hpc.FillPosition(a.ToCharArray(), b.ToCharArray());
            Console.WriteLine();
            Console.WriteLine(tp[0]);
            Console.WriteLine(tp[1]);
            Console.WriteLine(Library.MathHelper.Hpc.Sum(a, b));
            Console.WriteLine(Library.MathHelper.Hpc.Sum(a, b).TrimStart('0'));
            Console.ReadKey();

            //string a = Console.ReadLine();
            //string b = Console.ReadLine();
            //Console.WriteLine(Library.MathHelper.Hpc.Sum(a.ToCharArray(), b.ToCharArray()));
            //Console.ReadKey();
        }
    }
}
