using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ProgrammerDNA
{
    static int index = 0;
    static void Main()
    {
        List<char> alphabet = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };

        int n = int.Parse(Console.ReadLine());
        string startChar = Console.ReadLine();

        //int index = 0;

        char[,] array = new char[n, 7];

        for (int i = 0; i < alphabet.Count; i++)
        {
            if (startChar == alphabet[i].ToString())
            {
                index = i;
                break;
            }
        }

        List<StringBuilder> listLetters = new List<StringBuilder>();

        int count = 0;

        int times = 0;

        while (count<n)
        {
            times = 3;
            for (int i = 1; i < 7; i = i + 2)
            {
                string str = new string('.', times);
                if (count < n)
                {
                    Console.Write(str);
                    Test(index, alphabet, i);
                    Console.Write(str+"\n");
                    times--;
                    count++;
                }
            }
            for (int i = 7; i >= 1; i = i - 2)
            {
                string str = new string('.', times);
                if (count < n)
                {
                    Console.Write(str);
                    Test(index, alphabet, i);
                    Console.Write(str+'\n');
                    count++;
                    times++;
                }
            }
        }
    }
    static void Test(int ind, List<char> letters, int n)
    {
        StringBuilder str = new StringBuilder();
        int counter = 0;
        while (counter < n)
        {
            str.Append(letters[ind]);
            ind++;
            if (ind > letters.Count - 1)
            {
                ind = 0;
            }
            counter++;
        }
        index = ind;
        Console.Write(str);
    }
}

