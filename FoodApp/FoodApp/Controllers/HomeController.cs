using FoodApp.Models;
using FoodApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData ?? throw new System.ArgumentNullException(nameof(restaurantData));

        }
        public ActionResult Index()
        {
            var restaurant = _restaurantData.GetAll();
            return View(restaurant);
        }
    }
}
