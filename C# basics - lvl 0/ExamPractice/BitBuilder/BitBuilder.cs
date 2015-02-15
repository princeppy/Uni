using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitBuilder
{
    static void Main()
    {
        long number = int.Parse(Console.ReadLine());
        string str = Console.ReadLine();
        if (str == "quit")
        {
            Console.WriteLine(number);
        }
        else
        {
            int bitPosition = int.Parse(str);

            string command = Console.ReadLine();
            bool check = true;

            while (check == true)
            {
                if (command == "flip")
                {
                    number = number ^ (long)(1 << bitPosition);
                }

                else if (command == "insert")
                {
                    long power = 0;
                    long tempNumber = (((number >> bitPosition) << 1) | 1) << bitPosition;

                    for (int i = 0; i < bitPosition; i++)
                    {
                        power = power + (long)Math.Pow(2, i);
                    }
                    long tempNumber2 = number & power;
                    number = tempNumber | tempNumber2;
                }

                else if (command == "remove")
                {
                    long power = 0;
                    long tempNumber = (number >> (bitPosition + 1)) << (bitPosition);

                    for (int i = 0; i < bitPosition; i++)
                    {
                        power = power + (long)Math.Pow(2, i);
                    }
                    long tempNumber2 = number & power;
                    number = tempNumber | tempNumber2;
                }

                check = int.TryParse(Console.ReadLine(), out bitPosition);
                if (check == true)
                {
                    command = Console.ReadLine();
                }
            }
            Console.WriteLine(number);
        }
    }
}
