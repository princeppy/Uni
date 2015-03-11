using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Plane
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int dotsOut = n + n / 2;
        int dotsBetween = 1;
        Console.WriteLine("{0}*{0}", new string('.', dotsOut));
        for (int i = 0; i < n; i++)
        {


            if (i > (n / 2 + 1))
            {
                dotsOut -= 2;
                dotsBetween += 2;
                Console.WriteLine("{0}*{1}*{0}", new string('.', dotsOut), new string('.', dotsBetween));
                dotsBetween += 2;
            }
            else if (i <= (n / 2 + 1))
            {
                dotsOut--;

                Console.WriteLine("{0}*{1}*{0}", new string('.', dotsOut), new string('.', dotsBetween));
                dotsBetween += 2;
            }
        }


        dotsOut = n - 4;
        int dotsTemp = 1;

        for (int i = 0; i < n / 2; i++)
        {
            if (i == 0)
            {
                Console.WriteLine("*{0}*{1}*{0}*", new string('.', n - 2), new string('.', n));
            }

            else
            {

                Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*", new string('.', dotsOut), new string('.', dotsTemp), new string('.', n));
                dotsOut -= 2;
                dotsTemp += 2;
            }

        }
        dotsOut = n - 1;
        dotsBetween = n;
        for (int i = 0; i < n - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}",new string('.',dotsOut),new string('.',dotsBetween));
            dotsOut--;
            dotsBetween += 2;
        }
        Console.WriteLine("{0}",new string('*',3*n));

    }
}
