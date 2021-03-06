namespace OdeToFoodExercise.Migrations
{
    using OdeToFoodExercise.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFoodExercise.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OdeToFoodExercise.Models.OdeToFoodDb context)
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
            context.Restaurants.AddOrUpdate(
                r => r.Name,
                new Restaurant { Name="VietStar", City="Hawthorn", Country="Australia"},
                new Restaurant { Name="Grill'd", City="Hawthorn", Country="Australia"},
                new Restaurant { Name="ToroToro", City="Melbourne", Country="Australia",
                                 Reviews = new List<RestaurantReview>
                                 {
                                     new RestaurantReview{ Rating=9, Body="Very Yummy!", Reviewer="Bobby"}
                                 }
                }
            );
            //for (int loop = 0; loop < 333; loop++)
            //{
            //    context.Restaurants.AddOrUpdate(
            //    r => r.Name,
            //    new Restaurant { Name="VietStar"+loop, City="Hawthorn", Country="Australia"},
            //    new Restaurant { Name="Grill'd"+loop, City="Hawthorn", Country="Australia"},
            //    new Restaurant { Name="ToroToro"+loop, City="Melbourne", Country="Australia",
            //                     Reviews = new List<RestaurantReview>
            //                     {
            //                         new RestaurantReview{ Rating=9, Body="Very Yummy!", Reviewer="Bobby"}
            //                     }
            //                   }
            //);}
            seedMembership();

        }

        private void seedMembership()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("OdeToFoodDb", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            } 
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;
            if (!roles.RoleExists("admin"))
            {
                roles.CreateRole("admin");
            }
            if (membership.GetUser("bobby", false) == null)
            {
                membership.CreateUserAndAccount("bobby", "111111");
            }
            if (!roles.GetRolesForUser("bobby").Contains("admin"))
            {
                roles.AddUsersToRoles(new[] {"bobby"}, new[]{"admin"});
            }
        }
    }
}
