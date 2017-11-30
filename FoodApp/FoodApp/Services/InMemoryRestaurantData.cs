using FoodApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodApp.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _inMemoryRestaurantData;
        public InMemoryRestaurantData() => _inMemoryRestaurantData = new List<Restaurant>
            {
                new Restaurant{Id=1, Name="Rice Specials"},
                new Restaurant { Id = 2, Name = "Paratha Specials" },
                new Restaurant { Id = 3, Name = "Food Factory" }

            };

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _inMemoryRestaurantData.Max(i => i.Id) + 1;
            _inMemoryRestaurantData.Add(newRestaurant);
            return newRestaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _inMemoryRestaurantData;
        }

        public Restaurant GetRestaurant(int restaurantId)
        {
            return _inMemoryRestaurantData.FirstOrDefault(r => r.Id == restaurantId);
        }
    }
}
