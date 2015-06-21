using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFoodExercise.Models;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
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
    [TestFixture]
    public class RatingAlgorithmTests
    {
        [Test]
        public void Computes_Result_With_One_Review()
        {
            var model = BuildRestaurantAndReviews(new int[] { 4 });
            var alg = new SimpleAverageRatingAlgorithm();

            var rater = new RestaurantRater(model, alg);
            /////above code could be abtract to a set up or something like that to reduce duplicated code
            var result = rater.Compute(10);

            Assert.That(result.Rating, Is.EqualTo(4));
        }
        [Test]
        public void Computes_Result_With_Two_Reviews()
        {
            var model = BuildRestaurantAndReviews(new int[]{4,8});
            var alg = new SimpleAverageRatingAlgorithm();
            var rater = new RestaurantRater(model, alg);

            RatingResult result = rater.Compute(10);

            Assert.That(result.Rating, Is.EqualTo(6));

        }
        [Test]
        public void Weighted_Average_With_Two_Reviews()
        {
            var model = BuildRestaurantAndReviews(new int[] { 3, 6 });
            var alg = new WeightedRatingAlgorithm();
            var rater = new RestaurantRater(model, alg);
            RatingResult result = rater.Compute(10);

            Assert.That(result.Rating, Is.EqualTo(4));
        }
        [Test]
        public void Weighted_Average_With_Four_Reviews()
        {
            var model = BuildRestaurantAndReviews(new int[] { 1,1,1,1,3,3,3,3 });
            var alg = new WeightedRatingAlgorithm();
            var rater = new RestaurantRater(model, alg);
            RatingResult result = rater.Compute(10);

            Assert.That(result.Rating, Is.EqualTo(1));
        }
        [Test]
        public void Should_Only_Rate_From_First_N_Reviews()
        {
            var model = BuildRestaurantAndReviews(new int[] { 1, 1, 1, 1, 3, 3, 3, 3 });
            var alg = new SimpleAverageRatingAlgorithm();
            var rater = new RestaurantRater(model, alg);
            RatingResult result = rater.Compute(4);

            Assert.That(result.Rating, Is.EqualTo(1));

        }
        private Restaurant BuildRestaurantAndReviews(params int[] ratings)
        {
            Restaurant rest = new Restaurant();
            rest.Reviews = ratings.Select(r => new RestaurantReview { Rating = r }).ToList();
            return rest;
        }
    }
}
