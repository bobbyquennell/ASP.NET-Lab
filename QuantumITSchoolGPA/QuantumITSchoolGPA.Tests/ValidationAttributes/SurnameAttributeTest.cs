using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantumITSchoolGPA.Models;
using QuantumITSchoolGPA.Tests.Fakes;
using QuantumITSchoolGPA.Controllers;
using System.ComponentModel.DataAnnotations;

namespace QuantumITSchoolGPA.Tests.ValidationAttributes
{
    [TestClass]
    public class SurnameAttributeTest
    {
        [TestMethod]
        public void Create_newStu_WithUniqueSurname_ShouldBeValid()
        {
            //arrange
            var db = new FakeSchoolGpaDb();
            var stu = new Student{ Age= 12, ClassId = 1, GPA = 3.1f, Id = 2, Name= "Quantum Unique"};
            var testContext = new ValidationContext(stu,null,null);
            var attr = new SurnameAttribute(db);           
            var controller = new StudentController(db);

            //act
            
            controller.Create(new Student{ Age= 12, ClassId = 1, GPA = 3.2f, Id = 1, Name= "Quantum IT"});

            var result = Validator.TryValidateObject(stu, testContext, null, true);

            Assert.AreEqual(1, db.Added.Count);
            Assert.AreEqual(true, db.IsChangesSaved);
            Assert.IsTrue(result);

        }
    }
}
