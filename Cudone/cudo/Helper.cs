using System;
using System.IO;

namespace cudo
{
    class Helper
    {
        public static void cout(string content) => Console.Write(content);

        public static void print(string content) => Console.WriteLine(content);

        public static string ReadAll(string path)
        {
            string content;
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            content = sr.ReadToEnd();
            sr.Close(); sr.Dispose();
            fs.Close(); fs.Dispose();
            return content;
        }

        public static void WriteIn(string path, string content)
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