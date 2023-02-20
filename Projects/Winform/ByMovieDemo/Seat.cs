using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace 青鸟影院
{
    [Serializable]
    /// <summary>
    /// 座位类
    /// </summary>
    public class Seat
    {
        public Seat() { }
        public Seat(string seatNum,Color color)
        {
            this.SeatNum = seatNum;
            this.Color = color;
        }

        //座位号
        public string SeatNum { get; set; }
        //颜色
        public Color Color { get; set; }
    }
}
