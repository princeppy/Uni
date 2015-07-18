using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.EntityFW
{
    class DAOTest
    {
        static void Main(string[] args)
        {

             Testing problem 2
            var lastId = DAO.FindLastID();
            var employee = new Employee()
            {
                FirstName = "Batman",
                LastName = "Batmanov",
                JobTitle = "Production Technician",
                DepartmentID = 7,
                ManagerID = 16,
                HireDate = new DateTime(2000, 05, 01, 0, 0, 0),
                Salary = 15000.00m,
                Address = new Address()
                {
                    AddressText = "Tam tararam",
                    TownID = 32
                }
            };

            DAO.Add(employee);

            Console.WriteLine(DAO.FindByKey(employee.EmployeeID).FirstName);

            DAO.Modify(DAO.FindByKey(employee.EmployeeID));

            DAO.Delete(employee);

            
            
        }


    }
}
