using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFoodExercise.Models
{// this class combined too much stuff together, the restaurant name,the reviews
    // we need seperate these in two diffrent classes and form a relationship between them.
    public class RestaurantReview
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Body { get; set; }
        public string Reviewer { get; set; }
        public int RestaurantId { get; set; }// add to restaurant id here will help to create
        //the relationship between the reviews and the restaurant


    }
}