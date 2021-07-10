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
    public class EmployeeController : Controller
    {
        private EmployeeInfoContainer db = new EmployeeInfoContainer();

        //
        // GET: /Employee/

        public ViewResult Index(bool isDeleted=false)
        {
            //var employeeset = db.Employeeset.Include("Department").Include("BankCard");
            var employees = db.Employeeset.Where(e => e.IsDeleted == isDeleted).Include("Department");
            return View(employees.ToList());
        }

        //
        // GET: /Employee/Details/5

        public ViewResult Details(int id)
        {
            Employee employee = db.Employeeset.Single(e => e.ID == id);
            return View(employee);
        }

        //
        // GET: /Employee/Create

        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departmentset, "ID", "DepartmentName");
            ViewBag.ID = new SelectList(db.BankCardset, "ID", "CardNumber");
            return View();
        } 

        //
        // POST: /Employee/Create

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employeeset.AddObject(employee);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.DepartmentID = new SelectList(db.Departmentset, "ID", "DepartmentName", employee.DepartmentID);
            ViewBag.ID = new SelectList(db.BankCardset, "ID", "CardNumber", employee.ID);
            return View(employee);
        }
        
        //
        // GET: /Employee/Edit/5
 
        public ActionResult Edit(int id)
        {
            Employee employee = db.Employeeset.Single(e => e.ID == id);
            ViewBag.DepartmentID = new SelectList(db.Departmentset, "ID", "DepartmentName", employee.DepartmentID);
            ViewBag.ID = new SelectList(db.BankCardset, "ID", "CardNumber", employee.ID);
            return View(employee);
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employeeset.Attach(employee);
                db.ObjectStateManager.ChangeObjectState(employee, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departmentset, "ID", "DepartmentName", employee.DepartmentID);
            ViewBag.ID = new SelectList(db.BankCardset, "ID", "CardNumber", employee.ID);
            return View(employee);
        }

        //
        // GET: /Employee/Delete/5
 
        public ActionResult Delete(int id)
        {
            Employee employee = db.Employeeset.Single(e => e.ID == id);
            return View(employee);
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Employee employee = db.Employeeset.Single(e => e.ID == id);
            //db.Employeeset.DeleteObject(employee);
            if (employee.IsDeleted == false)
            {
                employee.IsDeleted = true;
                employee.QuitDate = DateTime.Today;
            }
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