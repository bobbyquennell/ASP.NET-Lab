using System;
using NUnit.Framework;
using OdeToFood.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

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
    public class UnitTest1
    {
        [Test]
        public void Compute_Results_With_Two_Ratings()
        {
            //arrange 

            IEnumerable<Review> reviews = FakeRatings(new int[]{4, 6});
            var sut = new RatingCalculator(reviews);

            //act
            var result = sut.ComputeAverageRating();
            //assert
            Assert.That(result, Is.EqualTo(5));
        }
        [Test]
        public void Should_Return_8_When_Input_4_ratings()
        {
            //arrange 
            
            IEnumerable<Review> reviews = FakeRatings(new int[]{10, 6, 7, 9});
            var sut = new RatingCalculator(reviews);
            //act
            var result = sut.ComputeAverageRating();
            //assert
            Assert.That(result, Is.EqualTo(8));
        }
        [Test]
        public void Weighted_Average_Rating_With_2_ratings()
        {
            //arrange 

            IEnumerable<Review> reviews = FakeRatings(new int[] { 10, 4});
            var sut = new RatingCalculator(reviews);
            //act
            var result = sut.WeightedComputeRating();
            //assert
            Assert.That(result, Is.EqualTo(8));
        }
        public IEnumerable<Review> FakeRatings(params int[] ratings)
        {
            new List<Review>(new List<Review>{
                new Review(){ Rating = 4 },
                new Review(){ Rating = 6 }
            });
            var result = ratings.Select(r => new Review { Rating = r });
            return result;
        }
    }
}
