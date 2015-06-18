using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyHierarchy.Enums;
using CompanyHierarchy.Interfaces;
using CompanyHierarchy.Validation;

namespace CompanyHierarchy
{
    

    public class Manager : Employee, IManager
    {
        private ICollection<Employee> employeesList;

        public Manager(string firstName, string lastName, string id, decimal price,Departments department,ICollection<Employee> employees)
            : base(firstName, lastName, id,price,department)
        {
            this.EmployeesList = employees;
        }
        public ICollection<Employee> EmployeesList
        {
            get { return employeesList; }
            set { employeesList = value; }
        }

        public void AddEmployees(params Employee[] employees)
        {
            foreach (var employee in employees)
            {
                Validate.IsNull(employee,"employee");
                this.EmployeesList.Add(employee);
            }

        }

        public void RemoveEmployees(params Employee[] employees)
        {
            foreach (var employee in employees)
            {
                Validate.IsNull(employee,"employee");
                this.EmployeesList.Remove(employee);
            }

        }

        public override string ToString()
        {
            StringBuilder strList = new StringBuilder();
            strList.Append(base.ToString());
            strList.Append("***********************\n");
            strList.AppendLine("Employees\n-----------------------");
            if (this.EmployeesList.Count == 0)
            {
                strList.Append("NONE\n");
            }
            foreach (var employee in this.EmployeesList)
            {
                strList.AppendLine(employee.FirstName+" "+employee.LastName);
            }
            strList.Append("-----------------------\n");
            return strList.ToString();

        }
    }
}
