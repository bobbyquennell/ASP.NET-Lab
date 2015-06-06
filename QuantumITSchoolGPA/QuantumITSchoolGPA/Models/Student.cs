using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuantumITSchoolGPA.Models
{
    public class Student
    {
        public virtual int Id { get; set; }
        [Surname]
        [NameLength(2,3)]
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual float GPA { get; set; }
        public virtual int ClassId { get; set; }
    }
}