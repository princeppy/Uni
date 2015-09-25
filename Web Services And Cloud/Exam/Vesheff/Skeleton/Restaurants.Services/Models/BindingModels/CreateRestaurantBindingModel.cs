using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurants.Services.Models.BindingModels
{
    public class CreateRestaurantBindingModel
    {
        [Required]
        [MinLength(1, ErrorMessage = "The {0} must be at least 1 character long.")]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The {0} must be greater than zero")]
        [Display(Name = "Town id")]
        public int TownId { get; set; }
    }
}