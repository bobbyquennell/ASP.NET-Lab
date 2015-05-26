using OdeToFoodExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFoodExercise.Controllers
{
    public class HomeController : Controller
    {
        //in order to show how to use the EF, suppose we want to show  restaurants from the database
        //in the home page.
           //First, before using the database, we instanciate the OdeToFoodDb firstly.
        OdeToFoodDb _db = new OdeToFoodDb();
        public ActionResult Index()
        {
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];
            var message = string.Format("route data is : {0}/{1}/{2}", controller, action, id);
            ViewBag.Message = message;
            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            //ViewBag.Location = "Maryland, USA";
            var model = new AboutModel();
            model.Name = "Bobby";
            model.Location = "Melbourne, Australia";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //second, this is a diposable resource, we should override Dispose method here
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
