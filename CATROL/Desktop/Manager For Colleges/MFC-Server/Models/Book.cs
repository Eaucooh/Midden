using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFC_Server.Pages
{
    class Book : Library
    {
        public string BookName { get; set; } //书名
        public string BookAuthor { get; set; } //作者
        public string BookPublisher { get; set; } //出版社
        public string BookVersion { get; set; } //版本
        public DateTime BookTime_Publish { get; set; } //出版时间
        public DateTime BookTime_LogIn { get; set; } //入库时间

        public void MoveTo(Library lib) //移动到（图书馆）
        {

        }

        public void LendOut(Person person) //借出给（某人）
        {

        }

        public void LendIn() //从借出人处收回
        {

        }

        public void Remove() //移除
        {

        }

        public void Sold(double money) //卖出
        {

        }
    }
}
