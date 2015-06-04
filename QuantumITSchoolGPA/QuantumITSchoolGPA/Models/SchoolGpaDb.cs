using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace QuantumITSchoolGPA.Models
{
    public class SchoolGpaDb:DbContext
    {
        public SchoolGpaDb() : base("name=QuantumITSchoolGPA") { }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}