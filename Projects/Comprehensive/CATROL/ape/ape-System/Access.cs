using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ape_System
{
    public class Access
    {
        public enum Identification
        {
            Creator = 0, //创作人
            Administrator = 1, //超级管理员
            Root = 2, //管理员
            User = 3, //用户
            Viewer = 4, //访客
            Unknown = 5
        }

        public string ToString(string access)
        {
            switch (access)
            {
                case "Creator":
                    return "创始人";
                case "Administrator":
                    return "超级管理员";
                case "Root":
                    return "管理员";
                case "User":
                    return "用户";
                case "Viewer":
                    return "访客";
                default:
                    return access;
            }
        }

        public Identification ToAccess(string access)
        {
            switch (access)
            {
                case "Creator":
                    return Identification.Creator;
                case "Administrator":
                    return Identification.Administrator;
                case "Root":
                    return Identification.Root;
                case "User":
                    return Identification.User;
                case "Viewer":
                    return Identification.Viewer;
                default:
                    return Identification.Unknown;
            }
        }
    }
}