using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurants.Data.Interfaces;

namespace Restaurants.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private IRestaurantsContext context;
        private IDbSet<T> set;

        public GenericRepository()
            : this(new RestaurantsContext())
        {
        }

        public GenericRepository(IRestaurantsContext context)
        {
            if (context != null)
            {
                this.Context = context;
                this.Set = context.Set<T>();
            }
        }

        public IRestaurantsContext Context
        {
            get { return this.context; }
            set { this.context = value; }
        }

        public IDbSet<T> Set
        {
            get { return this.set; }
            set { this.set = value; }
        }

        public void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public T Find(object id)
        {
            return this.Set.Find(id);
        }

        public void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public void Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
        }

        public void Detach(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Detached);
        }

        private void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }
            entry.State = state;
        }
    }
}
