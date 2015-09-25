using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restauranteur.Models;
using Restaurants.Data.Interfaces;
using Restaurants.Models;

namespace Restaurants.Data.Data
{
    public interface IRestaurantsData
    {
        IRepository<ApplicationUser> Authors { get; }

        IRepository<Rating> Ratings { get; }

        IRepository<Town> Towns { get; }

        IRepository<Restaurant> Restaurants { get; }

        IRepository<Meal> Meals { get; }

        IRepository<MealType> MealTypes { get; }

        IRepository<Order> Orders { get; }

        int SaveChanges();
    }
}
