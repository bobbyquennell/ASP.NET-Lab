using QuantumITSchoolGPA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuantumITSchoolGPA.Controllers
{
    public class HomeController : Controller
    {
        SchoolGpaDb _db = new SchoolGpaDb();
        public ActionResult Index()
        {
            var model = _db.Classes.ToList();

            return View(model);
        }
        public ActionResult ShowStudentList(int id =1)
        {
            Class myClass = _db.Classes.Find(id);
            return PartialView("_ShowStudentList", myClass.Students);

        }
        public ActionResult Details(int id = 0)
        {
            Class myclass = _db.Classes.Find(id);
            if (myclass == null)
            {
                return HttpNotFound();
            }
            return View(myclass);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
