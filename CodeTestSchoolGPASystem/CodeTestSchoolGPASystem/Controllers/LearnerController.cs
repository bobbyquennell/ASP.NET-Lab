using GPA.Domain.Entities;
using GPASystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPASystem.Web.Controllers
{
    public class LearnerController : Controller
    {
        EfGPARepository _GpaRepo = new EfGPARepository();
        //
        // GET: /Learner/

        public ActionResult Index(int id)
        {
            var model = _GpaRepo.GetAll<Course>().Single(c => c.Id == id);

            return View();
        }

        //
        // GET: /Learner/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Learner/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Learner/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Learner/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Learner/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Learner/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Learner/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
