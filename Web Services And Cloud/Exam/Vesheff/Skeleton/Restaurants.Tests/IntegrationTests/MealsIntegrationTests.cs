using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin;
using Restauranteur.Models;
using Restaurants.Data;
using Restaurants.Data.Data;
using Restaurants.Models;
using Restaurants.Services;
using Restaurants.Services.Controllers;
using Restaurants.Services.Models.ViewModels;
using Restaurants.Tests.Models;

namespace Restaurants.Tests.IntegrationTests
{
    [TestClass]
    public class MealsIntegrationTests
    {


        private const string Username = "vuichovanio";
        private const string Password = "topsecret";

        private static TestServer httpTestServer;
        private static HttpClient client;
        private string accessToken;

        private const string EditedName = "Meal Edit";
        private const string EditedId = "2";
        private const string EditedPrice = "9.99";
        public string AccessToken
        {
            get
            {
                if (this.accessToken == null)
                {
                    var loginResponse = this.LoginUser();
                    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);

                    var loginData = loginResponse.Content.ReadAsAsync<LoggedUser>().Result;
                    Assert.IsNotNull(loginData.access_token);

                    this.accessToken = loginData.access_token;
                }

                return this.accessToken;
            }
        }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            ClearDatabase();

            httpTestServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                var startup = new Startup();

                startup.Configuration(appBuilder);
                appBuilder.UseWebApi(config);
            });

            client = httpTestServer.HttpClient;

            SeedDatabase();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            if (httpTestServer != null)
            {
                httpTestServer.Dispose();
            }

            ClearDatabase();
        }

        [TestMethod]
        public void Edit_Meal_When_Invalid_MealName_Should_Return_BadRequest()
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", string.Empty),
                new KeyValuePair<string, string>("typeId", EditedId),
                new KeyValuePair<string, string>("price", EditedPrice),
            });
            var context = new RestaurantsContext();
            var meal = context.Meals.FirstOrDefault(m => m.Name == "Meal 1");
            Assert.IsNotNull(meal);
            var response = this.EditMealByIdLogged(meal.Id, data);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Edit_Meal_Invalid_Data_Should_Return_BadRequest()
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("price", "9.99"),
            });
            var context = new RestaurantsContext();
            var meal = context.Meals.FirstOrDefault(m => m.Name == "Meal 1");
            Assert.IsNotNull(meal);
            var response = this.EditMealByIdLogged(meal.Id, data);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Edit_Meal_When_Logged_Valid_Valid_Data_Should_Return_Ok()
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", EditedName),
                new KeyValuePair<string, string>("typeId", EditedId),
                new KeyValuePair<string, string>("price", EditedPrice),
            });
            var context = new RestaurantsContext();
            var meal = context.Meals.FirstOrDefault(m => m.Name == "Meal 1");
            Assert.IsNotNull(meal);

            var response = this.EditMealByIdLogged(meal.Id, data);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var returnedMeal = response.Content.ReadAsAsync<MealViewModel>().Result;
            Assert.AreEqual(returnedMeal.Name, EditedName);
            var type = context.MealTypes.First(t => t.Id == 2);
            Assert.AreEqual(returnedMeal.Type, type.Name);
            Assert.AreEqual(returnedMeal.Price, 9.99m);
        }

        [TestMethod]
        public void Edit_Meal_When_Logged_Invalid_Id_Should_Return_NotFound()
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", EditedName),
                new KeyValuePair<string, string>("typeId",EditedId),
                new KeyValuePair<string, string>("price", EditedPrice)
            });
            var context = new RestaurantsContext();
            var meal = context.Meals.FirstOrDefault(m => m.Id == int.MaxValue);
            Assert.IsNull(meal);
            var response = this.EditMealByIdLogged(int.MaxValue, data);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        

        [TestMethod]
        public void Edit_Meal_When_No_Owner_Should_Return_401()
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "Meal Edit"),
                new KeyValuePair<string, string>("typeId", "1"),
                new KeyValuePair<string, string>("price", "9.99"),
            });
            var context = new RestaurantsContext();
            var meal = context.Meals.FirstOrDefault(m => m.Name == "Invalid User Meal");
            Assert.IsNotNull(meal);
            Assert.IsTrue(meal.Restaurant.Owner.UserName != Username);

            var response = this.EditMealByIdLogged(meal.Id, data);
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        private static void SeedDatabase()
        {
            var context = new RestaurantsContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            var user = new ApplicationUser()
            {
                Id = "1",
                UserName = Username,
                Email = Username
            };

            var result = userManager.CreateAsync(user, Password).Result;
            if (!result.Succeeded)
            {
                Assert.Fail(string.Join(Environment.NewLine, result.Errors));
            }

            SeedMeals(context);
        }

        private static void ClearDatabase()
        {
            var context = new RestaurantsContext();
            var restaurants = context.Restaurants.ToList();
            
            while (restaurants.Count != 0)
            {
                var restaurant = restaurants[restaurants.Count - 1];
                restaurants.Remove(restaurant);
                context.Restaurants.Remove(restaurant);
            }

            var users = context.Users.ToList();
            while (users.Count != 0)
            {
                var user = users[users.Count - 1];
                users.Remove(user);
                context.Users.Remove(user);
            }

            var meals = context.Meals.ToList();
            while (meals.Count != 0)
            {
                var meal = meals[meals.Count - 1];
                meals.Remove(meal);
                context.Meals.Remove(meal);
            }

            context.SaveChanges();
        }

        private static void SeedMeals(RestaurantsContext context)
        {
            var restaurant = new Restaurant()
            {
                Name = "Restaurant 1",
                OwnerId = "1",
                Ratings = new List<Rating>(),
                Town = new Town() { Id = 1, Name = "Town" }
            };

            context.Meals.Add(new Meal()
            {
                Name = "Meal 1",
                Price = 1,
                Restaurant = restaurant,
                Type = new MealType()
                {
                    Name = "Soup"
                }
            });

           

            context.Meals.Add(new Meal()
            {
                Name = "Invalid User Meal",
                Price = 2,
                Restaurant = new Restaurant()
                {
                    Name = "Restaurant 2",
                    Owner = new ApplicationUser() { UserName = "Maliiiii", PasswordHash = "topsecrethash" },
                    Ratings = new List<Rating>(),
                    Town = new Town() { Id = 2, Name = "Town2" }
                },
                Type = new MealType()
                {
                    Name = "2"
                }
            });
            context.SaveChanges();
        }

        private HttpResponseMessage LoginUser()
        {
            var loginData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", Username),
                new KeyValuePair<string, string>("password", Password),
                new KeyValuePair<string, string>("grant_type", "password"),
            });

            var response = client.PostAsync("api/account/login", loginData).Result;

            return response;
        }

        private void AddAuthenticationToken()
        {
            if (!client.DefaultRequestHeaders.Contains("Authorization"))
            {
                client.DefaultRequestHeaders
                    .Add("Authorization", "Bearer " + this.AccessToken);
            }
        }

        private void RemoveAuthenticatioToken()
        {
            if (client.DefaultRequestHeaders.Contains("Authorization"))
            {
                client.DefaultRequestHeaders
                    .Remove("Authorization");
            }
        }

        private HttpResponseMessage EditMealByIdLogged(int id, FormUrlEncodedContent data)
        {
            this.AddAuthenticationToken();

            return client.PutAsync("/api/meals/" + id, data).Result;
        }

        private HttpResponseMessage EditMealByIdNotLogged(int id, FormUrlEncodedContent data)
        {
            this.RemoveAuthenticatioToken();

            return client.PutAsync("/api/meals/" + id, data).Result;
        }

        
    }
}
