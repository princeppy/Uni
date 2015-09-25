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
    public class OrdersController : BaseApiController
    {
        public OrdersController()
            : base(new RestaurantsData(new RestaurantsContext()))
        {
        }

        public OrdersController(IRestaurantsData data)
            : base(data)
        {
            this.Data = data;
        }

        [HttpPost]
        [Route("api/meals/{id}/order")]
        public IHttpActionResult CreateNewOrder(int id, MakeOrderBindingModel newOrder)
        {
            var mealToOrder = this.Data.Meals.Find(id);
            if (mealToOrder == null)
            {
                return this.NotFound();
            }
            if (newOrder == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var loggedUserId = this.User.Identity.GetUserId();

            if (loggedUserId == null)
            {
                return this.Unauthorized();
            }

            var loggedUser = this.Data.Authors.Find(loggedUserId);

            var order = new Order()
            {
                MealId = mealToOrder.Id, 
                UserId = loggedUser.Id,
                CreatedOn = DateTime.Now,
                OrderStatus = OrderStatus.Pending,
                Quantity = newOrder.Quantity,
                User = loggedUser

            };
            this.Data.Orders.Add(order);
            this.Data.SaveChanges();

            return this.Ok(string.Format("Ordered {0} from meal {1}", newOrder.Quantity, mealToOrder.Name));

        }

        [HttpGet]
        [Authorize]
        [Route("api/orders")]
        [ResponseType(typeof(IQueryable<OrderViewModel>))]
        public IHttpActionResult GetAllPendingOrders(int startPage, int limit, int? mealId = null)
        {
            var loggedUserID = this.User.Identity.GetUserId();
            var orders = this.Data.Orders.All()
                .Where(o => o.UserId == loggedUserID && o.OrderStatus == OrderStatus.Pending);

            if (startPage < 0 || (limit<2 || limit>10))
            {
                return this.BadRequest();
            }

            if (mealId != null)
            {
                orders = orders.Where(o => o.MealId == mealId);
            }

            orders = orders.OrderByDescending(o => o.CreatedOn);
            var viewModel = orders
                .Skip(startPage * limit)
                .Take(limit)
                .Select(OrderViewModel.Create);

            return this.Ok(viewModel);
        }
    }
}
