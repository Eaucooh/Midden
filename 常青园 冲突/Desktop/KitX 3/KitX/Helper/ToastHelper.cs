using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitX.Helper
{
    public class ToastHelper
    {
        public static void ToastStr(params string[] infos)
        {
            ToastContentBuilder tcb = new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .SetProtocolActivation(new Uri(App.runninginfo.WorkDirectory + "\\Nothing.exe"))
                .AddArgument("conversationId", 9813);
            foreach (string info in infos)
                tcb.AddText(info);
            tcb.Show();
        }


        public static void AppStart_Multex(string content, params string[] infos)
        {
            ToastContentBuilder tcb = new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813);
                //.AddInlineImage(new Uri("https://source.catrol.cn/img/blog-catrol/toper/moutain_1080p.jpg"))
                //.AddHeroImage(new Uri("https://source.catrol.cn/img/blog-catrol/toper/moutain_1080p.jpg"));
            foreach (string info in infos)
                tcb.AddText(info);
            tcb.AddButton(new ToastButton()
                .SetContent(content)
                .AddArgument("action", "showMainWin")
                .SetBackgroundActivation()
                    
                );
            tcb.Show();
        }

    }
}
