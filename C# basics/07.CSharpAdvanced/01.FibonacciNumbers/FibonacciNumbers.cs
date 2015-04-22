using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FibonacciNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter number from Fibonacci order");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("The {0} Fibonacci number is: {1}", n, FindFibonacci(n));

        Main();

    }

    static int FindFibonacci(int n)
    {
        int[] list = new int[n + 2];
        list[0] = list[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            list[i] = list[i - 2] + list[i - 1];
        }
        
        return list[n];
    }
}

