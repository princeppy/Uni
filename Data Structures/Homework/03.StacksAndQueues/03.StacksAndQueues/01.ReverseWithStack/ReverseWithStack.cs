using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseWithStack
{
    class ReverseWithStack
    {
        static void Main(string[] args)
        {
            var numbers =
                Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            Stack<int> stack = new Stack<int>(numbers);

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
