using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFoodExercise.Models;
using System.Collections.Generic;
using System.Linq;
/*
 * A restaurant's overall rating can be calculated using various methods
 * For this application we'll want to try different methods over time,
 * but for starters we'll allow an administrator to toggle between two
 * different techiniques.
 * 
 * 1. Simple mean of the "rating" value for the most recent n reviews
 *    (the admin can configure the value n).
 * 2. Weighted mean of the last n reviews. The most recent n/2 reviews
 *   will be weighted twice as much and the oldest n/2 reviews.
 *   
 * Overall rating should be a whole number.
 */
namespace OdeToFood.Tests.Features
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Computes_Result_With_One_Review()
        {
            var model = BuildRestaurantAndReviews(new int[] { 4 });

            var rater = new RestaurantRater(model);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(4, result.Rating);
        }
        [TestMethod]
        public void Computes_Result_With_Two_Reviews()
        {
            var model = BuildRestaurantAndReviews(new int[]{4,8});
            var rater = new RestaurantRater(model);

            RatingResult result = rater.ComputeRating(10);

            Assert.AreEqual(6, result.Rating);

        }

        private Restaurant BuildRestaurantAndReviews(params int[] ratings)
        {
            Restaurant rest = new Restaurant();
            rest.Reviews = ratings.Select(r => new RestaurantReview { Rating = r }).ToList();
            return rest;
        }
    }
}
