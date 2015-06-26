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

            string SurnameToCheck = getSurname(newStudent.Name);
            foreach (var item in repo.GetAll<Student>())
            {
                var surname = getSurname(item.Name);
                if (SurnameToCheck == surname)
                    return false;
            }  

            return true;
        }
        private string getSurname(string FullName)
        {
            return FullName.Split(' ').Last().ToLower();
        }
    }
}
