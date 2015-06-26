using GPA.Domain.Features;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GPASystem.Web.Models
{
    public class SurnameAttribute:ValidationAttribute
    {
        public SurnameAttribute()
            : base("Surname must be unique, please try another one")
        {

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var repo = new EfGPARepository();
            string path = HttpContext.Current.Request.Path;
            var Validator = new SurnameValidator(repo);

            if(value !=null)
            {
                int StudentId = 0;
                bool isCreateNew = path.ToLower().Contains("create");
                if (!isCreateNew)
                {
                    StudentId = Convert.ToInt32((path.Split('/').Last()));
                }
                if (!Validator.ValidSurname(value.ToString(), StudentId))
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}