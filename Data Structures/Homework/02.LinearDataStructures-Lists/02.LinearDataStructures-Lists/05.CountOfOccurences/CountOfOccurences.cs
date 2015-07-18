using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CountOfOccurences
{
    class CountOfOccurences
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).OrderBy(x => x).ToList();

            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (var key in numbers)
            {
                if (dict.ContainsKey(key))
                {
                    dict[key]++;
                }
                else
                {
                    dict[key] = 1;
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
            }

        }
    }
}
