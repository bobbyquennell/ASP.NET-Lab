using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eManager.Web.Models;
using eManager.Domain;

namespace eManager.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class EmployeeController : Controller
    {
        private IDepartmentDataSource _db;

        public EmployeeController(IDepartmentDataSource db)
        {
            _db = db;
        }

        //
        // GET: /Employee/
        [HttpGet]
        public ActionResult Create(int departmentId)
        {
            var model = new CreateEmployeeViewModel();
            model.DepartmentId = departmentId;
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var department = _db.Departments.Single(d => d.DepartmentId == viewModel.DepartmentId);
                var employee = new Employee();
                employee.Name = viewModel.Name;
                employee.HireDate = viewModel.HireDate;
                department.Employees.Add(employee);

                _db.Save();
                return RedirectToAction("Detail","Department", new{departmentId = viewModel.DepartmentId});
            }
            return View(viewModel);
        }

    }
}
