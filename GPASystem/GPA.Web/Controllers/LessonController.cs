using GPA.Domain.Entities;
using GPA.Domain.Repositories;
using GPA.Web.Models.Lesson;
using GPA.Web.Modelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPA.Web.Controllers
{
    public class LessonController : Controller
    {
        private IRepository _repo = new EfRepository();
        // GET: Lesson
        public ActionResult Index()
        {
            return View();
        }

        // GET: Lesson/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lesson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lesson/Create
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
        // GET: Lesson/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new LessonEditViewModel();
            var courseToEdit = _repo.GetById<Course>(id);
            model.CourseName = courseToEdit.Name;
            model.Location = courseToEdit.Location;
            model.TeacherName = courseToEdit.TeacherName;
            return View(model);
        }

        // POST: Lesson/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LessonEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                var courseToEdit = _repo.GetById<Course>(id);
                courseToEdit.Name =  model.CourseName;
                courseToEdit.Location = model.Location;
                courseToEdit.TeacherName = model.TeacherName;
                _repo.Update<Course>(courseToEdit);
                _repo.SaveChanges();

                return RedirectToAction("Index","Home",null);
            }
            else
            {
                return View();
            }
        }

        // GET: Lesson/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lesson/Delete/5
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
