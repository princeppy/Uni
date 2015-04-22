using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FiveSpecialLetters
{
    static void Main()
    {
        int min = int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());

        int counter = 0;

        List<string> list = new List<string>() { "a", "b", "c", "d", "e" };
        List<string> myList = Combos(list);
        for (int i = 0; i < myList.Count; i++)
        {
            int countA = -1;
            int countB = -1;
            int countC = -1;
            int countD = -1;
            int countE = -1;
            int result = 0;
            int multi = 0;
            for (int j = 0; j < 5; j++)
            {

                switch (myList[i][j])
                {
                    case 'a': countA++; if (countA == 0)
                        {
                            multi++;
                            result = result + 5*multi;
                        } break;
                    case 'b': countB++;
                        if (countB == 0)
                        {
                            multi++;
                            result = result - 12*multi;
                        } break;
                    case 'c': countC++;
                        if (countC == 0)
                        {
                            multi++;
                            result = result + 47*multi;
                        } break;
                    case 'd': countD++;
                        if (countD == 0)
                        {
                            multi++;
                            result = result + 7*multi;
                        } break;
                    case 'e': countE++;
                        if (countE == 0)
                        {
                            multi++;
                            result = result - 32*multi;
                        } break;
                    default:
                        break;
                }
            }
            if (result<=max &&result>=min)
            {
                Console.Write(myList[i] + " ");
                counter++;
            }
        }
        if (counter==0)
        {
            Console.Write("No");  
        }
        Console.WriteLine();
    }


    static List<string> Combos(List<string> list)
    {
        List<string> myList = new List<string>();
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < list.Count; j++)
            {
                for (int k = 0; k < list.Count; k++)
                {
                    for (int m = 0; m < list.Count; m++)
                    {
                        for (int l = 0; l < list.Count; l++)
                        {
                            myList.Add(list[i] + list[j] + list[k] + list[m] + list[l]);
                        }
                    }
                }
            }
        }
        return myList;
    }
}

