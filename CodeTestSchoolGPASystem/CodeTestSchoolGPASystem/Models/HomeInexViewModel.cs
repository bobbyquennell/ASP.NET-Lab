using GPA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPASystem.Web.Models
{
    public class HomeIndexViewModel
    {
        public IList<Course> Courses { get; set; }
    }
}