using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFlight.Models;

namespace MvcFlight.Controllers
{ 
    [Authorize(Roles="administrator")]
    public class FlightController : Controller
    {
        private FlightDBContext db = new FlightDBContext();
        private PassengerDBContext ne = new PassengerDBContext();

        //
        // GET: /Flight/

        public ViewResult Index()
        {
            return View(db.flights.ToList());
        }

        //
        // GET: /Flight/Details/5

        public ViewResult Details(int id)
        {
            Flight flight = db.flights.Find(id);
            return View(flight);
        }

        //
        // GET: /Flight/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Flight/Create

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
        // GET: /Flight/Edit/5
 
        public ActionResult Edit(int id)
        {
            Flight flight = db.flights.Find(id);
            return View(flight);
        }

        //
        // POST: /Flight/Edit/5

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
        // GET: /Flight/Delete/5
 
        public ActionResult Delete(int id)
        {
            Flight flight = db.flights.Find(id);
            return View(flight);
        }

        //
        // POST: /Flight/Delete/5

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
        public ActionResult Add(int id)
        {
            Flight flight = db.flights.Single(p => p.id == id);
            
            int[] pasInFlight = ne.passengers.ToList().Select(e => e.id).ToArray();
            
            return View(pasInFlight);
            
        }
        /*[HttpPost, ActionName("Add")]
        public ActionResult AddConfirmed(int id, int[] pasId)
        {
            Flight flight = db.flights.Single(p => p.id == id);
            if (pasId != null)
            {
                foreach (var pid in pasId)
                {
                    
                }
            }
        }*/
    }
}