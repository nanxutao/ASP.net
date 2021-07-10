using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VBlog.Models;

namespace VBlog.Controllers
{
    public class CategoryController : Controller
    {
        private VBlogDBContext context = new VBlogDBContext();

        public PartialViewResult List()
        {
            return PartialView(context.Categories.ToList());
        }

    }
}
