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
            //Check whether the student is already exist in our database.
            //if (StuToValid.Id > 0 )
            //{
            //    IQueryable<Student> stuList = from stu in repo.GetAll<Student>()
            //                  where stu.Id == StuToValid.Id
            //                  select stu;
            //    if (stuList.Count() > 0)
            //        isEdit = true;

            //}
            foreach (var item in repo.GetAll<Student>())
            {
                var surname = getSurname(item.Name);
                if (SurnameToCheck == surname)
                {
                    if (StuToValid.Id != item.Id)//new create or edit?
                    {
                        return false;
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
