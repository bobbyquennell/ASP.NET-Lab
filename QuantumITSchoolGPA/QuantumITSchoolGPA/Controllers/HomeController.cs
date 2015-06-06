using QuantumITSchoolGPA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace QuantumITSchoolGPA.Controllers
{
    public class HomeController : Controller
    {
        SchoolGpaDb _db = new SchoolGpaDb();
       // private ISchoolGpaDataSource _db;
        //public HomeController(ISchoolGpaDataSource db)
        //{
        //    _db = db;
        //}
        public ActionResult Index(int id =1)
        {
            
            var model = _db.Classes.ToList();

            return View(model);
        }
        [OutputCache(Location= OutputCacheLocation.None)]
        public ActionResult ShowStudentList(int id =1)
        {
            //Class myClass = _db.Classes.Find(id);
            Class myClass = (from item in _db.Classes
                          where item.Id == id
                          select item).SingleOrDefault();
            return PartialView("_ShowStudentList", myClass);

        }

    }
}
