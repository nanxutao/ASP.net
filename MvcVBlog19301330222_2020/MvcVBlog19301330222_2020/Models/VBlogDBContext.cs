using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcVBlog19301330222_2020.Models
{
    public class VBlogDBContext:DbContext
    {
        public DbSet<GuestBook> GuestBooks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}