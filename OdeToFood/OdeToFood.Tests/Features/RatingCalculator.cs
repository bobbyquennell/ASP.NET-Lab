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
        public RatingCalculator(IEnumerable<Review> reviews)
        {
            _reviews = reviews;
        }
        public int ComputeAverageRating()
        {
            int rating =(int) _reviews.Average(r => r.Rating);
            return rating;
        }

        public int WeightedComputeRating()
        {
            throw new NotImplementedException();
        }
    }
}
