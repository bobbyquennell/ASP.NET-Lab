namespace OdeToFoodExercise.Migrations
{
    using OdeToFoodExercise.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFoodExercise.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
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
                                     new RestaurantReview{ Rating=9, Body="Very Yummy!"}
                                 }
                }
            );
        }
    }
}
