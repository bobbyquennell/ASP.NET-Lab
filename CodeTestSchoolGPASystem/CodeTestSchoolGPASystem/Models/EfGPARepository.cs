using GPA.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GPA.Domain.Entities;

namespace GPASystem.Web.Models
{
    public class EfGPARepository:DbContext, IRepository
    {
        public EfGPARepository() : base("name = EfGPARepository") { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
           Set<TEntity>().Add(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = System.Data.EntityState.Modified;
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            Set<TEntity>().Remove(entity);
        }

        public new void SaveChanges()
        {
            SaveChanges();
        }
    }
}