namespace QuantumITSchoolGPA.Migrations
{
    using QuantumITSchoolGPA.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<QuantumITSchoolGPA.Models.SchoolGpaDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(QuantumITSchoolGPA.Models.SchoolGpaDb context)
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
            context.Classes.AddOrUpdate(
                c => c.Name,
                new Class { Name="Biology", Location="Building 5 Room 201", TeacherName="Mr Robertson",
                             Students = new List<Student>
                                 {
                                     new Student{Name="David Jackson", Age=19, GPA=3.4f },
                                     new Student{Name="Peter Parker", Age=19, GPA=2.9f },
                                     new Student{Name="Robert Smith", Age=18, GPA=3.1f },
                                     new Student{Name="Rebecca Black", Age=19, GPA=2.1f }
                                 }},
                new Class { Name="English", Location="Building 3 Room 134", TeacherName="Miss Sanderson"}
                );
        }
    }
}
