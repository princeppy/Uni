using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Tables
{
    static void Main()
    {
        long n1 = long.Parse(Console.ReadLine());
        long n2 = long.Parse(Console.ReadLine());
        long n3 = long.Parse(Console.ReadLine());
        long n4 = long.Parse(Console.ReadLine());

        long tops = long.Parse(Console.ReadLine());
        long neededTables = long.Parse(Console.ReadLine());


        long legs = 1 * n1 + 2 * n2 + 3 * n3 + 4 * n4;

        long fourLegsNum = legs / 4;



        long tablesToBeMade = Math.Min(fourLegsNum, tops);

        long tableDiff = tablesToBeMade - neededTables;



        if (tableDiff > 0)
        {
            long topsLeft = tableDiff;
            long legsLeft = legs - neededTables * 4;
            Console.WriteLine("more: {0}", tableDiff);
            Console.WriteLine("tops left: {0}, legs left: {1}", topsLeft, legsLeft);

        }
        else if (tableDiff < 0)
        {
            long topsNeeded = -tableDiff;
            long legsNeeded = 0;
            if (neededTables * 4 - legs >= 0)
            {
                legsNeeded = (neededTables * 4 - legs);
            }
            else if (neededTables * 4 - legs < 0)
            {
                legsNeeded = 0;
            }
            else
            {
                legsNeeded = 0;
            }

            Console.WriteLine("less: {0}", tableDiff);
            Console.WriteLine("tops needed: {0}, legs needed: {1}", topsNeeded, legsNeeded);



        }
        else
        {
            Console.WriteLine("Just enough tables made: {0}", neededTables);
        }


    }
}
