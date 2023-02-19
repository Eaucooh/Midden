using Dall;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class UserMessageBll
    {

        public static int UserQueryID(string id)
        {
            return UserMessageDall.UserQueryID(id);
        }
        public static List<UserMessage> UserQuery()
        {
            return UserMessageDall.UserQuery();
        }
        public static int UpdateUser(UserMessage id)
        {
            return UserMessageDall.UpdateUser(id);
        }
        public static int AddUser(UserMessage id)
        {
            return UserMessageDall.AddUser(id);
        }
        public static int DelUser(UserMessage id)
        {
            return UserMessageDall.DelUser(id);

        }
   
        public static List<UserMessage> UserIsVipQuery(UserMessage id)
        {

          return   UserMessageDall.UserIsVipQuery(id);
        }
        public static List<UserMessage> UserIDorPhoneorEmailQuery(string id)
        {
            return UserMessageDall.UserIDorPhoneorEmailQuery(id);
        }

            
    }
}
