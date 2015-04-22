using System;

class Dumbbell
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i <= (n - 2) / 2; i++)
        {
            Console.WriteLine(new string('.', n / 2 - i) + new string('|', n / 2 + i) + new string('.', n / 2 + 2) + new string('|', n / 2 + i) + new string('.', n / 2 - i));
        }

        //Print middle line
        Console.WriteLine("&" + new string('|', n * 2 + n / 2 - 2) + "&");

        for (int i = (n - 2) / 2; i >= 0; i--)
        {
            Console.WriteLine(new string('.', n / 2 - i) + new string('|', n / 2 + i) + new string('.', n / 2 + 2) + new string('|', n / 2 + i) + new string('.', n / 2 - i));
        }
    }
}

