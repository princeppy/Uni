using News.Models;

namespace AtmNamespace.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using AtmNamespace.Data.Migrations;
    using AtmNamespace.Models;

    public class AtmEntities : DbContext
    {
        // Your context has been configured to use a 'NewsEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'News.Data.NewsEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'NewsEntities' 
        // connection string in the application configuration file.
        public AtmEntities()
            : base("name=AtmEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmEntities,Configuration>());
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<TransactionData> TransactionHistory { get; set; }
    }
}