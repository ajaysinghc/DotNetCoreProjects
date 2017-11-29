using FoodApp.Models;
using System.Collections.Generic;

namespace FoodApp.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private IEnumerable<Restaurant> _inMemoryRestaurantData;
        public InMemoryRestaurantData() => _inMemoryRestaurantData = new List<Restaurant>
            {
                new Restaurant{Id=1, Name="Rice Specials"},
                new Restaurant { Id = 2, Name = "Paratha Specials" }

            };
        public IEnumerable<Restaurant> GetAll()
        {
            return _inMemoryRestaurantData;
        }
    }
}
