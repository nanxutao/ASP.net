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
    public class ArticleController : Controller
    {
        private VBlogDBContext db = new VBlogDBContext();

        //
        // GET: /admin/Article/

        public ViewResult Index()
        {
            var articles = db.Articles.Include(a => a.Category);
            return View(articles.ToList());
        }

        //
        // GET: /admin/Article/Details/5

        public ViewResult Details(int id)
        {
            Article article = db.Articles.Find(id);
            return View(article);
        }

        //
        // GET: /admin/Article/Create

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        } 

        //
        // POST: /admin/Article/Create

        [HttpPost]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", article.CategoryID);
            return View(article);
        }
        
        //
        // GET: /admin/Article/Edit/5
 
        public ActionResult Edit(int id)
        {
            Article article = db.Articles.Find(id);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", article.CategoryID);
            return View(article);
        }

        //
        // POST: /admin/Article/Edit/5

        [HttpPost]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", article.CategoryID);
            return View(article);
        }

        //
        // GET: /admin/Article/Delete/5
 
        public ActionResult Delete(int id)
        {
            Article article = db.Articles.Find(id);
            return View(article);
        }

        //
        // POST: /admin/Article/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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