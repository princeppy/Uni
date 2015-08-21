using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BookShop.Services.Models.ViewModels;
using ForumSystem.Models;
using Newtonsoft.Json;

namespace BookShop.Services.ViewModels
{
    public class BookViewModel:BookSimpleViewModel
    {
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public EditionType EditionType { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int? AuthorId { get; set; }

        [Required]
        public AgeRestriction AgeRestriction { get; set; }

        public ICollection<string> Categories { get; set; }
    }
}