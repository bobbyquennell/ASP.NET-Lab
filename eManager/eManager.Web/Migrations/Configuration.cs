using System.Web.Security;
using WebMatrix.WebData;

namespace eManager.Web.Migrations
{
    using eManager.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eManager.Web.Infrasructure.DepartmentDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(eManager.Web.Infrasructure.DepartmentDb context)
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
            context.Departments.AddOrUpdate(
                d => d.Name,
                new Department()
                {
                    Name = "Engineering"
                },
                new Department()
                {
                    Name = "Sales"
                },
                new Department()
                {
                    Name = "Human Resources"
                },
                new Department()
                {
                    Name = "Shipping"
                });
            SeedMemebership();
        }

        private void SeedMemebership()
        {
            WebSecurity.InitializeDatabaseConnection("DepartmentDb", "UserProfile", "UserId", "UserName",
                autoCreateTables: true);
            var roles = (SimpleRoleProvider) Roles.Provider;
            var membership = (SimpleMembershipProvider) Membership.Provider;
            if (!Roles.RoleExists("admin"))
            {
                Roles.CreateRole("admin");
            }
            if (membership.GetUser("bobbyquennell", false) == null)
            {
                membership.CreateUserAndAccount("bobbyquennell", "1234567");
            }
            if (!roles.GetRolesForUser("bobbyquennell").Contains("admin"))
            {
                roles.AddUsersToRoles(new[] {"bobbyquennell"}, new[]
                {
                    "admin"
                });
            }
        }
    }
}
