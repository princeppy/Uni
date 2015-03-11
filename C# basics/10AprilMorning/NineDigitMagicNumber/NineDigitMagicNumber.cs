using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class NineDigitMagicNumber
{
    static void Main()
    {
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        List<int> list = new List<int>();
        //StringBuilder str = new StringBuilder("111111111");
        List<string> listStr = new List<string>();
        int counter = 0;



        for (int num = 111; num <= 777-2*diff; num++)
        {
            
            bool valid = true;
            //string str = j.ToString();
            //list.Add(j);

            int num1 = num + diff;
            int num2 = num1 + diff;

            string all = num.ToString() + num1.ToString() + num2.ToString();


            for (int i = 0; i < 9; i++)
            {
                if (all[i] < '1' || all[i] > '7')
                {
                    valid = false;
                    break;
                }

            }

            if (CalculateSum(num) + CalculateSum(num1) + CalculateSum(num2) == sum && valid == true)
            {
                counter++;
                Console.WriteLine("{0}{1}{2}", num, num1, num2);
            }
        }
        if (counter==0)
        {
            Console.WriteLine("No");
        }
    }

    static int CalculateSum(int n)
    {
        int result = 0;
        string str1 = n.ToString();
        for (int m = 0; m < 3; m++)
        {
            result = result + int.Parse(str1[m].ToString());
        }
        return result;
    }
}


