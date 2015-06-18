using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.Computers;

namespace _03.PCCatalog
{
    public abstract class Component
    {
        private string name;
        private IDictionary<string,string> details;
        private decimal price;

        protected Component(string name, IDictionary<string,string> details, decimal price)
        {
            this.Name = name;
            this.Details = details;
            this.Price = price;
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                Validate.IsEmpty(value,"Name");
                this.name = value;
            }
        }

        public IDictionary<string, string> Details
        {
            get { return this.details; }
            set { this.details = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                Validate.IsNegative(value,"Price");
                this.price = value;
            }
        }


        


        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (var detail in this.Details)
            {
                str.Append(detail.Key).Append(": ").Append(detail.Value);
            }
            return String.Format("Component name: {0}\nComponent Details: {1}\nComponent price: {2}", this.Name, str,
                this.Price);
        }
    }
}
