﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Gpa { get; set; }
        public int CourseId { get; set; }
    }
}
