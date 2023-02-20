using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTest2
{
    public partial class Form1 : Form
    {
        //定义奖池
        List<string> nums = new List<string>();
        //定义中奖号码
        List<string> results = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 下载于www.mycodes.net 
        }

        //创建奖池按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            //初始化中奖队列
            results = new List<string>();
            //奖池显示初始化
            lstNums.Items.Clear();
            //中奖显示初始化
            lstResult.Items.Clear();
            //定义随机对象
            Random random = new Random();
            //创建一百个随机的中奖号码
            for (int i = 0; i < 100; i++)
            {
                //取随机数
                int num = random.Next(1000000, 9999999);
                //添加到奖池
                nums.Add(num.ToString());
                //显示号码
                lstNums.Items.Add(num);
            }
        }

        //抽奖按钮事件
        private void button2_Click(object sender, EventArgs e)
        {
            //如果有中奖号码代表已抽过奖
            if (results.Count > 0)
            {
                MessageBox.Show("已抽过奖，请重新创建奖池！");
                return;
            }
            //定义随机对象
            Random random = new Random();
            while(true)
            {
                //创建随机数
                int temp = random.Next(1000000, 9999999);
                //确实是否存在
                bool bExists = false;
                //查找当前创建的随机数是否已中奖
                for (int i = 0, len = results.Count; i < len; i++)
                {
                    if (results[i].Equals(temp.ToString()))
                    {
                        bExists = true;
                        break;
                    }
                }
                //如果此号码已中奖进入下次循环
                if (bExists)
                {
                    continue;
                }
                else
                {
                    //将中奖号码添加到中奖队列
                    results.Add(temp.ToString());
                    if (results.Count == 16)
                    {
                        //满足16个中奖位退出
                        break;
                    }
                }
            }

            //将结果显示在中奖列表中
            for (int i = 0; i < 16; i++)
            {
                if (i < 10)
                {
                    lstResult.Items.Add(string.Format("参与奖中奖号码为：{0}", results[i]));
                }
                else if (i < 13)
                {
                    lstResult.Items.Add(string.Format("三等奖中奖号码为：{0}", results[i]));
                }
                else if (i < 15)
                {
                    lstResult.Items.Add(string.Format("二等奖中奖号码为：{0}", results[i]));
                }
                else if (i < 16)
                {
                    lstResult.Items.Add(string.Format("一等奖中奖号码为：{0}", results[i]));
                }
            }
        }
    }
}
