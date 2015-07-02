namespace GPA.Web.Migrations
{
    using GPA.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GPA.Web.Models.EfRepository>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GPA.Web.Models.EfRepository context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Courses.AddOrUpdate(
                c => c.Name,
                new Course
                {
                    Name = "Biology",
                    Location = "Building2 Room301",
                    TeacherName = "Bobby Wang",
                    Students = new List<Student>() { 
                        new Student{ Name = "Tonny Albert", Age = 18, Gpa = 3.5},
                        new Student{Name = "Barack Obama", Age = 19, Gpa = 3.1},
                        new Student{ Name = "Xi Jinping", Age = 59, Gpa = 2.1},
                        new Student{ Name = "Levi Lee", Age = 18, Gpa = 3.0}
                    }
                },
                new Course
                {
                    Name = "English",
                    Location = "Building1 Room201",
                    TeacherName = "Tom Cruise",
                    Students = new List<Student>() { 
                        new Student{ Name = "Tonny Obama", Age = 18, Gpa = 3.5},
                        new Student{Name = "Barack Albert", Age = 19, Gpa = 3.1},
                        new Student{ Name = "Peng Liyuan", Age = 59, Gpa = 2.1},
                        new Student{ Name = "Zhu Rongji", Age = 18, Gpa = 3.0}
                    }
                }
            );
        }
    }
}
