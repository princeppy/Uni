using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Budget
{
    static void Main()
    {
        int budget = int.Parse(Console.ReadLine());
        int weekdaysOut = int.Parse(Console.ReadLine());
        int weekendHome = int.Parse(Console.ReadLine());

        int rent = 150;
        int weekendPrice = 40;
        //int hometownWeekendPrice = 0;
        int dayPrice = 10;
        int dayOutPrice = 10 + (int)(0.03 * budget);
        int weekDays = 22;


        //int month = 30;
        int weekendTotal = 4;

        int daysNotOut = weekDays - weekdaysOut;
        int weekEndNormal = weekendTotal - weekendHome;




        int expenses = rent + weekEndNormal * weekendPrice + daysNotOut * dayPrice + weekdaysOut * dayOutPrice;

        if (budget > expenses)
        {
            Console.WriteLine("Yes, leftover {0}.", budget - expenses);
        }
        else if (budget < expenses)
        {
            Console.WriteLine("No, not enough {0}.", expenses - budget);
        }
        else
        {
            Console.WriteLine("Exact Budget.");
        }

    }
}