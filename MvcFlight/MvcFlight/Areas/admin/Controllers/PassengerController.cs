using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFlight.Models;

namespace MvcFlight.Areas.admin.Controllers
{
    [Authorize(Roles = "administrator")]
    public class PassengerController : Controller
    {
        private PassengerDBContext db = new PassengerDBContext();

        //
        // GET: /admin/Passenger/

        public ViewResult Index()
        {
            return View(db.passengers.ToList());
        }

        //
        // GET: /admin/Passenger/Details/5

        public ViewResult Details(int id)
        {
            Passenger passenger = db.passengers.Find(id);
            return View(passenger);
        }

        //
        // GET: /admin/Passenger/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /admin/Passenger/Create

        [HttpPost]
        public ActionResult Create(Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                db.passengers.Add(passenger);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(passenger);
        }
        
        //
        // GET: /admin/Passenger/Edit/5
 
        public ActionResult Edit(int id)
        {
            Passenger passenger = db.passengers.Find(id);
            return View(passenger);
        }

        //
        // POST: /admin/Passenger/Edit/5

        [HttpPost]
        public ActionResult Edit(Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passenger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(passenger);
        }

        //
        // GET: /admin/Passenger/Delete/5
 
        public ActionResult Delete(int id)
        {
            Passenger passenger = db.passengers.Find(id);
            return View(passenger);
        }

        //
        // POST: /admin/Passenger/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Passenger passenger = db.passengers.Find(id);
            db.passengers.Remove(passenger);
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