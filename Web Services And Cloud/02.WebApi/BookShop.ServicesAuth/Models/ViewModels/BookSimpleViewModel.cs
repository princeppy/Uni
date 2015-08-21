using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BookShop.ServicesAuth.Models.ViewModels;
using ForumSystem.Models;

namespace BookShop.ServicesAuth.Models.ViewModels
{
    public class BookSimpleViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
    }
}