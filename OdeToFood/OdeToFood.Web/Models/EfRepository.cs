using OdeToFood.Domain.Entities;
using OdeToFood.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace OdeToFood.Web.Models
{
    public class EfRepository: DbContext,IRepository
    {
        public EfRepository() : base("name= OdeToFoodEfRepo") { }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public IQueryable<T> GetAll<T>() where T : class
        {
            return Set<T>();
        }

        public T GetById<T>(int Id) where T : class
        {
            throw new NotImplementedException();
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        void IRepository.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
