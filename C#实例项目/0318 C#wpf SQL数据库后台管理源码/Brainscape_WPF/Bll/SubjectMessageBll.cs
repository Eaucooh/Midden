using Dall;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
  public  class SubjectMessageBll
    {
        public static List<SubjectMessage> Querysubject()
        {
            return SubjectMessageDall.Querysubject();
        }
        public static int Deletesubject(SubjectMessage id)
        {
            return SubjectMessageDall.Deletesubject(id);
        }
        public static int Addsubject(SubjectMessage s)
        {
            return SubjectMessageDall.Addsubject(s);
        }
        public static int Updatesubject(SubjectMessage s)
        {
            return SubjectMessageDall.Updatesubject(s);
        }
        public static List<SubjectMessage> QuerysubjectSujectID(string SubjectName)
        {
            return SubjectMessageDall.QuerysubjectSujectID(SubjectName);
        }

        public static List<SubjectMessage> QuerysubjectID()
        {
            return SubjectMessageDall.QuerysubjectID();
        }
        public static SubjectMessage QuerySujectID(string SubjectID)
        {
            return SubjectMessageDall.QuerySujectID(SubjectID);
        }
        public static int UpdateCardsCount(string s)
        {
            return SubjectMessageDall.UpdateCardsCount(s);
        }
        public static int SubjectQueryName(string Name)
        {
            return SubjectMessageDall.SubjectQueryName(Name);
        }
        public static int UpdateCardsCount2(int CardsCount, string SubjectID)
        {
            return SubjectMessageDall.UpdateCardsCount2(CardsCount, SubjectID);
        }
    }
}
