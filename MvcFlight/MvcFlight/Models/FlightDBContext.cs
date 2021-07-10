using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcFlight.Models
{
    public class FlightDBContext:DbContext
    {
        public DbSet<Flight> flights { get; set; }
    }
}