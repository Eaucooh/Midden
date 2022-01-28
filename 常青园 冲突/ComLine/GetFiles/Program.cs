using System;
using System.Collections.Generic;
using System.IO;

namespace GetFiles
{
    class Program
    {
        static string[] modes = { "1.填充文件名", "2.获取文件大小" };

        static void Main(string[] args)
        {
            Console.WriteLine("请选择模式: ");
            for (int i = 0; i < modes.Length; i++)
            {
                Console.WriteLine($"\t{modes[i]}");
            }
            Console.Write("请选择模式: ");
            int choose = 1;
            if (int.TryParse(Console.ReadLine(), out choose))
            {
                string path;
                switch (choose)
                {
                    case 1:
                        Console.Write("请输入目标路径：");
                        path = Console.ReadLine();
                        if (Directory.Exists(path))
                        {
                            Console.Write("请输入格式(%s%)：");
                            string forMat = Console.ReadLine();
                            Console.WriteLine("正在处理......");
                            List<string> rt = new List<string>();
                            foreach (FileInfo file in new DirectoryInfo(path).GetFiles())
                            {
                                rt.Add(forMat.Replace("%s%", Path.GetFileName(file.FullName)));
                            }
                            spt();
                            for (int i = 0; i < rt.Count; i++)
                            {
                                Console.WriteLine(rt[i]);
                            }
                            spt();
                            Console.WriteLine("处理完毕");
                        }
                        else
                        {
                            Console.WriteLine("Fuck away.");
                        }
                        break;
                    case 2:
                        Console.Write("请输入目标路径:");
                        path = Console.ReadLine();
                        if (Directory.Exists(path))
                        {
                            Console.WriteLine("正在处理......");
                            spt();
                            foreach (FileInfo file in new DirectoryInfo(path).GetFiles())
                            {
                                double kb = file.Length / 1024;
                                string fn = Path.GetFileName(file.FullName), tab = "\t";
                                Console.WriteLine($"{fn}{(fn.Length >= 16 ? "" : tab)}\t{kb} KB\t{(kb > 1024 ? (kb / 1024).ToString() + "MB" : "")}\t{file.Length}");
                            }
                            spt();
                            Console.WriteLine("处理完毕 !!!");
                        }
                        break;
                }
                Console.ReadLine();
            }

        }

        static void spt()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }
        }
    }
}
