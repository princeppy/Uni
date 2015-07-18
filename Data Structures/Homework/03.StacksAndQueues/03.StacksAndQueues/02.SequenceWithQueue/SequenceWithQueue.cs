using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SequenceWithQueue
{
    class SequenceWithQueue
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            Queue<int> queue =new Queue<int>();
            
            queue.Enqueue(start);

            var list = new List<int>();

            for (int i = 0; i < 50; i++)
            {
                var currentStart = queue.Dequeue();
                list.Add(currentStart);
                queue.Enqueue(currentStart+1);
                queue.Enqueue(2*currentStart+1);
                queue.Enqueue(currentStart+2);
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
