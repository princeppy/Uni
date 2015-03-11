using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitRoller
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        int fixedBit = int.Parse(Console.ReadLine());
        int steps = int.Parse(Console.ReadLine());

        if (steps==0||n==524287||n==uint.MinValue)
        {
            //int p = Convert.ToInt32("1111111111111111111", 2);
            //Console.WriteLine(p);
            Console.WriteLine(n);
        }
        else
        {
            string str = Convert.ToString(n, 2).PadLeft(19, '0'); ;
            StringBuilder binaryStart = new StringBuilder();
            binaryStart.Append(str);
            //Console.WriteLine(binaryStart);

            char fixPosition;
            if (binaryStart[binaryStart.Length - 1 - fixedBit] == '0')
            {
                fixPosition = '0';
            }
            else
            {
                fixPosition = '1';
            }

            binaryStart.Remove(binaryStart.Length - 1 - fixedBit, 1);
            //Console.WriteLine(binaryStart);

            uint temp = Convert.ToUInt32(binaryStart.ToString(), 2);
            uint num1 = 0;
            uint num2 = 0;
            uint num = 0;
            for (int i = 0; i < steps; i++)
            {
                if (steps!=0)
                {
                    num1 = (temp >> 1);
                    num2 = ((temp << 32 - 1) >> 14);
                    temp = num1 | num2;
                }
                


            }
            num = temp;


            string final = Convert.ToString(num, 2);

            //Console.WriteLine(temp);
            //Console.WriteLine(binaryStart);

            StringBuilder finalStr = new StringBuilder();

            finalStr.Append(final);
            if (fixedBit == 17)
            {
                finalStr.Insert(finalStr.Length - fixedBit + 1, fixPosition);
            }
            else if (fixedBit == 0)
            {
                finalStr.Insert(finalStr.Length, fixPosition);
            }
            else
            {
                finalStr.Insert(finalStr.Length - fixedBit, fixPosition);
            }



            //Console.WriteLine(Convert.ToString((temp >> steps), 2).PadLeft(18, '0'));

            //Console.WriteLine(Convert.ToString(((temp << 32 - steps) >> 14), 2));

            //Console.WriteLine(Convert.ToString(((temp >> steps) | ((temp << 32 - steps) >> 14)), 2));

            //Console.WriteLine();
            //Console.WriteLine(str);
            //Console.WriteLine(finalStr);

            Console.WriteLine(Convert.ToInt32(finalStr.ToString(), 2));


            //uint final = (temp >> steps) | (temp << 14);

            //Console.WriteLine(Convert.ToString(final,2).PadLeft(18,'0'));
        }

        
    }
}

