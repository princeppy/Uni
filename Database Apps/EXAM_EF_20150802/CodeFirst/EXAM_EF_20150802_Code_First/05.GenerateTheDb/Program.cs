using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Data;

namespace _05.GenerateTheDb
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MoviesEntities();

            var p = ctx.Countries.ToList();

            ctx.SaveChanges();


        }
    }
}
