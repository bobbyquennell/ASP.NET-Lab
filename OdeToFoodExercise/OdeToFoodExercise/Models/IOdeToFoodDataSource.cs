using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFoodExercise.Models
{
    public interface IOdeToFoodDataSource: IDisposable
    {
        IQueryable<T> Query<T>() where T: class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void SaveChanges();
    }
}
