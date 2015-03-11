using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BookOrders
{
    static void Main()
    {
        int orders = int.Parse(Console.ReadLine());
        double priceFinal = 0;
        int booksFinal = 0;
        int packets = 0;
        int books = 0;
        double price = 0;


        for (int i = 0; i < orders; i++)
        {
            packets = int.Parse(Console.ReadLine());
            books = int.Parse(Console.ReadLine());
            price = double.Parse(Console.ReadLine());
            booksFinal = booksFinal + packets * books;
            priceFinal = priceFinal + CheckDiscount(packets) * packets * books*price;
        }

        Console.WriteLine("{0}\n{1:F2}",booksFinal,priceFinal);
    }

    static double CheckDiscount(int packets)
    {
        double discount;
        if (packets < 10)
        {
            return discount = 1;
        }
        else if (packets >= 10 && packets < 20)
        {
            return discount = 0.95;
        }
        else if (packets >= 20 && packets < 30)
        {
            return discount = 0.94;
        }
        else if (packets >= 30 && packets < 40)
        {
            return discount = 0.93;
        }
        else if (packets >= 40 && packets < 50)
        {
            return discount = 0.92;
        }
        else if (packets >= 50 && packets < 60)
        {
            return discount = 0.91;
        }
        else if (packets >= 60 && packets < 70)
        {
            return discount = 0.90;
        }
        else if (packets >= 70 && packets < 80)
        {
            return discount = 0.89;
        }
        else if (packets >= 80 && packets < 90)
        {
            return discount = 0.88;
        }
        else if (packets >= 90 && packets < 100)
        {
            return discount = 0.87;
        }
        else if (packets >= 100 && packets < 110)
        {
            return discount = 0.86;
        }
        else
        {
            return discount = 0.85;
        }
    }
}
