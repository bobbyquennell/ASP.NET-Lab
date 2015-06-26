using GPA.Domain.Entities;
using GPASystem.Web.Models.Home;
using GPASystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GPA.Domain.Repositories;

namespace GPASystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _GpaRepo;
        public HomeController()
        {
            _GpaRepo = new EfGPARepository();
        }
        public HomeController(IRepository repo)
        {
            _GpaRepo = repo;
        }
        public ActionResult Index()
        {
            // return list of courses
            //EfGPARepository _GpaRepo = new EfGPARepository();
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.Courses = _GpaRepo.GetAll<Course>().ToList();
            return View(model);
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your app description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}
