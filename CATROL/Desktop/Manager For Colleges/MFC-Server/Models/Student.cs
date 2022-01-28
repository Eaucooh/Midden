using ape_DataBase;
using MFC_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFC_Server.Pages
{
    class Student : Person
    {
        public int Grades { get; set; } //年级
        public string Classes { get; set; } //班级
        public string Department { get; set; } //专业院系
        public int Period { get; set; } //届
        public ape_System.Access.Identification Access { get; set; } //权限
        public DateTime EntranceTime { get; set; }
        public string[] Hobbies { get; set; } //爱好
        public string[] Certificates { get; set; } //证书

        public Student(string ID)
        {
            DataBaseHelper dbh = new DataBaseHelper("127.0.0.1", "MFC_Persons", "sa", "Zty213970");
            Name = dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Name").ToString();
            IDNumber = dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "IDNumber").ToString();
            Nation = dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Nation").ToString();
            Height = dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Height").ToString();
            Width = dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Width").ToString();
            Gender = new EnumHelper().GetGender(dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Gender").ToString());
            Ages = int.TryParse(dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Ages").ToString(), out int age) ? age : 1000;
            Address = dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Address").ToString();

            string[] nums = dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "PhoneNumbers").ToString().Split(';');
            PhoneNumbers = new string[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                PhoneNumbers[i] = nums[i];
            }

            string[] mails = dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Emails").ToString().Split(';');
            Emails = new ape_Network.Email[mails.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                Emails[i] = new ape_Network.Email().StringToEmail(nums[i]);
            }

            Grades = int.TryParse(dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Grades").ToString(), out int grade) ? grade : 1000;
            Classes = dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Classes").ToString();
            Department = dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Department").ToString();
            Period = int.TryParse(dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Period").ToString(), out int period) ? period : 1000;
            Access = new ape_System.Access().ToAccess(dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Access").ToString());
            EntranceTime = DateTime.TryParse(dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "EntranceTime").ToString(), out DateTime entranceTime) ? entranceTime : DateTime.Now;

            string[] hobbies = dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Hobbies").ToString().Split(';');
            Hobbies = new string[hobbies.Length];
            for (int i = 0; i < hobbies.Length; i++)
            {
                Hobbies[i] = hobbies[i];
            }

            string[] ctf = dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Certificates").ToString().Split(';');
            Certificates = new string[ctf.Length];
            for (int i = 0; i < ctf.Length; i++)
            {
                Certificates[i] = ctf[i];
            }
        }

        public new StringBuilder GetInfos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Name}^");
            sb.Append($"{IDNumber}^");
            sb.Append($"{Nation}^");
            sb.Append($"{Height}^");
            sb.Append($"{Width}^");
            sb.Append($"{Gender}^");
            sb.Append($"{Ages}^");
            sb.Append($"{Address}^");

            sb.Append($"{Grades}^");
            sb.Append($"{Classes}^");
            sb.Append($"{Department}^");
            sb.Append($"{Period}^");
            sb.Append($"{Access}^");
            sb.Append($"{EntranceTime}");
            return sb;
        }

        public StringBuilder[] GetSpecialInfoS()
        {
            StringBuilder[] sb = new StringBuilder[4];
            StringBuilder pns = new StringBuilder();
            StringBuilder adr = new StringBuilder();
            StringBuilder hob = new StringBuilder();
            StringBuilder ctf = new StringBuilder();
            for (int i = 0; i < PhoneNumbers.Length; i++)
            {
                pns.Append($"{PhoneNumbers[i]}^");
            }
            for (int i = 0; i < Emails.Length; i++)
            {
                adr.Append($"{Emails[i]}^");
            }
            for (int i = 0; i < Hobbies.Length; i++)
            {
                hob.Append($"{Hobbies[i]}^");
            }
            for (int i = 0; i < Certificates.Length; i++)
            {
                ctf.Append($" {Certificates[i]}^");
            }
            sb[0] = pns;
            sb[1] = adr;
            sb[2] = hob;
            sb[3] = ctf;
            return sb;
        }
    }
}