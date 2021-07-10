using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcVBlog19301330222_2020.Models;
using Webdiyer.WebControls.Mvc;

namespace MvcVBlog19301330222_2020.Areas.admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class GuestBookController : Controller
    {
        
            private VBlogDBContext db = new VBlogDBContext();
            private int pageSize = 10;
            //
            // GET: /admin/GuestBook/

            public ViewResult Index(int? pageIndex)
            {
                PagedList<GuestBook> pl = new PagedList<GuestBook>(db.GuestBooks.ToList(), pageIndex ?? 1, pageSize);
                return View(pl);
            }

            //
            // GET: /admin/GuestBook/Details/5

            public ActionResult Details(int id)
            {
                GuestBook guestbook = db.GuestBooks.Find(id);
                if (guestbook == null)
                {
                    return HttpNotFound();
                }
                return View(guestbook);
            }

            //
            // GET: /admin/GuestBook/Create

            public ActionResult Create()
            {
                return View();
            }

            //
            // POST: /admin/GuestBook/Create

            [HttpPost]
            public ActionResult Create(GuestBook guestbook)
            {
                if (ModelState.IsValid)
                {
                    db.GuestBooks.Add(guestbook);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(guestbook);
            }

            //
            // GET: /admin/GuestBook/Edit/5

            public ActionResult Edit(int id)
            {
                GuestBook guestbook = db.GuestBooks.Find(id);
                return View(guestbook);
            }

            //
            // POST: /admin/GuestBook/Edit/5

            [HttpPost]
            public ActionResult Edit(GuestBook guestbook)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(guestbook).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(guestbook);
            }

            //
            // GET: /admin/GuestBook/Delete/5

            public ActionResult Delete(int id)
            {
                GuestBook guestbook = db.GuestBooks.Find(id);
                if (guestbook == null)
                { return HttpNotFound(); }
                return View(guestbook);
            }

            //
            // POST: /admin/GuestBook/Delete/5

            [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int id)
            {
                GuestBook guestbook = db.GuestBooks.Find(id);
                db.GuestBooks.Remove(guestbook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            protected override void Dispose(bool disposing)
            {
                db.Dispose();
                base.Dispose(disposing);
            }
        }
    
}