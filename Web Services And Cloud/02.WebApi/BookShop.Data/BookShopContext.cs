using System.Data.Entity.ModelConfiguration.Conventions;
using BookShop.Data.Migrations;
using BookShop.Data.Repositories;
using ForumSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookShopContext : IdentityDbContext<ApplicationUser>, IBookShopContext
    {
        public BookShopContext()
            : base("name=BookShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>());
        }

        public static BookShopContext Create()
        {
            return new BookShopContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Book>()
                .HasMany(b => b.RelatedBooks)
                .WithMany()
                .Map(
                    m =>
                    {
                        m.MapLeftKey("BookID");
                        m.MapRightKey("RelatedBookID");
                        m.ToTable("BooksRelatedBooks");
                    });

            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public virtual new IDbSet<ApplicationRole> Roles { get; set; }

        //public IDbSet<Purchase> Purchases { get; set; }


        public new int SaveChanges()
        {
            return base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}