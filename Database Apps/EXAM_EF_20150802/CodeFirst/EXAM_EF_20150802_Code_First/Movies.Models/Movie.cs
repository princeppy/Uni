using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Movies.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Ratings = new HashSet<Rating>();
            this.Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Isbn { get; set; }


        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Title { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
