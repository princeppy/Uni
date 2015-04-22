using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class HalfByteSapper
{
    static void Main()
    {
        List<uint> list = new List<uint>();
        for (int i = 0; i < 4; i++)
        {
            list.Add(uint.Parse(Console.ReadLine()));
        }
        List<int> numbers = new List<int>();
        List<int> positions = new List<int>();
        List<int> temp = new List<int>();

        string str = "";
        while ((str = Console.ReadLine()) != "End")
        {

            foreach (var item in str.Split(' '))
            {
                temp.Add(int.Parse(item.ToString()));
            }
        }

        for (int i = 1; i <= temp.Count; i++)
        {
            if (i % 2 != 0)
            {
                numbers.Add(temp[i - 1]);
            }
            else
            {
                positions.Add(temp[i - 1]);
            }
        }



        uint[,] matrix = new uint[4, 8];

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                matrix[i, j] = (list[i] & ((uint)15 << (j * 4))) >> (j * 4);
                //Console.Write("{0} ",Convert.ToString(matrix[i,j],2).PadLeft(4,'0'));
            }
            //Console.WriteLine();
        }
        uint temp1 = 0;
        for (int i = 0; i < numbers.Count - 1; i=i+2)
        {
            temp1 = matrix[numbers[i], positions[i]];
            matrix[numbers[i], positions[i]] = matrix[numbers[i + 1], positions[i + 1]];
            matrix[numbers[i + 1], positions[i + 1]] = temp1;
            temp1 = 0;

        }
        //Console.WriteLine();
        for (int i = 0; i<4; i++)
        {
            string str1 = "";
            for (int j = 7; j >=0; j--)
            {
                str1 = str1 + Convert.ToString(matrix[i, j],2).PadLeft(4,'0');
                //Console.Write("{0} ", Convert.ToString(matrix[i, j], 2).PadLeft(4, '0'));
                

            }
            //Console.WriteLine(str1);
            Console.WriteLine(Convert.ToInt64((str1),2));
            //Console.WriteLine();
        }
    }
}
