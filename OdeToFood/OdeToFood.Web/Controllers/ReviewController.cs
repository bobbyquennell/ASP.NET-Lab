using OdeToFood.Domain.Entities;
using OdeToFood.Domain.Repositories;
using OdeToFood.Web.Models;
using OdeToFood.Web.Models.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class ReviewController : Controller
    {
        IRepository _repo = new EfRepository();
        // GET: Review
        public ActionResult Index(int id)
        {
            var model = _repo.GetAll<Review>().Where(r => r.RestaurantId == id)
                .Select(r => new ReviewViewModel
                {
                      Comments = r.Comment, Rating = r.Rating, Reviewer = r.Reviewer, Id = r.Id
                });
            var viewModel = new ReviewIndexViewModel();
            viewModel.RestaurantId = id;
            viewModel.Reviews = model;
            ViewBag.RestaurantName = _repo.GetById<Restaurant>(id).Name;
            return View(viewModel);
        }

        // GET: Review/Create
        public ActionResult Create(int RestaurantId)
        {
            
            return View(new ReviewEditViewModel());
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(int RestaurantId, ReviewEditViewModel ViewModel)
        {
            if(ModelState.IsValid)
            {
                var model = new Review();
                model.RestaurantId = RestaurantId;
                model.Reviewer = ViewModel.Reviewer;
                model.Rating = ViewModel.Rating;
                model.Comment = ViewModel.Comments;
                _repo.Add<Review>(model);

                return RedirectToAction("Index", new { id = RestaurantId });
            }
            else
            {
                return View(ViewModel);
            }
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int ReviewId)
        {
            var model = _repo.GetById<Review>(ReviewId);
            var ViewModel = new ReviewEditViewModel();
            ViewModel.Comments = model.Comment;
            ViewModel.Rating = model.Rating;
            ViewModel.Reviewer = model.Reviewer;
            return View(ViewModel);
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult Edit(int ReviewId, ReviewEditViewModel ViewModel)
        {
            if(ModelState.IsValid)
            {
                var model = _repo.GetById<Review>(ReviewId);
                model.Rating = ViewModel.Rating;
                model.Reviewer = ViewModel.Reviewer;
                model.Comment = ViewModel.Comments;
                _repo.Update<Review>(model);
                return RedirectToAction("Index", new { id = model.RestaurantId });
            }
            else
            {
                return View(ViewModel);
            }
        }


    }
}
