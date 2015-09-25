using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurants.Services.Models.BindingModels
{
    public class MakeOrderBindingModel
    {
        private const int MaxQuantity = 1000;

        [Required]
        [Range(1, MaxQuantity, ErrorMessage = "The {0} must be greater than zero and less than {2}")]
        [Display(Name = "quantity")]
        public int Quantity { get; set; }
    }
}