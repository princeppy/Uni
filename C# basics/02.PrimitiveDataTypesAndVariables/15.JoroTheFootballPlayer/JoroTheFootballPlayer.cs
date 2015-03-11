using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class JoroTheFootballPlayer
{
    static void Main(string[] args)
    {
        string year = Console.ReadLine();
        double numberHolidays = double.Parse(Console.ReadLine());
        double hometownWeekends = double.Parse(Console.ReadLine());

        //Console.WriteLine("{0}, {1}, {2}",year, numberHolidays, hometownWeekends);
        double playsFootball;

        double weekendsInYear = 52;

        double holidaysPlay = numberHolidays / 2;

        double normalWeekends = weekendsInYear - hometownWeekends;

        double notTiredWeekends = 2 * normalWeekends / 3;

        double playsHomeTown = hometownWeekends;

        playsFootball = holidaysPlay + notTiredWeekends + playsHomeTown;

        if (year == "t")
        {
            playsFootball = playsFootball + 3;
        }

        Console.WriteLine((int)playsFootball);
    }
}

