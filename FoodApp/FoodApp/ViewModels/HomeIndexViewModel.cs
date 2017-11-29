using FoodApp.Models;
using System.Collections.Generic;

namespace FoodApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
