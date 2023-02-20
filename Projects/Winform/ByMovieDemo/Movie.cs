using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 青鸟影院
{
    [Serializable]
    /// <summary>
    /// 电影类
    /// </summary>
    public class Movie
    {
        public Movie() { }
        public Movie(string actor, string director, string movieName, MovieType movieType, string poster, double price)
        {
            this.Actor = actor;
            this.Director = director;
            this.MovieName = movieName;
            this.MovieType = movieType;
            this.Poster = poster;
            this.Price = price;
        }

        //导演
        public string Actor { get; set; }
        //演员
        public string Director { get; set; }
        //电影名
        public string MovieName { get; set; }
        //电影类型
        public MovieType MovieType { get; set; }
        //海报路径
        public string Poster { get; set; }
        //电影价格
        public double Price { get; set; }
    }
}
