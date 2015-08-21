using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Data.Repositories;
using ForumSystem.Models;

namespace BookShop.Data
{
    public interface IBookShopData
    {
        IRepository<Author> Authors { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<Book> Books { get; }

        IRepository<Category> Category { get; }

        IRepository<Purchase> Purchases { get; }
        
        int SaveChanges();
    }
}
