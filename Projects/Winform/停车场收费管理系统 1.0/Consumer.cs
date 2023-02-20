using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 停车场项目
{
    [Serializable]
    /// <summary>
    /// 抽象用户类
    /// </summary>
   public abstract class Consumer
    {
       public string ID { get; set; }//卡号
       public string InTime { get; set; }//入库时间
       public string OutTime { get; set; }//出库时间
       public Type Types { get; set; }//身份类型 
       public State States { get; set; }//卡状态   
       public ParkingState ParkingStates { get; set; }//停车状态
       public Consumer(string a, string b, string c,Type w,State g,ParkingState f)
       {
           this.ID = a;
           this.InTime = b;
           this.OutTime = c;
           this.Types = w;
           this.States = g;
           this.ParkingStates = f;
       }
        /// <summary>
        /// 计费
        /// </summary>
        /// <param name="a"></param>
       public abstract double Charging();
    }
}
