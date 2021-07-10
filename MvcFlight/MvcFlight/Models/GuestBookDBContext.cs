using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcFlight.Models
{
    public class GuestBookDBContext:DbContext
    {
        public DbSet<GuestBook> guestbooks { get; set; }
    }
}