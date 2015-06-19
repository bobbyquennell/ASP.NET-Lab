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
        private FakeSchoolGpaDb db;
        private StudentController sut;
        [Test]
        public void Create_Should_Save_A_New_Student_When_Valid()
        {
                 
            sut.Create(new Student());

            Assert.That(db.Added.Count, Is.EqualTo(1));
            Assert.That(db.IsChangesSaved, Is.True);
        }

        [SetUp]
        public void StudentControllerArrange()
        {
            db = new FakeSchoolGpaDb();
            sut = new StudentController(db);
        }
    }
}
