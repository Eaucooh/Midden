using Dall;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
  public  class ManagerMessageBll
    {
        public static List<ManagerMessage> Query()
        {
            return ManagerMessageDall.Query();
        }
        public static int UpdateManagerMessage(ManagerMessage id)
        {
            return ManagerMessageDall.UpdateManagerMessage(id);
        }
        public static int AddManager(ManagerMessage id)
        {
            return ManagerMessageDall.AddManager(id);
        }
        public static int DelManager(ManagerMessage id)
        {
            return ManagerMessageDall.DelManager(id);
        }
        public static List<ManagerGrade> QueryGrade()
        {
            return ManagerMessageDall.QueryGrade();
        }
            public static ManagerGrade QueryGradeID(int id)
        {
            return ManagerMessageDall.QueryGradeID(id);
        }
        public static int ManagerQueryID(string id)
        {
            return ManagerMessageDall.ManagerQueryID(id);
        }
        public static int Login(string ManagerID, string ManagerPassword)
        {
            return ManagerMessageDall.Login(ManagerID,ManagerPassword);
        }
        public static ManagerMessage ManagerType(string id)
        {
            return ManagerMessageDall.ManagerType(id);
        }
        public static int UpdateManager(ManagerMessage id)
        {
            return ManagerMessageDall.UpdateManager(id);

        }
    }
}
