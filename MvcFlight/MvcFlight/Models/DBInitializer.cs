using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcFlight.Models
{
    public class DBInitializer:DropCreateDatabaseIfModelChanges<FlightDBContext>
    {
        protected override void Seed(FlightDBContext context)
        {
            List<Flight> blist = new List<Flight>()
            {
                new Flight{
                    FlightName = "DF101",
                    Start = "Shanghai",
                    Destination = "Beijing",
                    StartTime =Convert.ToDateTime("2020-1-1 8:00:00"),
                    EndTime = Convert.ToDateTime("2020-1-1 10:10:00"),
                    price = 550.00
                },
                new Flight{
                    FlightName = "DF107",
                    Start = "Shanghai",
                    Destination = "GuangDong",
                    StartTime = DateTime.Parse("2020-1-1 10:00:00"),
                    EndTime = DateTime.Parse("2020-1-1 12:20:00"),
                    price = 605.00
                }

            };
            blist.ForEach(b => context.flights.Add(b));
        }
    }
}