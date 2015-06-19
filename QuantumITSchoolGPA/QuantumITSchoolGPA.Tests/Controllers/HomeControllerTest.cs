using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantumITSchoolGPA;
using QuantumITSchoolGPA.Controllers;
using QuantumITSchoolGPA.Tests.Fakes;
using QuantumITSchoolGPA.Models;
using NUnit.Framework;

namespace QuantumITSchoolGPA.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private HomeController sut;
        private FakeSchoolGpaDb db;
        [Test]
        public void Index_Should_Return_Class_Model_List()
        {

            // Act
            ViewResult result = sut.Index() as ViewResult;
            IEnumerable<Class> model = result.Model as IEnumerable<Class>;
            // Assert
            Assert.That(model.Count(), Is.EqualTo(4));
        }

        [Test]
        public void ShowStudentList_Should_Return_a_ClassModel_with_Student_List()
        {
            //// Arrange
            int classId = 1;

            // Act
            PartialViewResult result = sut.ShowStudentList(classId) as PartialViewResult;
            Class model = result.Model as Class;
            // Assert
            Assert.That(model.Id, Is.EqualTo(classId));
            Assert.That(model.Students.Count, Is.EqualTo(1));
        }

        [SetUp]
        public void Arrange()
        {
             db = new FakeSchoolGpaDb();
            db.AddSet(TestData.Classes);
            sut = new HomeController(db);
        }

       
    }
}
