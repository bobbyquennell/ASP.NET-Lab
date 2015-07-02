using GPA.Domain.Entities;
using GPA.Domain.Repositories;
using GPA.Web.Models.Learner;
using GPA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPA.Web.Controllers
{
    public class StudentController : Controller
    {
        private IRepository _repo = new EfRepository();
        // GET: Student
        public ActionResult Index(int id)
        {
            var viewModel = new StudentListViewModel();
            var model = _repo.GetById<Course>(id).Students.
                Select( stu => new StudentListViewModel{
                     Age = stu.Age,
                      Gpa = stu.Gpa,
                       StudentName = stu.Name
                });
            ViewBag.CourseName = _repo.GetById<Course>(id).Name;
            return PartialView("_PartialViewStudentList", model);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
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

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
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
