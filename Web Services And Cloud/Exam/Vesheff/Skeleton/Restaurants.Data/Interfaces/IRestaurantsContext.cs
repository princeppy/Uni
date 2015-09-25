using Restaurants.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restauranteur.Models;

namespace Restaurants.Data.Interfaces
{
    public interface IRestaurantsContext
    {
        IDbSet<Rating> Ratings { get; set; }

        IDbSet<Town> Towns { get; set; }

        IDbSet<Restaurant> Restaurants { get; set; }

        IDbSet<Meal> Meals { get; set; }

        IDbSet<MealType> MealTypes { get; set; }

        IDbSet<Order> Orders { get; set; }

        int SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
