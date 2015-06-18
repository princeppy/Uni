using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
    public interface IManager
    {
        ICollection<Employee> EmployeesList { get; set; }
        void AddEmployees(params Employee[] employees);
    }
}
