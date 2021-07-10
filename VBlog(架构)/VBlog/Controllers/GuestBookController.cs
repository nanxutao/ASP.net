using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VBlog.Models;
using Webdiyer.WebControls.Mvc;

namespace VBlog.Controllers
{
    public class GuestBookController : Controller
    {
        private VBlogDBContext context = new VBlogDBContext();
        private int pageSize = 10;

        public ActionResult Index(int ? pageIndex)
        {
            var guestbookQuery = from gb in context.GuestBooks
                                 orderby gb.AddDate descending
                                 select gb;
            PagedList<GuestBook> p1 = new PagedList<GuestBook>(guestbookQuery.ToList(), pageIndex ?? 1, pageSize);
            return View(p1);
        }
        [HttpPost, ValidateMvcCaptcha]
        public ViewResult Index(GuestBook gbook)
        {
            if (ModelState.IsValid)
            {
                gbook.AddDate = DateTime.Now;
                context.GuestBooks.Add(gbook);
                context.SaveChanges();
                ViewBag.Nickname = "";
                ViewBag.Message = "";
            }
            else
            {
                ViewBag.Nickname = gbook.Nickname;
                ViewBag.Message = gbook.Message;
            }
            var guestbookQuery = from gb in context.GuestBooks
                                 orderby gb.AddDate descending
                                 select gb;
            PagedList<GuestBook> p1 = new PagedList<GuestBook>(guestbookQuery.ToList(), 1, pageSize);
            return View(p1);
        }

    }
}
