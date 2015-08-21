using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ForumSystem.Models;

namespace BookShop.ServicesAuth.Models.BindingModels
{
    public class BookUpdateBindingModel
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "The {0} must be at between {2} and {1} characters long.")]
        [Display(Name="Book title")]
        [DataType(DataType.Text)]   
        public string Title { get; set; }

        [StringLength(1000, ErrorMessage = "The {0} must be max {2} characters long.")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }

        public int? AuthorId { get; set; }

        [Required]
        public EditionType EditionType { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public AgeRestriction AgeRestriction { get; set; }
    }
}