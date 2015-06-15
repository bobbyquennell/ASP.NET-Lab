using OdeToFoodExercise.Models;
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

        public void Dispose()
        {
            throw new NotImplementedException();//this can be ignore
        }
        public void  AddSets<T>(IQueryable<T> objects){
            Sets.Add(typeof(T), objects);
        }

        public Dictionary<Type, object> Sets = new Dictionary<Type,object>();
    }
}
