using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OdeToFoodExercise.Models
{
    // we also need to add this class for EF to retrieve our data,
    //and this class need to derived from a EF class named--DbContext
    public class OdeToFoodDb:DbContext, IOdeToFoodDataSource
    {
        public OdeToFoodDb() : base("name=OdeTOFoodDb") { }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();//The Set<T>() method is derived from base class: DbContext
        }
    }
}