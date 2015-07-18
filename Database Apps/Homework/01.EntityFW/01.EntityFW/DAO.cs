using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.EntityFW
{
    public static class DAO
    {
        public static object FindLastID()
        {
            SoftuniContext context = new SoftuniContext();
            var lastEmployee = context.Employees
                .OrderByDescending(e=>e.EmployeeID)
                .Take(1)
                .First();

            return lastEmployee.EmployeeID;
        }
        public static void Add(Employee employee)
        {
            SoftuniContext context = new SoftuniContext();
            var employees = context.Employees;

            employees.Add(employee);

            context.SaveChanges();
        }

        public static Employee FindByKey(object key)
        {
            SoftuniContext context = new SoftuniContext();
            var employee = context.Employees.
                FirstOrDefault(x => (object)x.EmployeeID == key);

            return employee;
        }

        public static void Modify(Employee employee)
        {
            SoftuniContext context = new SoftuniContext();
            var employees = context.Employees
                .Where(e => e.FirstName == employee.FirstName);

            foreach (var emp in employees)
            {
                emp.FirstName = "Superman";
            }

            context.SaveChanges();
        }

        public static void Delete(Employee employee)
        {
            SoftuniContext context = new SoftuniContext();
            var employees = context.Employees
                .RemoveRange(context.Employees
                                    .Where(e => e.FirstName == "Superman"));

            context.SaveChanges();
            
        }
    }
}
