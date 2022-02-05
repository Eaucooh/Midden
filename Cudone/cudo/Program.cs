using System;
using System.IO;

namespace cudo
{
    class Program
    {
        static bool testing(ref string[] args)
        {
            bool has = false;
            for(int i = 0; i < args.Length; ++ i)
            {
                if(args[i].Equals("-t"))
                {
                    has = true;
                }
            }
            return has;
        }

        static void Main(string[] args)
        {
            int cnum = args.Length;
            if(cnum > 0)
            {
                if(File.Exists(args[0]))
                {
                    Processor.Translate(args[0], testing(ref args));
                    if(cnum == 2 && args[1].Equals("-o"))
                    {
                        Helper.print(InfoList.GetErrInfo(1));
                        Environment.Exit(1);
                    }
                    Processor.Compile(args[0], cnum >= 3 ? args[2] : "NoOFName");
                    Helper.print("");
                    Helper.print(InfoList.GetInfo(4));
                }
                else
                {
                    //ExCmd(args[0]);
                }
            }
            else
            {
                Helper.print(InfoList.GetErrInfo(1));
            }
        }
    }
}
