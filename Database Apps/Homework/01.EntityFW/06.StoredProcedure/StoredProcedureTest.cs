using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.StoredProcedure
{
    class StoredProcedureTest
    {
        // Use the file in the dir of the project to make a stored procedure. You should add it to the model along with the tables.
        static void Main(string[] args)
        {
            GetProjectsByEmployee("Ruth", "Ellerbrock");
        }

        private static void GetProjectsByEmployee(string firstName, string lastName)
        {
            SoftuniContext context = new SoftuniContext();
            var emp = context.usp_FindProjectsForEmployee(firstName, lastName);

            foreach (var project in emp)
            {
                Console.WriteLine("{0} - {1}, Start date: {2}",
                    project.Name,
                    project.Description.Substring(0, 50) + "...",
                    project.StartDate);
            }
        }
    }
}
