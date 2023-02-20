using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 青鸟影院
{
    [Serializable]
    /// <summary>
    /// 学生票
    /// </summary>
    public class StudentTicket:Ticket
    {
        public StudentTicket() { }
        public StudentTicket(ScheduleItem scheduleItem,Seat seat,double discount):base(scheduleItem,seat)
        {
            this.Discount = discount;
            this.Price = CalcPrice();
        }

        //折扣
        public double Discount { get; set; }

        /// <summary>
        /// 计算学生票价格
        /// </summary>
        /// <returns></returns>
        public override double CalcPrice()
        {
            return this.ScheduleItem.Movie.Price * this.Discount /10;
        }

        /// <summary>
        /// 打印学生票
        /// </summary>
        public override void Print()
        {
            string path = (this.ScheduleItem.Time + " " + this.Seat.SeatNum).Replace(":", "-") + ".txt";
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                {
                    sw.WriteLine("*******************************");
                    sw.WriteLine("      青鸟影院(学生票)         ");
                    sw.WriteLine("-------------------------------");
                    sw.WriteLine("电影名：" + ScheduleItem.Movie.MovieName);
                    sw.WriteLine("时间：" + this.ScheduleItem.Time);
                    sw.WriteLine("座位号：" + this.Seat.SeatNum);
                    sw.WriteLine("折扣："+this.Discount);
                    sw.WriteLine("价格：" + this.Price);
                    sw.WriteLine("*******************************");
                }
            }
        }
    }
}
