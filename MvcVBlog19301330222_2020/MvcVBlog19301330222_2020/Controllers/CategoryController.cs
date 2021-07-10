using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcVBlog19301330222_2020.Models;

namespace MvcVBlog19301330222_2020.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/

        private VBlogDBContext context = new VBlogDBContext();
        public PartialViewResult List()
        {
            return PartialView(context.Categories.ToList());
        }

    }
}
