using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFoodExercise.Controllers
{
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/

        public ActionResult Search(string name = "French")
        {   
             
            //var name = RouteData.Values["name"];
            //var message = String.Format("the parameter is: {0}", name);
            //return View();
            var encodedMessage = Server.HtmlEncode(name);
            //return Content(encodedMessage);
           // return RedirectPermanent("http://www.sina.com.cn");
            //return RedirectToRoute("Default", new { controller = "Home", action = "About" });
            //return RedirectToAction("About", "Home" ,new { name = name});
            //return File(Server.MapPath("~/Content/site.css"), "text/css");
            return Json(new { Message = encodedMessage, Name = "Bobby" }, JsonRequestBehavior.AllowGet);
        }

    }
}
