using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DoubleDowns
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> list = new List<int>();
        int vertical = 0;
        int leftDia = 0;
        int rightDia = 0;
        for (int i = 0; i < n; i++)
        {
            list.Add(int.Parse(Console.ReadLine()));
        }

        for (int k = 0; k < 32; k++)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                    if (((list[i]&(1<<k))==(1<<k)) && ((list[i+1]&(1<<k))==(1<<k)))
                    {
                        vertical++;
                    }

                    if (((list[i]&(1<<k))==(1<<k)) && ((list[i+1]&(1<<k+1))==(1<<k+1)))
                    {
                        leftDia++;
                    }

                    if (((list[i] & (1 << k+1)) == (1 << k+1)) && ((list[i + 1] & (1 << k )) == (1 << k )))
                    {
                        rightDia++;
                    }
            }
        }
        Console.WriteLine(rightDia);
        Console.WriteLine(leftDia);
        Console.WriteLine(vertical);
    }
}

