using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitX.lang
{
    public class lang
    {

        public static string[] zn_ch =
        {
            "来自 KitX 的通知",
            "你已经启动了一个实例了 :)",
            "显示界面"
        };

        public static string[] zn_cht =
        {
            "來自 KitX 的通知",
            "已經又一个實例正在运行 :)",
            "显示界面"
        };

        public static string[] en_us =
        {
            "Notification from KitX",
            "You have started an instance :)",
            "Show the MainWindow"
        };

        public static string[] ja_jp =
        {
            "KitXからの通知",
            "インスタンスを開始しました :)",
            "メインウィンドウを表示する"
        };

        public static string[][] langs = { zn_ch, zn_cht, en_us, ja_jp };
    }
}
