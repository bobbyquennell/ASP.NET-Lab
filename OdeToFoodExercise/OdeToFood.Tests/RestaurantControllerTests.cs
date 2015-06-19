using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFoodExercise.Controllers;
using OdeToFoodExercise.Models;
using NUnit.Framework;

namespace OdeToFood.Tests
{
    [TestFixture]
    public class RestaurantControllerTests
    {
        [Test]
        public void Create_Saves_Restaurant_When_Valid()
        {
            var db = new FakeOdeToFoodDb();
            var controller = new RestaurantController(db);
            controller.Create(new Restaurant());
            Assert.That(db.Added.Count, Is.EqualTo(1));
            Assert.That(db.IsSaved, Is.True);

        }
        [Test]
        public void Create_Does_Not_Save_Restaurant_When_Invalid()
        {
            var db = new FakeOdeToFoodDb();
            var controller = new RestaurantController(db);
            controller.ModelState.AddModelError("", "Invalid");
            controller.Create(new Restaurant());
            Assert.That(db.Added.Count, Is.EqualTo(0));
        }
    }
}
