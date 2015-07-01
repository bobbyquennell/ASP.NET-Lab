using GPA.Domain.Entities;
using GPA.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace GPA.Web.Modelss
{
    public class EfRepository:DbContext,IRepository
    {
        public EfRepository() : base("name=GPADb") { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public IQueryable<T> GetAll<T>() where T : class
        {
            return Set<T>();
        }
        public T GetById<T>(int id) where T : class
        {
            return Set<T>().Find(id);
        }
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            Entry<T>(entity).State = EntityState.Modified;
            base.SaveChanges();
        }


        void IRepository.SaveChanges()
        {
            base.SaveChanges();
        }
        public void Delete<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
            base.SaveChanges();
        }

    }
}
