using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcFlight.Models
{
    public class GuestBookInitializer:DropCreateDatabaseIfModelChanges<GuestBookDBContext>
    {

        protected override void Seed(GuestBookDBContext context)
        {
            var gbooks = new List<GuestBook>
            {
               new GuestBook(){
                   Nickname="牛哥",
                   Message="飞机很舒服，下次再来。",
                   AddDate=DateTime.Parse("2021-6-10 10:00:00")
               },
               new GuestBook(){
                   Nickname="rich哥",
                   Message="已经买了1000张票了。",
                   AddDate=DateTime.Parse("2021-6-11 11:00:00"),
                   Reply="不要停下来啊！"
               }
            };

        }
    }
}