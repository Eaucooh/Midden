using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ape_System
{
    public class Log
    {
        public Log()
        {

        }

        public void Log_Append(string logPath, string content)
        {
            File.AppendAllText(logPath, $"\n[{string.Format("{0:G}", DateTime.Now)}]\n{content}\n");
        }
    }
}
