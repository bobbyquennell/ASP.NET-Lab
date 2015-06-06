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
    public class SchoolGpaDb:DbContext//, ISchoolGpaDb
    {
        public SchoolGpaDb() : base("name=QuantumITSchoolGPA") { }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }

        //IQueryable<T> ISchoolGpaDb.Query<T>()
        //{
        //    return Set<T>();
        //}
    }
}