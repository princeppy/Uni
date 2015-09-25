using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Restaurants.Data;
using Restaurants.Data.Data;
using Restaurants.Models;
using Restaurants.Services.Models.BindingModels;
using Restaurants.Services.Models.ViewModels;

namespace Restaurants.Services.Controllers
{
    [RoutePrefix("api/meals")]
    public class MealsController : BaseApiController
    {
        public MealsController()
            : base(new RestaurantsData(new RestaurantsContext()))
        {
        }

        public MealsController(IRestaurantsData data)
            : base(data)
        {
            this.Data = data;
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateNewMeal(CreateMealBindingModel newMeal)
        {
            if (newMeal == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var restaurant = this.Data.Restaurants.Find(newMeal.RestaurantId);
            if (restaurant == null)
            {
                return this.BadRequest(string.Format("There is no restaurant with id: {0}", newMeal.RestaurantId));
            }


            var loggedUser = this.User.Identity.GetUserId();
            if (restaurant.OwnerId != loggedUser)
            {
                return
                    this.Unauthorized();
            }

            var mealType = this.Data.MealTypes.Find(newMeal.TypeId);
            if (mealType == null)
            {
                return this.BadRequest(string.Format("There is no meal type with id: {0}", newMeal.TypeId));
            }

            var mealToAdd = new Meal()
            {
                Name = newMeal.Name,
                Price = newMeal.Price,
                Type = mealType
            };

            restaurant.Meals.Add(mealToAdd);
            this.Data.SaveChanges();



            var viewModel = new MealViewModel()
            {
                Id = mealToAdd.Id,
                Name = mealToAdd.Name,
                Price = mealToAdd.Price,
                Type = mealToAdd.Type.Name
            };

            return this.CreatedAtRoute("DefaultApi", new { id = viewModel.Id }, newMeal);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public IHttpActionResult EditExistingMeal(int id, EditMealBindingModel mealData)
        {
            var mealToEdit = this.Data.Meals.Find(id);
            if (mealToEdit == null)
            {
                return this.NotFound();
            }

            var loggedUser = this.User.Identity.GetUserId();
            if (mealToEdit.Restaurant.OwnerId != loggedUser)
            {
                return this.Unauthorized();
            }

            if (mealData == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var type = this.Data.MealTypes.Find(mealData.TypeId);
            if (type == null)
            {
                return this.BadRequest(string.Format("There is no such meal type: {0}", mealData.TypeId));
            }

            mealToEdit.Name = mealData.Name;
            mealToEdit.Price = mealData.Price;
            mealToEdit.Type = type;
            this.Data.SaveChanges();

            var viewModel = new MealViewModel()
            {
                Id = mealToEdit.Id,
                Name = mealToEdit.Name,
                Price = mealToEdit.Price,
                Type = mealToEdit.Type.Name
            };

            return this.Ok(viewModel);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public IHttpActionResult DeleteMeal(int id)
        {
            var mealToDelete = this.Data.Meals.Find(id);

            if (mealToDelete == null)
            {
                return this.NotFound();
            }

            var loggedUser = this.User.Identity.GetUserId();

            if (mealToDelete.Restaurant.OwnerId != loggedUser)
            {
                return this.Unauthorized();
            }

            this.Data.Meals.Delete(mealToDelete);
            this.Data.SaveChanges();

            var message = new
            {
                message = string.Format("Meal #{0} deleted.", id)
            };

            return this.Ok(message);
        }
    }
}
