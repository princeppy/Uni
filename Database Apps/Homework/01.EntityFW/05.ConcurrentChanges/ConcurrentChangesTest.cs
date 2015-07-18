using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.ConcurrentChanges
{
    class ConcurrentChangesTest
    {
        static void Main(string[] args)
        {
            //Change the concurrency mode of the FirstName column in table Employees in the Designer

            SoftuniContext contextOne = new SoftuniContext();

            var empFirstNameContextOne = contextOne.Employees.Where(e => e.FirstName.Contains("Ruth"));

            SoftuniContext contextTwo = new SoftuniContext();

            var empFirstNameContextTwo = contextTwo.Employees.Where(e => e.FirstName.Contains("Ruth"));

            foreach (var empFirstName in empFirstNameContextOne)
            {
                empFirstName.FirstName = "Ruth Context One";
            }

            foreach (var empFirstName in empFirstNameContextTwo)
            {
                empFirstName.FirstName = "Ruth Context Two";
            }
           

            contextOne.SaveChanges();
            contextTwo.SaveChanges();

        }
    }
}
