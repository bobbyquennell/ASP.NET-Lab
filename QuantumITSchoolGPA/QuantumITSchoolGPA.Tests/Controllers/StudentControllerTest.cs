using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantumITSchoolGPA.Tests.Fakes;
using QuantumITSchoolGPA.Controllers;
using QuantumITSchoolGPA.Models;
using NUnit.Framework;

namespace QuantumITSchoolGPA.Tests.Controllers
{
    [TestFixture]
    public class StudentControllerTest
    {
        [Test]
        public void Create_Should_Save_A_New_Student_When_Valid()
        {
            var db = new FakeSchoolGpaDb();
            var controller = new StudentController(db);            
            controller.Create(new Student());

            Assert.That(db.Added.Count, Is.EqualTo(1));
            Assert.That(db.IsChangesSaved, Is.True);
        }
    }
}
