using Dall;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
public  class SubjectContentBll
    {
        public static List<SubjectContent> QueryContent(string SectionID)
        {
            return SubjectContentDall.QueryContent(SectionID);
        }
        public static int UpdateContent(SubjectContent s)
        {
            return SubjectContentDall.UpdateContent(s);
        }
        public static int AddContent(SubjectContent s)
        {
            return SubjectContentDall.AddContent(s);
        }
        public static int DeleteContent(SubjectContent id)
        {
            return SubjectContentDall.DeleteContent(id);
        }

    }
}
