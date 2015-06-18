using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyHierarchy.Enums;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            Sale sale1 = new Sale("Software",DateTime.Now,3000m);
            SalesEmployee em = new SalesEmployee("Batman","Batmanov","112008",1800m,new List<Sale>());
            em.AddSale(sale1);

           Manager mgr = new Manager("Superman","Supermanov","112001",3000m,Departments.Marketing, new List<Employee>(){});
            mgr.AddEmployees(em);

            Project prj1 = new Project("Software development",DateTime.Now.AddDays(1),"Nice project");

            Developer dvp = new Developer("Developer","Developerov","112056",2300m,new List<Project>());
            dvp.AddProject(prj1);


            List<Employee> employees = new List<Employee>();

            employees.Add(em);
            employees.Add(mgr);
            employees.Add(dvp);

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
