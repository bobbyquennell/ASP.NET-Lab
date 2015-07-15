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
namespace OdeToFood.Tests.Controllers
{
    [TestFixture]
    class RestaurantControllerTest
    {
        [Test]
        public void Create_Saves_New_Restaurant_When_Valid()
        {
            //arrange
            FakeRepo repo = new FakeRepo();
            var sut = new RestaurantController(repo);
            RestaurantEditViewModel model = new RestaurantEditViewModel()
            {
                City = "Xi'an",
                Country = "China",
                Name = "ZhuYuanCun"
            };
            //act
            ActionResult result = sut.Create(model);
            //assert
            Assert.That(repo.AddList.Count, Is.EqualTo(1));
        }
    }
}
