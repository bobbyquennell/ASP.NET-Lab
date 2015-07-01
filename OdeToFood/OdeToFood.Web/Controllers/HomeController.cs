using OdeToFood.Domain.Entities;
using OdeToFood.Domain.Repositories;
using OdeToFood.Web.Models;
using OdeToFood.Web.Models.Home;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class HomeController : Controller
    {
        IRepository _repo = new EfRepository();
        public ActionResult Index()
        {
            var model = _repo.GetAll<Restaurant>()
                .Select(r => new RestaurantListViewModel
                {
                    City = r.City,
                    Country = r.Country,
                    RestaurantName = r.Name,
                    ReviewNumber = r.Reviews.Count
                });

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