using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTool
{
    public class Main
    {
        /// <summary>
        /// 展示本扩展程序的关于框
        /// </summary>
        public void ShowAbout()
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
