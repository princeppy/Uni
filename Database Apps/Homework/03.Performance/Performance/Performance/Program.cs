using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    class ShowData
    {
        static void Main()
        {
            var ctx = new AdsContext();

            //Please uncomment and test one by one to make it easier to track

            //// Problem 01
            //  Console.WriteLine("PROBLEM 1");
            //Console.WriteLine("====================");
            //// 29 SQL Statements
            //var swWithoutInclude = WithoutInclude(ctx);

            //// 1 SQL Statement
            //var swWithInclude = WithInclude(ctx);

            //Console.WriteLine("\nTIMES PROBLEM 1:");
            //Console.WriteLine("------------------------------");
            //Console.WriteLine("Without Include: {0}", swWithoutInclude);
            //Console.WriteLine("With Include: {0}", swWithInclude);
            //Console.WriteLine();


            ////Problem 02
            //Console.WriteLine("PROBLEM 2");
            //Console.WriteLine("====================");
            //Console.WriteLine("\nTIMES PROBLEM 2:");
            //Console.WriteLine("------------------------------");
            //int count = 10;
            //// 40 SQL Statements
            //ctx.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS;");
            //var allAdsTime = GetAllAds(ctx);
            //Console.WriteLine("Slow way: {0}", allAdsTime);

            //// 1 SQL Statement
            //ctx.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS;");
            //var allAdsOptimizedTime = GetAllAdsOptimized(ctx);
            //Console.WriteLine("Optimized way: {0}", allAdsOptimizedTime);
            //Console.WriteLine();


            //// Problem 03
            //Console.WriteLine("PROBLEM 3");
            //Console.WriteLine("====================");
            //ctx.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS;");
            //var slow = SlowWayProblem03(ctx);
            //ctx.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS;");
            //var optimized = OptimizedProblem03(ctx);
            //Console.WriteLine("\nTIMES PROBLEM 3:");
            //Console.WriteLine("------------------------------");
            //Console.WriteLine("Slow way: {0}", slow);
            //Console.WriteLine("Optimized way: {0}", optimized);
        }

        private static TimeSpan OptimizedProblem03(AdsContext ctx)
        {
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            var ads1 = ctx.Ads.Select(a => a.Title);

            foreach (var ad in ads1)
            {
                Console.WriteLine(ad);
            }
            return sw1.Elapsed;
        }

        private static TimeSpan SlowWayProblem03(AdsContext ctx)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var ads = ctx.Ads;

            foreach (var ad in ads)
            {
                Console.WriteLine(ad.Title);
            }

            return sw.Elapsed;
        }

        private static TimeSpan GetAllAdsOptimized(AdsContext ctx)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var ads = ctx.Ads
                .Where(a => a.AdStatus.Status == "Published")
                .Include(a => a.Category)
                .Include(a => a.Town).ToList();

            //foreach (var ad in ads)
            //{
            //    Console.WriteLine("{0}, category: {1}, town: {2}",
            //        ad.Title,
            //        ad.CategoryId == null ? "N/A" : ad.Category.Name,
            //        ad.TownId == null ? "N/A" : ad.Town.Name);
            //}
            sw.Stop();
            return sw.Elapsed;
        }

        private static TimeSpan GetAllAds(AdsContext ctx)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var ads = ctx.Ads
                .ToList()
                .Where(a => a.AdStatus.Status == "Published")
                .OrderBy(a => a.Date)
                .Select(a => new
                {
                    a.Title,
                    Category = a.CategoryId == null ? "N/A" : a.Category.Name,
                    Town = a.TownId == null ? "N/A" : a.Town.Name
                })
                .ToList();

            //foreach (var ad in ads)
            //{
            //    Console.WriteLine("{0}, category: {1}, town: {2}",
            //        ad.Title,
            //        ad.Category,
            //        ad.Town);
            //}
            //sw.Stop();
            return sw.Elapsed;
        }

        private static TimeSpan WithInclude(AdsContext ctx)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            var ads1 = ctx.Ads
                .Include(a => a.AdStatus)
                .Include(a => a.Category)
                .Include(a => a.Town)
                .Include(a => a.AspNetUser);

            foreach (var ad in ads1)
            {
                Console.WriteLine(
                    "{0}, status: {1}, category: {2}, town: {3}, user: {4}",
                    ad.Title,
                    ad.AdStatus.Status,
                    ad.CategoryId == null ? "N/A" : ad.Category.Name,
                    ad.TownId == null ? "N/A" : ad.Town.Name,
                    ad.AspNetUser.Name);
            }
            sw.Stop();
            return sw.Elapsed;
        }

        private static TimeSpan WithoutInclude(AdsContext ctx)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ctx = new AdsContext();

            var ads = ctx.Ads;

            foreach (var ad in ads)
            {
                Console.WriteLine(
                    "{0}, status: {1}, category: {2}, town: {3}, user: {4}",
                    ad.Title,
                    ad.AdStatus.Status,
                    ad.CategoryId == null ? "N/A" : ad.Category.Name,
                    ad.TownId == null ? "N/A" : ad.Town.Name,
                    ad.AspNetUser.Name
                    );
            }
            sw.Stop();
            return sw.Elapsed;
        }
    }
}
