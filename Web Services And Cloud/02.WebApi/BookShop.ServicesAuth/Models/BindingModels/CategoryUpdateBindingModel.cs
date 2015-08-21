using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.ServicesAuth.Models.BindingModels
{
    public class CategoryUpdateBindingModel
    {
        [Required]
        [Display(Name = "Category name")]
        [StringLength(100, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}