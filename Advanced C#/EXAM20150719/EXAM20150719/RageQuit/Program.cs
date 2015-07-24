using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            Regex regex = new Regex("([^0-9]+)([0-9]+)");

            var arr = regex.Matches(line);

            var uniqueSymbols = new HashSet<string>();
            var sb = new StringBuilder();

            foreach (Match match in arr)
            {
                //Console.WriteLine(match.Groups[1]);

                var group = match.Groups[1].ToString();

              
                var repeat = int.Parse(match.Groups[2].ToString());

                for (int i = 0; i < repeat; i++)
                {
                    sb.Append(group.ToUpper());
                }

                if (repeat != 0)
                {
                    for (int i = 0; i < group.Length; i++)
                    {
                        //Console.WriteLine(group[i]);
                        uniqueSymbols.Add(group[i].ToString().ToUpper());
                    }
                }

                //Console.WriteLine(match);  
                
            }
            Console.WriteLine("Unique symbols used: {0}",uniqueSymbols.Count);
            Console.WriteLine(sb);

            //Console.WriteLine(string.Join(",", uniqueSymbols));

        }
    }
}
