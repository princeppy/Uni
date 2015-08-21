using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Data;
using Newtonsoft.Json;
using System.IO;
using Movies.Models;

namespace _06.QueryTheDatabase
{
    class QueryTheDatabase
    {
        static void Main(string[] args)
        {
            // 1.Adult Movies
            GetAdultMovies();

            // 2.Rated Movies by User

            RatedMoviesByUser(new User()
            {
                Username = "jmeyery"
            });

            // 3.Top 10 Favourite Movies

            GetTop10FavouritedTeenMovies();
        }

        private static void GetTop10FavouritedTeenMovies()
        {
            var ctx = new MoviesEntities();

            var top10MoviesTeenMovies = ctx.Movies
                .Where(m => (int) m.AgeRestriction == 1)
                .OrderByDescending(m => m.Users.Count)
                .ThenBy(m => m.Title)
                .Select(m => new
                {
                    isbn = m.Isbn,
                    title = m.Title,
                    favouritedBy = m.Users.Select(u => u.Username)
                }).Take(10);

            var json = JsonConvert.SerializeObject(top10MoviesTeenMovies, Formatting.Indented);

            Console.WriteLine(json);
            File.WriteAllText(@"..\..\top-10-favourite-movies.json", json);
        }

        private static void RatedMoviesByUser(User user)
        {
            var ctx = new MoviesEntities();

            var users = ctx.Users.Where(u=>u.Username==user.Username).Select(u => new
            {
                username = u.Username,
                ratedMovies = u.Ratings.Where(r => r.User.Username == u.Username).Select(r => new
                {
                    title = r.Movie.Title,
                    userrating = r.Stars,
                    averageRating = r.Movie.Ratings.Sum(mr => mr.Stars)/(double) r.Movie.Ratings.Count()
                }).OrderBy(mm => mm.title)
            }).FirstOrDefault();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            Console.WriteLine(json);
            File.WriteAllText(@"..\..\rated-movies-by-" + user.Username + ".json", json);
        }

        private static void GetAdultMovies()
        {
            var ctx = new MoviesEntities();

            var adultMovies = ctx.Movies
                .Where(m => (int)m.AgeRestriction == 2)
                .Select(m => new
                {
                    title = m.Title,
                    ratingsGiven = m.Ratings.Count()
                }).OrderBy(m => m.title).ThenBy(m => m.ratingsGiven)
                ;

            var json = JsonConvert.SerializeObject(adultMovies, Formatting.Indented);

            Console.WriteLine(json);
            File.WriteAllText(@"..\..\adult-movies.json", json);
        }
    }
}
