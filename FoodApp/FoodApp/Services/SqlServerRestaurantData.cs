using FoodApp.Data;
using FoodApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodApp.Services
{
    public class SqlServerRestaurantData : IRestaurantData
    {
        private readonly FoodAppDbContext _dbContext;
        public SqlServerRestaurantData(FoodAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            _dbContext.Restaurant.Add(newRestaurant);
            _dbContext.SaveChanges();
            return newRestaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _dbContext.Restaurant.OrderBy(r => r.Name);
        }

        public Restaurant GetRestaurant(int restaurantId)
        {
            return _dbContext.Restaurant.FirstOrDefault(r => r.Id == restaurantId);
        }
    }
}
