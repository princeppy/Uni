using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StudentCables
{
    static void Main()
    {
        int numberCables = int.Parse(Console.ReadLine());
        List<string> listAll = new List<string>();

        for (int i = 0; i < 2 * numberCables; i++)
        {
            listAll.Add(Console.ReadLine());
        }

        List<int> cableLength = new List<int>();
        for (int i = 0; i < 2 * numberCables; i = i + 2)
        {
            cableLength.Add(int.Parse(listAll[i]));
            listAll[i] = "clear";

        }

        for (int i = 0; i < 2 * numberCables; i++)
        {
            listAll.Remove("clear");
        }

        int length = 0;
        int multiplier = 0;

        for (int i = 0; i < numberCables; i++)
        {
            if (listAll[i] == "meters")
            {
                multiplier = 100;
            }
            else
            {
                multiplier = 1;
            }

            if ((cableLength[i] < 20 && listAll[i] == "centimeters"))
            {
                cableLength[i] = 3;
            }

            length = length + cableLength[i] * multiplier-3;
        }

        length = length + 3;

        int oneCable = 504;

        int finalCables = length / oneCable;

        int reminder = length - finalCables * oneCable;


        Console.WriteLine(finalCables);
        Console.WriteLine(reminder);
    }
}

