using eManager.Domain;
using eManager.Web.Infrasructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDepartmentDataSource _db;
       // private IDepartmentDataSource _db = new DepartmentDb(); 
        //if you want the controller only knows about the IDepartmentDataSource,remove the hard code dependency above,
        //define a new contructor like this:
        public HomeController(IDepartmentDataSource db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            var AllDepartments = _db.Departments;
            return View(AllDepartments);
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
