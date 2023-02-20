using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace calendar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DateTime dt = DateTime.Now;
            Calendar cc = new Calendar(dt);
            lbl1.Text = cc.DateString;
            lbl2.Text = cc.AnimalString;
            lbl3.Text = cc.ChineseDateString;
            lbl4.Text = cc.ChineseHour;
            lbl5.Text = cc.ChineseTwentyFourDay;
            lbl6.Text = cc.DateHoliday;
            lbl7.Text = cc.ChineseTwentyFourPrevDay;
            lbl8.Text = cc.ChineseTwentyFourNextDay;
            lbl9.Text = cc.GanZhiDateString;
            lbl10.Text = cc.WeekDayStr;
            lbl11.Text = cc.ChineseConstellation;
            lbl12.Text = cc.Constellation;
            
        }
    }
}
