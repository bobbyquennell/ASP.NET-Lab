using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eManager.Domain
{
    public interface IDepartmentDataSource
    {
        public IQueryable<Employee> Employees { get;}
        public IQueryable<Department> Departments { get;}
    }
}
