using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitSifting
{
    static void Main()
    {
        ulong fall = ulong.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        List<ulong> myList = new List<ulong>();
        for (int i = 0; i < n; i++)
        {
            myList.Add(ulong.Parse(Console.ReadLine()));
        }

        Console.WriteLine( Check(fall, myList)); 
    }

    static int Check(ulong n, List<ulong> list)
    {
        int counter = 0;
        for (int i = 0; i < 64; i++)
        {
            if ((n&(ulong)1<<i)==(ulong)1<<i)
            {
                int tempCounter = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    if ((list[j]&(ulong)1<<i)!=0)
                    {
                        tempCounter++;
                    }
                }
                if (tempCounter==0)
                {
                    counter++;
                }
            }
        }
        return counter;
    }
}


//ulong final = result ^ fall;
//int counter = 0;

//for (int i = 0; i < 64; i++)
//{
//    if ((final&(ulong)(1<<i))==1)
//    {
//        counter++;
//    }
//}
//Console.WriteLine(counter);
