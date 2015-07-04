using GPA.Domain.Entities;
using GPA.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.Domain.Features
{
    public class StupidRule
    {
        IRepository _repo;
        public StupidRule(IRepository repo)
        {
            _repo = repo;
        }
        public bool NameValidator(string newName, int StudentId = 0)
        {
            //get surname
            string SurnameToCheck = getSurname(newName);
            var list = _repo.GetAll<Student>().Select(stu=> new{stu.Name, stu.Id});
            foreach (var item in list)
            {
                if (SurnameToCheck == getSurname(item.Name)) {
                    if (item.Id != StudentId)
                    {
                        return false;
                    }
                    
                }
            }
            return true;
        }

        private string getSurname(string newName)
        {
            return newName.Split(' ').LastOrDefault().ToLower();
        }

    }
}
