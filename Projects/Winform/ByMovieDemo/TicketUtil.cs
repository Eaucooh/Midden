using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 青鸟影院
{
    /// <summary>
    /// 创建电影票工具类
    /// 使用简单工厂模式创建票
    /// </summary>
    public class TicketUtil
    {
        public static Ticket CreateTicket(ScheduleItem item,Seat seat,string customerName,double discount,string type)
        {
            Ticket ticket = null;
            switch (type)
            {
                case "normal":
                    ticket = new Ticket(item, seat);
                    break;
                case "free":
                    ticket = new FreeTicket(customerName, item, seat);
                    break;
                case "student":
                    ticket = new StudentTicket(item, seat, discount);
                    break;
            }
            return ticket;
        }
    }
}
