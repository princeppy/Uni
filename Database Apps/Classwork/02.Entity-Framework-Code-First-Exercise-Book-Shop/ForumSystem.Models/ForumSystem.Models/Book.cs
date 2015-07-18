using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ForumSystem.Models
{
    public class Book
    {
        private ICollection<Category> categories;
        private ICollection<Book> relatedBooks;

        public Book()
        {
            this.Categories = new HashSet<Category>();
            this.RelatedBooks = new HashSet<Book>();
        }

        public int BookID { get; set; }

        [MinLength(1), MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }
        
        public virtual Author Author { get; set; }

        [Required]
        public EditionType EditionType { get; set; }

        public DateTime? ReleaseDate { get; set; }
        
        [Required]
        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        public virtual ICollection<Book> RelatedBooks
        {
            get { return this.relatedBooks; }
            set { this.relatedBooks = value; }
        }

    }
}
