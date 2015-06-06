using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuantumITSchoolGPA.Models
{
    public class NameLengthAttribute:ValidationAttribute
    {
        public NameLengthAttribute(int minWords, int maxWords) : base("Woops, Name length error, please input your full name split with a space")
        {
            _maxWords = maxWords;
            _minWords = minWords;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string[] stringSeparators = new string[] { " " };
                var NameList = value.ToString().Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                //var nameLength = NameList.Count - NameList.Count(item => item.Contains(' '));
                if (NameList.Length > _maxWords || NameList.Length < _minWords)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
        private int _maxWords;
        private int _minWords;
    }
}