using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GPA.Domain.Features;
using GPA.Domain.Repositories;
namespace GPA.Web.Models
{
    public class StupidValidation:ValidationAttribute
    {
        IRepository _repo;
        public StupidValidation()
            : base("Invalid Surname, please input an unique one")
        {
            _repo = new EfRepository();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Validator = new StupidRule(_repo);
            string SurNameToCheck = value.ToString().Split(' ').LastOrDefault().ToLower();
            bool checkResult;
            string path = HttpContext.Current.Request.Path;
            if (path.Contains("Create"))
            {
                checkResult =  Validator.NameValidator(SurNameToCheck);
            }
            else
            {
                int id = Convert.ToInt32(path.Split('/').LastOrDefault());
                checkResult = Validator.NameValidator(SurNameToCheck, id);
            }
            if (checkResult)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }
}