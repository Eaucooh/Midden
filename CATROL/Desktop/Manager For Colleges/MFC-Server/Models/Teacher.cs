using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFC_Server.Pages
{
    class Teacher : Person
    {
        public int Grades { get; set; } //年级
        public int Classes { get; set; } //班级
        public string Department { get; set; } //专业院系
        public ape_System.Access.Identification Access { get; set; } //权限
        public string[] Certificates { get; set; } //证书

        public new StringBuilder GetInfos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"姓名: {Name}");
            sb.Append($"身份证号: {IDNumber}");
            sb.Append($"民族: {Nation}");
            sb.Append($"身高: {Height}");
            sb.Append($"体重: {Width}");
            sb.Append($"性别: {Gender}");
            sb.Append($"年龄: {Ages}");
            sb.Append($"住址: {Address}");
            for (int i = 0; i < PhoneNumbers.Length; i++)
            {
                sb.Append($"联系电话: {PhoneNumbers[i]}");
            }
            for (int i = 0; i < Emails.Length; i++)
            {
                sb.Append($"邮箱地址: {Emails[i]}");
            }

            sb.Append($"年级: {Grades}");
            sb.Append($"班级: {Classes}");
            sb.Append($"专业院系: {Department}");
            sb.Append($"权限: {Access}");
            for (int i = 0; i < Certificates.Length; i++)
            {
                sb.Append($"证书: {Certificates[i]}");
            }
            return sb;
        }
    }
}
