using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DifferenceBetweenDates
{
    static void Main()
    {
        Console.WriteLine("\nEnter a start date");
        DateTime startDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Enter an end date");
        DateTime endDate = DateTime.Parse(Console.ReadLine());

        double daysBetween = endDate.Subtract(startDate).TotalDays;
        Console.WriteLine("The days between start date and end date are: {0}",daysBetween);

        Main();
    }
}

