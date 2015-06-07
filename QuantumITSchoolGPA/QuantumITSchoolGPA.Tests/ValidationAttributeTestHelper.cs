using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace QuantumITSchoolGPA.Tests
{
    public class ValidationAttributeTestHelper
    {
        public static IList<ValidationResult> GetValidationErrorsForObject(object model)
        {
            var validationContext = new ValidationContext(model, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults);
            return validationResults;
        }
 
        public static void CheckValidationErrorsForObject(object model, IEnumerable<string> expectedValidationMessages)
        {
            var errors = GetValidationErrorsForObject(model);
            errors.Count.ShouldBeEquivalentTo(expectedValidationMessages.Count());
            var i = 0;
            foreach (var msg in expectedValidationMessages)
            {
                msg.ShouldBeEquivalentTo(errors[i++].ErrorMessage);
            }
        }
 
        public static IList<ValidationResult> GetValidationErrorsForProperty(object model, object property, string propertyName)
        {
            var validationContext = new ValidationContext(model, null, null) { MemberName = propertyName };
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateProperty(property, validationContext, validationResults);
            return validationResults;
        }
 
        public static void CheckValidationErrorsForProperty(object model, object property, string propertyName, IEnumerable<string> expectedValidationMessages)
        {
            var errors = GetValidationErrorsForProperty(model, property, propertyName);
            errors.Count.ShouldBeEquivalentTo(expectedValidationMessages.Count());
            var i = 0;
            foreach (var msg in expectedValidationMessages)
            {
                msg.ShouldBeEquivalentTo(errors[i++].ErrorMessage);
            }
        }
    }
}
