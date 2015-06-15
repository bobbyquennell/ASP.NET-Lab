using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFoodExercise.Controllers;
using OdeToFoodExercise.Models;

namespace OdeToFood.Tests
{
    [TestClass]
    public class RestaurantControllerTests
    {
        [TestMethod]
        public void Create_Saves_Restaurant_When_Valid()
        {
            var db = new FakeOdeToFoodDb();
            var controller = new RestaurantController(db);
            controller.Create(new Restaurant());
            Assert.AreEqual(1, db.Added.Count);
            Assert.AreEqual(true, db.IsSaved);

        }
        [TestMethod]
        public void Create_Does_Not_Save_Restaurant_When_Invalid()
        {
            var db = new FakeOdeToFoodDb();
            var controller = new RestaurantController(db);
            controller.ModelState.AddModelError("", "Invalid");
            controller.Create(new Restaurant());
            Assert.AreEqual(0, db.Added.Count);
        }
    }
}
