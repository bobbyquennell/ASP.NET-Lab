using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPASystem.Web.Tests.Features
{
    class SurnameValidator
    {
        private GPA.Domain.Repositories.IRepository repository;

        public SurnameValidator(GPA.Domain.Repositories.IRepository repository)
        {
            // TODO: Complete member initialization
            this.repository = repository;
        }

        internal bool ValidSurname(GPA.Domain.Entities.Student newStudent)
        {
            throw new NotImplementedException();
        }
    }
}
