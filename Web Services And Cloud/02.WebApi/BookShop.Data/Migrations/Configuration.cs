using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Configuration;
using System.Threading.Tasks;
using ForumSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web;

namespace BookShop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShopContext>
    {
        public Configuration()
        {
            //Disabled at prodution
            //AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            //this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "BookShop.Data.BookShopContext";
        }

        protected override void Seed(BookShopContext context)
        {
            
            if (!context.Users.Any())
            {
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new BookShopContext()));

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new BookShopContext()));

                var user = new ApplicationUser()
                {
                    UserName = "SuperUser",
                    Email = "kovri@kovrii.bg",
                    EmailConfirmed = true,

                };

                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 3,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };

                Task<IdentityResult> result = manager.CreateAsync(user, "admin");

                var a = manager.Create(user);

                if (!roleManager.Roles.Any())
                {
                    roleManager.Create(new IdentityRole { Name = "Admin" });
                    roleManager.Create(new IdentityRole { Name = "User" });
                }

                var adminUser = manager.FindByNameAsync("SuperUser").Result;

                manager.AddToRoles(adminUser.Id, new string[] { "Admin" });
            }

            if (!context.Authors.Any())
            {
                using (var reader = new StreamReader("../../../authors.txt"))
                {
                    var currentLine = reader.ReadLine();

                    currentLine = reader.ReadLine();

                    while (currentLine != null)
                    {

                        var names = currentLine.Split(new char[] { ' ' }, 2);
                        var firstName = names[0];
                        var lastName = names[1];

                        context.Authors.AddOrUpdate(new Author()
                        {
                            FirstName = firstName,
                            LastName = lastName
                        });

                        currentLine = reader.ReadLine();
                    }

                }
                context.SaveChanges();
            }


            if (!context.Categories.Any())
            {
                using (var reader = new StreamReader("../../../categories.txt"))
                {
                    var currentLine = reader.ReadLine();

                    while (currentLine != null)
                    {
                        var category = currentLine;

                        context.Categories.AddOrUpdate(new Category()
                        {
                            Name = category
                        });

                        currentLine = reader.ReadLine();
                    }
                }
                context.SaveChanges();
            }


            if (!context.Books.Any())
            {
                using (var reader = new StreamReader("../../../books.txt"))
                {
                    var currentLine = reader.ReadLine();
                    Random random = new Random();
                    currentLine = reader.ReadLine();
                    var authors = context.Authors.ToArray();

                    while (currentLine != null)
                    {
                        var rand = random.Next(0, authors.Length);
                        var author = authors[rand];
                        var array = currentLine.Split(new char[] { ' ' }, 6);
                        var edition = (EditionType)int.Parse(array[0]);
                        var releaseDate = DateTime.Parse(array[1]);
                        var copies = int.Parse(array[2]);
                        var price = decimal.Parse(array[3]);
                        var ageRestriction = (AgeRestriction)int.Parse(array[4]);
                        var title = array[5];

                        var categoriesCount = random.Next(0, context.Categories.Count());
                        var listOfCategories = new List<Category>();

                        for (int i = 0; i < categoriesCount; i++)
                        {
                            var index = random.Next(0, categoriesCount);
                            listOfCategories.Add(context.Categories.ToArray()[index]);
                        }

                        context.Books.AddOrUpdate(new Book()
                        {
                            AgeRestriction = ageRestriction,
                            Author = author,
                            Copies = copies,
                            ReleaseDate = releaseDate,
                            Price = price,
                            Title = title,
                            EditionType = edition,
                            Categories = listOfCategories
                        });

                        currentLine = reader.ReadLine();
                    }
                    context.SaveChanges();
                }


            } if (!context.Authors.Any())
            {


                using (var reader = new StreamReader("../../../authors.txt"))
                {
                    var currentLine = reader.ReadLine();

                    currentLine = reader.ReadLine();

                    while (currentLine != null)
                    {

                        var names = currentLine.Split(new char[] { ' ' }, 2);
                        var firstName = names[0];
                        var lastName = names[1];

                        context.Authors.AddOrUpdate(new Author()
                        {
                            FirstName = firstName,
                            LastName = lastName
                        });

                        currentLine = reader.ReadLine();
                    }

                }
                context.SaveChanges();
            }


            if (!context.Categories.Any())
            {
                using (var reader = new StreamReader("../../../categories.txt"))
                {
                    var currentLine = reader.ReadLine();

                    while (currentLine != null)
                    {
                        var category = currentLine;

                        context.Categories.AddOrUpdate(new Category()
                        {
                            Name = category
                        });

                        currentLine = reader.ReadLine();
                    }
                }
                context.SaveChanges();
            }


            if (!context.Books.Any())
            {
                using (var reader = new StreamReader("../../../books.txt"))
                {
                    var currentLine = reader.ReadLine();
                    Random random = new Random();
                    currentLine = reader.ReadLine();
                    var authors = context.Authors.ToArray();

                    while (currentLine != null)
                    {
                        var rand = random.Next(0, authors.Length);
                        var author = authors[rand];
                        var array = currentLine.Split(new char[] { ' ' }, 6);
                        var edition = (EditionType)int.Parse(array[0]);
                        var releaseDate = DateTime.Parse(array[1]);
                        var copies = int.Parse(array[2]);
                        var price = decimal.Parse(array[3]);
                        var ageRestriction = (AgeRestriction)int.Parse(array[4]);
                        var title = array[5];

                        var categoriesCount = random.Next(0, context.Categories.Count());
                        var listOfCategories = new List<Category>();

                        for (int i = 0; i < categoriesCount; i++)
                        {
                            var index = random.Next(0, categoriesCount);
                            listOfCategories.Add(context.Categories.ToArray()[index]);
                        }

                        context.Books.AddOrUpdate(new Book()
                        {
                            AgeRestriction = ageRestriction,
                            Author = author,
                            Copies = copies,
                            ReleaseDate = releaseDate,
                            Price = price,
                            Title = title,
                            EditionType = edition,
                            Categories = listOfCategories
                        });

                        currentLine = reader.ReadLine();
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}

