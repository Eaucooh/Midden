using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0+2-1;
            switch (result)
            {
                case 0:
                    Outln("我，兄弟或姐妹");
                    break;
                case 1:
                    Outln("父亲或母亲");
                    break;
                case 2:
                    Outln("爷爷或奶奶");
                    break;
                case 3:
                    Outln("祖父或祖母");
                    break;
                case 4:
                    Outln("曾祖父或曾祖母");
                    break;
                case 5:
                    Outln("高祖父或高祖母");
                    break;
                case -1:
                    Outln("儿子或女儿");
                    break;
                case -2:
                    Outln("孙子或孙女");
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }

        static void Outln (string content)
        {
            Console.WriteLine(content);
        }
    }
}
