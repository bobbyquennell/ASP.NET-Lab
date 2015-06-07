using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantumITSchoolGPA.Tests.Fakes;
using QuantumITSchoolGPA.Controllers;
using QuantumITSchoolGPA.Models;

namespace QuantumITSchoolGPA.Tests.Controllers
{
    [TestClass]
    public class StudentControllerTest
    {
        [TestMethod]
        public void Create_Saves_Student_When_Valid()
        {
            var db = new FakeSchoolGpaDb();
            var controller = new StudentController(db);

            controller.Create(new Student());

            Assert.AreEqual(1, db.Added.Count);
            Assert.AreEqual(true, db.IsChangesSaved);
        }
    }
}
