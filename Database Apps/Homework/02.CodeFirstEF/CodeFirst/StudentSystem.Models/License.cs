﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class License
    {
        public int LicenseId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
