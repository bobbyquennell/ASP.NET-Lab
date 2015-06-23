using GPA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPASystem.Web.Models.Home
{
    public class HomeIndexViewModel
    {
        public IList<Course> Courses { get; set; }
    }
}