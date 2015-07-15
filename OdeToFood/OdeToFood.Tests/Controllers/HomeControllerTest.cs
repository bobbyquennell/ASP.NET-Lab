using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using OdeToFood.Web;
using OdeToFood.Web.Controllers;
using OdeToFood.Domain.Entities;
using Moq;
using OdeToFood.Domain.Repositories;

namespace OdeToFood.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.GetAll<Restaurant>()).Returns( FakeData.FakeRest);
            //http://abelperezmartinez.blogspot.com.au/2014/01/mocking-repository-using-moq.html
            //FakeRepo repo = new FakeRepo();
            //repo.AddSets<Restaurant>(FakeData.FakeRest);
            HomeController controller = new HomeController(mockRepo.Object);
            controller.ControllerContext = new FakeControllerContext();
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.That(result.ViewBag.Message, Is.EqualTo("Your application description page."));
        }

        [Test]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}
