using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuantumITSchoolGPA.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string TeacherName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}