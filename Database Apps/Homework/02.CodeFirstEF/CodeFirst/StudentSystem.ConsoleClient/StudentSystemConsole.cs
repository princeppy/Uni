using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using StudentSystem.Data;
using StudentSystem.Models;

namespace StudentSystem.ConsoleClient
{
    class StudentSystemConsole
    {
        static void Main()
        {
            var ctx = new StudentSystemContext();

            Console.WriteLine("All Students");
            Console.WriteLine("-------------------");
            AllStudentsAndSubmssions(ctx);

            Console.WriteLine("All Courses and their Resources");
            Console.WriteLine("-------------------");
            CoursesAndResources(ctx);

            int count = 5;
            Console.WriteLine("All Courses with more than {0} resources", count);
            Console.WriteLine("-------------------");
            CoursesWithMoreThanCountResources(ctx, count);

            var dateToCheck = new DateTime(2014, 12, 20);
            Console.WriteLine("Courses active on date {0}", dateToCheck.ToShortDateString());
            Console.WriteLine("-------------------");
            CoursesActiveOnGivenDate(ctx, dateToCheck);

            Console.WriteLine("Students and courses prices");
            Console.WriteLine("-------------------");
            StudentsAndPricesOfCourses(ctx);
        }

        private static void StudentsAndPricesOfCourses(StudentSystemContext ctx)
        {
            var students = ctx.Students.Select(s => new
            {
                s.Name,
                CourseCount = s.Courses.Count,
                TotalPrice = s.Courses.Sum(c => c.Price),
                AvgPrice = s.Courses.Average(c => c.Price)
            }).OrderByDescending(s => s.TotalPrice)
                .ThenByDescending(s => s.CourseCount)
                .ThenBy(s => s.Name);

            foreach (var student in students)
            {
                Console.WriteLine("{0} Courses: {1}, Total Price: {2}, Average Price: {3}",
                    student.Name, student.CourseCount, student.TotalPrice, student.AvgPrice);
            }
            Console.WriteLine();
        }

        private static void CoursesActiveOnGivenDate(StudentSystemContext ctx, DateTime dateToCheck)
        {
            var courses = ctx.Courses.Where(c => c.StartDate < dateToCheck && c.EndDate > dateToCheck).Select(c => new
            {
                c.Name,
                StudentsCount = c.Students.Count,
                c.StartDate,
                c.EndDate,
                Duration = DbFunctions.DiffDays(c.StartDate, c.EndDate)
            });

            foreach (var course in courses)
            {
                Console.WriteLine("{0} Start: {1}, End: {2}, Duration: {3} days, Students: {4}",
                    course.Name, course.StartDate.ToShortDateString(), course.EndDate.ToShortDateString(), course.Duration,
                    course.StudentsCount);
            }
            Console.WriteLine();
        }

        private static void CoursesWithMoreThanCountResources(StudentSystemContext ctx, int count)
        {
            var coursesWithMoreThan5Resources = ctx.Courses
                .Where(r => r.Resources.Count > count)
                .OrderByDescending(r => r.Resources.Count)
                .ThenByDescending(c => c.StartDate).Select(c => new
                {
                    c.Name,
                    c.Resources.Count
                });

            foreach (var course in coursesWithMoreThan5Resources)
            {
                Console.WriteLine("{0} -> resources count: {1}", course.Name, course.Count);
            }
            Console.WriteLine();
        }

        private static void CoursesAndResources(StudentSystemContext ctx)
        {
            var courses = ctx.Courses
                .OrderBy(c => c.StartDate)
                .ThenBy(c => c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    c.Resources
                });

            foreach (var course in courses)
            {
                Console.WriteLine("{0} {1} -> {2}", course.Name, course.Description,
                    string.Join(", ", course.Resources.Select(r => r.Name).ToArray()));
            }
            Console.WriteLine();
        }

        private static void AllStudentsAndSubmssions(StudentSystemContext ctx)
        {
            var students = ctx.Students.Select(s => new
            {
                s.Name,
                Homeworks = s.Homeworks.Select(h => new
                {
                    h.Content,
                    h.Type
                })
            });

            foreach (var student in students)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Homeworks: [");
                foreach (var homework in student.Homeworks)
                {
                    sb.Append(string.Format("{0} - {1}", homework.Content, homework.Type));
                    sb.Append(", ");
                }
                string str = sb.ToString().Trim().Trim(',');

                sb.Clear();

                sb.Append(str + "]");

                Console.WriteLine(string.Format("{0} -> {1}", student.Name, sb.ToString()));
            }
            Console.WriteLine();
        }
    }
}
