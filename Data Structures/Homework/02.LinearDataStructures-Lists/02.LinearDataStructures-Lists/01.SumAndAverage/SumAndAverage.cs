using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumAndAverage
{
    class SumAndAverage
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            Console.WriteLine("The sum is {0}", numbers.Sum());

            Console.WriteLine("The average is {0}",numbers.Sum()/numbers.Count());
        }
    }
}
