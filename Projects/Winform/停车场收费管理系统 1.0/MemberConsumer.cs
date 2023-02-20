using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace 停车场项目
{
    [Serializable]
   /// <summary>
   /// 会员用户类
   /// </summary>
    public class MemberConsumer : Consumer, Iprint
    {
       public string Balance { get; set; }//余额
       public string CustName { get; set; }//会员名
       public string CustTel { get; set; }//电话
       public string PlateNumber { get; set; }//车牌号
       public string RegDate { get; set; }//注册时间

       public MemberConsumer(string a, string b, string c,Type w,State l,ParkingState gg,string d,string e,string f,string g,string h)
           : base(a,b,c,w,l,gg)
       {
           this.Balance = d;
           this.CustName = e;
           this.CustTel = f;
           this.PlateNumber = g;
           this.RegDate = h;
       }

       /// <summary>
       /// 充值
       /// </summary>
       /// <param name="a"></param>
       public void Recharge(string a)
       {
           double aa = double.Parse(this.Balance) + double.Parse(a);
           this.Balance = aa.ToString();
       }
       /// <summary>
       /// 开户
       /// </summary>
       /// <param name="a"></param>
       /// <param name="b"></param>
       /// <param name="c"></param>
       /// <param name="d"></param>
       /// <param name="g"></param>
       /// <param name="e"></param>
       public void Account(string a,string b,string c,string d,string g,State e)
       {
           this.Balance = a;
           this.CustName = b;
           this.CustTel = c;
           this.PlateNumber = d;
           this.RegDate = g;
           this.States = e;
       }
       /// <summary>
       /// 计费
       /// </summary>
       /// <param name="a"></param>
       public override double Charging()
       {
           DateTime aa =Convert.ToDateTime(DateTime.Now.ToString("yyy年MM月dd日 HH:mm:ss"));
           DateTime bb = Convert.ToDateTime(this.InTime);
           TimeSpan ss =aa - bb;
           return ((double.Parse(ss.TotalHours.ToString()) * double.Parse(Magager.Park.Pak.Price)) * double.Parse(Magager.Park.Pak.Discount));
       }
        /// <summary>
        /// 扣费
        /// </summary>
        /// <param name="a"></param>
       public bool Fasmo(double a)
       {
           if (double.Parse(this.Balance) >= a)
           {
               this.Balance = (double.Parse(this.Balance) - a).ToString();
               return true;
           }
           else
           {
               return false;
           }
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
           sw.WriteLine("入库时间：\t{0}",this.InTime);
           sw.WriteLine("出库时间：\t{0}",this.OutTime);
           sw.WriteLine("消费金额：\t{0}",b+"元");
           sw.WriteLine("-----------------------------------------");
           sw.Close();
           fs.Close();
       }
    }
}
