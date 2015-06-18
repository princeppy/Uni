using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyHierarchy.Interfaces;
using CompanyHierarchy.Validation;

namespace CompanyHierarchy
{
    public abstract class Person:IPerson
    {
        private string firstName;
        private string lastName;
        private string id;

        protected Person(string firstName, string lastName,string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                Validate.IsNullOrWhitespace(value,"first name");
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                Validate.IsNullOrWhitespace(value, "last name");
                this.lastName = value;
            }
        }

        public string Id
        {
            get { return this.id; }
            set
            {
                Validate.IsNullOrWhitespace(value, "id");
                this.id = value;
            }
        }

        public virtual void RepresentSelf()
        {
            Console.WriteLine("Hello I am {0} {1}",this.FirstName,this.LastName);
        }


        public override string ToString()
        {
            return String.Format("Name: {0} {1}\nID: {2}\n", this.FirstName, this.LastName,this.Id);

        }
    }
}
