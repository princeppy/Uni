using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ArrayBasedStack
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>();
            arrayStack.Push(5);
            arrayStack.Push(6);
            arrayStack.Push(7);
            arrayStack.Push(8);

            Console.WriteLine(string.Join(", ", arrayStack.ToArray()));

            Console.WriteLine(arrayStack.Pop());

            arrayStack.Push(9);

            Console.WriteLine(string.Join(", ", arrayStack.ToArray()));

            
        }
    }
}
