﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ExtractBitNumberThree
{
    static void Main()
    {
        Console.WriteLine("Enter a number to check the third bit:");
        int i = int.Parse(Console.ReadLine());
        
        byte b = 3;

        int mask = 1 << b;
        int result = i & mask;
        Console.WriteLine("number {0} in decimal is = {1} in binary",i, Convert.ToString(i, 2).PadLeft(32, '0'));

        if (result == 0)
        {
            Console.WriteLine("Bit number {0} is 0\n", b);
        }
        else
        {
            Console.WriteLine("Bit number {0} is 1\n", b);
        }

        Main();
    }
}
