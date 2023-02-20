using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// 下载于www.mycodes.net 
namespace WindowsFormsTest2
{
    public partial class MyFrm : Form
    {
        List<int> nums = new List<int>();
        List<int> indexs = new List<int>();
        public MyFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            bool b = false;
            while(true)
            {
                int num = random.Next(1000000, 9999999);
                foreach (int temp in nums)
                {
                    if (temp == num)
                    { 
                        //出现过
                        b = true;
                    }
                }
                if (b)
                {
                    continue;
                }
                nums.Add(num);
                lstNums.Items.Add(num);
                if (nums.Count == 100)
                {
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nums.Count <= 0)
            {
                MessageBox.Show("没有需要抽奖的号码！");
                return;
            }
            Random random = new Random();
            while(true)
            {
                int index = random.Next(0, nums.Count);
                bool b = false;
                foreach(int temp in indexs)
                {
                    if (index == temp)
                    {
                        b = true;
                    }
                }
                if (b)
                {
                    continue;
                }
                //lstResult.Items.Add(nums[index]);
                indexs.Add(index);
                if (indexs.Count == 16)
                {
                    break;
                }
            }
            for (int i = 0; i < 16; i++)
            {
                if (i < 10)
                { 
                    //参与奖
                    lstResult.Items.Add(string.Format("参与奖：{0}", nums[indexs[i]]));
                }
                else if (i < 13)
                {
                    lstResult.Items.Add(string.Format("三等奖：{0}", nums[indexs[i]]));
                }
                else if (i < 15)
                {
                    lstResult.Items.Add(string.Format("二等奖：{0}", nums[indexs[i]]));
                }
                else
                {
                    lstResult.Items.Add(string.Format("一等奖：{0}", nums[indexs[i]]));
                }
            }
        }
    }
}
