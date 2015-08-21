using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.ServicesAuth.Models.BindingModels
{
    public class BookCreateBindingModel:BookUpdateBindingModel
    {
        public string Categories { get; set; }
    }
}