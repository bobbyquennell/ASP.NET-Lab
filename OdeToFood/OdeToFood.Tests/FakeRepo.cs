using OdeToFood.Domain.Entities;
using OdeToFood.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Tests
{
    class FakeRepo:IRepository
    {
        public IQueryable<T> GetAll<T>() where T : class
        {
            return Sets[typeof(T)] as IQueryable<T>;
        }

        public T GetById<T>(int Id) where T : class
        {
            throw new NotImplementedException();
        }

        public void Add<T>(T entity) where T : class
        {
             AddList.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        Dictionary<Type, object> Sets = new Dictionary<Type, object>();
        public List<object> AddList = new List<object>();
        public void AddSets<T>(IQueryable<T> objects){
            Sets.Add(typeof(T), objects);
       }
    }
}
