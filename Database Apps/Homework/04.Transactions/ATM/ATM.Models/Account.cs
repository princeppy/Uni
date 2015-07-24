using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmNamespace.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string CardNumber { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public string CardPin { get; set; }

        [Required]
        [Range(0.0, Double.MaxValue)]
        public decimal Money { get; set; }
    }
}
