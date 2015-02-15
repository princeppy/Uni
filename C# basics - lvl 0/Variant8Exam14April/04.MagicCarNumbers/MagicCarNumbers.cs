using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitFlipper
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        StringBuilder str = new StringBuilder("0000000000000000000000000000000000000000000000000000000000000000");

        int position = 64;

        while (n >= 1)
        {
            if (n % 2 == 1)
            {
                str[position - 1] = '1';
            }
            else
            {
                str[position - 1] = '0';
            }
            n /= 2;
            position--;
        }
        //Console.WriteLine(str);

        List<int> list = new List<int>();
        int counterOnes = 0;
        int counterZeros = 0;

        for (int i = 0; i < 64; i++)
        {
            if (str[i] == '0')
            {
                counterZeros++;
                counterOnes = 0;
            }

            else
            {
                counterOnes++;
                counterZeros = 0;
            }

            if (counterOnes == 3)
            {
                str[i - 2] = '0';
                str[i - 1] = '0';
                str[i] = '0';
                counterOnes = 0;
            }
            else if (counterZeros == 3)
            {
                str[i - 2] = '1';
                str[i - 1] = '1';
                str[i] = '1';
                counterZeros = 0;
            }

        }

        //Console.Write(str);
        ulong result = 0;
        int power = 0;

        for (int i = str.Length - 1; i >= 0; i--)
        {
            if (str[i] == '1')
            {
                result = result + (ulong)Math.Pow(2, power);
            }
            power++;
        }

        Console.WriteLine(result);
    }
}
