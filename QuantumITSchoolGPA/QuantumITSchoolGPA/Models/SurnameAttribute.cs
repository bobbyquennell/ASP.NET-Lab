using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuantumITSchoolGPA.Models
{
    public class SurnameAttribute:ValidationAttribute
    {
        SchoolGpaDb _db = new SchoolGpaDb();
        public SurnameAttribute() : base("Surname must be unique, please try another one") { }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string path = HttpContext.Current.Request.Path;
            int StudentId = 0x0fffffff;
            bool isCreateNew = path.ToLower().Contains("create");
            if (!isCreateNew)
            {
                //get old name
                StudentId = Convert.ToInt32((path.Split('/').Last()));
                string oldName =_db.Students.Find(StudentId).Name;
            }
            if (value!=null)
            {
                var ValueAsString = value.ToString();
                string Surname = ValueAsString.Split(' ').Last().ToLower();
                var CandidateStuList = _db.Students.Where(stu => stu.Name.Contains(Surname))
                    .Select( stu=> new
                            {
                                name = stu.Name,
                                id = stu.Id
                            }
                        );
                foreach (var item in CandidateStuList)
                {
                    if (item.name.Split(' ').Last().ToLower()==Surname)
                    {
                        if (isCreateNew || StudentId != item.id)//error happens when create a new dupliacted surname or change an current Surname which is duplicated with otherone's
                        {
                            var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                            return new ValidationResult(errorMessage);
                        }


                        //found duplicated surname
                    }
                }
               
            }
            return ValidationResult.Success;
        }
    }
}