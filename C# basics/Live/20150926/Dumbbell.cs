using System;
using System.Linq;

namespace Dumbbell
{
    class Dumbbell
    {
        static void Main(string[] args)
        {
            // Dumbbell
            // Link: https://judge.softuni.bg/Contests/Practice/Index/78#2

            int size = int.Parse(Console.ReadLine());

            string dotsFront = new string('.', size / 2);
            string symbols = new string('&', size / 2 + 1);
            string dotsMiddle = new string('.', size);

            // Uppermost row
            Console.WriteLine("{0}{1}{2}{1}{0}", dotsFront, symbols, dotsMiddle);


            string dots = new string('.', dotsFront.Count() - 1);
            string stars = new string('*', size / 2);

            // Upper part
            for (int i = 0; i < size / 2; i++)
            {
                if (i == (size / 2 - 1))
                {
                    string handle = new string('=', size);
                    Console.WriteLine("{0}{1}{2}{1}{3}{1}{2}{1}{0}", dots, "&", stars, handle);
                    dots = new string('.', 0);
                }
                else
                {
                    Console.WriteLine("{0}{1}{2}{1}{3}{1}{2}{1}{0}", dots, "&", stars, dotsMiddle);
                    dots = new string('.', dots.Count() - 1);
                }

                stars = new string('*', stars.Count() + 1);
            }

            // Lower part
            dots = new string('.', 1);
            stars = new string('*', stars.Count() - 2);

            for (int i = 0; i < size / 2 - 1; i++)
            {
                Console.WriteLine("{0}{1}{2}{1}{3}{1}{2}{1}{0}", dots, "&", stars, dotsMiddle);

                dots = new string('.', dots.Count() + 1);
                stars = new string('*', stars.Count() - 1);
            }

            // Lowermost row
            Console.WriteLine("{0}{1}{2}{1}{0}", dotsFront, symbols, dotsMiddle);
        }
    }
}
