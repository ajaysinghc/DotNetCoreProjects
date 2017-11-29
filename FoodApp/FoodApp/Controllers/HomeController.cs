using FoodApp.Services;
using FoodApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IGreetMessage _greetMessage;

        public HomeController(IRestaurantData restaurantData,
                              IGreetMessage greetMessage)
        {
            _restaurantData = restaurantData ?? throw new System.ArgumentNullException(nameof(restaurantData));
            _greetMessage = greetMessage ?? throw new System.ArgumentNullException(nameof(greetMessage));

        }
        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                Message = _greetMessage.getMessage(),
                Restaurants = _restaurantData.GetAll()
            };

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.GetRestaurant(id);
            if (model == null)
                return RedirectToAction(nameof(Index));

            return View(model);

        }
    }
}
