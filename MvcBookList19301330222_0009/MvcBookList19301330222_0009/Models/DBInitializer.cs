using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcBookList19301330222_0009.Models
{
    public class DBInitializer:DropCreateDatabaseIfModelChanges<BookDBContext>
    {
        protected override void Seed(BookDBContext context)
        {
            List<Book> blist = new List<Book>()
            {
                new Book(){
                    isbn="9787302287537",
                    bookName = "ASP.NET从入门到精通(第三版)",
                    author = "明日科技",
                    press = "清华大学出版社",
                    pressDate = DateTime.Parse("2012-9-2"),
                    price = 89.80,
                    size = "25.8*20.2*4.4 cm",
                    weight = 1.6,
                    format = 16
                },
                new Book(){
                    isbn="9787302264538",
                    bookName = "Visual C#程序设计基础",
                    author = "徐安东",
                    press = "清华大学出版社",
                    pressDate = DateTime.Parse("2012-1-1"),
                    price = 29.00,
                    size = "25.8*18.2*1.4 cm",
                    weight = 0.458,
                    format = 16
                }

            };
            blist.ForEach(b => context.books.Add(b));
        }
    }
}