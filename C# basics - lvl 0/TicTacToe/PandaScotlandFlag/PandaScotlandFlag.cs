using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PandaScotlandFlag
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int middle = n - 2;
        int end = 0;
        char letter = 'A';

        if (n == 1)
        {
            Console.WriteLine("A");
        }
        else
        {
            Console.WriteLine("{0}{1}{2}", letter, new string('#', middle), ++letter);
            for (int i = 1; i <= n / 2 - 1; i++)
            {
                end++;
                middle -= 2;
                Console.WriteLine("{0}{1}{2}{3}{0}", new string('~', end), ++letter, new string('#', middle), ++letter);
                if (letter >= 'Z')
                {
                    letter = '@';
                }

            }

            Console.WriteLine("{0}{1}{0}", new string('-', n / 2), ++letter);

            if (letter >= 'Z')
            {
                letter = '@';
            }
            for (int i = 1; i <= n / 2 - 1; i++)
            {
                if (letter == 'Y')
                {
                    Console.WriteLine("{0}{1}{2}{3}{0}", new string('~', end), ++letter, new string('#', middle), 'A');
                    letter = 'A';
                }
                else
                {
                    Console.WriteLine("{0}{1}{2}{3}{0}", new string('~', end), ++letter, new string('#', middle), ++letter);
                }
                end--;
                middle += 2;
                if (letter >= 'Z')
                {
                    letter = '@';
                }
            }

            Console.WriteLine("{0}{1}{2}", ++letter, new string('#', middle), ++letter);
        }
    }
}
