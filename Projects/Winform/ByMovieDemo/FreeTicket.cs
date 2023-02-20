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
    /// 赠票
    /// </summary>
    public class FreeTicket:Ticket
    {
        public FreeTicket() { }
        public FreeTicket(string customerName,ScheduleItem scheduleItem,Seat seat):base(scheduleItem,seat)
        {
            this.CustomerName = customerName;
            this.Price = CalcPrice();
        }

        //赠票人姓名
        public string CustomerName { get; set; }


        /// <summary>
        /// 计算赠票票价
        /// </summary>
        /// <returns></returns>
        public override double CalcPrice()
        {
            return 0;
        }

        /// <summary>
        /// 打印赠票
        /// </summary>
        public override void Print()
        {
            string path = (this.ScheduleItem.Time + " " + this.Seat.SeatNum).Replace(":", "-") + ".txt";
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                {
                    sw.WriteLine("*******************************");
                    sw.WriteLine("      青鸟影院(赠票)         ");
                    sw.WriteLine("-------------------------------");
                    sw.WriteLine("电影名：" + ScheduleItem.Movie.MovieName);
                    sw.WriteLine("时间：" + this.ScheduleItem.Time);
                    sw.WriteLine("座位号：" + this.Seat.SeatNum);
                    sw.WriteLine("赠送人："+this.CustomerName);
                    sw.WriteLine("价格：" + this.Price);
                    sw.WriteLine("*******************************");
                }
            }
        }
    }
}
