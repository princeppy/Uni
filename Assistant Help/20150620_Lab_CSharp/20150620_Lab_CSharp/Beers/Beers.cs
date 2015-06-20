using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers
{
    class Beers
    {
        static void Main(string[] args)
        {
            int stacks = 0;
            int beers = 0;
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] arr = line.Split(' ');

                if (arr[1].ToLower() == "stacks")
                {
                    stacks += int.Parse(arr[0]);
                }
                else
                {
                    beers += int.Parse(arr[0]);
                }


                line = Console.ReadLine();
            }

            if (beers >= 20)
            {
                int stacksToAdd = beers / 20;
                int beersLeft = beers % 20;
                stacks += stacksToAdd;
                beers = beersLeft;
            }
            Console.WriteLine("{0} stacks + {1} beers",stacks,beers);
            
        }
    }
}
