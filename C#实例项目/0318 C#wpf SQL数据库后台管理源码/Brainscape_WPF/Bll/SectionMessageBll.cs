using Dall;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
 public   class SectionMessageBll
    {
        public static List<SectionMessage> Querysubject(string SubjectID)
        {
            return SectionMessageDall.QuerySection(SubjectID);
        }
        public static int DeleteSection(SectionMessage id)
        {
            return SectionMessageDall.DeleteSection(id);
        }
        public static int AddSection(SectionMessage s)
        {
            return SectionMessageDall.AddSection(s);
        }
        public static int UpdateSection(SectionMessage s)
        {
            return SectionMessageDall.UpdateSection(s);
        }
        public static List<SectionMessage> QuerysubjectID(string ID)
        {
            return SectionMessageDall.QuerysubjectID(ID);
        }
        public static int UpdateCardsCount(int cout, string s)
        {

            return SectionMessageDall.UpdateCardsCount(cout,s);
        }
        public static int SectionQueryName(string Name, string SubjectID)
        {

            return SectionMessageDall.SectionQueryName(Name,SubjectID);
        }
    }
}
