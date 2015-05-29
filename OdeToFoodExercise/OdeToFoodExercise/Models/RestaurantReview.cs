using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFoodExercise.Models
{// this class combined too much stuff together, the restaurant name,the reviews
    // we need seperate these in two diffrent classes and form a relationship between them.
    public class RestaurantReview
    {
        public int Id { get; set; }
        [Range(1,10)]
        [Required]
        public int Rating { get; set; }
        [Required]
        [StringLength(1024)]
        public string Body { get; set; }
        [Display(Name=" User Name")]
        [DisplayFormat(NullDisplayText="anonymous")]
        public string Reviewer { get; set; }
        public int RestaurantId { get; set; }// add to restaurant id here will help to create
        //the relationship between the reviews and the restaurant


    }
}