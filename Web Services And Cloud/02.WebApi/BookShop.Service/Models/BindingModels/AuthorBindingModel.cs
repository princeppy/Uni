using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Service.Models.BindingModels
{
    public class AuthorBindingModel
    {
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(100, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
    }
}