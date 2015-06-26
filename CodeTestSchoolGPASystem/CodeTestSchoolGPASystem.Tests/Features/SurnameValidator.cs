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

        internal bool ValidSurname(Student StuToValid)
        {
            //bool isEdit = false;
            string SurnameToCheck = getSurname(StuToValid.Name);
            foreach (var item in repo.GetAll<Student>())
            {
                var surname = getSurname(item.Name);
                if (SurnameToCheck == surname)
                {
                    if (StuToValid.Id != item.Id)//if the one we fund is itself?
                    {
                        return false;
                        //case 1) new create student.Id should be 0 or null, while item.Id >=1, then should return false, cuz we found a already existed one in database.
                        //case 2) an edit student.Id should >=1, if we found an item, whose name equals to the student.name while their ID do not match, when we found an already existed one in database. 
                    }

                }
            }  

            return true;
        }
        private string getSurname(string FullName)
        {
            return FullName.Split(' ').Last().ToLower();
        }
    }
}
