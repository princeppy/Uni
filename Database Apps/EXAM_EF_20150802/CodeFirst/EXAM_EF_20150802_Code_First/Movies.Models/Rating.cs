using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Movies.Models
{
    public class Rating
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0,10)]
        public int Stars { get; set; }

        [Index("IX_FirstAndSecond", 4, IsUnique = true)]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        [Index("IX_FirstAndSecond", 3, IsUnique = true)]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
