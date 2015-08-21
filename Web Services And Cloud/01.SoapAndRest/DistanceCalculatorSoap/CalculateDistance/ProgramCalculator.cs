using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistanceCalculator.ServiceReferenceCalculator;

namespace DistanceCalculator
{
    class ProgramCalculator
    {
        static void Main()
        {
            CalculatorClient calc = new CalculatorClient();

            double distance = calc.CalcDistanse(new Point() { X = 5, Y = 4 }, new Point() { X = 3.4, Y = -11.6 });

            Console.WriteLine(distance);

        }
    }
}
