using System;
using NUnit.Framework;
using OdeToFood.Domain.Entities;
using System.Collections.Generic;

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
        public void TestMethod1()
        {
            //arrange 
            var sut = new RatingCalculator();
            List<Review> reviews = new List<Review>(new List<Review>{
                new Review(){ Rating = 4 },
                new Review(){ Rating = 6 }
            });
            //act
            var result = sut.ComputeAverageRating(reviews);
            //assert
            Assert.That(result, Is.EqualTo(5));
        }
        [Test]
        public void Should_Return_8_When_Input_4_ratings()
        {
            //arrange 
            var sut = new RatingCalculator();
            List<Review> reviews = new List<Review>(new List<Review>{
                new Review(){ Rating = 10 },
                new Review(){ Rating = 6 },
                new Review(){ Rating = 7 },
                new Review(){ Rating = 9 }
            });
            //act
            var result = sut.ComputeAverageRating(reviews);
            //assert
            Assert.That(result, Is.EqualTo(8));
        }
    }
}
