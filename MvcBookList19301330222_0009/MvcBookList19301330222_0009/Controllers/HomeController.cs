using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBookList19301330222_0009.Models;

namespace MvcBookList19301330222_0009.Controllers
{
    public class HomeController : Controller
    {
        private BookDBContext db = new BookDBContext();
        public ActionResult Index(string bookname)
        {
            var blist = db.books.Where(b => b.bookName.Contains(bookname));
            return View(blist);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
