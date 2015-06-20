using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteParty
{
    class ByteParty
    {
        static void Main(string[] args)
        {
            List<int> listNumbers = new List<int>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                listNumbers.Add(int.Parse(Console.ReadLine()));
            }
            string line = Console.ReadLine();
            while (line!="party over")
            {
                string[] arr = line.Split(' ');

                int command = int.Parse(arr[0]);
                int postition = int.Parse(arr[1]);

                for (int i = 0; i < listNumbers.Count; i++)
                {
                    switch (command)
                    {
                        case -1:
                            listNumbers[i] ^= (1 << postition);
                            break;
                        case 0:
                            listNumbers[i] &= ~(1 << postition);
                            break;
                        case 1:
                            listNumbers[i] |= 1 << postition;

                            break;

                    }

                    //Console.WriteLine(Convert.ToString(listNumbers[i],2));
                }
                line = Console.ReadLine();
            }
            foreach (var number in listNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
