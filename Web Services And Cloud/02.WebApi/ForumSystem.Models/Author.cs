using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Models
{
    public class Author
    {
        private ICollection<Book> books;

        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public int AuthorID { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }

    }
}
