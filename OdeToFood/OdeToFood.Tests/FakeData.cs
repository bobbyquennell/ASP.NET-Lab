using OdeToFood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Tests
{
    public class FakeData
    {
        static public IQueryable<Restaurant> FakeRest { get { 
            var restaurants = new List<Restaurant>();
            for (int i = 0; i < 100; i++)
			{
                restaurants.Add(new Restaurant(){
                     Id = i+1, City = "Xi'an", Country = "China", Name = "Restaunt" + i,
                     Reviews = new List<Review>() { new Review() {  Rating = 9} }
                });
			}
            return restaurants.AsQueryable();
        } }
    }
}
