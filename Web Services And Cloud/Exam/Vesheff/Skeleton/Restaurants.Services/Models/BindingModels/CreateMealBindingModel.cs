using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurants.Services.Models.BindingModels
{
    public class CreateMealBindingModel
    {
        private const double MaxPrice = 10000.0;

        [Required]
        [MinLength(1, ErrorMessage = "The {0} must be at least 1 character long.")]
        [Display(Name = "Meal")]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The {0} must be greater than zero")]
        [Display(Name = "Restaurant id")]
        public int RestaurantId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The {0} must be greater than zero")]
        [Display(Name = "Meal type")]
        public int TypeId { get; set; }

        [Required]
        [Range(0.0, MaxPrice, ErrorMessage = "The {0} of the meal must be greater than zero")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}