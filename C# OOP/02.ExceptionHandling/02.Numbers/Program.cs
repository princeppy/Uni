using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {

                if (!ReadNumber(1, 100))
                {
                    i--;
                }
            }
        }

        public static bool ReadNumber(int start, int end)
        {
            try
            {
                int num = int.Parse(Console.ReadLine());
                if (num < start || num > end)
                {
                    throw new ArgumentOutOfRangeException();
                    
                }
                return true;
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine("The number should be in the interval [{0}, {1}]",
                        start.ToString(), end.ToString());
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine("The number must be a positive integer", ae.StackTrace);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("The number must be a positive integer", fe.StackTrace);
            }
            return false;

        }
    }
}
