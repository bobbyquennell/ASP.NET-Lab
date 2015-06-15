using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFoodExercise.Models;

namespace OdeToFoodExercise.Controllers
{
    public class RestaurantController : Controller
    {
        private IOdeToFoodDataSource db;
        public RestaurantController(IOdeToFoodDataSource db)
        {
            this.db = db;
        }
        //
        // GET: /Restaurant/

        public ActionResult Index()
        {
            return View(db.Query<Restaurant>().ToList());
        }

        //
        // GET: /Restaurant/Details/5

        public ActionResult Details(int id = 0)
        {
            Restaurant restaurant = db.Query<Restaurant>().Single(r=> r.Id == id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //
        // GET: /Restaurant/Create

        [Authorize(Roles="admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Restaurant/Create

        [HttpPost]
        [ValidateAntiForgeryToken]//step1 to avoid cross site request forgery issue.
        [Authorize(Roles = "admin")]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Add<Restaurant>(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        //
        // GET: /Restaurant/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Restaurant restaurant = db.Query<Restaurant>().Single(r=> r.Id == id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //
        // POST: /Restaurant/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Update<Restaurant>(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        //
        // GET: /Restaurant/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Restaurant restaurant = db.Query<Restaurant>().Single(r=> r.Id == id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //
        // POST: /Restaurant/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Query<Restaurant>().Single(r=> r.Id == id);
            db.Remove<Restaurant>(restaurant);
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