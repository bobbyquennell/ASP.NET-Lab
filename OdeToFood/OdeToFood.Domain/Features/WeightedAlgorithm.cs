using OdeToFood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Domain.Features
{
    public class WeightedAlgorithm:IAlgorithm
    {
        //private IEnumerable<Review> _reviews;

        public int computeRating(IEnumerable<Review> reviews)
        {

            int length = reviews.Count();
            int RatingSum = 0;

            for (int i = 0; i < length; i++)
            {
                if (i < length / 2)
                    RatingSum += reviews.ElementAt(i).Rating * 2;
                else
                    RatingSum += reviews.ElementAt(i).Rating;

            }
            return RatingSum / (length + length / 2);
        }
    }
}
