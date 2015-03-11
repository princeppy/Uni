using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class HalfSum
{
    static void Main(string[] args)
    {
        List<int> numbersLeft = new List<int>();
        List<int> numbersRight = new List<int>();

        int lengthList = int.Parse(Console.ReadLine())*2;

        for (int i = 0; i < lengthList/2; i++)
        {
            numbersLeft.Add(int.Parse(Console.ReadLine()));
        }

        for (int j = 0; j < lengthList/2; j++)
        {
            numbersRight.Add(int.Parse(Console.ReadLine()));
        }

        int diff = Math.Abs(numbersLeft.Sum() - numbersRight.Sum());

        if (diff==0)
        {
            Console.WriteLine("Yes, sum={0}",numbersLeft.Sum());   
        }
        else
        {
            Console.WriteLine("No, diff={0}",diff);
        }
    }
}

