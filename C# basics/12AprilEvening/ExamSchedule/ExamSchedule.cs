using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

class ExamSchedule
{
    static void Main()
    {
        string hour = Console.ReadLine();
        string minutes = Console.ReadLine();
        string partTime = Console.ReadLine();

        int afterHour = int.Parse(Console.ReadLine());
        int afterMinutes = int.Parse(Console.ReadLine());

        string timeString = hour + ":" + minutes + " " + partTime;

        DateTime timeGiven = DateTime.Parse(timeString);
        DateTime examTime = timeGiven.AddHours(afterHour).AddMinutes(afterMinutes);


        var str = examTime.ToString("hh:mm:tt", new CultureInfo("en-US"));
        
        Console.WriteLine(str);
    
       
    }
}
