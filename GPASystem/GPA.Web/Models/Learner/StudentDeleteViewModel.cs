﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPA.Web.Models.Learner
{
    public class StudentDeleteViewModel
    {
        public string StudentName { get; set; }
        public int Age { get; set; }
        public double Gpa { get; set; }
    }
}