using OdeToFood.Domain.Entities;
using OdeToFood.Domain.Repositories;
using OdeToFood.Web.Models;
using OdeToFood.Web.Models.Bristo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantController : Controller
    {
        private IRepository _repo = new EfRepository();
        // GET: Restaurant
        public ActionResult Index()
        {
            var model = _repo.GetAll<Restaurant>().OrderBy(r=>r.Name).Take(10)
                .Select(r => new RestaurantIndexViewModel
                    {
                         City = r.City,
                          Country = r.Country,
                           Restaurant = r.Name,
                            Id = r.Id
                           
                    }
                );
            return View(model);
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            var ViewModel = new RestaurantEditViewModel();
            return View(ViewModel);
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(RestaurantEditViewModel ViewModel)
        {
            if(ModelState.IsValid)
            {
                var model = new Restaurant();
                model.Name = ViewModel.Name;
                model.Country = ViewModel.Country;
                model.City = ViewModel.City;
                _repo.Add<Restaurant>(model);

                return RedirectToAction("Index");
            }
            else
            {
                return View(ViewModel);
            }
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            var ViewModel = new RestaurantEditViewModel();
            var model = _repo.GetById<Restaurant>(id);
            ViewModel.City = model.City;
            ViewModel.Country = model.Country;
            ViewModel.Name = model.Name;
            return View(ViewModel);
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RestaurantEditViewModel ViewModel)
        {
            if(ModelState.IsValid)
            {
                var model = _repo.GetById<Restaurant>(id);
                model.Name = ViewModel.Name;
                model.Country = ViewModel.Country;
                model.City = ViewModel.City;
                _repo.Update<Restaurant>(model);

                return RedirectToAction("Index");
            }
            else
            {
                return View(ViewModel);
            }
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            var ViewModel = new RestaurantEditViewModel();
            var model = _repo.GetById<Restaurant>(id);
            ViewModel.City = model.City;
            ViewModel.Country = model.Country;
            ViewModel.Name = model.Name;
            return View(ViewModel);
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RestaurantEditViewModel ViewModel)
        {
            try
            {
                var RestaurantToDelete = _repo.GetById<Restaurant>(id);
                _repo.Delete<Restaurant>(RestaurantToDelete);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(ViewModel);
            }
        }
    }
}
