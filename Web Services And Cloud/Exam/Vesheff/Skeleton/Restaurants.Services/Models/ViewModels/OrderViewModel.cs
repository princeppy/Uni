using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Restaurants.Models;

namespace Restaurants.Services.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public MealViewModel Meal { get; set; }

        public int Quantity { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public static Expression<Func<Order, OrderViewModel>> Create
        {
            get
            {
                return order => new OrderViewModel()
                {
                    Id = order.Id,
                    CreatedOn = order.CreatedOn,
                    Quantity = order.Quantity,
                    Status = order.OrderStatus,
                    Meal = new MealViewModel()
                    {
                        Id = order.Meal.Id,
                        Name = order.Meal.Name,
                        Price = order.Meal.Price,
                        Type = order.Meal.Type.Name
                    }
                };
            }
        }
    }
}