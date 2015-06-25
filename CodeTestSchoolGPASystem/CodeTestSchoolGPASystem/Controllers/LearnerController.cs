using GPA.Domain.Entities;
using GPASystem.Web.Models;
using GPASystem.Web.Models.Learner;
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
            var viewModel = new LearnerIndexViewModel();
            viewModel.CourseName = model.Name;
            viewModel.Students = model.Students;
            viewModel.CourseId = model.Id;
            return PartialView("_IndexPartialView",viewModel);
        }
        //
        // GET: /Learner/Create

        public ActionResult Create(int id )
        {
            var course = _GpaRepo.GetAll<Course>().Single(c => c.Id == id);
            var model = new LearnerCreateViewModel();
            return View(model);
        }

        //
        // POST: /Learner/Create

        [HttpPost]
        public ActionResult Create(int id, LearnerCreateViewModel learnerToCreate)
        {
            try
            {
                var NewStudent = new Student();
                NewStudent.Name = learnerToCreate.StudentName;
                NewStudent.Age = learnerToCreate.StudentAge;
                NewStudent.Gpa = learnerToCreate.GPA;
                NewStudent.CourseId = id;

                _GpaRepo.Add<Student>(NewStudent);

                _GpaRepo.SaveChanges();
                return RedirectToAction("Index","Home",null);
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
            Student stu =_GpaRepo.GetAll<Student>().Single(s => s.Id == id);
            var StuViewModel = new LearnerCreateViewModel();
            StuViewModel.GPA = stu.Gpa;
            StuViewModel.StudentName = stu.Name;
            StuViewModel.StudentAge = stu.Age;
            return View(StuViewModel);
        }

        //
        // POST: /Learner/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, LearnerCreateViewModel studentToUpdate)
        {
            try
            {
                Student stu = _GpaRepo.GetAll<Student>().Single(s => s.Id == id);
                stu.Gpa = studentToUpdate.GPA;
                stu.Name = studentToUpdate.StudentName;
                stu.Age = studentToUpdate.StudentAge;
                _GpaRepo.Update<Student>(stu);
                _GpaRepo.SaveChanges();

                return RedirectToAction("Index","Home",null);
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
            Student stu = _GpaRepo.GetAll<Student>().Single(s => s.Id == id);
            var StuViewModel = new LearnerCreateViewModel();
            StuViewModel.GPA = stu.Gpa;
            StuViewModel.StudentName = stu.Name;
            StuViewModel.StudentAge = stu.Age;
            return View(StuViewModel);
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
