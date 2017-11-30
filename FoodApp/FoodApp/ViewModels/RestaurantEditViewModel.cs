using FoodApp.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodApp.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Required, MaxLength(40)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
