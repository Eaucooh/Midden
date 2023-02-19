using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFC_Server.Models
{
    public class EnumHelper
    {
        public enum Gender
        {
            male = 0, //男性
            female = 1, //女性
            unknown = 2 //未知
        }

        /// <summary>
        /// 通过字符串返回一个Gender类
        /// </summary>
        /// <param name="gender">性别字符串</param>
        /// <returns></returns>
        public Gender GetGender(string gender)
        {
            switch (gender)
            {
                case "男":
                    return Gender.male;
                case "女":
                    return Gender.female;
                default:
                    return Gender.unknown;
            }
        }

        public enum GrowlType
        {
            Ask, Error, Fatal, Info, Success, Warning
        }
    }
}