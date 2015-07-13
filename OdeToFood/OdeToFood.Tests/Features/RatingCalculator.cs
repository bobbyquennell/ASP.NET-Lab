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

        public int WeightedComputeRating(int numberOfReviews)
        {            
            int length = _reviews.Count();
            int RatingSum = 0;

            for (int i = 0; i < length; i++)
            {
                if (i < length / 2)
                    RatingSum += _reviews.ElementAt(i).Rating * 2;
                else
                    RatingSum += _reviews.ElementAt(i).Rating;

            }
            return RatingSum / (length + length / 2);
        }
    }
}
