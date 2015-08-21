using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ForumSystem.Models;

namespace BookShop.Service.Models.ViewModels
{
    public class PurchaseViewModel
    {
        public virtual ApplicationUser User { get; set; }

        public virtual Book Book { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfPurchase { get; set; }




    }
}