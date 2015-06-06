using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuantumITSchoolGPA.Models
{
    public class Class
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string TeacherName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}