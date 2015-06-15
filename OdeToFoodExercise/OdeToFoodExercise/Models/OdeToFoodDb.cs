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




        public void Add<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            Entry(entity).State = System.Data.EntityState.Modified;
        }

        public void Remove<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
        }

        void IOdeToFoodDataSource.SaveChanges()
        {
            SaveChanges();
        }
    }
    
}