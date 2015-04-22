using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PrimeNumberCheck
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter an integer between 1 and 100:");
        int numberToCheck = int.Parse(Console.ReadLine());
        bool prime = true;

        for (int i = 2; i < 10; i++)
        {
            if (numberToCheck % i == 0 && numberToCheck != i || numberToCheck <=1)
            {
                prime = false;
            }
        }
        Console.WriteLine("Is {0} prime: {1}",numberToCheck, prime);
    }
}
