using OdeToFood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Web.Models.Home
{
    public class HomeIndexViewModel
    {
        public IQueryable<Restaurant> Restaurants { get; set; }
    }
}
