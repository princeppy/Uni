using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Services.Models.BindingModel
{
    public class BookCreateBindingModel:BookUpdateBindingModel
    {
        public string Categories { get; set; }
    }
}