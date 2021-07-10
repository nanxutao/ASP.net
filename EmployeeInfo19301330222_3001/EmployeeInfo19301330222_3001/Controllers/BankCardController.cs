using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeInfo19301330222_3001.Models;

namespace EmployeeInfo19301330222_3001.Controllers
{ 
    public class BankCardController : Controller
    {
        private EmployeeInfoContainer db = new EmployeeInfoContainer();

        //
        // GET: /BankCard/

        public ViewResult Index()
        {
            return View(db.BankCardset.ToList());
        }

        //
        // GET: /BankCard/Details/5

        public ViewResult Details(int id)
        {
            BankCard bankcard = db.BankCardset.Single(b => b.ID == id);
            return View(bankcard);
        }

        //
        // GET: /BankCard/Create

        public ActionResult Create()
        {
            int[] empHaveCard = db.BankCardset.Select(c => c.Employee.ID).ToArray();
            var empListNoCard = db.Employeeset.Where(e => !empHaveCard.Contains(e.ID)).Where(e => e.IsDeleted == false).ToList();
            ViewBag.employeeID = new SelectList(empListNoCard, "ID", "EmployeeName");
            return View();
        } 

        //
        // POST: /BankCard/Create

        [HttpPost]
        public ActionResult Create(BankCard bankcard,int employeeID)
        {
            if (ModelState.IsValid)
            {
                var employee = db.Employeeset.SingleOrDefault(e => e.ID == employeeID);
                db.BankCardset.AddObject(bankcard);
                bankcard.Employee = employee;
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(bankcard);
        }
        
        //
        // GET: /BankCard/Edit/5
 
        public ActionResult Edit(int id)
        {
            BankCard bankcard = db.BankCardset.Single(b => b.ID == id);
            return View(bankcard);
        }

        //
        // POST: /BankCard/Edit/5

        [HttpPost]
        public ActionResult Edit(BankCard bankcard)
        {
            if (ModelState.IsValid)
            {
                db.BankCardset.Attach(bankcard);
                db.ObjectStateManager.ChangeObjectState(bankcard, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bankcard);
        }

        //
        // GET: /BankCard/Delete/5
 
        public ActionResult Delete(int id)
        {
            BankCard bankcard = db.BankCardset.Single(b => b.ID == id);
            return View(bankcard);
        }

        //
        // POST: /BankCard/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            BankCard bankcard = db.BankCardset.Single(b => b.ID == id);
            db.BankCardset.DeleteObject(bankcard);
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