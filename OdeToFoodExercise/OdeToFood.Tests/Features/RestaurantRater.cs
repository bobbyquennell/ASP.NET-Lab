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

        public RestaurantRater(Restaurant restaurant)
        {
            this._restaurant = restaurant;
        }
        public RatingResult ComputeRating(int NumberOfReviews)
        {
            var result = new RatingResult();
            result.Rating = (int)_restaurant.Reviews.Average(r => r.Rating);
            return result;
        }

        internal RatingResult ComputeRatingWeighted(int p)
        {

            RatingResult result = new RatingResult();
            int sumValue = 0;
            int sumWeight = 0;
            for (int i = 0; i < _restaurant.Reviews.Count; i++)
            {
                if (i < _restaurant.Reviews.Count/2)
	            {
                    sumValue += _restaurant.Reviews.ElementAt(i).Rating * 2;
                    sumWeight += 2;
	            }
                else
                {
                    sumValue += _restaurant.Reviews.ElementAt(i).Rating;
                    sumWeight += 1;
                }
                
            }

            result.Rating = sumValue / sumWeight;
            return result;
        }
    }
}
