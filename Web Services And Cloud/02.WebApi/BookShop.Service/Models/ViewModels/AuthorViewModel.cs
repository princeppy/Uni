using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ForumSystem.Models;

namespace BookShop.Service.Models.ViewModels
{
    public class AuthorViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}