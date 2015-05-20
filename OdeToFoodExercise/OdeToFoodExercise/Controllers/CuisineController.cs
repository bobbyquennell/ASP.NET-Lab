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
            return Content(encodedMessage);
        }

    }
}
