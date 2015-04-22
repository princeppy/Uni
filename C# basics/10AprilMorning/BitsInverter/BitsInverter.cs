using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitsInverter
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        StringBuilder str = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            int p = int.Parse(Console.ReadLine());
            string str1 = Convert.ToString(p, 2).PadLeft(8, '0');
            str.Append(str1);
            
        }
       

        //Console.WriteLine(str);
        

        for (int i = 0; i < str.Length; i = i + step)
        {
            
            if (str[i] == '0')
            {
                str[i] = '1';
            }
            else
            {
                str[i] = '0';
            }
        }

        for (int i = 8; i < str.Length; i = i + 9)
        {
            str.Insert(i, '.');
        }

        //Console.WriteLine(str);
        foreach (var item in str.ToString().Split('.'))
        {
            int p = Convert.ToInt32(item, 2);
            Console.WriteLine(p);
            //Console.WriteLine(item);
        } 

    }
}

