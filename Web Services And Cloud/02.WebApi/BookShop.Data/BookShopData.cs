using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Data.Repositories;
using ForumSystem.Models;

namespace BookShop.Data
{
    public class BookShopData: IBookShopData
    {
        private BookShopContext context;
        private IDictionary<Type, object> repositories;

        public BookShopData(BookShopContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Author> Authors
        {
            get { return this.GetRepository<Author>(); }
        }

        public IRepository<ApplicationUser> Users
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }
        
        public IRepository<Book> Books
        {
            get { return this.GetRepository<Book>(); }
        }

        public IRepository<Category> Category
        {
            get { return this.GetRepository<Category>(); }
        }

        public IRepository<Purchase> Purchases
        {
            get { return this.GetRepository<Purchase>(); }
        }

        public IRepository<ApplicationRole> Roles
        {
            get { return this.GetRepository<ApplicationRole>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T: class 
        {
            var type = typeof (T);
            if (!this.repositories.ContainsKey(type))
            {
                var repositoryType = typeof (GenericRepository<T>);
               
                var newRepository = Activator.CreateInstance(repositoryType, this.context);

                this.repositories.Add(type, newRepository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
