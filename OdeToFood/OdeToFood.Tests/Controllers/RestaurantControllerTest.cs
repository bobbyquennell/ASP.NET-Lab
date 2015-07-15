using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OdeToFood.Web.Controllers;
using OdeToFood.Domain.Repositories;
using System.Web.Mvc;
using OdeToFood.Web.Models.Bristo;
using Moq;
using OdeToFood.Domain.Entities;
namespace OdeToFood.Tests.Controllers
{
    [TestFixture]
    class RestaurantControllerTest
    {
        [Test]
        public void Create_Saves_New_Restaurant_When_Valid()
        {
            //arrange
            //FakeRepo repo = new FakeRepo();
            List<Restaurant> Restaurants = new List<Restaurant>();
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.Add<Restaurant>(It.IsAny<Restaurant>())).Callback<Restaurant>(new Action<Restaurant>(
                r => {
                    Restaurants.Add(r);
                }));
            var sut = new RestaurantController(mockRepo.Object);
            RestaurantEditViewModel model = new RestaurantEditViewModel();
            //act
            ActionResult result = sut.Create(model);
            //assert
            Assert.That(Restaurants.Count, Is.EqualTo(1));
        }

        [Test]
        public void Create_Will_Not_Save_New_Restaurant_When_InValid()
        {
            //arrange
            //FakeRepo repo = new FakeRepo();
            List<Restaurant> Restaurants = new List<Restaurant>();
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.Add<Restaurant>(It.IsAny<Restaurant>())).Callback(new Action<Restaurant>(
                r => { Restaurants.Add(r); }
                ));
            var sut = new RestaurantController(mockRepo.Object);
            RestaurantEditViewModel model = new RestaurantEditViewModel();

            sut.ModelState.AddModelError("", " ");
            //act
            ActionResult result = sut.Create(model);
            //assert
            Assert.That(Restaurants.Count, Is.EqualTo(0));
        }
    }
}
