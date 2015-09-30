using System;

namespace LiveDemos
{
    class KingOfThieves
    {
        // King of thieves
        // Link: https://judge.softuni.bg/Contests/Practice/Index/81#2
        private static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char symbol = char.Parse(Console.ReadLine());

            int dashesCount = size / 2;
            int symbolCount = 1;

            for (int i = 0; i < size; i++)
            {
                string dashes = new string('-', dashesCount);
                string symbols = new string(symbol, symbolCount);
                Console.WriteLine("{0}{1}{0}", dashes, symbols);

                if (i < size / 2)
                {
                    dashesCount--;
                    symbolCount += 2;
                }
                else
                {
                    dashesCount++;
                    symbolCount -= 2;
                }
            }
        }
    }
}
