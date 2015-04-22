using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Sunglasses
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string empty = new string(' ', n);
        string connection = new string('|', n);
        for (int i = 0; i < n; i++)
        {
            if (i == 0 || i == n - 1)
            {
                MakeFrame(n);
                Console.Write(empty);
                MakeFrame(n);
                Console.WriteLine();
            }
            else if (i == n / 2)
            {
                MakeGlasses(n);
                Console.Write(connection);
                MakeGlasses(n);
                Console.WriteLine();
            }
            else
            {
                MakeGlasses(n);
                Console.Write(empty);
                MakeGlasses(n);
                Console.WriteLine();
            }
        }
    }

    static void MakeFrame(int n)
    {
        string str = new string('*', 2 * n);
        Console.Write(str);
    }

    static void MakeGlasses(int n)
    {
        string str = new string('/', 2 * n - 2);
        str = '*' + str + '*';
        Console.Write(str);
    }
}
