using OdeToFoodExercise.Models;
using System;
using System.Collections.Generic;
namespace OdeToFood.Tests.Features
{
    public interface IRatingAlgorithm
    {
        RatingResult ComputeRating(IEnumerable<RestaurantReview> reviews);
    }
}
