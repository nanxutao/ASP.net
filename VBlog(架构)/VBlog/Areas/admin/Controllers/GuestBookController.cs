using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VBlog.Models;

namespace VBlog.Areas.admin.Controllers
{
    [Authorize(Roles = "BlogOwner")]
    public class GuestBookController : Controller
    {
        private VBlogDBContext db = new VBlogDBContext();

        //
        // GET: /admin/GuestBook/

        public ViewResult Index()
        {
            return View(db.GuestBooks.ToList());
        }

        //
        // GET: /admin/GuestBook/Details/5

        public ViewResult Details(int id)
        {
            GuestBook guestbook = db.GuestBooks.Find(id);
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