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
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LessonEditViewModel viewModel = new LessonEditViewModel();
                    var model = _GpaRepo.GetAll<Course>().Single(c => c.Id == id);
                    model.Name = collection["CourseName"];
                    model.Location = collection["Location"];
                    model.TeacherName = collection["TeacherName"];
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
            return View();
        }

        //
        // POST: /Course/Delete/5

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
