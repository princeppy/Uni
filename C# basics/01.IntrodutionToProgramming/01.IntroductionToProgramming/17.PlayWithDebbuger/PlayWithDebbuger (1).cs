using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PlayWithDebbuger
{
    static void Main(string[] args)
    {
        int startNumber = 1;
        int lengthOfSequnce = 1000;
        for (int i = startNumber; i < lengthOfSequnce + startNumber; i++)       //Loops from startNumber to the desired length of the sequence
        {
            Console.WriteLine(i);                                               //Breakpoint
        }
    }
}

