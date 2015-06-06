using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuantumITSchoolGPA.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Surname]
        [NameLength(2,3)]
        public string Name { get; set; }
        public int Age { get; set; }
        public float GPA { get; set; }
        public int ClassId { get; set; }
    }
}