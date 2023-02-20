using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 停车场项目
{
    [Serializable]
    /// <summary>
    /// 管理员类
    /// </summary>
   public class Admin
    {
       public string LongName { get; set; }//账号
       public string LongPassword { get; set; }//密码
       public Admin(string a,string b)
       {
           this.LongName = a;
           this.LongPassword = b;
       }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
       public bool Longin(string a,string b)
       {
           if (a == this.LongName && b == this.LongPassword)
           {
               return true;
           }
           return false;
       }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="f"></param>
       public void UpdatePwd(string f)
       {
           this.LongPassword = f;
       }


    }
}
