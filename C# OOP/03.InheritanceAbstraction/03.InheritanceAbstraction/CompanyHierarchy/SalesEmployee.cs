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
    class SalesEmployee : Employee
    {
        private ICollection<Sale> sales;
        public SalesEmployee(string firstName, string lastName, string id, decimal salary,ICollection<Sale> sales)
            : base(firstName, lastName, id, salary, Departments.Sales)
        {
            this.Sales = sales;
        }

        public ICollection<Sale> Sales
        {
            get { return sales; }
            set { sales = value; }
        }

        public void AddSale(Sale sale)
        {
            Validate.IsNull(sale, "sale");
            this.Sales.Add(sale);
        }

        public void RemoveSale(Sale sale)
        {
            Validate.IsNull(sale, "sale");
            this.Sales.Remove(sale);
        }

        public override string ToString()
        {

            StringBuilder strList = new StringBuilder();
            strList.Append(base.ToString());
            strList.Append("***********************\n");
            strList.AppendLine("SALES\n-----------------------");
            if (this.Sales.Count == 0)
            {
                strList.Append("NONE\n");
            }
            foreach (var sale in this.Sales)
            {
                strList.AppendLine(sale.ToString());
            }
            strList.Append("-----------------------\n");
            return strList.ToString();
        }
    }
}
