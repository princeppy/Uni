using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ChessQueens
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());

        int counter = 0;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (i + diff + 1 <= n)
                {
                    counter++;
                    Console.WriteLine("{0}{1} - {2}{3}", (char)(i + 96), j, (char)(i + diff + 1 + 96), j);
                    Console.WriteLine("{2}{3} - {0}{1}", (char)(i + 96), j, (char)(i + diff + 1 + 96), j);
                }
                if (j + diff + 1 <= n)
                {
                    Console.WriteLine("{0}{1} - {2}{3}", (char)(i + 96), j, (char)(i + 96), j + diff + 1);
                    Console.WriteLine("{2}{3} - {0}{1}", (char)(i + 96), j, (char)(i + 96), j + diff + 1);
                }
                if ((i + diff + 1 <= n) && (j + diff + 1 <= n))
                {
                    Console.WriteLine("{0}{1} - {2}{3}", (char)(i + 96), j, (char)(i + diff + 1 + 96), j + diff + 1);
                    Console.WriteLine("{2}{3} - {0}{1}", (char)(i + 96), j, (char)(i + diff + 1 + 96), j + diff + 1);
                }
                if ((i + diff + 1 <= n) && (j - diff - 1 >= 1))
                {
                    Console.WriteLine("{0}{1} - {2}{3}", (char)(i + 96), j, (char)(i + diff + 1 + 96), j - diff- 1);
                }
                if ((i - diff - 1 >=1) && (j + diff + 1 <= n))
                {
                    Console.WriteLine("{0}{1} - {2}{3}", (char)(i + 96), j, (char)(i - diff - 1 + 96), j + diff + 1);
                }
            }
        }
        if (counter==0)
        {
            Console.WriteLine("No valid positions");
        }
        
    }
}
