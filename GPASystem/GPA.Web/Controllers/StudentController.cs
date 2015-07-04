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
            var viewModel = new StudentIndexViewModel();
            var model = _repo.GetById<Course>(id).Students.
                Select( stu => new StudentListViewModel{
                     Age = stu.Age,
                      Gpa = stu.Gpa,
                       StudentName = stu.Name,
                       Id = stu.Id
                });
            viewModel.CourseId = id;
            viewModel.Students = model;
            ViewBag.CourseName = _repo.GetById<Course>(id).Name;
            return PartialView("_PartialViewStudentList", viewModel);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create(int id)
        {
            var model = new StudentEditViewModel();

            return View(model);
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(int id, StudentEditViewModel ViewModel)
        {
            if(ModelState.IsValid)
            {
                var model = new Student();
                model.Age = ViewModel.Age;
                model.Name = ViewModel.StudentName;
                model.Gpa = ViewModel.Gpa;
                model.CourseId = id;
                _repo.Add<Student>(model);

                return RedirectToAction("Index","Home",null);
            }
            else
            {
                return View(ViewModel);
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var ViewModel = new StudentEditViewModel();
            var model = _repo.GetById<Student>(id);
            ViewModel.Gpa = model.Gpa;
            ViewModel.Age = model.Age;
            ViewModel.StudentName = model.Name;
            return View(ViewModel);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentEditViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var model = _repo.GetById<Student>(id);
                model.Name = viewModel.StudentName;
                model.Age = viewModel.Age;
                model.Gpa = viewModel.Gpa;
                _repo.Update<Student>(model);
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View(viewModel);
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _repo.GetById<Student>(id);
            var ViewModel = new StudentDeleteViewModel();
            ViewModel.Gpa = model.Gpa;
            ViewModel.StudentName = model.Name;
            ViewModel.Age = model.Age;
            return View(ViewModel);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, StudentDeleteViewModel ViewModel)
        {
            try
            {
                var model = _repo.GetById<Student>(id);
                _repo.Delete<Student>(model);

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View(ViewModel);
            }
        }
    }
}
