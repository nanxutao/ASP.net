using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MvcFlight.Models
{
    public class PassengerInitializer:DropCreateDatabaseIfModelChanges<PassengerDBContext>
    {
        protected override void Seed(PassengerDBContext context)
        {
            List<Passenger> plist = new List<Passenger>()
            {
                new Passenger()
                {
                    Name = "张三",
                    Sex = "男",
                    BirthDay = DateTime.Parse("2001-1-1"),
                    Phone = "18812345678"
                },
                new Passenger()
                {
                    Name = "李四",
                    Sex = "男",
                    
                    BirthDay = DateTime.Parse("2001-1-2"),
                    Phone = "18898765432"
                }
            };
            plist.ForEach(b => context.passengers.Add(b));
        }
    }
}