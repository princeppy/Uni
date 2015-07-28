using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;
using ProductsShop.Models;
using System.Transactions;

namespace ProductsShop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsShop.Data.ProductsShopEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ProductsShop.Data.ProductsShopEntities context)
        {
            if (!context.Users.Any())
            {
                Console.WriteLine("Start seeding data!");
                var xmlDoc = XDocument.Load("../../../SeedData/users.xml");

                var users = xmlDoc.Descendants("user");

                foreach (XElement user in users)
                {
                    var firstName = user.Attribute("first-name");
                    var lastName = user.Attribute("last-name");
                    var age = user.Attribute("age");

                    var userToAdd = new User();
                    userToAdd.FirstName = firstName != null ? firstName.Value : null;
                    userToAdd.LastName = lastName.Value;

                    if (age != null)
                    {
                        userToAdd.Age = int.Parse(age.Value);
                    }
                    else
                    {
                        userToAdd.Age = null;
                    }

                    context.Users.Add(userToAdd);

                }

                context.SaveChanges();

                string jsonProducts = "";
                string jsonCategories = "";

                using (StreamReader file = File.OpenText("../../../SeedData/products.json"))
                {
                    jsonProducts = file.ReadToEnd();
                }

                using (StreamReader file = File.OpenText("../../../SeedData/categories.json"))
                {
                    jsonCategories = file.ReadToEnd();
                }

                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonProducts);
                List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(jsonCategories);

                var rand = new Random();
                var usersForPorducts = context.Users;

                foreach (var product in products)
                {
                    // Random categories to add to the product
                    List<Category> categoriesToAdd = new List<Category>();
                    var count = rand.Next(1, 4);
                    for (int i = 0; i < count; i++)
                    {
                        var randomCategoryId = rand.Next(categories.First(c => c.Id == c.Id).Id,
                            categories.Count());
                        categoriesToAdd.Add(categories[randomCategoryId]);
                    }

                    // Random seller and random buyer
                    var randomSellerId = rand.Next(usersForPorducts.First(u => u.Id == u.Id).Id,
                        usersForPorducts.Count());
                    var randomBuyerId = rand.Next(usersForPorducts.First(u => u.Id == u.Id).Id,
                        usersForPorducts.Count() * 2);

                    // Product to add
                    var productToAdd = new Product()
                    {
                        Name = product.Name,
                        Price = product.Price,
                        Seller = usersForPorducts.FirstOrDefault(u => u.Id == randomSellerId),
                        Buyer = usersForPorducts.FirstOrDefault(u => u.Id == randomBuyerId),
                        Categories = categoriesToAdd
                    };

                    context.Products.Add(productToAdd);
                }

                context.SaveChanges();

                Console.WriteLine("Data seeding completed!");
            }
        }
    }
}
