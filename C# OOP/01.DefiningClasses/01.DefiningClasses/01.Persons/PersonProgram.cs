using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Persons
{
    class PersonProgram
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Pesho",28);
            Person p2 = new Person("Maria", 27,"maria@abv.bg");
            Console.WriteLine(p1);
            Console.WriteLine(p2);

        }
    }
}
