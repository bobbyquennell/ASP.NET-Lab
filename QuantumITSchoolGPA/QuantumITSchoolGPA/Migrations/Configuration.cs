namespace QuantumITSchoolGPA.Migrations
{
    using QuantumITSchoolGPA.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuantumITSchoolGPA.Models.SchoolGpaDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(QuantumITSchoolGPA.Models.SchoolGpaDb context)
        {
            context.Classes.AddOrUpdate(
                            c => c.Name,
                            new Class
                            {
                                Name = "Biology",
                                Location = "Building 5 Room 201",
                                TeacherName = "Mr Robertson",
                                Students = new List<Student>
                                 {
                                     new Student{Name="David Jackson", Age=19, GPA=3.4f },
                                     new Student{Name="Peter Parker", Age=19, GPA=2.9f },
                                     new Student{Name="Robert Smith", Age=18, GPA=3.1f },
                                     new Student{Name="Rebecca Black", Age=19, GPA=2.1f }
                                 }
                            },
                            new Class
                            {
                                Name = "English",
                                Location = "Building 3 Room 134",
                                TeacherName = "Miss Sanderson",
                                Students = new List<Student>
                                         {
                                             new Student{Name="David Jason", Age=17, GPA=3.3f },
                                             new Student{Name="Peter Allen", Age=15, GPA=2.8f },
                                             new Student{Name="Robert King", Age=16, GPA=3.0f },
                                             new Student{Name="Rebecca White", Age=17, GPA=2.0f }
                                         }
                            }
                            );
        }
    }
}
