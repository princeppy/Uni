using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.Computers;

namespace _03.PCCatalog
{
    public class Computer
    {
        private string name;
        private IList<Component> components;
        private decimal price;

        public Computer(string name, IList<Component> components)
        {
            this.Name = name;
            this.Components = components;
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

        public IList<Component> Components
        {
            get { return this.components; }
            set { this.components = value; }
        }

        public decimal Price
        {
            get
            {
                decimal price = this.Components.Sum(component => component.Price);
                return price;
            }
          
        }


        public void AddComponent(Component component)
        {
            this.Components.Add(component);
        }

        public void RemoveComponent(Component component)
        {
            this.Components.Remove(component);
        }


        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (var component in this.Components)
            {
                str.AppendLine(component.ToString()).AppendLine("******************");
            }
            return String.Format("PC Name: {0}\n==================\nPC Components:\n------------------\n{1}PC Price: {2}", this.Name, str,
                this.Price);
        }
    }
}
