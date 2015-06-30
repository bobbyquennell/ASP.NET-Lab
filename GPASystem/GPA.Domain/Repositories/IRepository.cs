using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA.Domain.Repositories
{
    public interface IRepository
    {
        IQueryable<T> GetAll<T>() where T : class;
        T GetById<T>(int id) where T:class;
        void Add<T>(T entity) where T:class;
        void Update<T>(T entity) where T : class;
        void SaveChanges();
        void Delete<T>(T entity) where T:class;
    }
}
