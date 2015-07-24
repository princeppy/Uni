using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.LinkedStack
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedStack<int> link = new LinkedStack<int>();

            link.Push(5);
            link.Push(6);
            link.Push(7);
            link.Push(8);

            Console.WriteLine(link.Pop());
            Console.WriteLine(link.Pop());


            Console.WriteLine(string.Join(", ", link.ToArray()));
        }
    }
}
