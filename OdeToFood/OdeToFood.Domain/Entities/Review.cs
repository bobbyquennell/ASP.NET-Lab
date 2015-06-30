using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string Reviewer { get; set; }
        public int RestaurantId { get; set; }
    }
}
