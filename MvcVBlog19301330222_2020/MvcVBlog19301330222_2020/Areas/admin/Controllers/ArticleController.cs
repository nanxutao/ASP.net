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
    public class ArticleController : Controller
    {
        private VBlogDBContext db = new VBlogDBContext();
        private int pageSize = 10;
        //
        // GET: /admin/Article/

        public ViewResult Index(int? pageIndex)
        {
            var articles = db.Articles.Include(a => a.Category);
            PagedList<Article> pla = new PagedList<Article>(articles.ToList(), pageIndex ?? 1, pageSize);
            return View(pla);
        }

        //
        // GET: /admin/Article/Details/5

        public ActionResult Details(int id)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
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
                article.addDate = DateTime.Now;
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
            if (article == null)
            { return HttpNotFound(); }
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
            if (article == null)
            {
                return HttpNotFound();
            }
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