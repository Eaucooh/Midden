using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace 青鸟影院
{
    [Serializable]
    /// <summary>
    /// 电影院类
    /// </summary>
    public class Cinema
    {
        public Cinema()
        {

            SoldTickets = new List<Ticket>();
            Schedule = new Schedule();
            Seats = new Dictionary<string, Seat>();
        }


        public Schedule Schedule { get; set; }

        public Dictionary<string, Seat> Seats { get; set; }

        public List<Ticket> SoldTickets { get; set; }

        /// <summary>
        /// 加载放映场次
        /// </summary>
        public void Load()
        {
            using (FileStream fs = new FileStream("student.dat",FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                this.SoldTickets = bf.Deserialize(fs) as List<Ticket>;
            }
        }

        /// <summary>
        /// 保存销售信息
        /// </summary>
        public void Save()
        {
            //
            using (FileStream fs = new FileStream("student.dat",FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, SoldTickets);
            }

        }
    }
}
