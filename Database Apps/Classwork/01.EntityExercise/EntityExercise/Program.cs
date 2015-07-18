using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityExercise
{
    class Program
    {

        static void Main(string[] args)
        {
            var context = new SoftUniEntities();

            //AllEmployeesWithSalaryOver50000(context);

            GetAllEmployeesFromDept(context);
        }

        private static void GetAllEmployeesFromDept(SoftUniEntities context)
        {
            var employeesList = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .OrderByDescending(x => x.Salary)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    DepartmentName = x.Department.Name,
                    x.Salary
                });

            foreach (var employee in employeesList)
            {
                Console.WriteLine("{0} {1} from {2} - ${3:F2}",
                    employee.FirstName,
                    employee.LastName,
                    employee.DepartmentName,
                    employee.Salary);
            }
        }

        private static void AllEmployeesWithSalaryOver50000(SoftUniEntities context)
        {
            var employeesNames = context.Employees
                .Where(x => x.Salary > 50000)
                .Select(x => x.FirstName);


            foreach (var employee in employeesNames)
            {
                Console.WriteLine("First name: {0}", employee);
            }
        }
    }
}
