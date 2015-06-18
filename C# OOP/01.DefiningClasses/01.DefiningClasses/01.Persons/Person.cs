using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Persons
{
    class Person
    {
        private string name;
        private int age;
        private string email;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public Person(string name, int age, string email = null)
            : this(name, age)
        {

            this.Email = email;
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentNullException("The name must be at least 2 chartacters long");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 1 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("The age in the interval [1,120]");
                }
                this.age = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                Regex reg = new Regex("([A-Za-z0-9]+[A-Za-z0-9_.-]+(?<![._-]))(@[A-Za-z.-]+(?<![.-]))\\.([A-Za-z]{2,3})");
                if (!reg.IsMatch(value))
                {
                    throw new ArgumentException("The email is not valid");
                }
                this.email = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}: {1} years old, email: {2}", this.Name, this.Age, this.Email??"n/a");
        }
    }
}
