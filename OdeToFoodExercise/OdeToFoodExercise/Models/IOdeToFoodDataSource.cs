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
    }
}
