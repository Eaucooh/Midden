using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3
{
    public class ErrorCode
    {
        public int Code { get; set; }
        public string Data { get; set; }
        public string Desc { get; set; }
        public string Sid { get; set; }

        public ErrorCode()
        {

        }

        /// <summary>
        /// 将错误码转为等效的字符串表示
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("code：");
            sb.AppendLine(Code.ToString());
            sb.AppendFormat("data：");
            sb.AppendLine(Data);
            sb.AppendFormat("desc：");
            sb.AppendLine(Desc);
            sb.AppendFormat("sid：");
            sb.AppendLine(Sid);
            return sb.ToString();
        }
    }
}