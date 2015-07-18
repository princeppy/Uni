using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.LinkedList
{
    class Program
    {
        private static void Main()
        {
            var list = new LinkedList<int>();

            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");

            list.Add(5);
            list.Add(10);

            Console.WriteLine("Count = {0}", list.Count());

            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");

            list.Remove(1);

            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");

        }
    }
}
