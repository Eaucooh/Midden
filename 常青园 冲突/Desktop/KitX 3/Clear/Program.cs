using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Clear
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory;
            string[] dirs = { "ca-ES", "en", "fa", "fr", "ko-KR", "pl", "pt-BR", "ru", "tr" };
            Console.WriteLine("This program will delete these directories:");
            foreach (string dir in dirs)
            {
                Console.WriteLine($"\t{dir}");
            }
            Console.WriteLine("Press 'Enter' to continue.");
            Console.ReadLine();
            foreach (string dir in dirs)
            {
                DirectoryInfo dirInfo = new DirectoryInfo($"{path}\\{dir}");
                dirInfo.Delete(true);
            }
        }
    }
}
