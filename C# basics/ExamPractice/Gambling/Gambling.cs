using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Gambling
{
    static void Main()
    {
        decimal cash = decimal.Parse(Console.ReadLine());
        decimal counter = 0;
        decimal combos = 0;

        string[] deck = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string hand = Console.ReadLine();


        int myHand = 0;
        foreach (var item in hand.Split(' '))
        {
            

            for (int j = 0; j < deck.Length; j++)
            {
                if (item == deck[j])
                {
                    myHand += j;
                }
            }
        }





        for (int i1 = 2; i1 < deck.Length; i1++)
        {
            for (int i2 = 2; i2 < deck.Length; i2++)
            {
                for (int i3 = 2; i3 < deck.Length; i3++)
                {
                    for (int i4 = 2; i4 < deck.Length; i4++)
                    {
                        int value = i1 + i2 + i3 + i4;
                        combos++;
                        if (value > myHand)
                        {
                            counter++;
                        }
                    }
                }
            }
        }
        //Console.WriteLine(counter);
        //Console.WriteLine(combos);
        //Console.WriteLine(counter/combos);

        if (counter / combos >= 0.5m)
        {
            Console.WriteLine("DRAW");
            Console.WriteLine("{0:F2}",2 * cash * counter / combos);
        }
        else
        {
            Console.WriteLine("FOLD");
            Console.WriteLine("{0:F2}",2 * cash * counter / combos);
        }


    }
}