using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class UsersFavoriteMoviesJson
    {

        public string  username { get; set; }

        public List<string> FavouriteMovies { get; set; }
    }
}
