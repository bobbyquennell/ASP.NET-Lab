using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OdeToFoodExercise;
using OdeToFoodExercise.Controllers;
using OdeToFoodExercise.Models;


namespace OdeToFood.Tests
{
    [TestClass]
    public class HomeControllerUT
    {
        [TestMethod]
        public void Index()
        {
            //arrange
            IOdeToFoodDataSource db = new FakeOdeToFoodDb();
            HomeController controller = new HomeController(db);
            // Act
            ViewResult result = controller.Index() as ViewResult;
            //Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }
        [TestMethod]
        public void About()
        {
            //arrange
            IOdeToFoodDataSource db = new FakeOdeToFoodDb();
            HomeController controller = new HomeController(db);
            //Act
            ViewResult result = controller.About()as ViewResult;
            //Assert
            Assert.IsNotNull(result.Model);
        }
    }
}
