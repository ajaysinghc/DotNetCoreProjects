using FoodApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodApp.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private IEnumerable<Restaurant> _inMemoryRestaurantData;
        public InMemoryRestaurantData() => _inMemoryRestaurantData = new List<Restaurant>
            {
                new Restaurant{Id=1, Name="Rice Specials"},
                new Restaurant { Id = 2, Name = "Paratha Specials" },
                new Restaurant { Id = 3, Name = "Food Factory" }

            };
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
