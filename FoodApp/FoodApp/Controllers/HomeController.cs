using FoodApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var restaurant = new Restaurant { Id = 1, Name = "Place to eat" };
            return View(restaurant);
        }
    }
}
