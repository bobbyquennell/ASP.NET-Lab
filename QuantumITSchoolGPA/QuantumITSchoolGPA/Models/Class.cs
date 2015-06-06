using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuantumITSchoolGPA.Models
{
    public class Class
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Location { get; set; }
        [Required]
        public virtual string TeacherName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}