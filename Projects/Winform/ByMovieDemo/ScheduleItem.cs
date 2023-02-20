using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 青鸟影院
{
    [Serializable]
    /// <summary>
    /// 放映场次
    /// </summary>
    public class ScheduleItem
    {
        public ScheduleItem() { }
        public ScheduleItem(Movie movie,string time)
        {
            this.Movie = movie;
            this.Time = time;
        }

        //电影
        public Movie Movie { get; set; }
        //放映时间
        public string Time { get; set; }
    }
}
