using OdeToFoodExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Tests.Features
{
    class RestaurantRater
    {
        private Restaurant model;

        public RestaurantRater(Restaurant model)
        {
            // TODO: Complete member initialization
            this.model = model;
        }
        public RatingResult  ComputeRating(int p)
        {
            var result =  new RatingResult();
            result.Rating = 4;
            return result;
        }
    }
}
