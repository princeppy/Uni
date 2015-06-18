using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculator
{
    class CalculateFractionsProgram
    {
        static void Main(string[] args)
        {

            Fraction fraction1 = new Fraction(22, 7);
            Fraction fraction2 = new Fraction(40, 4);

            Console.WriteLine("\nAdding fractions\n----------------");
            Fraction result1 = fraction1 + fraction2;
            Console.WriteLine("Numerator: {0}",result1.Numerator);
            Console.WriteLine("Denominator: {0}", result1.Denominator);
            Console.WriteLine("Fraction: {0}", result1);

            Console.WriteLine("\nSubtracting fractions\n----------------");
            Fraction result2 = fraction1 - fraction2;
            Console.WriteLine("Numerator: {0}",result2.Numerator);
            Console.WriteLine("Denominator: {0}",result2.Denominator);
            Console.WriteLine("Fraction: {0}",result2);

        }
    }
}
