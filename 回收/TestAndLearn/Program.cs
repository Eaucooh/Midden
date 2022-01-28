using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TestAndLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            AppTool.Math math = new AppTool.Math();
            Console.Write(math.MultiplicationChart(1, 9));
            Console.ReadLine();
            Console.Write(math.MultiplicationChart_bottomUp(1,9));
            Console.ReadLine();
            AppTool.Other other = new AppTool.Other();
            Console.WriteLine(other.ASCIIChart("-"));
            Console.ReadLine();

            bool IsEndCount = true;
            int startPoint = 0;
            do
            {
                string temp = Convert.ToString(startPoint, 8);
                if (int.Parse(temp)<1000)
                {
                    Console.WriteLine($"十进制：{startPoint} - 八进制 {temp}\t");
                }
                else
                {
                    IsEndCount = false;
                }
                startPoint++;
            } while (IsEndCount);
            Console.ReadLine();

            for (int i = 0; i < 1000; i++)
            {
                string eight = Convert.ToString(i, 8);
                string two = Convert.ToString(i, 2);
                string sixteen = Convert.ToString(i, 16);
                Console.WriteLine($"十进制：{i} - 八进制：{eight} - 二进制：{two} - 十六进制：{sixteen}\t");
            }
            Console.ReadLine();

            int[] tui = new int[] { 10355, 24586, 4899, 5600, 287, 243, 150, 24, 5, 9 };
            for (int i = 0; i < tui.Length; i++)
            {
                Console.Write($"原：{tui[i]}，\t");
                Console.Write($"万：{tui[i] / 10000}，千：{(tui[i] % 10000) / 1000}，百：{(tui[i] % 1000) / 100}，十：{(tui[i] % 100) / 10}，个：{tui[i] % 10}\n");
            }
            Console.ReadLine();

            for (int i = 1000; i < 9999; i++)
            {
                for (int o = 1; o < 9; o++)
                {
                    int num = i / o;
                    if (i % o == 0)
                    {
                        if (num >= 100 && num <= 999)
                        {
                            if (((num % 1000) / 100) * o < 10 && ((num % 100) / 10) * o < 10) // && (num % 10) * o == 80
                            {
                                Console.WriteLine($"被除数：{i}，除数：{o}，商：{num}。");
                            }
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
