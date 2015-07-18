using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SortWords
{
    class SortWords
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var orderedWords = words.OrderBy(x => x.ToLower());

            Console.WriteLine(String.Join(" ",orderedWords));
        }
    }
}
