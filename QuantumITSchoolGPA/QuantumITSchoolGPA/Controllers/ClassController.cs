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
    public class ClassController : Controller
    {
        //private SchoolGpaDb db = new SchoolGpaDb();
        private ISchoolGpaDataSource db;
        public ClassController(ISchoolGpaDataSource db)
        {
            this.db = db;
        }

        // GET: /Class/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Class/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Class myClass)
        {
            if (ModelState.IsValid)
            {
                db.Add<Class>(myClass);
                db.SaveChanges();
                return RedirectToAction("Index","Home",null);
            }

            return View(myClass);
        }

        //
        // GET: /Class/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Class myClass = db.Classes.Find(id);
            Class myClass = (from item in db.Query<Class>()
                             where item.Id == id
                             select item).SingleOrDefault();
            if (myClass == null)
            {
                return HttpNotFound();
            }
            return View(myClass);
        }

        //
        // POST: /Class/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Class myClass)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(myClass).State = EntityState.Modified;
                db.Update<Class>(myClass);
                db.SaveChanges();
                return RedirectToAction("Index", "Home", null);
            }
            return View(myClass);
        }

        //
        // GET: /Class/Delete/5

        public ActionResult Delete(int id = 0)
        {
            //Class myClass = db.Classes.Find(id);
            Class myClass = (from item in db.Query<Class>()
                             where item.Id == id
                             select item).SingleOrDefault();
            if (myClass == null)
            {
                return HttpNotFound();
            }
            return View(myClass);
        }

        //
        // POST: /Class/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Class myClass = db.Classes.Find(id);
            Class myClass = (from item in db.Query<Class>()
                             where item.Id == id
                             select item).SingleOrDefault();
            db.Remove<Class>(myClass);
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