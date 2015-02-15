using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SortingNumbers
{
    static void Main()
    {
        List<int> list = new List<int>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            list.Add(int.Parse(Console.ReadLine()));
        }

        IEnumerable<int> orderedList = list.OrderBy(x => x).Select(x => x);

        foreach (var num in orderedList)
        {
            Console.WriteLine(num);
        }
    }
}

