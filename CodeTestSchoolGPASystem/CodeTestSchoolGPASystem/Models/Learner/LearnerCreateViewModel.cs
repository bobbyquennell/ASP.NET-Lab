using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GPASystem.Web.Models.Learner
{
    public class LearnerCreateViewModel
    {
        [Required]
        [Surname]
        public string StudentName { get; set; }
        [Required]
        public int StudentAge { get; set; }
        [Required]
        public double GPA { get; set; }
    }
}