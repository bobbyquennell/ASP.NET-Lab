using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantumITSchoolGPA;
using QuantumITSchoolGPA.Controllers;
using QuantumITSchoolGPA.Tests.Fakes;
using QuantumITSchoolGPA.Models;

namespace QuantumITSchoolGPA.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var db = new FakeSchoolGpaDb();
            db.AddSet(TestData.Classes);
            HomeController controller = new HomeController(db);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            IEnumerable<Class> model = result.Model as IEnumerable<Class>;
            // Assert
            Assert.AreEqual(4, model.Count());
        }

        [TestMethod]
        public void ShowStudentList()
        {
            // Arrange
            var db = new FakeSchoolGpaDb();
            db.AddSet(TestData.Classes);
            HomeController controller = new HomeController(db);

            // Act
            PartialViewResult result = controller.ShowStudentList() as PartialViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

       
    }
}
