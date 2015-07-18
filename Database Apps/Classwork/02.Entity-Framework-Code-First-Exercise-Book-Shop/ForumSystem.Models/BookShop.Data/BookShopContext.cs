using System.Data.Entity.ModelConfiguration.Conventions;
using BookShop.Data.Migrations;
using ForumSystem.Models;

namespace BookShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookShopContext : DbContext
    {
        public BookShopContext()
            : base("name=BookShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext>());
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

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}