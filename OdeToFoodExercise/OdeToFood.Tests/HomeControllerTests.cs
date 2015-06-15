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
            var db = new FakeOdeToFoodDb();
            db.AddSets(FakeData.Restaurants);
            HomeController controller = new HomeController(db);
            controller.ControllerContext = new FakeControllerContext();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            IEnumerable<RestaurantListViewModel> model = result.Model as IEnumerable<RestaurantListViewModel>;
            //Assert
            Assert.AreEqual(10, model.Count());
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
