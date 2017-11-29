using FoodApp.Models;
using System.Collections.Generic;

namespace FoodApp.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetRestaurant(int restaurantId);
    }
}
