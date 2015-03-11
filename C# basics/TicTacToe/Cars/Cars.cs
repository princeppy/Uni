using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Cars
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int dotsOutside = 0;
        int dotsBetween = 0;

        for (int i = 0; i <= n / 2; i++)
        {

            if (i == 0)
            {
                Console.WriteLine("{0}{1}{0}", new string('.', n), new string('*', n));
            }
            else if (i == n / 2)
            {
                dotsBetween = 2 * (i - 1) + n;
                Console.WriteLine("{0}{1}{0}", new string('*', n / 2 + 1), new string('.', dotsBetween));
            }
            else
            {
                dotsOutside = n - i;
                dotsBetween = 2 * (i - 1) + n;
                Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', dotsOutside), '*', new string('.', dotsBetween), '*'
                                                   , new string('.', dotsOutside));

            }

        }
        for (int i = n / 2 + 1; i < n-1; i++)
        {
            dotsBetween = 3 * n - 2;
            Console.WriteLine("{0}{1}{0}", '*', new string('.', dotsBetween));
            
        }
        for (int i = n-1; i < 3 * n / 2 - 1; i++)
        {
            dotsOutside = n / 2;
            dotsBetween = n - 2;
            if (i == 3 * n / 2 - 2)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', dotsOutside), new string('*', dotsOutside + 1), new string('.', dotsBetween)
                                                    , new string('*', dotsOutside + 1), new string('.', dotsOutside));
            }

            else if (i == n - 1)
            {
                Console.WriteLine("{0}", new string('*', 3 * n));
            }
            else
            {
                int dotsWheel = n / 2 - 1;
                dotsOutside = n / 2;
                dotsBetween = n - 2;
                Console.WriteLine("{0}{1}{2}{3}{4}{3}{2}{1}{0}", new string('.', dotsOutside), '*', new string('.', dotsWheel), '*', new string('.', dotsBetween)
                                                               , '*', new string('.', dotsWheel), '*', new string('.', dotsOutside));

            }
        }
    }
}
