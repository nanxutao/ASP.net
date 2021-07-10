using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFlight.Models;
using Webdiyer.WebControls.Mvc;

namespace MvcFlight.Areas.admin.Controllers
{
    [Authorize(Roles = "administrator")]
    public class FlightController : Controller
    {
        private FlightDBContext db = new FlightDBContext();

        //
        // GET: /admin/Flight/

        public ViewResult Index(int? pageIndex)
        {
            PagedList<Flight> p1 = new PagedList<Flight>(db.flights.ToList(), pageIndex ?? 1, 8);
            return View(p1);
            
        }

        //
        // GET: /admin/Flight/Details/5

        public ViewResult Details(int id)
        {
            Flight flight = db.flights.Find(id);
            return View(flight);
        }

        //
        // GET: /admin/Flight/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /admin/Flight/Create

        [HttpPost]
        public ActionResult Create(Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(flight);
        }
        
        //
        // GET: /admin/Flight/Edit/5
 
        public ActionResult Edit(int id)
        {
            Flight flight = db.flights.Find(id);
            return View(flight);
        }

        //
        // POST: /admin/Flight/Edit/5

        [HttpPost]
        public ActionResult Edit(Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        //
        // GET: /admin/Flight/Delete/5
 
        public ActionResult Delete(int id)
        {
            Flight flight = db.flights.Find(id);
            return View(flight);
        }

        //
        // POST: /admin/Flight/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Flight flight = db.flights.Find(id);
            db.flights.Remove(flight);
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