using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using Restaurants.Data;
using Restaurants.Data.Data;
using Restaurants.Models;
using Restaurants.Services.Models.BindingModels;
using Restaurants.Services.Models.ViewModels;

namespace Restaurants.Services.Controllers
{
    [RoutePrefix("api/restaurants")]
    public class RestaurantsController : BaseApiController
    {
        public RestaurantsController()
            : base(new RestaurantsData(new RestaurantsContext()))
        {
        }

        public RestaurantsController(IRestaurantsData data)
            : base(data)
        {
            this.Data = data;
        }

        [HttpGet]
        [ResponseType(typeof(IQueryable<RestaurantViewModel>))]
        public IHttpActionResult GetAllRestaurantsByTown(int townId)
        {
            var restaurants = this.Data.Towns.Find(townId);

            if (restaurants == null)
            {
                return this.Ok(string.Format("There are no restaurants in this town"));
            }

            var viewModel = restaurants.Restaurants.AsQueryable()
                .Select(RestaurantViewModel.Create)
                .OrderByDescending(r => r.Rating)
                .ThenBy(r => r.Name);
            return this.Ok(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateRestaurant(CreateRestaurantBindingModel newRestaurant)
        {
            if (newRestaurant == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var town = this.Data.Towns.Find(newRestaurant.TownId);
            if (town == null)
            {
                return this.BadRequest(string.Format("There is no town with id: {0}", newRestaurant.TownId));
            }

            var loggedUser = this.User.Identity.GetUserId();
            var owner = this.Data.Authors.Find(loggedUser);

            var restaurantToAdd = new Restaurant()
            {
                Name = newRestaurant.Name,
                Owner = owner,
                Meals = new List<Meal>(),
                Ratings = new List<Rating>()
            };

            town.Restaurants.Add(restaurantToAdd);
            this.Data.SaveChanges();

            var restaurantViewModel = new RestaurantViewModel()
            {
                Id = restaurantToAdd.Id,
                Name = restaurantToAdd.Name,
                Rating = null,
                Town = new TownViewModel()
                {
                    Id = town.Id,
                    Name = town.Name
                }
            };

            return this.CreatedAtRoute("DefaultApi",new {id=newRestaurant.TownId},newRestaurant);
        }

        [HttpPost]
        [Authorize]
        [Route("{id}/rate")]
        public IHttpActionResult RateRestaurant(int id, RateRestaurantBindingModel rateModel)
        {
            if (rateModel == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var restaurant = this.Data.Restaurants.Find(id);
            if (restaurant == null)
            {
                return this.NotFound();
            }

            var loggedUser = this.User.Identity.GetUserId();
            if (restaurant.OwnerId == loggedUser)
            {
                return this.BadRequest("Restaurant owner cannot rate his own restaurant");
            }

            if (restaurant.Ratings.Any(r => r.UserId == loggedUser))
            {
                var currentRating = restaurant.Ratings.First(r => r.UserId == loggedUser);
                currentRating.Stars = rateModel.Stars;
                this.Data.SaveChanges();
                return this.Ok(string.Format("User changed his rating for restaurant {0} to {1} stars",restaurant.Name,rateModel.Stars));
            }

            var user = this.Data.Authors.Find(loggedUser);
            var rating = new Rating()
            {
                Stars = rateModel.Stars,
                User = user
            };

            restaurant.Ratings.Add(rating);
            this.Data.SaveChanges();
            return this.Ok(string.Format("User rated restaurant {0} with {1} stars", restaurant.Name, rateModel.Stars));

        }

        [HttpGet]
        [Route("{id}/meals")]
        [ResponseType(typeof(IQueryable<MealViewModel>))]
        public IHttpActionResult GetRestaurantMeals(int id)
        {
            var restaurant = this.Data.Restaurants.Find(id);
            if (restaurant == null)
            {
                return this.NotFound();
            }

            var viewModel = restaurant.Meals.AsQueryable()
                .Select(MealViewModel.Create)
                .OrderBy(m => m.Type)
                .ThenBy(m => m.Name);

            return this.Ok(viewModel);
        }
    }
}
