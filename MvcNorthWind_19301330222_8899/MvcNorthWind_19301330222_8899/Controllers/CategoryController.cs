using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcNorthWind_19301330222_8899.Models;

namespace MvcNorthWind_19301330222_8899.Controllers
{
    public class CategoryController : Controller
    {

        NorthwindEntities ne = new NorthwindEntities();
        public PartialViewResult categoryList()
        {

            var cl = from c in ne.Categories
                     select c;
            return PartialView(cl);
        }

    }
}
