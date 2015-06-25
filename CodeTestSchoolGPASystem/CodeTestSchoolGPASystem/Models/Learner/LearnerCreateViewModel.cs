using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPASystem.Web.Models.Learner
{
    public class LearnerCreateViewModel
    {
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public double GPA { get; set; }
    }
}