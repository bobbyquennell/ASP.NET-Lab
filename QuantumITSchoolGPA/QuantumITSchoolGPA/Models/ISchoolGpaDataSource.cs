﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuantumITSchoolGPA.Models
{
    public interface ISchoolGpaDataSource:IDisposable
    {
         //IQueryable<Class> Classes { get; }
         //IQueryable<Student> Students { get; }
        IQueryable<T> Query<T>() where T : class;
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Remove<T>(T entity) where T : class;
         void SaveChanges();

    }
}