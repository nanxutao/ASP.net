using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFlight.Models;
using Webdiyer.WebControls.Mvc;

namespace MvcFlight.Controllers
{
    public class HomeController : Controller
    {
        private FlightDBContext db = new FlightDBContext();
        public ActionResult Index(int ? pageIndex)
        {
            int count = db.flights.ToList().Count();
            ViewBag.Count = count;
            PagedList<Flight> p1 = new PagedList<Flight>(db.flights.ToList(),pageIndex ?? 1, 5);   
            return View(p1);
            
        }
        public ActionResult Search(string flightname,string start,string end,int ? pageIndex,bool temp = true)
        {
            var flist = from p in db.flights
                        select p;
            if (!String.IsNullOrEmpty(flightname))
            {
                flightname = flightname.Trim();
                flist = from p in db.flights
                            where p.FlightName.Contains(flightname)
                            select p;
            }
            if (!String.IsNullOrEmpty(start)) 
            {
                start = start.Trim();
                flist = from p in flist
                        where p.Start.Contains(start)
                        select p;
            }
            if (!String.IsNullOrEmpty(end))
            {
                end = end.Trim();
                flist = from p in flist
                        where p.Destination.Contains(end)
                        select p;
            }
            
            flist = flist.Where(e => ((DateTime.Compare(e.StartTime, DateTime.Now) >= 0) == temp));
            int count = flist.Count();
            ViewBag.Count = count;
            PagedList<Flight> p1 = new PagedList<Flight>(flist.ToList(), pageIndex ?? 1, 5);
            return View ("index",p1);
        }
    }
}
