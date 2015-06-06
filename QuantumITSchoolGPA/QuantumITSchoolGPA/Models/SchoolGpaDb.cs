using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace QuantumITSchoolGPA.Models
{
    //public interface ISchoolGpaDb : IDisposable
    //{
    //    IQueryable<T> Query<T>() where T : class;
    //}
    public class SchoolGpaDb:DbContext, ISchoolGpaDataSource//, ISchoolGpaDb
    {
        public SchoolGpaDb() : base("name=QuantumITSchoolGPA") { }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }

        //IQueryable<T> ISchoolGpaDb.Query<T>()
        //{
        //    return Set<T>();
        //}

        //IQueryable<Class> ISchoolGpaDataSource.Classes
        //{
        //    get { return Classes; }
        //}

        //IQueryable<Student> ISchoolGpaDataSource.Students
        //{
        //    get { return Students; }
        //}



        IQueryable<T> ISchoolGpaDataSource.Query<T>()
        {
            return Set<T>();
        }

        void ISchoolGpaDataSource.Add<T>(T entity)
        {
            Set<T>().Add(entity);
        }

        void ISchoolGpaDataSource.Update<T>(T entity)
        {
            Entry(entity).State = System.Data.EntityState.Modified;
        }

        void ISchoolGpaDataSource.Remove<T>(T entity)
        {
            Set<T>().Remove(entity);
        }

        void ISchoolGpaDataSource.SaveChanges()
        {
            SaveChanges();
        }

        //void IDisposable.Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}