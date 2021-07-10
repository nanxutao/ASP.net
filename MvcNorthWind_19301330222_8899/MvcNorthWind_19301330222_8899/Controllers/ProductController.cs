using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcNorthWind_19301330222_8899.Models;
using Webdiyer.WebControls.Mvc;

namespace MvcNorthWind_19301330222_8899.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities ne = new NorthwindEntities();
        public ActionResult Index(int ? pageIndex)
        {
            
            ViewBag.productCategory = new SelectList(ne.Categories.ToList(), "CategoryID", "CategoryName");
            ViewBag.productSupplier = new SelectList(ne.Suppliers.ToList(), "SupplierID", "CompanyName");
            
            PagedList<Products> p1 = new PagedList<Products>(ne.Products.ToList(), pageIndex ?? 1, 5);
            return View(p1);
        }
        public ActionResult Detail(int id = 0)
        {
            var plist = from p in ne.Products
                        where p.ProductID == id
                        select p;
            if (plist.Count() == 0)
                return HttpNotFound();
            var product = plist.First();
            return View(product);

         
        }
        public ActionResult Search(string pname,int ? productCategory,int ? pageIndex,int ? productSupplier,int ? id)
        {
            ViewBag.productCategory = new SelectList(ne.Categories.ToList(), "CategoryID", "CategoryName");
            ViewBag.productSupplier = new SelectList(ne.Suppliers.ToList(), "SupplierID", "CompanyName");
            
            var plist = from p in ne.Products
                        select p;
            if (!String.IsNullOrEmpty(pname))
            {
                pname = pname.Trim();
                plist = from p in ne.Products
                            where p.ProductName.Contains(pname)
                            select p;
            }
            if (productCategory != null)
                plist = from p in plist
                        where p.CategoryID == productCategory
                        select p;
            if (productSupplier != null)
                plist = from p in plist
                        where p.SupplierID == productSupplier
                        select p;
            if (id != null)
                plist = from p in plist
                        where p.CategoryID == id
                        select p;
            int x = plist.Count();
            ViewBag.s = x;
            PagedList<Products> p1 = new PagedList<Products>(plist.ToList(), pageIndex ?? 1, 5);
            return View("index",p1);
        }

    }
}
