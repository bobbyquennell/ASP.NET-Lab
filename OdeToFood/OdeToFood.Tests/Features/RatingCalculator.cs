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
        public int ComputeAverageRating(IEnumerable<Review> reviews)
        {
            int rating = 0;
            foreach (var review in reviews)
            {
                rating += review.Rating;
            }
            rating = rating / reviews.Count();
            return rating;
        }
    }
}
