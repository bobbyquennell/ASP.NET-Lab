using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OdeToFoodExercise;
using OdeToFoodExercise.Controllers;
using OdeToFoodExercise.Models;
using NUnit.Framework;


namespace OdeToFood.Tests
{
    [TestFixture]
    public class HomeControllerUT
    {
        [Test]
        public void Index_Should_Return_Restaurant_List()
        {
            //arrange
            var db = new FakeOdeToFoodDb();
            db.AddSets(FakeData.Restaurants);
            HomeController controller = new HomeController(db);
            controller.ControllerContext = new FakeControllerContext();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            IEnumerable<RestaurantListViewModel> model = result.Model as IEnumerable<RestaurantListViewModel>;
            //Assert
            Assert.That(model.Count(), Is.EqualTo(10));
        }
        [Test]
        public void About_SHould_Not_Return_Null_Model()
        {
            //arrange
            IOdeToFoodDataSource db = new FakeOdeToFoodDb();
            HomeController controller = new HomeController(db);
            //Act
            ViewResult result = controller.About()as ViewResult;
            //Assert
            Assert.That(result.Model, Is.Not.Null);
        }
    }
}
