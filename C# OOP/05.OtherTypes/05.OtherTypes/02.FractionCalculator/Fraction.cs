using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculator
{
    public struct Fraction
    {
        private int denominator;


        public Fraction(int numerator, int denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }
        public int Numerator { get; set; }

        public int Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("You cannot divide by zero!");
                }
                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int commonDenominator = 0;
            if (f1.Denominator == f2.Denominator)
            {
                commonDenominator = f1.Denominator;
            }
            else if (f1.Denominator > f2.Denominator)
            {
                if (f1.Denominator%f2.Denominator == 0)
                {
                    commonDenominator = f1.Denominator;
                }
                else
                {
                    commonDenominator = f1.Denominator*f2.Denominator;
                }
                
            }
            else if (f1.Denominator < f2.Denominator)
            {
                if (f2.Denominator % f1.Denominator == 0)
                {
                    commonDenominator = f2.Denominator;
                }
                else
                {
                    commonDenominator = f1.Denominator * f2.Denominator;
                }
            }

            return new Fraction(
                f1.Numerator*commonDenominator/f1.Denominator +
                f2.Numerator*commonDenominator/f2.Denominator,
                commonDenominator);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int commonDenominator = 0;
            if (f1.Denominator == f2.Denominator)
            {
                commonDenominator = f1.Denominator;
            }
            else if (f1.Denominator > f2.Denominator)
            {
                if (f1.Denominator % f2.Denominator == 0)
                {
                    commonDenominator = f1.Denominator;
                }
                else
                {
                    commonDenominator = f1.Denominator * f2.Denominator;
                }

            }
            else if (f1.Denominator < f2.Denominator)
            {
                if (f2.Denominator % f1.Denominator == 0)
                {
                    commonDenominator = f2.Denominator;
                }
                else
                {
                    commonDenominator = f1.Denominator * f2.Denominator;
                }
            }

            return new Fraction(
                f1.Numerator * commonDenominator / f1.Denominator -
                f2.Numerator * commonDenominator / f2.Denominator,
                commonDenominator);
        }

        public override string ToString()
        {
            return ((decimal)this.Numerator/this.Denominator).ToString();
        }
    }
}
