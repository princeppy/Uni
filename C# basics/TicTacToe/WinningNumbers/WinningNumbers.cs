using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class WinningNumbers
{
    static void Main()
    {
        string str = Console.ReadLine();
        int letSum = 0;
        str = str.ToLower();

        for (int i = 0; i < str.Length; i++)
        {
            letSum = letSum + ((int)str[i] - 96);
        }
        //Console.WriteLine(letSum);

        string str1 = "";
        string str2 = "";
        int counter = 0;

        for (int i = 0; i <= 999; i++)
        {
            int product1 = 1;
            if (i < 100)
            {
                str1 = i.ToString().PadLeft(3, '0');
            }
            else
            {
                str1 = i.ToString();
            }

            for (int m = 0; m < 3; m++)
            {
                product1 = product1 * int.Parse(str1[m].ToString());
            }
            if (product1 == letSum)
            {
                for (int j = 0; j <= 999; j++)
                {
                    int product2 = 1;
                    if (j < 100)
                    {
                        str2 = j.ToString().PadLeft(3, '0');
                    }
                    else
                    {
                        str2 = j.ToString();
                    }

                    for (int k = 0; k < 3; k++)
                    {
                        product2 = product2 * int.Parse(str2[k].ToString());
                    }
                    if (product1 == product2)
                    {
                        counter++;
                        Console.WriteLine(str1 + "-" + str2);
                    }
                }
            }
        }
        if (counter == 0)
        {
            Console.WriteLine("No");
        }
    }
}
