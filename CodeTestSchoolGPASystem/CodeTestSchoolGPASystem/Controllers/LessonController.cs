using GPA.Domain.Entities;
using GPASystem.Web.Models;
using GPASystem.Web.Models.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPASystem.Web.Controllers
{
    public class LessonController : Controller
    {
        private EfGPARepository _GpaRepo = new EfGPARepository();
        public ActionResult Create()
        {
            var viewModel = new LessonEditViewModel();
            return View(viewModel);
        }
        // GET: /Course/Edit/5

        public ActionResult Edit(int id)
        {
            //get a course model from the repo and put it to the view back
            LessonEditViewModel viewModel = new LessonEditViewModel();
            var model = _GpaRepo.GetAll<Course>().Single(c=> c.Id==id);
            viewModel.CourseName = model.Name;
            viewModel.Location = model.Location;
            viewModel.TeacherName = model.TeacherName;
            return View(viewModel);
        }

        //
        // POST: /Course/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, LessonEditViewModel LessonToEdit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = _GpaRepo.GetAll<Course>().Single(c => c.Id == id);
                    model.Name = LessonToEdit.CourseName;
                    model.Location = LessonToEdit.Location;
                    model.TeacherName = LessonToEdit.TeacherName;
                    _GpaRepo.Update<Course>(model);
                    _GpaRepo.SaveChanges();
                }

                return RedirectToAction("Index","Home",null);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Course/Delete/5

        public ActionResult Delete(int id)
        {
            //get a course model from the repo and put it to the view back
            LessonEditViewModel viewModel = new LessonEditViewModel();
            var model = _GpaRepo.GetAll<Course>().Single(c => c.Id == id);
            viewModel.CourseName = model.Name;
            viewModel.Location = model.Location;
            viewModel.TeacherName = model.TeacherName;
            return View(viewModel);
        }

        //
        // POST: /Course/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var model = _GpaRepo.GetAll<Course>().Single(c => c.Id == id);
                _GpaRepo.Delete<Course>(model);
                _GpaRepo.SaveChanges();
                return RedirectToAction("Index","Home",null);
            }
            catch
            {
                return View();
            }
        }
    }
}
