using eManager.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using eManager.Web.Models;

namespace eManager.Web.Infrasructure
{
    //IdepartmentDataSource: I dont' want the controllers to know about the DepartmentDb directly,I want them to do data access through the interface defination
    // that just make the controller more testable, when I go into unit test in this modules, that makes them more decoulped and flexible.
    public class DepartmentDb:DbContext, IDepartmentDataSource
    {
        public DepartmentDb()
            : base("name=DepartmentDb")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        void IDepartmentDataSource.Save()
        {
            SaveChanges();
        }
        IQueryable<Employee> IDepartmentDataSource.Employees
        {
            get { return Employees; }
        }

        IQueryable<Department> IDepartmentDataSource.Departments
        {
            get { return Departments; }
        }

    }
}