using ProductsShop.Data.Migrations;
using ProductsShop.Models;

namespace ProductsShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductsShopEntities : DbContext
    {
        // Your context has been configured to use a 'ProductsShopEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ProductsShop.Data.ProductsShopEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ProductsShopEntities' 
        // connection string in the application configuration file.

        public ProductsShopEntities()
            : base("name=ProductsShopEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductsShopEntities, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Friends).WithMany().Map(m =>
            {
                m.MapLeftKey("UserId");
                m.MapRightKey("FriendId");
                m.ToTable("UserFriends");
            });

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProductsSold)
                .WithRequired(p => p.Seller)
                .Map(m =>
                {
                    m.MapKey("SellerId");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProductsBought)
                .WithOptional(p => p.Buyer)
                .Map(m =>
                {
                    m.MapKey("BuyerId");
                });

            modelBuilder.Entity<Product>().
            HasMany(c => c.Categories).
            WithMany(p => p.Products).
            Map(
             m =>
             {
                 m.MapLeftKey("ProductId");
                 m.MapRightKey("CategoryId");
                 m.ToTable("ProductsCategories");
             });

            base.OnModelCreating(modelBuilder);
        }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<User> Users { get; set; }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}