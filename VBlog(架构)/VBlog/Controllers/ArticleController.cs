﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VBlog.Models;
using Webdiyer.WebControls.Mvc;

namespace VBlog.Controllers
{ 
    public class ArticleController : Controller
    {
        private VBlogDBContext context = new VBlogDBContext();
        private int pageSize = 2;

        //
        // GET: /Default1/

        public ViewResult Index(int?pageIndex)
        {
            var articleQuery = from article in context.Articles
                               orderby article.addDate descending
                               select article;
            PagedList<Article> p1 = new PagedList<Article>(articleQuery.ToList(), pageIndex ?? 1, pageSize);
            return View(p1);
        }
        public ActionResult Search(string key,int ? pageIndex)
        {
            var articleQuery = from article in context.Articles
                               select article;
            if (!string.IsNullOrEmpty(key))
            {
                key = key.Trim();
                articleQuery = articleQuery.Where(a => a.Title.Contains(key));
            }
            PagedList<Article> p1 = new PagedList<Article>(articleQuery.ToList(), pageIndex ?? 1, pageSize);
            return View("Index", p1);
       }
        public ActionResult ListArticleByCategory(int id, int? pageIndex)
        {
            var category = context.Categories.Find(id);
            if (category == null)
                return HttpNotFound();
            var articleQuery = from article in context.Articles
                               where article.CategoryID == id
                               select article;
            PagedList<Article> p1 = new PagedList<Article>(articleQuery.ToList(), pageIndex ?? 1, pageSize);
            return View("Index", p1);
        }
        public PartialViewResult Top10()
        {
            var articleQuery = from article in context.Articles
                               orderby article.Hit descending
                               select article;
            return PartialView(articleQuery.Take(10).ToList());
        }
        public ActionResult ShowArticle(int id)
        {
            var article = context.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            article.Hit++;
            context.SaveChanges();
            return View(article);
        }
    }
    
}