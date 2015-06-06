using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuantumITSchoolGPA.Models;

namespace QuantumITSchoolGPA.Controllers
{
    public class StudentController : Controller
    {
        //private SchoolGpaDb db = new SchoolGpaDb();
        private ISchoolGpaDataSource db;
        public StudentController(ISchoolGpaDataSource db)
        {
            this.db = db;
        }
        //
        // GET: /Student/

        public ActionResult Index()
        {
            return View(db.Query<Student>().ToList());
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            //Student student = db.Students.Find(id);
            Student student = (from item in db.Query<Student>()
                             where item.Id == id
                             select item).SingleOrDefault();
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // GET: /Student/Create

        public ActionResult Create(int ClassId)
        {
            //var model = db.Classes.Find(ClassId);
            var model = (from item in db.Query<Class>()
                         where item.Id == ClassId
                         select item).SingleOrDefault();
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Add<Student>(student);
                db.SaveChanges();
                return RedirectToAction("Index", "Home", new { id=student.ClassId});
            }

            return View(student);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Student student = db.Students.Find(id);
            Student student = (from item in db.Query<Student>()
                               where item.Id == id
                               select item).SingleOrDefault();
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(student).State = EntityState.Modified;
                db.Update<Student>(student);
                db.SaveChanges();
                return RedirectToAction("Index", "Home", null);
            }
            return View(student);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            //Student student = db.Students.Find(id);
            Student student = (from item in db.Query<Student>()
                               where item.Id == id
                               select item).SingleOrDefault();
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Student student = db.Students.Find(id);
            Student student = (from item in db.Query<Student>()
                               where item.Id == id
                               select item).SingleOrDefault();
            db.Remove<Student>(student);
            db.SaveChanges();
            return RedirectToAction("Index", "Home", null);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}