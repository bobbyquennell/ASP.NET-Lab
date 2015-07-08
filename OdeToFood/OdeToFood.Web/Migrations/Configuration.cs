namespace OdeToFood.Web.Migrations
{
    using OdeToFood.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Web.Models.EfRepository>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OdeToFood.Web.Models.EfRepository context)
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
                new Restaurant
                {
                    Name = "Little Ramen Bar",
                    City = "Melbourne",
                    Country = "Australia",
                    Reviews = new List<Review>()
                    {
                       new Review{ Rating = 8, Comment = "Good but not perfect", Reviewer = "Bobby"},
                       new Review{ Rating = 9, Comment = "Best Ramen in the CBD", Reviewer = "Dandan"}
                    }
                },
                new Restaurant
                {
                    Name = "SiJiMinFu Peking Duck",
                    City = "Beijing",
                    Country = "China",
                    Reviews = new List<Review>()
                    {
                        new Review{ Rating = 10, Comment = "The best roast duck I have ever eaten", Reviewer = "Bobby"},
                        new Review{ Rating = 9, Comment = "Mouth watering", Reviewer = "Levi Bin Lee"}
                    }
                },
                new Restaurant
                {
                    Name = "HaiDiLao Hot Pot",
                    City = "Beijing",
                    Country = "China",
                    Reviews = new List<Review>()
                    {
                        new Review{ Rating = 10, Comment = "The service is second to none", Reviewer = "Bobby"},
                        new Review{ Rating = 9, Comment = "Soooooo yummy", Reviewer = "Levi Bin Lee"}
                    }
                }
               
            );
            for (int i = 0; i < 300; i++)
            {
                context.Restaurants.AddOrUpdate(
                    r => r.Name,
                    new Restaurant
                    {
                        Name = "Restaurant" + i,
                        City = "Melbourne",
                        Country = "Australia",
                        Reviews = new List<Review>()
                                    {
                                       new Review{ Rating = 8, Comment = "Good but not perfect", Reviewer = "Bobby"},
                                       new Review{ Rating = 9, Comment = "Best Ramen in the CBD", Reviewer = "Dandan"}
                                    }
                    }

                );
            }
        }
    }
}
