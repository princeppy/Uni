using System;
using System.Linq;
using BookShop.Data;

namespace BookShop.ConsoleClient
{
    class Program
    {
        static void Main()
        {
            var context = new BookShopContext();

            var categories = context.Categories;

            foreach (var category in categories)
            {
                foreach (var category1 in category.Books)
                {
                    Console.WriteLine(category1.Title);
                }
            }

            
        }
    }
}
