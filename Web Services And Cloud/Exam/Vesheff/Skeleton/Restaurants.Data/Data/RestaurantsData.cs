using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restauranteur.Models;
using Restaurants.Data.Interfaces;
using Restaurants.Data.Repositories;
using Restaurants.Models;

namespace Restaurants.Data.Data
{
    public class RestaurantsData : IRestaurantsData
    {
        private RestaurantsContext context;
        private IDictionary<Type, object> repositories;

        public RestaurantsData(RestaurantsContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Authors
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public IRepository<Meal> Meals
        {
            get { return this.GetRepository<Meal>(); }
        }
        
        public IRepository<MealType> MealTypes
        {
            get { return this.GetRepository<MealType>(); }
        }

        public IRepository<Order> Orders
        {
            get { return this.GetRepository<Order>(); }
        }

        public IRepository<Rating> Ratings
        {
            get { return this.GetRepository<Rating>(); }
        }

        public IRepository<Restaurant> Restaurants
        {
            get { return this.GetRepository<Restaurant>(); }
        }

        public IRepository<Town> Towns
        {
            get { return this.GetRepository<Town>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T: class 
        {
            var type = typeof (T);

            if (!this.repositories.ContainsKey(type))
            {
                var repositoryType = typeof (GenericRepository<T>);
               
                var newRepository = Activator.CreateInstance(repositoryType, this.context);

                this.repositories.Add(type, newRepository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
