using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcBookList19301330222_0009.Models
{
    public class BookDBContext:DbContext
    {
        public DbSet<Book> books { get; set; }
    }
}