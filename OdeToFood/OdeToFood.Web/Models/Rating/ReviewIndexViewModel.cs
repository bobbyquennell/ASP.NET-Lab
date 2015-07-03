using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Web.Models.Rating
{
    public class ReviewIndexViewModel
    {
        public int Rating { get; set; }
        public string Comments { get; set; }
        public string Reviewer { get; set; }
        public int Id { get; set; }
    }
}