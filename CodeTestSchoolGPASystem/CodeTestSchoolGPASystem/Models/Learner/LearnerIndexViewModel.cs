using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GPA.Domain.Entities;

namespace GPASystem.Web.Models.Learner
{
    public class LearnerIndexViewModel
    {
        public ICollection<Student> Students { get; set; }
        public string CourseName { get; set; }
    }
}