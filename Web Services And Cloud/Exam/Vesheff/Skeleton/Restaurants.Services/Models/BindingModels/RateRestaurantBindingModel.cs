using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurants.Services.Models.BindingModels
{
    public class RateRestaurantBindingModel
    {
        [Required]
        [Range(1,10, ErrorMessage = "The {0} must be in the range [{1},{2}].")]
        [Display(Name = "Rating")]
        public int Stars { get; set; }
    }
}