using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Arrow
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i < 2 * n; i++)
        {
            if (i == 1)
            {
                Top(n);
            }
            else if (i > 1 & i < n)
            {
                Mid(n);
            }
            else if (i == n)
            {
                Border(n);
            }
            else if(i<2*n-1)
            {
                ArrowHead(n, i - n);
            }
            else
            {
                Pointer(n);
            }

        }

    }


    static void Top(int n)
    {
        string str = new string('.', n / 2);
        string str1 = new string('#', n);

        Console.WriteLine(str + str1 + str);
    }

    static void Mid(int n)
    {
        string str = new string('.', n / 2);
        string str1 = new string('.', n - 2);
        Console.WriteLine(str + "#" + str1 + "#" + str);
    }

    static void Border(int n)
    {
        string str = new string('#', n / 2 + 1);
        string str1 = new string('.', n - 2);
        Console.WriteLine(str + str1 + str);
    }

    static void ArrowHead(int n, int i)
    {
        string str = new string('.', i);
        string str1 = "#";
        string str2 = new string('.', 2 * n - 1 - 2 - i - i);
        Console.WriteLine(str + str1 + str2 + str1 + str);

    }

    static void Pointer(int n)
    {
        string str = new string('.', n - 1);
        Console.WriteLine(str+"#"+str);
    }
}
