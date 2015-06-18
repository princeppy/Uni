using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                Console.WriteLine(CalculateSquareRoot(number));

            }
            catch (ArgumentNullException ane)
            {

                Console.WriteLine("The number cannot be null" + ane.StackTrace);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("The number must be a positive integer" + ae.StackTrace);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("The number must be an integer"+ fe.StackTrace);
            }

            finally
            {
                Console.WriteLine("Good bye");
            }
        }

        public static double CalculateSquareRoot(int number)
        {
            return Math.Sqrt(number);
        }
    }
}
