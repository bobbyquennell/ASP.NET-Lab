using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA.Domain.Repositories
{
    public interface IRepository:IDisposable
    {
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void SaveChanges();

    }
}
