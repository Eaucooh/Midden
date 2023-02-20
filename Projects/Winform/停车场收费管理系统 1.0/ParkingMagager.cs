using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace 停车场项目
{
    [Serializable]
    /// <summary>
    /// 停车场系统管理类
    /// </summary>
   public class ParkingMagager
    {
       /// <summary>
       /// 管理员对象
       /// </summary>
       public  Admin Adm;
       /// <summary>
       /// 停车场对象
       /// </summary>
       public Parking Pak;
       /// <summary>
       /// 用户集合
       /// </summary>
       public Dictionary<string, Consumer> Diy;
       public void Inte()
       {
           Adm = new Admin("admin", "admin");
           Pak = new Parking("100","0.8","0","0","3");
           Diy = new Dictionary<string, Consumer>();
           for (int i = 1; i <= 100; i++)
           {
               if (i <=50)
               {
                   MemberConsumer d1 = new MemberConsumer("48400" + (i < 10 ? "0"+i.ToString() : i.ToString()), "", "", Type.nember, State.NotOpenaccount, ParkingState.NotParking, "0", "", "", "", "");
                   this.Add(d1.ID, d1);
               }
               else
               {
                   TemporaryConsumer d3 = new TemporaryConsumer("48400"+i, "", "", Type.temporary, State.NotOpenaccount, ParkingState.NotParking);
                   this.Add(d3.ID, d3);
               }
           }
       }

       public void Add(string a,Consumer b)
       {
           Diy.Add(a,b);
           
       }
       /// <summary>
       /// 会员注销
       /// </summary>
       /// <param name="a"></param>
       public void Remove(string a)
       {
           (Diy[a] as MemberConsumer).Balance = "";
           (Diy[a] as MemberConsumer).CustName = "";
           (Diy[a] as MemberConsumer).CustTel = "";
           (Diy[a] as MemberConsumer).PlateNumber = "";
           (Diy[a] as MemberConsumer).RegDate = "";
           (Diy[a] as MemberConsumer).InTime = "";
           (Diy[a] as MemberConsumer).OutTime = "";
           (Diy[a] as MemberConsumer).States = State.NotOpenaccount;
       }

    }
}
