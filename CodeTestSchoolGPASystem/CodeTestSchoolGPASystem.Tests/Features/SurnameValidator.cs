using GPA.Domain.Entities;
using GPA.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPASystem.Web.Tests.Features
{
    class SurnameValidator
    {
        private IRepository repo;

        public SurnameValidator(IRepository repository)
        {
            this.repo = repository;
        }

        internal bool ValidSurname(Student newStudent)
        {

            string SurnameToCheck = newStudent.Name.Split(' ').Last().ToLower();
            foreach (var item in repo.GetAll<Student>())
            {
                var surname = item.Name.Split(' ').Last().ToLower();
                if (SurnameToCheck == surname)
                    return false;
            }  

            return true;
        }
    }
}
