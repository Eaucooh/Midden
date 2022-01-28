using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZKit
{
    class Converts
    {
        public static Point Config_Location(string value, double width, double height)
        {
            switch (value)
            {
                case "CenterScreen":
                    return new Point()
                    {
                        X = (App.WorkAreaWidth - width) / 2,
                        Y = (App.WorkAreaHeight - height) / 2,
                    };
                default:
                    string[] Locs = value.Split(',');
                    return new Point()
                    {
                        X = Convert.ToDouble(Locs[0]),
                        Y = Convert.ToDouble(Locs[1])
                    };
            }
        }

        public static Point Config_Size(string value)
        {
            string[] lgs = value.Split(',');
            return new Point()
            {
                X = Convert.ToDouble(lgs[0]),
                Y = Convert.ToDouble(lgs[1])
            };
        }
    }
}
