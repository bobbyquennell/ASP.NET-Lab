using OdeToFood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Domain.Features
{
    public class SimpleAlgorithm:IAlgorithm
    {
        //IEnumerable<Review> _reviews;
        public int computeRating(IEnumerable<Review> reviews)
        {
            int rating = (int)reviews.Average(r => r.Rating);
            return rating;
        }
    }
}
