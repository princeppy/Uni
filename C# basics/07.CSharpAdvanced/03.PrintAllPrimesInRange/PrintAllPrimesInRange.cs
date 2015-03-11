using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PrintAllPrimesInRange
{
    static void Main()
    {
        int startNum = int.Parse(Console.ReadLine());
        int endNum = int.Parse(Console.ReadLine());

        List<int> finalList = FindPrimesInRange(startNum, endNum);

        if (finalList.Count == 0)
        {
            Console.WriteLine("(empty list)");
        }
        else
        {
            Console.WriteLine("All the prime numbers in the range {0} to {1} are:\n-------------------------", startNum, endNum);
            PrintList(finalList);
        }

        Main();
    }

    static List<int> FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primeList = new List<int>();

        for (int i = startNum; i <= endNum; i++)
        {
            bool check = true;
            for (int j = 2; j <= Math.Sqrt(i); j++)
            {
                if (i % j == 0 && i != j)
                {
                    check = false;
                    break;
                }
            }
            if (i == 0 || i == 1)
            {
                check = false;
            }
            if (check)
            {
                primeList.Add(i);
            }
        }
        return primeList;
    }

    static void PrintList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (i == list.Count - 1)
            {
                Console.WriteLine(list[i]);
            }
            else
            {
                Console.Write(list[i] + ", ");
            }
        }
    }
}

