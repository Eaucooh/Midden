using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace 停车场项目
{
    [Serializable]
    /// <summary>
    /// 临时用户类
    /// </summary>
    class TemporaryConsumer:Consumer,Iprint
    {
        public TemporaryConsumer(string a, string b, string c,Type w,State g,ParkingState f):base(a,b,c,w,g,f)
        {

        }
        /// <summary>
        /// 计费
        /// </summary>
        /// <param name="a"></param>
        public override double Charging()
        {
            DateTime aa = Convert.ToDateTime(DateTime.Now.ToString("yyy年MM月dd日 HH:mm:ss"));
            DateTime bb = Convert.ToDateTime(this.InTime);
            TimeSpan ss = aa - bb;
            return (double.Parse(ss.TotalHours.ToString()) * double.Parse(Magager.Park.Pak.Price));
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void Print(string a, string b)
        {
            FileStream fs = new FileStream(a, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("-------------停车场消费清单--------------");
            sw.WriteLine("用户卡号：\t{0}", this.ID);
            sw.WriteLine("入库时间：\t{0}", this.InTime);
            sw.WriteLine("出库时间：\t{0}", this.OutTime);
            sw.WriteLine("消费金额：\t{0}", b + "元");
            sw.WriteLine("-----------------------------------------");
            sw.Close();
            fs.Close();        
        }
    }
}
