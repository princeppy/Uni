using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SearchQueries
{
    class SearchQueriesTest
    {
        static void Main(string[] args)
        {
            FindAllProjectsBetween(2001, 2003);

            AdressesByEmployees(10);

            GetEmployeeById(147);

            GetAllDepartmentsWithMoreThanCountEmployees(5);
        }

        private static void GetAllDepartmentsWithMoreThanCountEmployees(int count)
        {
            SoftuniContext context = new SoftuniContext();

            var departments = context.Departments
                .Where(d => d.Employees1.Count > count)
                .OrderBy(d => d.Employees1.Count)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Employees1.FirstOrDefault(e => e.EmployeeID == d.ManagerID).FirstName,
                    ManagerLastName = d.Employees1.FirstOrDefault(e => e.EmployeeID == d.ManagerID).LastName,
                    Employees = d.Employees1.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.HireDate,
                        e.JobTitle
                    })
                });

            foreach (var department in departments)
            {
                Console.WriteLine("--{0} - Manager: {1} {2}, Employees: {3}",
                    department.Name,
                    department.ManagerFirstName,
                    department.ManagerLastName,
                    department.Employees.Count());
            }
        }

        private static void GetEmployeeById(int empId)
        {
            SoftuniContext context = new SoftuniContext();

            var employee = context.Employees
                .Where(e => e.EmployeeID == empId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.Projects.OrderBy(p => p.Name).Select(p => p.Name)
                })
                .FirstOrDefault();

            if (employee!=null)
            {
                Console.WriteLine("{0} {1} - {2} -> Projects:[{3}]",
                employee.FirstName,
                employee.LastName,
                employee.JobTitle,
                string.Join(", ", employee.Projects));
            }
            else
            {
                Console.WriteLine("no such employee id");
            }
            
        }

        private static void AdressesByEmployees(int count)
        {
            SoftuniContext context = new SoftuniContext();

            var adresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Towns.Name)
                .Take(count)
                .Select(a => new
                {
                    a.AddressText,
                    a.Towns.Name,
                    EmployeesCount = a.Employees.Count
                });

            foreach (var adress in adresses)
            {
                Console.WriteLine("{0}, {1} - {2} employees",
                    adress.AddressText,
                    adress.Name,
                    adress.EmployeesCount);
            }
        }

        private static void FindAllProjectsBetween(int start, int end)
        {
            SoftuniContext context = new SoftuniContext();

            var projects = context.Projects
                .Where(p => p.StartDate.Year >= start && p.StartDate.Year <= end)
                .Select(p => new
                {
                    p.Name,
                    p.StartDate,
                    p.EndDate,
                    FirstName =
                        context.Employees.FirstOrDefault(m => m.EmployeeID == p.Employees.FirstOrDefault().ManagerID).FirstName,
                    LastName =
                        context.Employees.FirstOrDefault(m => m.EmployeeID == p.Employees.FirstOrDefault().ManagerID).LastName
                });

            foreach (var project in projects)
            {
                Console.WriteLine("{0} -> [Start:{1}, End:{2}] - Manager:{3} {4}",
                    project.Name,
                    project.StartDate.ToShortDateString(),
                    project.EndDate == null ? "Not specified" : DateTime.Parse(project.EndDate.ToString()).ToShortDateString(),
                    project.FirstName,
                    project.LastName);
            }
        }
    }
}
