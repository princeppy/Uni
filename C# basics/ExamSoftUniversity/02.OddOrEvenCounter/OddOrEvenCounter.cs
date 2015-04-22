using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class OddOrEvenCounter
{
    static void Main()
    {
        int sets = int.Parse(Console.ReadLine());
        int numbers = int.Parse(Console.ReadLine());
        string str = Console.ReadLine();
        int counterOdd = 0;
        int counterEven = 0;
        int tempOdd = 0;
        int tempEven = 0;
        string nameOdd = "";
        string nameEven = "";
        int counterEqual = 0;

        List<string> name = new List<string>() { "First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh", "Eighth", "Ninth", "Tenth" };

        for (int i = 0; i < sets; i++)
        {
            tempEven = 0;
            tempOdd = 0;
            for (int j = 0; j < numbers; j++)
            {

                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    tempEven++;
                    if (tempEven > counterEven)
                    {
                        counterEven = tempEven;
                        nameEven = name[i];
                    }
                }
                else
                {
                    tempOdd++;
                    if (tempOdd > counterOdd)
                    {
                        counterOdd = tempOdd;
                        nameOdd = name[i];
                    }
                }
            }
        }
        if (counterEven==0 || counterOdd ==0)
        {
            Console.WriteLine("No");
        }
        else if (str == "odd")
        {
            Console.WriteLine("{0} set has the most odd numbers: {1}", nameOdd, counterOdd);
        }
        else if (str == "even")
        {
            Console.WriteLine("{0} set has the most even numbers: {1}", nameEven, counterEven);
        }


        //Console.WriteLine(counterEven);
        //Console.WriteLine(counterOdd);
        //Console.WriteLine(nameEven);
        //Console.WriteLine(nameOdd);
    }
}
