using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form, IMessageFilter
    {
        public Form1()
        {
            InitializeComponent();
            Init();
    
        }
        int alts,altd;
        private void Init()
        {
            alts = HotKey.GlobalAddAtom("Alt-S");
            altd = HotKey.GlobalAddAtom("Alt-D");
            HotKey.RegisterHotKey(this.Handle, alts, HotKey.KeyModifiers.Alt, (int)Keys.S);
            HotKey.RegisterHotKey(this.Handle, altd, HotKey.KeyModifiers.Alt, (int)Keys.D);
            if (DwmApi.DwmIsCompositionEnabled())
            {
                DwmApi.DwmExtendFrameIntoClientArea(this.Handle, new DwmApi.MARGINS(-1, -1, -1, -1));
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (DwmApi.DwmIsCompositionEnabled())
            {
                e.Graphics.Clear(Color.Black);
            }
        } 
        protected override void WndProc(ref Message m)// 监视Windows消息
        {
            switch (m.Msg)
            {
                case HotKey.WM_HOTKEY:
                    ProcessHotkey(m);//按下热键时调用ProcessHotkey()函数
                    break;
            }
            base.WndProc(ref m); //将系统消息传递自父类的WndProc
        }

         private void ProcessHotkey(Message m) //按下设定的键时调用该函数
        {
            IntPtr id = m.WParam;//IntPtr用于表示指针或句柄的平台特定类型
             int sid=id.ToInt32();
            if(sid==alts)
            {
                MessageBox.Show("按下Alt+S");
            }
            else if(sid==altd)
            {
                MessageBox.Show("按下Alt+D");
            }
        }


         bool IMessageFilter.PreFilterMessage(ref Message m)
         {
             const int WM_HOTKEY = 0x0312;//如果m.Msg的值为0x0312那么表示用户按下了热键
             switch (m.Msg)
             {
                 case WM_HOTKEY:
                     ProcessHotkey(m);//按下热键时调用ProcessHotkey()函数
                     break;
             }
             //如果筛选消息并禁止消息被调度，则为 true；如果允许消息继续到达下一个筛选器或控件，则为 false
             return false ;
         }

         private void button1_Click(object sender, EventArgs e)
         {
             DwmApi.DwmEnableComposition(false);
         }

    }
}
