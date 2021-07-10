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
    public class DepartmentController : Controller
    {
        private EmployeeInfoContainer db = new EmployeeInfoContainer();

        //
        // GET: /Department/

        public ViewResult Index()
        {
            return View(db.Departmentset.Where(d=>d.IsDeleted==false).ToList());
        }

        //
        // GET: /Department/Details/5

        public ViewResult Details(int id)
        {
            Department department = db.Departmentset.Single(d => d.ID == id);
            return View(department);
        }

        //
        // GET: /Department/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Department/Create

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departmentset.AddObject(department);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(department);
        }
        
        //
        // GET: /Department/Edit/5
 
        public ActionResult Edit(int id)
        {
            Department department = db.Departmentset.Single(d => d.ID == id);
            return View(department);
        }

        //
        // POST: /Department/Edit/5

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departmentset.Attach(department);
                db.ObjectStateManager.ChangeObjectState(department, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        //
        // GET: /Department/Delete/5
 
        public ActionResult Delete(int id)
        {
            Department department = db.Departmentset.Single(d => d.ID == id);
            if(department.Employees.Count()>0)
            return View("DepartmentDeleteErr");
            return View(department);
        }

        //
        // POST: /Department/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Department department = db.Departmentset.Single(d => d.ID == id);
            if (department.Employees.Count() > 0)
                return View("DepartmentDeleteErr");
            //db.Departmentset.DeleteObject(department);
            department.IsDeleted = true;
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