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

        // GET: Lesson/Create
        public ActionResult Create()
        {
            var model = new LessonEditViewModel();
            return View(model);
        }

        // POST: Lesson/Create
        [HttpPost]
        public ActionResult Create(LessonEditViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var model = new Course();
                model.Name = viewModel.CourseName;
                model.Location = viewModel.Location;
                model.TeacherName = viewModel.TeacherName;
                _repo.Add<Course>(model);

                return RedirectToAction("Index","Home", null);
            }
            else
            {
                return View(viewModel);
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
            var model = _repo.GetById<Course>(id);
            var viewModel = new LessonEditViewModel();
            viewModel.TeacherName = model.TeacherName;
            viewModel.Location = model.Location;
            viewModel.CourseName = model.Name;
            return View(viewModel);
        }

        // POST: Lesson/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LessonEditViewModel viewModel)
        {
            try
            {
                var model = _repo.GetById<Course>(id);
                _repo.Delete<Course>(model);
                return RedirectToAction("Index","Home",null);
            }
            catch
            {
                return View(viewModel);
            }
        }
    }
}
