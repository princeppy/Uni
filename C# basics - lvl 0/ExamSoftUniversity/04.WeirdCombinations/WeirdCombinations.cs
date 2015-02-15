using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class WeirdCombinations
{
    static void Main()
    {
        string str = Console.ReadLine();
        List<string> list = new List<string>();
        int index = int.Parse(Console.ReadLine());

        for (int i1 = 0; i1 < str.Length; i1++)
        {
            for (int i2 = 0; i2 < str.Length; i2++)
            {
                for (int i3 = 0; i3 < str.Length; i3++)
                {
                    for (int i4 = 0; i4 < str.Length; i4++)
                    {
                        for (int i5 = 0; i5 < str.Length; i5++)
                        {
                            list.Add(str[i1].ToString() + str[i2].ToString() + str[i3].ToString() + str[i4].ToString() + str[i5].ToString());
                        }
                    }
                }
            }
        }
        if (list.Count==0 || index>=list.Count)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine(list[index]);
        }
        
    }
}
