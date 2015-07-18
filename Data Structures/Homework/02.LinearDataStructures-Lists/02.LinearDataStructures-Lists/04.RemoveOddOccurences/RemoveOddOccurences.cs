using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _04.RemoveOddOccurences
{
    class RemoveOddOccurences
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var sortedElements = elements.OrderBy(x => x).ToList();


            var count = 1;
            var tempCount = 1;
            var repeatingArr = new List<int>();

            for (int i = 0; i < sortedElements.Count() - 1; i++)
            {
                bool equals = false;
                if (String.Equals(sortedElements[i + 1], sortedElements[i]))
                {
                    tempCount++;
                    equals = true;
                }
                else
                {
                    if (count % 2 != 0)
                    {
                        elements = RemoveFromList(elements, sortedElements[i]);
                    }

                    tempCount = 1;
                    count = 1;
                }
                if (i == sortedElements.Count - 2)
                {
                    if (!equals)
                    {
                        var elementToRemove = sortedElements[sortedElements.Count - 1];
                        elements.Remove(elementToRemove);
                    }
                    if (tempCount % 2 != 0)
                    {
                        elements = RemoveFromList(elements, sortedElements[i]);
                    }
                    continue;
                }

                if (tempCount >= count)
                {
                    count = tempCount;
                }
            }

            Console.WriteLine(String.Join(", ", elements));
        }


        public static List<string> RemoveFromList(List<string> list, string elementToRemove)
        {
            list.RemoveAll(x => x==elementToRemove);
            return list;
        }
    }
}
