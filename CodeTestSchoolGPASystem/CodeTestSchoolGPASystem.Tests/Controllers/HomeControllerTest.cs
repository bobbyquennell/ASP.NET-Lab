using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPASystem.Web;
using GPASystem.Web.Controllers;
using NUnit.Framework;
using Moq;
using GPA.Domain.Repositories;
using GPA.Domain.Entities;
using GPASystem.Web.Models.Home;

namespace GPASystem.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index_Should_Return_Course_List()
        {
            // Arrange
            Mock<IRepository> GpaRepoMock = new Mock<IRepository>();
            GpaRepoMock.Setup(r => r.GetAll<Course>()).Returns(new Course[]{
             new Course{Location = "building1 Room201", Name="English"},
             new Course{Location = "building5 Room301", Name="French"},
             }.AsQueryable());

            HomeController controller = new HomeController(GpaRepoMock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            HomeIndexViewModel model = result.Model as HomeIndexViewModel;
            // Assert
            Assert.That(model.Courses.Count, Is.EqualTo(2));
        }

    }
}
