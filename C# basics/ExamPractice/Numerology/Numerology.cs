using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Numerology
{
    static void Main()
    {
        string[] strSplit = Console.ReadLine().Split(' ');

        string[] date = strSplit[0].Split('.');
        string name = strSplit[1];

        int day = int.Parse(date[0]);
        int month = int.Parse(date[1]);
        int year = int.Parse(date[2]);

        int temp = 0;
        int value = 0;
        long sum = 0;

        for (int i = 0; i < name.Length; i++)
        {
            if (name[i] < 58)
            {
                value = name[i] - 48;
            }

            else if (name[i] < 91 && name[i] > 10)
            {
                value = (name[i] - 64) * 2;
            }

            else if (name[i] > 96)
            {
                value = name[i] - 96;
            }
            temp = temp + value;
            value = 0;
        }

        long number = day*month*year;

        if (month % 2 != 0)
        {
            number = number * number;
        }
        sum = temp + number;

        while (sum > 13)
        {
            string stringNum = sum.ToString();
            sum = 0;

            for (int i = 0; i < stringNum.Length; i++)
            {
                sum = sum + int.Parse(stringNum[i].ToString());
            }
        }
        Console.WriteLine(sum);
    }
}
