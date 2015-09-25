﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Restaurants.Models;

namespace Restaurants.Services.Models.ViewModels
{
    public class MealViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Type { get; set; }

        public static Expression<Func<Meal, MealViewModel>> Create
        {
            get
            {
                return meal => new MealViewModel()
                {
                    Id = meal.Id,
                    Name = meal.Name,
                    Type = meal.Type.Name,
                    Price = meal.Price
                    
                };
            }
        }
    }
}