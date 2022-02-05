using System;
using System.Diagnostics;
using System.IO;

namespace cudo
{
    class Processor
    {
        static string head = "", body = "", code = "";

        static bool Catch(string left, string right, out int li, out int ri)
        {
            bool pass = false;
            li = code.IndexOf(left); ri = code.IndexOf(right);
            if(li != -1 && ri != -1)
            {
                pass = true;
            }
            return pass;
        }

        static string[] key_head = new string[]
        {
            "## 导入库 ", ":Cudone:",
            "@ 关键词 ", ":: 使用名称 :: ", "标准"
        };

        static string[] tar_head = new string[]
        {
            "#include ", "<bits/stdc++.h>",
            "#define ", "using namespace ", "std"
        };

        static string[] key_body = new string[]
        {
            "自加", "自减", "大于等于", "小于等于", "大于", "小于", "等于", "取",
            "乘以", "除以", "模以", "为真", "为假", "并且", "或者", "非", "值为",
            "字符串", "长整数", "短整数", "非负", "浮点", "实数", "字符", "布尔",
            "整数", "加", "减",
            "结构体", "循环", "执行", "当", "如果", "真", "假", "是", "否",
            "主函数", "返回", "为", "换行符", "的长度"
        };

        static string[] tar_body = new string[]
        {
            " ++ ", " -- ", " >= ", " <= ", " > ", " < ", " == ", " = ",
            " * ", " / ", " % ", " == true ", " == false", " && ", " || ", " ! ", "==",
            "string", "long long", "short", "unsigned", "float", "double", "char", "bool",
            "int", " + ", " - ",
            "struct", "for", "do", "while", "if", "true", "false", "true", "false",
            "main", "return", "=", "endl", ".length()"
        };

        static void Replace_Head()
        {
            for(int i = 0; i < key_head.Length; ++ i)
            {
                head = head.Replace(key_head[i], tar_head[i]);
            }
        }

        static void Replace_Body()
        {
            for(int i = 0; i < key_body.Length; ++ i)
            {
                body = body.Replace(key_body[i], tar_body[i]);
            }
        }

        static int NextChar(int now, char next)
        {
            for(; now < body.Length; ++ now)
            {
                if(body[now].Equals(next) && !body[now- 1].Equals('\\')) break;
            }
            return now;
        }

        static void Process_Body()
        {
            int nowlines = 0, deviation = 10;
            for(int i = 0; i < body.Length; ++ i)
            {
                if(body[i].Equals('\r')) nowlines ++;
                if(body[i].Equals('令') || body[i].Equals('使'))
                {
                    int j = i, k; // i - 令/使, j - 为, k - ;
                    while(true)
                    {
                        if(body[j].Equals('为') || j > body.Length - deviation)
                        {
                            if(j > body.Length - deviation)
                            {
                                Helper.print(InfoList.GetErrInfo(5));
                                Environment.Exit(1);
                            }
                            break;
                        }
                        ++ j;
                    }
                    k = j;
                    while(true)
                    {
                        if(body[k].Equals('\"')) k = NextChar(k + 1, '\"') + 1;
                        if(body[k].Equals(';') || k > body.Length - deviation)
                        {
                            if(k > body.Length - deviation)
                            {
                                Helper.print(InfoList.GetErrInfo(6) + $"{nowlines}");
                                Environment.Exit(1);
                            }
                            break;
                        }
                        ++ k;
                    }
                    string s_s = body.Substring(i + 1, j - i - 1).Trim(),
                    tar = body.Substring(j + 1, k - j).Trim();
                    body = body.Replace(body.Substring(i, k - i + 1), $"{s_s} = {tar}");
                }
                if(body[i].Equals('多') && body[i + 1].Equals('输') &&
                    body[i + 2].Equals('出') && body[i + 3].Equals('('))
                {
                    body = body.Remove(i, 4);
                    body = body.Insert(i, "cout << ");
                    int j = i;
                    while(true)
                    {
                        if((body[j].Equals(')') && body[j + 1].Equals(';')) ||
                            j > body.Length - deviation)
                        {
                            if(j > body.Length - deviation)
                            {
                                Helper.print(InfoList.GetErrInfo(6) + $"{nowlines}");
                                Environment.Exit(1);
                            }
                            break;
                        }
                        ++ j;
                    }
                    body = body.Remove(j, 1);
                    for(int k = i; k < j; ++ k)
                    {
                        if(body[k].Equals('\"')) k = NextChar(k + 1, '\"') + 1;
                        if(body[k].Equals(','))
                        {
                            body = body.Remove(k, 1);
                            body = body.Insert(k, " <<");
                        }
                    }
                }
                if(body[i].Equals('多') && body[i + 1].Equals('输') &&
                    body[i + 2].Equals('入') && body[i + 3].Equals('('))
                {
                    body = body.Remove(i, 4);
                    body = body.Insert(i, "cin >> ");
                    int j = i;
                    while(true)
                    {
                        if((body[j].Equals(')') && body[j + 1].Equals(';')) ||
                            j > body.Length - deviation)
                        {
                            if(j > body.Length - deviation)
                            {
                                Helper.print(InfoList.GetErrInfo(6) + $"{nowlines}");
                                Environment.Exit(1);
                            }
                            break;
                        }
                        ++ j;
                    }
                    body = body.Remove(j, 1);
                    for(int k = i; k < j; ++ k)
                    {
                        if(body[k].Equals('\"')) k = NextChar(k + 1, '\"') + 1;
                        if(body[k].Equals(','))
                        {
                            body = body.Remove(k, 1);
                            body = body.Insert(k, " >>");
                        }
                    }
                }
            }
        }

        public static void Translate(string fileName, bool test)
        {
            code = Helper.ReadAll(fileName);
            int yl, yr, cl, cr, nllen = Environment.NewLine.Length;
            if(Catch("<预处理>", "</预处理>", out yl, out yr))
            {
                if(Catch("<代码>", "</代码>", out cl, out cr))
                {
                    head = code.Substring(yl + 5 + nllen, yr - yl - 6 - nllen);
                    body = code.Substring(cl + 4 + nllen, cr - cl - 5 - nllen);
                    Replace_Head();
                    Process_Body();
                    Replace_Body();
                    if(test)
                    {
                        Helper.print(head);
                        Helper.print(body);
                    }
                    Helper.WriteIn($"{fileName}.cpp", $"{head}\n{body}");
                }
                else
                {
                    Helper.print(InfoList.GetErrInfo(4));
                    Environment.Exit(1);
                }
            }
            else
            {
                Helper.print(InfoList.GetErrInfo(3));
                Environment.Exit(1);
            }
        }

        public static string extension = ".cdbin";

        public static void Compile(string fileName, string ofile)
        {
            string ofname = ofile.Equals("NoOFName") ? $"{fileName}{extension}" : ofile;
            Helper.WriteIn($"{fileName}.com.sh", $"g++ {fileName}.cpp -o {ofname}");
            Process process = new Process();
            process.StartInfo.FileName = "sh";
            process.StartInfo.Arguments = $"{fileName}.com.sh";
            process.Start();
            process.WaitForExit();
            process.Close();
            File.Delete($"{fileName}.cpp");
            File.Delete($"{fileName}.com.sh");
        }
    }
}