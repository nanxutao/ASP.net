using System;
using System.Data.Entity;

namespace VBlog.Models
{
    public class VBlogDBContext:DbContext
    {
        public DbSet<GuestBook> GuestBooks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
