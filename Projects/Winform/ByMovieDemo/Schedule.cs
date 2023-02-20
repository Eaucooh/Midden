using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace 青鸟影院
{
    [Serializable]
    /// <summary>
    /// 放映计划类
    /// </summary>
    public class Schedule
    {
        public Schedule() { Items = new Dictionary<string, ScheduleItem>(); }
        public Schedule(Dictionary<string, ScheduleItem> items)
        {
            this.Items = items;
        }

        public Dictionary<string, ScheduleItem> Items { get; set; }

        //加载XML中的放映场次信息
        public void LoadItems()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"Data\ShowList.xml");
                XmlNode root = doc.DocumentElement;

                foreach (XmlNode var in root.ChildNodes)//Movie
                {
                    Movie movie = new Movie();
                    foreach (XmlNode var2 in var.ChildNodes)//Name
                    {
                        switch (var2.Name)
                        {
                            case "Name":
                                movie.MovieName = var2.InnerText;
                                break;
                            case "Poster":
                                movie.Poster = var2.InnerText;
                                break;
                            case "Director":
                                movie.Director = var2.InnerText;
                                break;
                            case "Actor":
                                movie.Actor = var2.InnerText;
                                break;
                            case "Price":
                                movie.Price = Convert.ToDouble(var2.InnerText);
                                break;
                            case "Type":
                                movie.MovieType = (MovieType)Enum.Parse(typeof(MovieType), var2.InnerText);
                                break;
                            case "Schedule":
                                foreach (XmlNode var3 in var2.ChildNodes)//Item
                                {
                                    ScheduleItem item = new ScheduleItem(movie, var3.InnerText);
                                    this.Items.Add(var3.InnerText, item);
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
