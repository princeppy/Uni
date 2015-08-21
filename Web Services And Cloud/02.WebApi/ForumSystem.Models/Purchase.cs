using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ForumSystem.Models;

namespace ForumSystem.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public virtual Book Book { get; set; }

        public decimal Price { get; set; }

        [Required]
        public DateTime DateOfPurchase { get; set; }

        public PurchaseStatus PurchaseStatus { get; set; }

    }
}