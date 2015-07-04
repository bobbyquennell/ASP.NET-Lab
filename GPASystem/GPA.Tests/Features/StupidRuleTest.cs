using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GPA.Domain.Repositories;
using Moq;
using GPA.Domain.Entities;
using GPA.Domain.Features;
/*
 * A (stupid) business rule is that surnames must be unique across classes
 * (and within the same class) i.e. if there is a student with the surname
 * Black, we cannot add another sudent with the surname Black to this or
 * any other class
 */
namespace GPA.Tests.Features
{
    [TestFixture]
    class StupidRuleTest
    {
        [Test]
        public void Should_Return_True_When_Add_A_NewStudent_with_Valid_Name()
        {
            //arrange
            string newName = "Bobby Wang";
            var MockRepo = new Mock<IRepository>();
            MockRepo.Setup(IRepository => IRepository.GetAll<Student>())
                .Returns(new Student[]{
                    new Student{ Id =1, Name = "Levi Li"},
                    new Student{ Id =2, Name = "Barack Obama"}
                }.AsQueryable());
            var sut = new StupidRule(MockRepo.Object);
            //act
            var result = sut.NameValidator(newName);
            //assert
            Assert.That(result, Is.True);

        }

        [Test]
        public void Should_Return_False_When_Add_A_NewStudent_with_Invalid_Name()
        {
            //arrange
            string newName = "Bobby Wang";
            var MockRepo = new Mock<IRepository>();
            MockRepo.Setup(IRepository => IRepository.GetAll<Student>())
                .Returns(new Student[]{
                    new Student{ Id =1, Name = "Levi Wang"},
                    new Student{ Id =2, Name = "Barack Obama"}
                }.AsQueryable());
            var sut = new StupidRule(MockRepo.Object);
            //act
            var result = sut.NameValidator(newName);
            //assert
            Assert.That(result, Is.False);

        }
        [Test]
        public void Should_Return_False_When_Edit_A_Student_with_Invalid_Name()
        {
            //arrange
            var MockRepo = new Mock<IRepository>();
            MockRepo.Setup(IRepository => IRepository.GetAll<Student>())
                .Returns(new Student[]{
                    new Student{ Id =1, Name = "Levi Wang"},
                    new Student{ Id =2, Name = "Barack Obama"}
                }.AsQueryable());
            var sut = new StupidRule(MockRepo.Object);
            //act
            string newName = "Levi Obama";//eidt the first student's surname to the second one's, which is invalid.
            int StudentId = 1;
            //edit 
            var result = sut.NameValidator(newName, StudentId);
            //assert
            Assert.That(result, Is.False);

        }
        [Test]
        public void Should_Return_True_When_Edit_A_Student_with_Valid_Name()
        {
            //arrange
            var MockRepo = new Mock<IRepository>();
            MockRepo.Setup(IRepository => IRepository.GetAll<Student>())
                .Returns(new Student[]{
                    new Student{ Id =1, Name = "Levi Wang"},
                    new Student{ Id =2, Name = "Barack Obama"}
                }.AsQueryable());
            var sut = new StupidRule(MockRepo.Object);
            //act
            string newName = "Tony Wang";//eidt the first student's fisrt name, which is valid.
            int StudentId = 1;
            //edit 
            var result = sut.NameValidator(newName, StudentId);
            //assert
            Assert.That(result, Is.True);

        }
    }
}
