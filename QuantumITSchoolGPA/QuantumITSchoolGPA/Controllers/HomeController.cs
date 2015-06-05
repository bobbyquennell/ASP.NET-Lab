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

    }
}
