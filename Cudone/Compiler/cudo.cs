using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Compiler
{
    class Program
    {
        static void spt(int length)
        {
            string cout = "";
            int i = length;
            while(i != 0)
            {
                cout += "-";
                i --;
            }
            Console.WriteLine(cout);
        }

        static void hello(){
            Console.Write("Cudone - Programing Language Compiler\n");
            Console.Write("Copyright © Catrol, 2021\n");
            Console.Write("\n");
            Console.Write("View more info from the author with the address:\n");
            Console.Write("https://blog.catrol.cn\n");
        }

        static Queue<string> errs = new Queue<string>();
        static Queue<task> tasks = new Queue<task>();

        struct task{
            public string inputFN, outputFN;
            public bool binded;
            // FN - FileName
        }

        static string[] cmds = new string[4]
        {
            "-hello", "-i", "-o", "-d"
        };
        static string[] tips = new string[4]
        {
            "Error : code(0) : Please give at least 1 argument !!!",
            "Error : code(1) : 404 Command not found : ",
            "Error : code(2) : No input file after argument \"-i\" !!!",
            "Error : code(3) : No output file after argument \"-o\" !!!"
        };

        static void Processor(string[] args)
        {
            for(int i = 0; i < args.Length; ++ i)
            {
                int index = -1;
                for(int j = 0; j < cmds.Length; ++ j)
                {
                    if(cmds[j].Equals(args[i]))
                    {
                        index = j;
                        break;
                    }
                }
                switch(index)
                {
                    case 0:
                        Console.WriteLine("Hello Cudone !!!");
                        break;
                    case 1:
                        if(i + 1 < args.Length)
                        {
                            ++ i;
                            tasks.Enqueue(new task{
                                inputFN = args[i], outputFN = "output.cdbin", binded = false
                            });
                        }
                        else
                        {
                            errs.Enqueue(tips[2]);
                        }
                        break;
                    case 2:
                        if(i + 1 < args.Length)
                        {
                            ++ i;
                            int size = tasks.Count;
                            for(int j = 0; j < size; ++ j)
                            {
                                task item = (task)tasks.Dequeue();
                                if(!item.binded)
                                {
                                    item.outputFN = args[i];
                                    item.binded = true;
                                    tasks.Enqueue(item);
                                    break;
                                }
                                tasks.Enqueue(item);
                            }
                        }
                        else
                        {
                            errs.Enqueue(tips[3]);
                        }
                        break;
                    default:
                        errs.Enqueue($"{tips[1]}{args[i]}");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            hello();
            if(args.Length != 0)
            {
                Processor(args);
            }
            else
            {
                Console.WriteLine(tips[0]);
            }
            if(errs.Count != 0)
            {
                Console.WriteLine();
                foreach(string item in errs)
                {
                    Console.WriteLine(item);
                }
                errs.Clear();
            }
            if(tasks.Count != 0)
            {
                Console.WriteLine();
                int index = 0;
                foreach(task item in tasks)
                {
                    Console.WriteLine($"task({index}) : -i {item.inputFN} - -o {item.outputFN}");
                    index ++;
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You added no tasks !!!");
                Console.WriteLine("Cudone Compiler exited.");
                return;
            }
            bool first = true;
            Console.WriteLine();
            while(true)
            {
                if(!first)
                {
                    Console.WriteLine("Please check in \"Y\" to confirm or \"n\" to cancel !");
                }
                else
                {
                    first = false;
                }
                Console.Write("Do you want to compile all of them now ? [Y/n] : ");
                string cos = Console.ReadLine();
                if(cos.Equals("Y"))
                {
                    break;
                }
                else if(cos.Equals("n"))
                {
                    Console.WriteLine();
                    Console.WriteLine("You have cancled all compile tasks !");
                    Console.WriteLine("Cudone Compiler exited.");
                    return;
                }
            }
            foreach(task item in tasks)
            {
                Translate(item.inputFN, item.outputFN);
            }
        }

        const int wordsnum = 43;

        static string[] keywords = new string[wordsnum]
        {
            "#导入 ", "使用库 ", " 主函数(", " 输出(\"", " 新建 ", " 返回 ", " <Cudone>", " 标准库;", "{字符串}", "{数}",
            "字符串", "数", "字符", "队列", "列表", "循环(", "做", "当(", "如果", "大于等于",
            "取模", "除", "乘", "加", "减", "^", "取地址->", "解引用->", "结构体 ", "布尔",
            "设为真", "设为假", "为真", "为假", "真", "假", "换行;", "小于等于", "等于", "并且",
            "大于", "小于", "或者"
        };

        static string[] tarwords = new string[wordsnum]
        {
            "#include ", "using namespace ", " main(", " printf(\"", " new ", " return ", " <bits/stdc++.h>", " std;", "%s", "%d",
            "string", "int", "char", "queue", "list", "for(", "do", "while(", "if", ">=",
            "%", "/", "*", "+", "-", "*", "&", "*", "struct ", "bool",
            " = true", " = false", " == true", " == false", "true", "false", "cout << endl;", "<=", "==", "&&",
            ">", "<", "||"
        };

        static void Translate(string ifn, string ofn)
        {
            if(File.Exists(ifn))
            {
                string cc = ReadAll(ifn);
                for(int i = 0; i < wordsnum; ++ i)
                {
                    cc = cc.Replace(keywords[i], tarwords[i]);
                }
                WriteIn($"{ofn}.cpp", cc);
                WriteIn($"{ofn}.com.sh", $"g++ {ofn}.cpp -o {ofn}.exe");
                Process process = new Process();
                process.StartInfo.FileName = "sh";
                process.StartInfo.Arguments = $"{ofn}.com.sh";
                process.Start();
                process.WaitForExit();
                process.Close();
                File.Delete($"{ofn}.cpp");
                File.Delete($"{ofn}.com.sh");
            }
        }
        
        static string ReadAll(string path)
        {
            string content;
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            content = sr.ReadToEnd();
            sr.Close(); sr.Dispose();
            fs.Close(); fs.Dispose();
            return content;
        }

        static void WriteIn(string path, string content)
        {
            if(File.Exists(path))
            {
                File.Delete(path);
            }
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter sr = new StreamWriter(fs);
            sr.Write(content);
            sr.Close(); sr.Dispose();
            fs.Close(); fs.Dispose();
        }
    }
}