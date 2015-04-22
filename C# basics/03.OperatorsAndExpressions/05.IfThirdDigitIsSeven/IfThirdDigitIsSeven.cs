using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class IfThirdDigitIsSeven
{
    static void Main(string[] args)
    {
        bool check = false;
        Console.WriteLine("Input an integer:");

        int numberToCheck = int.Parse(Console.ReadLine());

        int number = numberToCheck / 100;

        if (number % 10 == 7)
        {
            check = true;
        }
        Console.WriteLine("Third digit is 7: {0}", check.ToString().ToLower());
    }
}

