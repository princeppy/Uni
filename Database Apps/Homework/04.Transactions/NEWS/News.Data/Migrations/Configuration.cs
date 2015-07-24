using News.Models;

namespace News.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using NewsNamespace = News;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NewsEntities context)
        {

            if (!context.News.Any())
            {
                Console.WriteLine("DATABASE GENERATED FROM SCRATCH");
                var newsList = new List<NewsModel>()
                {
                    new NewsModel() {Content = "Qkata novina"},
                    new NewsModel() {Content = "Qkata novina 1"},
                    new NewsModel() {Content = "Qkata novina 2"},
                    new NewsModel() {Content = "Qkata novina 3"},
                    new NewsModel() {Content = "NAI-Qkata novina, brato"}
                };
                context.News.AddRange(newsList);

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("DATABSE ALREADY GENERATED");
            }
        }
    }
}
