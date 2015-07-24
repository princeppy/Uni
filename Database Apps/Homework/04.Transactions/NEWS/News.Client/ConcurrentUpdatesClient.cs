using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Data;

namespace News.ConcurrentUpdates
{
    class ConcurrentUpdatesClient
    {
        static void Main(string[] args)
        {
            // Create the DB
            GenerateDatabase();
            
            // Run the program two times. Complete the first and then try to complete the second :)
            ChangeNewsContent(2);
        }

        private static void GenerateDatabase()
        {
            var ctx = new NewsEntities();
            var news = ctx.News.ToList();
        }

        private static void ChangeNewsContent(int id, bool isConflicted = false)
        {
            if (!isConflicted)
            {
                Console.WriteLine("Application started");
                
                Console.WriteLine(new string('-', 30));
            }

            using (var ctx = new NewsEntities())
            {

                var newsToEdit = ctx.News.FirstOrDefault(n => n.Id == id);

                try
                {
                    if (newsToEdit == null)
                    {
                        throw new ArgumentNullException("There is no such news");
                    }
                    else
                    {
                        if (isConflicted)
                        {
                            Console.WriteLine(new string('-', 30));
                            Console.WriteLine("Enter text if you want to change it or press ENTER to accept the change:");
                            Console.WriteLine(new string('-', 30));
                        }
                        else
                        {
                            Console.WriteLine("Content from DB: {0}", newsToEdit.Content);
                        }
                    }

                    if (!isConflicted)
                    {
                        Console.WriteLine(new string('-', 30));
                        Console.WriteLine("User Input:");
                    }

                    var userInputContent = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(userInputContent.Trim()))
                    {

                        ctx.News.FirstOrDefault(n => n.Id == id).Content = userInputContent;
                    }

                    try
                    {
                        ctx.SaveChanges();
                        Console.WriteLine(new string('-', 30));
                        Console.WriteLine("Changes successfully saved in the DB");
                        Console.WriteLine(new string('-', 30));

                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine(new string('#', 30));
                        Console.WriteLine("Conflict!!!\nContent in DB is changed: {0}", GetChangedContent(id));
                        Console.WriteLine(new string('#', 30));

                        // If there is conflict rerun the change but with isConflicted = true. This changes the user interface :D
                        ChangeNewsContent(id, true);
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("No such news found!");
                }
            }
        }

        private static string GetChangedContent(int id)
        {
            using (var ctx = new NewsEntities())
            {
                var newsToChange = ctx.News.FirstOrDefault(n => n.Id == id);

                return newsToChange.Content;
            }
        }
    }
}
