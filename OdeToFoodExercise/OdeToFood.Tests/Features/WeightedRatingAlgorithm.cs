using OdeToFoodExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Tests.Features
{
    class WeightedRatingAlgorithm:IRatingAlgorithm
    {
        public RatingResult ComputeRating(IEnumerable<RestaurantReview> reviews)
        {
            RatingResult result = new RatingResult();
            int sumValue = 0;
            int sumWeight = 0;
            for (int i = 0; i < reviews.Count(); i++)
            {
                if (i < reviews.Count() / 2)
                {
                    sumValue += reviews.ElementAt(i).Rating * 2;
                    sumWeight += 2;
                }
                else
                {
                    sumValue += reviews.ElementAt(i).Rating;
                    sumWeight += 1;
                }

            }

            result.Rating = sumValue / sumWeight;
            return result;
        }
    }
}
