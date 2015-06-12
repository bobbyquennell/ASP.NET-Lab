using OdeToFoodExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Tests.Features
{
    class RestaurantRater
    {
        private Restaurant _restaurant;
        private IRatingAlgorithm _alg;

        public RestaurantRater(Restaurant restaurant, IRatingAlgorithm alg)
        {
            this._restaurant = restaurant;
            this._alg = alg;
        }
        public RatingResult Compute(int NumberOfReviews)
        {
            return _alg.ComputeRating(_restaurant.Reviews.Take(NumberOfReviews));
        }


    }
}
