using OdeToFood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Web.Models.Home
{
    public class HomeIndexViewModel
    {

        public IQueryable<Restaurant> RestaurantList { get; set; }
    }
    public class RestaurantListViewModel
    {
        public string RestaurantName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int ReviewNumber { get; set; }
    }
}
