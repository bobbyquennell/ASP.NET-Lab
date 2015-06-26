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
        private IRepository repository;

        public SurnameValidator(IRepository repository)
        {
            this.repository = repository;
        }

        internal bool ValidSurname(Student newStudent)
        {
            return true;
        }
    }
}
