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
        public int ComputeAverageRating(int numberOfReviews)
        {
            var SelectedReviews = _reviews.Take(numberOfReviews);
            int rating = (int)SelectedReviews.Average(r => r.Rating);
            return rating;
        }

        public int WeightedComputeRating(int numberOfReviews)
        {
            var SelectedReviews = _reviews.Take(numberOfReviews);
            int length = SelectedReviews.Count();
            int RatingSum = 0;

            for (int i = 0; i < length; i++)
            {
                if (i < length / 2)
                    RatingSum += SelectedReviews.ElementAt(i).Rating * 2;
                else
                    RatingSum += SelectedReviews.ElementAt(i).Rating;

            }
            return RatingSum / (length + length / 2);
        }
    }
}
