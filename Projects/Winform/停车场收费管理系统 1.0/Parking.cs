using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 停车场项目
{
    [Serializable]
    /// <summary>
    /// 停车场类
    /// </summary>
   public class Parking
    {
       public string CountNumber { get; set; }//总车位
       public string Discount { get; set; }//会员折扣
       public string InNumber { get; set; }//入库车数
       public string OutNumber { get; set; }//出库车数
       public string Price { get; set; }//小时停车费

       public Parking(string a,string b,string c,string d,string e)
       {
           this.CountNumber = a;
           this.Discount = b;
           this.InNumber = c;
           this.OutNumber = d;
           this.Price = e;
       }
        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="a"></param>
       public void ParkingD()
       {
           if (Convert.ToInt32(this.InNumber) < Convert.ToInt32(this.CountNumber))
           {
               this.InNumber = ((int.Parse(this.InNumber) + 1).ToString());
           }
           else
           {
               MessageBox.Show("车位已满");
           }
       }
       /// <summary>
       /// 出库
       /// </summary>
       public void ParkingS(Consumer aa)
       {
           this.InNumber = ((int.Parse(this.InNumber) - 1).ToString());
           aa.ParkingStates = ParkingState.NotParking;
           aa.InTime = "";
           aa.OutTime = "";
       }

    }
}
