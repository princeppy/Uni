using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MagicStrings
{
    static void Main()
    {
        List<char> listChar = new List<char>() { 'k', 'n', 'p', 's' };
        int diff = int.Parse(Console.ReadLine());
        List<string> list = Combos(listChar);
        int counter = 0;

        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < list.Count; j++)
            {
                int res1 = CalcWeight(list[i]);
                int res2 = CalcWeight(list[j]);
                
                if (Math.Abs(res1 - res2) == diff)
                {
                    counter++;
                    Console.WriteLine(list[i] + list[j]);
                }
            }
        }
        if (counter==0)
        {
            Console.WriteLine("No");
        }
    }

    static List<string> Combos(List<char> list)
    {
        List<string> list1 = new List<string>();
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < list.Count; j++)
            {
                for (int k = 0; k < list.Count; k++)
                {
                    for (int m = 0; m < list.Count; m++)
                    {
                        list1.Add(list[i].ToString() + list[j].ToString() + list[k].ToString() + list[m].ToString());
                    }
                }
            }
        }
        return list1;
    }

    static int CalcWeight(string str)
    {
        int res = 0;
        for (int i = 0; i < str.Length; i++)
        {
            switch (str[i])
            {
                case 'k': res = res + 1; break;
                case 'n': res = res + 4; break;
                case 'p': res = res + 5; break;
                case 's': res = res + 3; break;
                default:
                    break;
            }
        }
        return res;
    }
}
