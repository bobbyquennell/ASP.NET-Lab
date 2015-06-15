﻿using OdeToFoodExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Tests
{
    class FakeOdeToFoodDb:IOdeToFoodDataSource
    {
        public IQueryable<T> Query<T>() where T : class
        {
            return Sets[typeof(T)] as IQueryable<T>;
        }

        public void Dispose(){}
        public void  AddSets<T>(IQueryable<T> objects){
            Sets.Add(typeof(T), objects);
        }

        public void Add<T>(T entity) where T : class
        {
            Added.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            Updated.Add(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            Added.Add(entity);
        }

        public void SaveChanges()
        {
            this.IsSaved = true;
        }

        public Dictionary<Type, object> Sets = new Dictionary<Type, object>();
        public List<object> Added = new List<object>();
        public List<object> Updated = new List<object>();
        public List<object> Removed = new List<object>();

        public bool IsSaved = false;
    }
}
