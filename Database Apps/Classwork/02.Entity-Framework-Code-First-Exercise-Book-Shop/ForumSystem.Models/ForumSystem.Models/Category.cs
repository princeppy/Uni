using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Models
{
    public class Category
    {


        private ICollection<Book> books;

        public Category()
        {
            this.Books =new HashSet<Book>();
        }
        public int CategoryID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}
