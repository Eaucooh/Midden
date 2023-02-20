using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrithdayEigth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string[] date = {
         "甲子", "乙丑", "丙寅", "丁卯", "戊辰", "己巳", "庚午", "辛未", "壬申", "癸酉",
         "甲戊", "乙亥", "丙子", "丁丑", "戊寅", "乙卯", "庚辰", "辛巳", "壬午", "癸未",         "甲申", "乙酉", "丙戌", "丁亥", "戊子", "己丑", "庚寅", "辛卯", "壬辰", "癸巳",         "甲午", "乙未", "丙申", "丁酉", "戊戌", "己亥", "庚子", "辛丑", "壬寅", "癸卯",         "甲辰", "乙巳", "丙午", "丁未", "戊申", "乙酉", "庚戌", "辛亥", "壬子", "癸丑",         "甲寅", "乙卯", "丙辰", "丁巳", "戊午", "己未", "庚申", "辛酉", "壬戌", "癸亥" 
                                    
                                      };

        public int yearZi=0;
        private void btnOk_Click(object sender, EventArgs e)
        {
           DateTime dt=Day.Value;
           int year=dt.Year;
           int moon = dt.Month;
           int date = dt.DayOfYear;
            
           MessageBox.Show("Test:"+(year%60-3)+":"+moon+":"+date);
            //调用获得年生辰的方法
           String yearZi = yearZ(year);
           string moonZi = moonZ(moon,year);
           string dayZi = dayei(year, date);
           int hour = int.Parse(hourDate.Text);
          string hourZi= Hours(hour, date, year);
           txtBrithday.Text = yearZi+" "+moonZi+" "+dayZi+" "+hourZi;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        //获得年生辰的方法
        public string yearZ(int y) {
            int yearZie = yearNum(y);
            return date[yearZie-1];
        }
        public string moonZ(int m,int year) {

            int yearZie = yearNum(year);
            if (yearZie >= 12)
            {
                if (yearZie % 10 == 6 || yearZie % 10 == 1)
                {
                    return date[2+m-1];
                }
                else if (yearZie % 10 == 2 || yearZie % 10 == 7) {
                    return date[14 + m - 1];
                }
                else if (yearZie % 10 == 3 || yearZie % 10 == 8)
                {
                    return date[26 + m - 1];
                }
                else if (yearZi % 10 == 4 || yearZi % 10 == 9)
                {
                    return date[38 + m - 1];
                }
                else if (yearZie % 10 == 5 || yearZie % 10 == 0)
                {
                    return date[50 + m - 1 > 60 ? (m - 11) : 49 + m];
                }
            }
            else 
            {
                if (yearZie  == 6 || yearZie == 1)
                {
                    return date[2 + m - 1];
                }
                else if (yearZie  == 2 || yearZie  == 7)
                {
                    return date[14 + m - 1];
                }
                else if (yearZie  == 3 || yearZie  == 8)
                {
                    return date[26 + m - 1];
                }
                else if (yearZi  == 4 || yearZi == 9)
                {
                    return date[38 + m - 1];
                }
                else if (yearZie== 5 || yearZie == 10)
                {
                    return date[50 + m - 1>60?(m-11):49+m];
                }
            }
            return date[1];
        }

        public string dayei(int year,int day) {

            int yearZie = yearNum(year);
            return date[(yearZie + day)%60-1];
        }
        public string Hours(int hour,int day,int year) {
            int yearZie=yearNum(year);
            string strH = "";
            int datey=(yearZie+day)%60-1;
            int dateZi=datey%10;
            if (dateZi == 1 || dateZi == 5)
            {
                strH += "甲";
            }
            else if (dateZi == 2 || dateZi == 6)
            {
                strH += "丙";
            }
            else if (dateZi == 3 || dateZi == 7)
            {
                strH += "戊";
            }
            else if (dateZi == 4 || dateZi == 8)
            {
                strH += "庚";
            }
            else if (dateZi == 5 || dateZi == 0)
            {
                strH += "壬";
            }


            if (hour > 0 && hour <= 1) 
            { 
                  strH+="子";
            }
            else if (hour > 1 && hour <= 3)
            {
                strH += "丑";
            }
            else if (hour > 3 && hour <= 5)
            {
                strH += "寅";
            }
            else if (hour > 5 && hour <= 7)
            {
                strH += "卯";
            }
            else if (hour > 7 && hour <= 9)
            {
                strH += "辰";
            }
            else if (hour > 9 && hour <= 11)
            {
                strH += "巳";
            }
            else if (hour > 11 && hour <= 13)
            {
                strH += "午";
            }
            else if (hour > 13 && hour <= 15)
            {
                strH += "未";
            }
            else if (hour > 15 && hour <= 17)
            {
                strH += "申";
            }
            else if (hour > 17 && hour <= 19)
            {
                strH += "子";
            }
            else if (hour > 19 && hour <= 21)
            {
                strH += "酉";
            }
            else if (hour > 21 && hour <= 23)
            {
                strH += "戊";
            }
            else if (hour > 0 && hour <= 1) 
            {
                strH += "亥";
            }
            return strH;
        }

        public int yearNum(int year) {
            int yearZie = year % 60 - 3;

            if (yearZie <= 0)
            {
                yearZie += 60;
            }
            return yearZie;

        }
    }
}
