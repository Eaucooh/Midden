using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 停车场项目
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Magager.Park.Inte();//初始化
            Magager.Load();//加载数据
            Register aa = new Register();
            DialogResult hh = aa.ShowDialog();
            if(hh==DialogResult.OK)
            Application.Run(new Homepage());
        }
    }
}
