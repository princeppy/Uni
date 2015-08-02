using System.Collections.Generic;
using Movies.Data.Migrations;
using Movies.Models;

namespace Movies.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MoviesEntities : DbContext
    {
        // Your context has been configured to use a 'MoviesEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Movies.Data.MoviesEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MoviesEntities' 
        // connection string in the application configuration file.
        public MoviesEntities()
            : base("name=MoviesEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesEntities, Configuration>());
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Rating>().HasKey(x => new { x.MovieId, x.UserId });
        //    base.OnModelCreating(modelBuilder);
        //}

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Movie> Movies { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }


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