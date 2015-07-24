using News.Data.Migrations;
using News.Models;

namespace News.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using News.Data.Migrations;
    using News.Models;

    public class NewsEntities : DbContext
    {
        // Your context has been configured to use a 'NewsEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'News.Data.NewsEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'NewsEntities' 
        // connection string in the application configuration file.
        public NewsEntities()
            : base("name=NewsEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsEntities,Configuration>());
        }

        public virtual DbSet<NewsModel> News { get; set; }
    }
}