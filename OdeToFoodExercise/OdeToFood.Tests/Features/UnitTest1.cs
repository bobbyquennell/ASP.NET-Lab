using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFoodExercise.Models;
using System.Collections.Generic;
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
        public void TestMethod1()
        {
            var model = new Restaurant();
            model.Reviews = new List<RestaurantReview>();
            model.Reviews.Add(new RestaurantReview
            {
                Rating = 4
            });

            var rater = new RestaurantRater(model);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(4, result.Rating);
        }
    }
}
