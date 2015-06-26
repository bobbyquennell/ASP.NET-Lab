using System;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using GPA.Domain.Entities;
using GPA.Domain.Repositories;
using System.Linq;
using GPASystem.Web.Tests.Features;
/*
 * A (stupid) business rule is that surnames must be unique across classes
 * (and within the same class/lesson)i.e. 
 * if there is a student with surname Black, we cannot add another sudent 
 * with the surname Black to this
 * or any other class
 */
namespace GPASystem.Web.Tests.Features
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void SurnameValidator_Should_Return_True_When_Add_A_Student_With_Valid_Surname()
        {
            //arrange
            Student newStudent = new Student();
            newStudent.Name = "Peter Black";
            IList<Student> Students = new List<Student>(){ 
                new Student(){ Name = "Peter Wang"},
                new Student(){ Name = "Peter White"}
            };
            Mock<IRepository> MockGpaRepo = new Mock<IRepository>();
            MockGpaRepo.Setup(r => r.GetAll<Student>()).Returns(Students.AsQueryable());

            //act
            var Validator = new SurnameValidator(MockGpaRepo.Object);
            bool isSurnameValid = Validator.ValidSurname(newStudent);

            //assert
            Assert.That(isSurnameValid, Is.True);

        }
        [Test]
        public void SurnameValidator_Should_Return_False_When_Add_A_Student_With_Invalid_Surname()
        {
            //arrange
            Student newStudent = new Student();
            newStudent.Name = "Peter Black";
            IList<Student> Students = new List<Student>(){ 
                new Student(){ Name = "Peter Wang", Id = 1},
                new Student(){ Name = "Peter Black", Id = 2}
            };
            Mock<IRepository> MockGpaRepo = new Mock<IRepository>();
            MockGpaRepo.Setup(r => r.GetAll<Student>()).Returns(Students.AsQueryable());

            //act
            var Validator = new SurnameValidator(MockGpaRepo.Object);
            bool isSurnameValid = Validator.ValidSurname(newStudent);

            //assert
            Assert.That(isSurnameValid, Is.False);
        }
        [Test]
        public void SurnameValidator_Should_Return_True_When_Edit_A_Student_With_Valid_Surname()
        {
            //arrange
            Student stuToEdit = new Student()
            {
                Id = 2,
                Name = "Peter Black"
            };
            IList<Student> Students = new List<Student>(){ 
                new Student(){ Name = "Peter Yellow", Id = 1},
                stuToEdit,
                new Student(){ Name = "Peter White", Id = 3}
            };
            Mock<IRepository> MockGpaRepo = new Mock<IRepository>();
            MockGpaRepo.Setup(r => r.GetAll<Student>()).Returns(Students.AsQueryable());
            var Validator = new SurnameValidator(MockGpaRepo.Object);

            //act
              //edit the student's properties:
            stuToEdit.Name = "Bobby Black";//change first name.
            stuToEdit.Gpa = 3.8;
            bool isSurnameValid = Validator.ValidSurname(stuToEdit);

            //assert
            Assert.That(isSurnameValid, Is.True);
        }
    }
}
