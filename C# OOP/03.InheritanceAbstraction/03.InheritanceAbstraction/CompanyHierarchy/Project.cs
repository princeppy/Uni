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
    class Project
    {
        private string productName;
        private DateTime startDate;
        private string details;
        private ProjectStatus status;

        public Project(string productName, DateTime startDate, string details)
        {
            this.ProductName = productName;
            this.StartDate = startDate;
            this.Details = details;
            this.Status = ProjectStatus.Open;
        }

        public string ProductName
        {
            get { return productName; }
            set
            {
                Validate.IsNullOrWhitespace(value,"product name");
                productName = value;
            }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                Validate.IsInThePast(value);
                startDate = value;
            }
        }

        public string Details
        {
            get { return details; }
            set
            {
                Validate.IsNullOrWhitespace(value, "details");
                details = value;
            }
        }

        public ProjectStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public void CloseProject()
        {
            this.Status = ProjectStatus.Closed;
        }

        public override string ToString()
        {
            return String.Format("Project name: {0}\nStart date: {1}\nDetails: {2}\nStatus: {3}\n", this.ProductName, this.StartDate,
                this.Details, this.Status);
        }
    }
}
