using OdeToFoodExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Tests.Features
{
    public class SimpleAverageRatingAlgorithm: IRatingAlgorithm
    {

        public RatingResult ComputeRating(IEnumerable<RestaurantReview> reviews)
        {
            var result = new RatingResult();
            result.Rating = (int)reviews.Average(r => r.Rating);
            return result;
        }
    }
}
