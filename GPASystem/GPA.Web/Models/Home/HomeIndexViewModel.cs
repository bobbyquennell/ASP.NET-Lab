using GPA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GPA.Web.Models.Home
{
    public class HomeIndexViewModel
    {
        public IList<Course> Courses { get; set; }
    }
}
