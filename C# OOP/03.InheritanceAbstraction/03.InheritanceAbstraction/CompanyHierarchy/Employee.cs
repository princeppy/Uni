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
    

    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;
        private Departments department;

        public Employee(string firstName, string lastName, string id, decimal salary, Departments department)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
            this.Department = department;

        }
        public decimal Salary
        {
            get { return salary; }
            set
            {
                Validate.IsNegative(value,"salary");
                salary = value;
            }
        }

        public Departments Department
        {
            get { return department; }
            set { department = value; }
        }

        public override string ToString()
        {
            StringBuilder str= new StringBuilder();
            str.Append(base.ToString());
            str.Append(String.Format("Salary: {0}BGN\nDepartment: {1}\n", this.Salary, this.Department));
            return str.ToString();
        }
    }
}
