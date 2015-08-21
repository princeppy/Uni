using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BookShop.Services.ViewModels;
using ForumSystem.Models;

namespace BookShop.Services.Models.ViewModels
{
    public class BookSimpleViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
    }
}