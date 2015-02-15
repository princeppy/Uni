using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OddEven
{
    static void Main()
    {
        string str = Console.ReadLine();
        List<decimal> listOdd = new List<decimal>();
        List<decimal> listEven = new List<decimal>();
        int counter = 1;
        if (str == "")
        {
            // Known issue: split on empty string returns 1 token ""
            listOdd = new List<decimal>(0);
        }
        else
        {
            foreach (var item in str.Split(' '))
            {

                if (counter % 2 != 0)
                {
                    listOdd.Add(decimal.Parse(item));
                }
                else
                {
                    listEven.Add(decimal.Parse(item));
                }
                counter++;
            }
        }
        

        if (listOdd.Count == 0)
        {
            Console.Write("OddSum={0}, ", "No");
            Console.Write("OddMin={0}, ", "No");
            Console.Write("OddMax={0}, ", "No");
        }
        else
        {
            Console.Write("OddSum={0:G29}, ", listOdd.Sum());
            Console.Write("OddMin={0:G29}, ", listOdd.Min());
            Console.Write("OddMax={0:G29}, ", listOdd.Max());
        }

        if (listEven.Count == 0)
        {
            Console.Write("EvenSum={0}, ", "No");
            Console.Write("EvenMin={0}, ", "No");
            Console.Write("EvenMax={0}\n", "No");
        }
        else
        {
            Console.Write("EvenSum={0:G29}, ", listEven.Sum());
            Console.Write("EvenMin={0:G29}, ", listEven.Min());
            Console.Write("EvenMax={0:G29}\n", listEven.Max());
        }
        



    }
}

