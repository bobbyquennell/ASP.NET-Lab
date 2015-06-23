using GPA.Domain;
using GPASystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPASystem.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // return list of courses
            EfGPARepository _GpaRepo = new EfGPARepository();
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
