using System.Text;

namespace MFC_Server.Pages
{
    class Person
    {
        public string Name { get; set; } //姓名
        public string IDNumber { get; set; } //身份证号码
        public string Nation { get; set; } //民族
        public string Height { get; set; } //身高
        public string Width { get; set; } //体重
        public Models.EnumHelper.Gender Gender { get; set; } //性别
        public int Ages { get; set; } //年龄
        public string Address { get; set; } //住址
        public string[] PhoneNumbers { get; set; } //联系电话
        public ape_Network.Email[] Emails { get; set; } //邮箱地址

        public StringBuilder GetInfos()
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
            return sb;
        }
    }
}