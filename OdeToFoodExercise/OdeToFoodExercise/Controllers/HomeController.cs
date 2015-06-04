using OdeToFoodExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace OdeToFoodExercise.Controllers
{
    public class HomeController : Controller
    {
        //in order to show how to use the EF, suppose we want to show  restaurants from the database
        //in the home page.
        //First, before using the database, we instanciate the OdeToFoodDb firstly.
        OdeToFoodDb _db = new OdeToFoodDb();
        public ActionResult AutoComplete(string term)
        {
            //var result = from r in _db.Restaurants
            //             where r.Name.Contains(term)
            //             select new{
            //                r.Name
            //             };
            var result = _db.Restaurants.Where(restaurant => restaurant.Name.Contains(term))
                .Take(10).Select(r => new { label = r.Name, value = r.Name });
            return Json(result,"text/json",JsonRequestBehavior.AllowGet);
        }
        [ChildActionOnly]
        [OutputCache(Duration=20)]
        public ActionResult ChildActionSayHello()
        {
            return Content("Say Hello");
        }
        [OutputCache(Duration=10)]
        public ActionResult Index(string searchTerm = null, int pageNumber = 1)
        {
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];
            var message = string.Format("route data is : {0}/{1}/{2}", controller, action, id);
            ViewBag.Message = message;
            // this line of code below will go into the database, find all the restaurants
            //retrieve all of them and put them into a list.
            //var model = _db.Restaurants.ToList();
            //using LINQ comprehensive syntax expression to order restaurants in alphabetic order
            //var model = from r in _db.Restaurants
            //            orderby r.Reviews.Average(review => review.Rating) descending
            //            select new RestaurantListViewModel
            //            {
            //                Id = r.Id,
            //                Name = r.Name,
            //                City = r.City,
            //                Country = r.Country,
            //                CountOfReviews = r.Reviews.Count()
            //            };
            //besides the above method--comprehensive query syntax method,we can do it in the second way---extension method with 
            //Lamda expression.
            var model = _db.Restaurants.OrderByDescending(r => r.Reviews.Average(reviews => reviews.Rating))
                .Where(restaurant => searchTerm == null || restaurant.Name.StartsWith(searchTerm))
                //.Take(10)//some operaters like take and skip can be only used when using the extension syntax method.
                .Select(r => new RestaurantListViewModel
                            {
                                Id = r.Id,
                                Name = r.Name,
                                City = r.City,
                                Country = r.Country,
                                CountOfReviews = r.Reviews.Count()
                            }
                        ).ToPagedList(pageNumber, 10);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_PartialRestaurant", model);
            }
            return View(model);
        }

        [Authorize]//this action filter attribute will trigger an authentication action.
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
