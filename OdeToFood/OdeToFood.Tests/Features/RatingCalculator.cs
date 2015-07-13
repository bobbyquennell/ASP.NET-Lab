using OdeToFood.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Tests.Features
{
    public class RatingCalculator
    {
        IEnumerable<Review> _reviews;
        IAlgorithm _alg;
        public RatingCalculator(IAlgorithm alg, IEnumerable<Review> reviews)
        {
            _reviews = reviews;
            _alg = alg;
        }
        public int ComputeRating(int numberOfReviews)
        {
            return _alg.computeRating(_reviews.Take(numberOfReviews));
        }
    }
}
