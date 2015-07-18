using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LongestSubsequence
{
    class LongestSubsequence
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var count = 1;
            var tempCount = 1;
            var mostRepeatedElement = elements[0];
            for (int i = 0; i < elements.Count()-1; i++)
            {

                if (elements[i + 1] == elements[i])
                {
                    tempCount++;
                }
                else
                {
                    tempCount = 1;
                }
                
                if (tempCount > count)
                {
                    count = tempCount;
                    mostRepeatedElement = elements[i];
                }

            }

            Console.WriteLine(new String('X', count).Replace("X", mostRepeatedElement+" "));
        }
    }
}
