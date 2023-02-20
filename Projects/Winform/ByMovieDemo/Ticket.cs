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
    /// 电影票父类
    /// </summary>
    public class Ticket
    {
        public Ticket() { }
        public Ticket(ScheduleItem scheduleItem,Seat seat)
        {
            this.ScheduleItem = scheduleItem;
            this.Seat = seat;
            this.Price = CalcPrice();
        }

        //价格
        public double Price { get; set; }
        //放映场次
        public ScheduleItem ScheduleItem { get; set; }
        //座位
        public Seat Seat { get; set; }


        /// <summary>
        /// 计算价格
        /// </summary>
        /// <returns></returns>
        public virtual double CalcPrice()
        {
            return this.ScheduleItem.Movie.Price;
        }

        /// <summary>
        /// 打印电影票
        /// </summary>
        public virtual void Print()
        {
            string path = (this.ScheduleItem.Time + " " + this.Seat.SeatNum).Replace(":", "-") + ".txt";
            using (FileStream fs = new FileStream(path,FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs,Encoding.Default))
                {
                    sw.WriteLine("*******************************");
                    sw.WriteLine("          青鸟影院             ");
                    sw.WriteLine("-------------------------------");
                    sw.WriteLine("电影名："+ScheduleItem.Movie.MovieName);
                    sw.WriteLine("时间："+this.ScheduleItem.Time);
                    sw.WriteLine("座位号："+this.Seat.SeatNum);
                    sw.WriteLine("价格："+this.Price);
                    sw.WriteLine("*******************************");
                }
            }
        }
    }
}
