using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeInfo19301330222_3001.Models;
using EmployeeInfo19301330222_3001.ViewModels;

namespace EmployeeInfo19301330222_3001.Controllers
{ 
    public class ProjectController : Controller
    {
        private EmployeeInfoContainer db = new EmployeeInfoContainer();

        //
        // GET: /Project/

        public ViewResult Index(int id = 0)
        {
            ProjectViewModel pvm = new ProjectViewModel();
            pvm.SelectedProjectID = id;
            pvm.Projects = db.Projectset.ToList();
            if (id > 0)
            {
                var project = db.Projectset.SingleOrDefault(p => p.ID == id);
                pvm.EmployeesInProject = project.Employees.ToList();
            }
            return View(pvm);
        }

        //
        // GET: /Project/Details/5

        public ViewResult Details(int id)
        {
            Project project = db.Projectset.Single(p => p.ID == id);
            return View(project);
        }

        //
        // GET: /Project/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Project/Create

        [HttpPost]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projectset.AddObject(project);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(project);
        }
        
        //
        // GET: /Project/Edit/5
 
        public ActionResult Edit(int id)
        {
            Project project = db.Projectset.Single(p => p.ID == id);
            return View(project);
        }

        //
        // POST: /Project/Edit/5

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projectset.Attach(project);
                db.ObjectStateManager.ChangeObjectState(project, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        //
        // GET: /Project/Delete/5
 
        public ActionResult Delete(int id)
        {
            Project project = db.Projectset.Single(p => p.ID == id);
            return View(project);
        }

        //
        // POST: /Project/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Project project = db.Projectset.Single(p => p.ID == id);
            db.Projectset.DeleteObject(project);
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
            Project project = db.Projectset.Single(p => p.ID == id);
            int[] empInProject = project.Employees.Select(e => e.ID).ToArray();
            var employeeList = db.Employeeset.Where(e => !empInProject.Contains(e.ID)).Where(e => e.IsDeleted == false);
            return View(employeeList);
        }
        [HttpPost, ActionName("Add")]
        public ActionResult AddConfirmed(int id, int[] empId)
        {
            Project project = db.Projectset.Single(p => p.ID == id);
            if (empId != null)
            {
                foreach (var eid in empId)
                {
                    project.Employees.Add(db.Employeeset.Single(e => e.ID == eid));
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index", new { id = id });
        }
        public ActionResult Quit(int empid, int proid)
        {
            Project project = db.Projectset.Single(p => p.ID == proid);
            Employee employee = db.Employeeset.Single(e => e.ID == empid);
            project.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = proid });
        }
    }
}