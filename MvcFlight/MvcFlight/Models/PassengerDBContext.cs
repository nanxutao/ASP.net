using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcFlight.Models
{
    public class PassengerDBContext:DbContext
    {
        public DbSet<Passenger> passengers { get; set; }
    }
}