namespace GPASystem.Web.Migrations
{
    using GPA.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<GPASystem.Web.Models.EfGPARepository>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GPASystem.Web.Models.EfGPARepository context)
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
                    Location = "Building 5 Room 201",
                    TeacherName = "Mr Robertson",
                    Students = new List<Student>() { 
                         new Student(){ Name = "David Jackson", Age=19, Gpa= 3.4},
                         new Student(){ Name = "Peter Parker", Age= 19, Gpa = 2.9},
                         new Student(){Name="Robert Smith", Age=18, Gpa =3.1},
                         new Student(){Name="Rebecca Black", Age =19, Gpa=2.1}
                    }
                },
                new Course
                {
                    Name = "English",
                    Location = "Building 3 Room 134",
                    TeacherName = "Miss Sanderson",
                    Students = new List<Student>() { 
                        new Student(){ Name = "David Beckham", Age=19, Gpa= 3.4},
                        new Student(){ Name = "Peter Obama", Age= 19, Gpa = 2.9},
                        new Student(){Name="Robert Merkel", Age=18, Gpa =3.1},
                        new Student(){Name="Rebecca Albert", Age =19, Gpa=2.1}
                    }
                }
            );
        }
    }
}
