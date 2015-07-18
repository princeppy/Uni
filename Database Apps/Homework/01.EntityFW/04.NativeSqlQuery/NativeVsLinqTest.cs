using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.NativeSqlQuery
{
    class NativeVsLinqTest
    {
        static void Main(string[] args)
        {
            //If you want to see the employees uncomment the line in the below methods

            SoftuniContext context = new SoftuniContext();
            var totalCount = context.Employees.Count();

            var sw = new Stopwatch();
            sw.Start();
            PrintNamesWithNativeSqlQuery(2002);
            Console.WriteLine("Native: {0}", sw.Elapsed);

            sw.Restart();

            PrintNamesWithLinqQuery(2002);
            Console.WriteLine("LINQ: {0}", sw.Elapsed);
        }

        private static void PrintNamesWithNativeSqlQuery(int year)
        {
            SoftuniContext context = new SoftuniContext();

            string nativeQuery =
                "SELECT e.FirstName FROM Employees e" +
                " LEFT JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID" +
                " LEFT JOIN Projects p ON ep.ProjectID = p.ProjectID" +
                " WHERE DATEPART(YY,p.StartDate)={0}";

            var employees = context.Database.SqlQuery<String>(nativeQuery, year);

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}
        }

        private static void PrintNamesWithLinqQuery(int year)
        {
            SoftuniContext context = new SoftuniContext();

            var employees = context.Employees
                .Where(e => e.Projects.Any(p => p.StartDate.Year == year))
                .Select(e => new
                {
                    e.FirstName
                });

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee.FirstName);
            //}
        }
    }
}
