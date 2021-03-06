﻿using System;
using NUnit.Framework;
using OdeToFood.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Domain.Features;

/*
* A restaurant's overall rating can be calculated using various methods
* For this application we'll want to try different methods over time,
* but for starters we'll allow an administrator to toggle between two
* different techiniques.
* 
* 1. Simple mean of the "rating" value for the most recent n reviews
* (the admin can configure the value n).
* 2. Weighted mean of the last n reviews. The most recent n/2 reviews
* will be weighted twice as much and the oldest n/2 reviews.
* 
* Overall rating should be a whole number.
*/
namespace OdeToFood.Tests.Features
{
    [TestFixture]
    public class RatingCalculatorTest
    {
        [Test]
        public void Simple_Compute_With_Two_Ratings()
        {
            //arrange 

            IEnumerable<Review> reviews = FakeRatings(new int[]{4, 6});
            SimpleAlgorithm alg = new SimpleAlgorithm();
            var sut = new RatingCalculator(alg,reviews);

            //act
            var result = sut.ComputeRating(10);
            //assert
            Assert.That(result, Is.EqualTo(5));
        }
        [Test]
        public void Simple_Compute_With_4_ratings()
        {
            //arrange 
            
            IEnumerable<Review> reviews = FakeRatings(new int[]{10, 6, 7, 9});
            SimpleAlgorithm alg = new SimpleAlgorithm();
            var sut = new RatingCalculator(alg, reviews);
            //act
            var result = sut.ComputeRating(10);
            //assert
            Assert.That(result, Is.EqualTo(8));
        }
        [Test]
        public void Weighted_Average_Rating_With_2_ratings()
        {
            //arrange 

            IEnumerable<Review> reviews = FakeRatings(new int[] { 10, 4});
            WeightedAlgorithm alg = new WeightedAlgorithm();
            var sut = new RatingCalculator(alg, reviews);
            //act
            var result = sut.ComputeRating(10);
            //assert
            Assert.That(result, Is.EqualTo(8));
        }
        [Test]
        public void Weighted_Average_Rating_With_4_ratings()
        {
            //arrange 

            IEnumerable<Review> reviews = FakeRatings(new int[] { 10, 4,3,5 });
            WeightedAlgorithm alg = new WeightedAlgorithm();

            var sut = new RatingCalculator(alg, reviews);
            //act
            var result = sut.ComputeRating(10);
            //assert
            Assert.That(result, Is.EqualTo(6));
        }
        [Test]
        public void Should_Weighted_Rating_the_First_4_ratings()
        {
            //arrange 

            IEnumerable<Review> reviews = FakeRatings(new int[] { 10, 4, 3, 5,3,3,3,3 });
            WeightedAlgorithm alg = new WeightedAlgorithm();
            var sut = new RatingCalculator(alg, reviews);
            //act
            var result = sut.ComputeRating(4);
            //assert
            Assert.That(result, Is.EqualTo(6));
        }
        [Test]
        public void Should_Simple_Rating_the_First_4_ratings()
        {
            //arrange 

            IEnumerable<Review> reviews = FakeRatings(new int[] { 3,3,3,3, 10, 4, 3, 5 });
            SimpleAlgorithm alg = new SimpleAlgorithm();
            var sut = new RatingCalculator(alg, reviews);
            //act
            var result = sut.ComputeRating(4);
            //assert
            Assert.That(result, Is.EqualTo(3));
        }
        public IEnumerable<Review> FakeRatings(params int[] ratings)
        {
            var result = ratings.Select(r => new Review { Rating = r });
            return result;
        }
    }
}
