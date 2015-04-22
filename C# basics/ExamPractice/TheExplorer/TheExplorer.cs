using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TheExplorer
{
    static int j = 0;
    static int k = 0;
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Print(n, i);

        }
    }

    static void Print(int n, int index)
    {
        string star = "*";

        if (index == 0)
        {
            string str = new string('-', n / 2 - index);
            Console.WriteLine(str + star + str);
        }
        else if (index == 1)
        {
            string str = new string('-', n / 2 - index);
            string str1 = new string('-', index);
            Console.WriteLine(str + star + str1 + star + str);
        }
        else if (index <= n / 2)
        {
            j++;
            string str = new string('-', n / 2 - index);
            string str1 = new string('-', index + j);
            Console.WriteLine(str + star + str1 + star + str);
        }
        else if (index == n - 1)
        {
            string str1 = new string('-', index - n / 2);
            Console.WriteLine(str1 + star + str1);
        }
        else
        {
            j--;
            k = index+1-j;
            string str = new string('-', index + n / 2 + 1 - n);
            string str1 = new string('-', n-k);
            Console.WriteLine(str + star + str1 + star + str);
        }
    }
}

