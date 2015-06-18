using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyHierarchy.Validation;

namespace CompanyHierarchy
{
    class Sale
    {
        private string productName;
        private DateTime date;
        private decimal price;

        public Sale(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
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

        public DateTime Date
        {
            get { return date; }
            set
            {
                Validate.IsInTheFuture(value);
                date = value;
            }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                Validate.IsNegative(value,"price");
                price = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Product name: {0}\nSales date: {1}\nPrice: {2}", this.ProductName, this.Date,
                this.Price);
        }
    }
}
