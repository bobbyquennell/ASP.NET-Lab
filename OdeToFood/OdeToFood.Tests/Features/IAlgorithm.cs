using OdeToFood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Tests.Features
{
    public interface IAlgorithm
    {
        int computeRating(IEnumerable<Review> reviews);
    }
}
