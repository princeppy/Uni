using System.Collections.Generic;
using System.IO;
using Movies.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Movies.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Movies.Data.MoviesEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Movies.Data.MoviesEntities context)
        {

            if (!context.Users.Any())
            {
                string jsonCountries = "";
                string jsonUsers = "";
                string jsonMovies = "";
                string jsonMovieRatings = "";
                string jsonFavouriteMovies = "";

                using (StreamReader file = File.OpenText("../../countries.json"))
                {
                    jsonCountries = file.ReadToEnd();
                }
                using (StreamReader file = File.OpenText("../../users.json"))
                {
                    jsonUsers = file.ReadToEnd();
                }
                using (StreamReader file = File.OpenText("../../movies.json"))
                {
                    jsonMovies = file.ReadToEnd();
                }
                using (StreamReader file = File.OpenText("../../movie-ratings.json"))
                {
                    jsonMovieRatings = file.ReadToEnd();
                }

                using (StreamReader file = File.OpenText("../../users-and-favourite-movies.json"))
                {
                    jsonFavouriteMovies = file.ReadToEnd();
                }




                List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(jsonCountries);
                List<JsonUser> users = JsonConvert.DeserializeObject<List<JsonUser>>(jsonUsers);


                List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonMovies);


                List<MoviesRatingJson> moviesRatings = JsonConvert.DeserializeObject<List<MoviesRatingJson>>(jsonMovieRatings);


                List<UsersFavoriteMoviesJson> favouriteMovies = JsonConvert.DeserializeObject<List<UsersFavoriteMoviesJson>>(jsonFavouriteMovies);



                foreach (var country in countries)
                {
                    context.Countries.Add(country);
                }
                context.SaveChanges();

                foreach (var movie in movies)
                {
                    context.Movies.Add(movie);
                }

                context.SaveChanges();

                foreach (var user in users)
                {
                    var userToAdd = new User()
                    {
                        Country = context.Countries.FirstOrDefault(c => c.Name == user.country),
                        Username = user.username,
                        Email = user.email,
                        Age = user.age,
                        Movies = new List<Movie>()
                    };

                    var favouriteMoviesForCurrentUser =
                        favouriteMovies.Where(fm => fm.username == user.username)
                            .Select(fm => fm.FavouriteMovies).FirstOrDefault().ToList();
                            

                    foreach (var movieToAdd in favouriteMoviesForCurrentUser)
                    {
                        userToAdd.Movies.Add(context.Movies.FirstOrDefault(m => m.Isbn == movieToAdd));
                    }

                    context.Users.Add(userToAdd);

                }
                context.SaveChanges();



                foreach (var moviesRatingJson in moviesRatings)
                {
                    context.Ratings.Add(new Rating()
                    {
                        User = context.Users.FirstOrDefault(u => u.Username == moviesRatingJson.user),
                        Movie = context.Movies.FirstOrDefault(m => m.Isbn == moviesRatingJson.movie),
                        Stars = moviesRatingJson.rating
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
