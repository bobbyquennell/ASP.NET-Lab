using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFoodExercise.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        //any restaurant can have multiple associated reviews, we can put that in 
        //the ICollection:
        public ICollection<RestaurantReview> Reviews { get; set; }

    }
}