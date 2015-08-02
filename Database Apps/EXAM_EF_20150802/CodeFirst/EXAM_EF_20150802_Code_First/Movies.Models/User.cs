using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;

namespace Movies.Models
{
    public class User
    {
        public User()
        {
            this.Ratings = new HashSet<Rating>();
            this.Movies = new HashSet<Movie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Username { get; set; }

        public string Email { get; set; }

        public int? Age { get; set; }

        public Country Country { get; set; }

        
        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }



    }
}
