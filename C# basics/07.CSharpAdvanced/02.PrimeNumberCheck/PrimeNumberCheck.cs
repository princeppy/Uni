using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PrimeNumberCheck
{
    static void Main()
    {
        Console.WriteLine("Input the number to check");
        ulong n = ulong.Parse(Console.ReadLine());
        Console.Write("The number {0} is prime: ",n);
        CheckPrime(n);

        Main();
    }

    static void CheckPrime(ulong n)
    {
        bool check = true;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % (ulong)i == 0 && n!=(ulong)i)
            {
                check = false;
                break;
            }
        }
        if (n==0 || n==1)
        {
            check = false;
        }
        Console.WriteLine(check);
    }
}

