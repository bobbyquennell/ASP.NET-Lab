﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFoodExercise.Models;

namespace OdeToFoodExercise.Controllers
{
    public class ReviewsController : Controller
    {
        //
        // GET: /Reviews/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Reviews/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Reviews/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Reviews/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Reviews/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Reviews/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Reviews/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Reviews/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //add some in-memory data here to work with, so we don't focus on data access, and we can focus on views right now
        // using a static list with example data：
        static List<RestaurantReview> _reviews = new List<RestaurantReview>
        {
            new RestaurantReview{
                Id = 1,
                Name = "Cinnamon Club",
                City = "Melbourne",
                Country = "Australia",
                Rating = 10,
            },
            new RestaurantReview{
                Id = 1,
                Name = "Cinnamon Club2",
                City = "Melbourne",
                Country = "Australia",
                Rating = 10,
            },
            new RestaurantReview{
                Id = 1,
                Name = "Cinnamon Club3",
                City = "Melbourne",
                Country = "Australia",
                Rating = 10,
            },
            new RestaurantReview{
                Id = 1,
                Name = "Cinnamon Club4",
                City = "Melbourne",
                Country = "Australia",
                Rating = 10,
            },
        };

    }
}
