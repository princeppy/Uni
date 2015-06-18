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
    class Developer:Employee
    {
        private ICollection<Project> projects;  
        public Developer(string firstName, string lastName,string id, decimal salary, ICollection<Project> projects )
            : base(firstName, lastName,id, salary, Departments.Production)
        {
            this.Projects = projects;
        }

        public ICollection<Project> Projects
        {
            get { return projects; }
            set { projects = value; }
        }

        public void AddProject(params Project[] projects)
        {
            foreach (var project in projects)
            {
                Validate.IsNull(project, "project");
                this.Projects.Add(project);
            }

        }

        public void RemoveProject(params Project[] projects)
        {
            foreach (var project in projects)
            {
                Validate.IsNull(project, "project");
                this.Projects.Remove(project);
            }

        }
        public override string ToString()
        {
            StringBuilder str= new StringBuilder();
            str.Append(base.ToString());
            str.Append("***********************\n");
            str.AppendLine("Projects\n-----------------------");
            if (this.Projects.Count == 0)
            {
                str.Append("NONE\n");
            }
            foreach (var project in this.Projects)
            {
                str.Append(project);
            }
            str.Append("-----------------------\n");
            return str.ToString();
        }
    }
}
