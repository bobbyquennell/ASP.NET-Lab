using GPA.Domain.Entities;
using GPA.Domain.Repositories;
using GPA.Web.Models.Home;
using GPA.Web.Modelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPA.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo = new EfRepository();
        public ActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.Courses = _repo.GetAll<Course>().ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}