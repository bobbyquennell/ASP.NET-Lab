using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFoodExercise.Models;
using System.Data;

namespace OdeToFoodExercise.Controllers
{
    
    public class ReviewsController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();
        //
        // GET: /Reviews/
        //[ChildActionOnly]//ChildActionOnly action filter will prohibit call the action with url in the browser
        //public ActionResult BestReviewRestaurant()
        //{
        //    var restaurants = from r in _reviews
        //                      orderby r.Rating descending
        //                      select r;
        //    return PartialView("_Review", restaurants.First());
        //}
        public ActionResult Index(/*int id*/[Bind(Prefix="id") ]int restaurantId)
            //this id parameter represent a id of a restaurant not a review id, 
            //and this is a little bit confusing. To fix this, we got 3 approaches, the quickest way is to 
            //use a "Bind" attribute
        {
            //using LinQ to grab some in-memory static data for the view:
            //var model = from r in _db.Restaurants
            //            where r.Id == restaurantId
            //            select r;
            var model = _db.Restaurants.Find(restaurantId);
            if (model != null)
            {
                return View(model);
            }
            else
                return HttpNotFound();
            
        }
        [HttpGet]
        public ActionResult Create(int restaurantId)// the input parameter must match the Html.ActionLink's routeValue exactly
        {
            var restaurant_id = restaurantId;
            var model = _db.Restaurants.Find(restaurantId);
            return View();
        }
        [HttpPost]
        public ActionResult Create(RestaurantReview review)// the model binder will instansize that type 
            // and look through all the properties to see if it can match up something in the request.
        {
            if (ModelState.IsValid)
            {
                //if validation is done, save the new review to the database
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View();
        }

        public ActionResult edit([Bind(Prefix = "id")]int reviewId)
        {
            RestaurantReview review = _db.Reviews.Find(reviewId);
            return View(review);
        }
        [HttpPost]
        public ActionResult edit(RestaurantReview review)
        {
            //the model binder will still populate the review object with things that find in the request
            //so,again, we don't have to look in the query strings and post the form values ourself.
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        //
        // GET: /Reviews/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        ////
        //// GET: /Reviews/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Reviews/Create

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /Reviews/Edit/5

        //public ActionResult Edit(int id)
        //{
        //    var review = _reviews.Single(r => r.Id == id);


        //    return View(review);
        //}

        ////
        //// POST: /Reviews/Edit/5

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{

        //    var review = _reviews.Single(r => r.Id == id);
        //    if (TryUpdateModel(review))
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(review);
        //}

        ////
        //// GET: /Reviews/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Reviews/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        //add some in-memory data here to work with, so we don't focus on data access, and we can focus on views right now
        // using a static list with example data：
        //static List<RestaurantReview> _reviews = new List<RestaurantReview>
        //{
        //    new RestaurantReview{
        //        Id = 1,
        //        Name = "Cinnamon Club",
        //        City = "Melbourne",
        //        Country = "Australia",
        //        Rating = 10,
        //    },
        //    new RestaurantReview{
        //        Id = 2,
        //        Name = "Cinnamon Club2",
        //        //City = "Melbourne",
        //        City = "<script>alert('this is a cross-site scripting attack');</script>",//to demonstrate the cross-site scripting attack
        //        Country = "Australia",
        //        Rating = 10,
        //    },
        //    new RestaurantReview{
        //        Id = 3,
        //        Name = "Cinnamon Club3",
        //        City = "Melbourne",
        //        Country = "Australia",
        //        Rating = 10,
        //    },
        //    new RestaurantReview{
        //        Id = 4,
        //        Name = "Cinnamon Club4",
        //        City = "Melbourne",
        //        Country = "Australia",
        //        Rating = 10,
        //    },
        //};

    }
}
